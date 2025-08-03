using Personal.Application.Features.Authentication.Commands.Login;
using Personal.Application.IServices;
using Personal.Domain.Contracts;
using Personal.Infrastructure.Repositories;
using Personal.Infrastructure.Services;

namespace Personal.WebApi.Configurations
{
    public static class ServicesConfiguration
    {
        

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IUserRepository, UserRepository>();



            services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly));


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:1669")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
