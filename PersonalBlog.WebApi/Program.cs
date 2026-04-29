using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PersonalBlog.Infrastructure.Context;
using PersonalBlog.WebApi.Configurations;
using PersonalBlog.WebApi.Extensions;
using PersonalBlog.WebApi.Middlewares;
using PersonalBlog.Application.Options;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonalBlogConnection")));

builder.Services.AddApplicationServices();
var settings = new PersonalSettings();
builder.Configuration.GetSection("Settings").Bind(settings);
builder.Services.AddSingleton(settings);
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = settings.Jwt.Issuer,
            ValidAudience = settings.Jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(settings.Jwt.Key!)
            )
        };
    });

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddSingleton<IAmazonS3>(s3 =>
{
    var cfg = new AmazonS3Config
    {
        ServiceURL = settings.S3Storage.ServiceUrl,
        ForcePathStyle = true,
    };
    return new AmazonS3Client(settings.S3Storage.AccessKey, settings.S3Storage.SecretKey, cfg);
});

builder.Host.UseSerilog();

builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowReactApp");

//app.UseCors();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MigrateDatabase();
    app.MapOpenApi();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
