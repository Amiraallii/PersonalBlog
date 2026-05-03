using PersonalBlog.Application.Features.Authentication.Commands.Login;
using PersonalBlog.Application.IServices;
using Personal.Domain.Contracts;
using PersonalBlog.Infrastructure.Repositories;
using PersonalBlog.Domain.Contracts;
using PersonalBlog.Infrastructure.Shared.Authentication.JWT;
using PersonalBlog.Infrastructure.Shared.FileServices;

namespace PersonalBlog.WebApi.Configurations
{
    public static class ServicesConfiguration
    {


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            services.AddScoped<IFileCompressorService, FileCompressorService>();
            services.AddScoped<ICommentRepository, CommentRepository>();



            services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly));


            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                        builder =>
                        {
                            builder.WithOrigins("http://amirali.me", "http://www.amirali.me")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        });
            });

            return services;
        }
    }
}
