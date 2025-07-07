using Personal.Application.Contracts;
using Personal.Application.IServices;
using Personal.Infrastructure.Repositories;
using Personal.Infrastructure.Services;

namespace Personal.WebApi.Configurations
{
    public static class ServicesConfiguration
    {
        

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Personal.Application.IServices.IAuthService).Assembly));

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
