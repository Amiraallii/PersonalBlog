using Personal.Application.Contracts;
using Personal.Infrastructure.Repositories;
using Personal.Infrastructure.Services;

namespace Personal.WebApi.Configurations
{
    public static class ServicesConfiguration
    {
        

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            #region ' Services '

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            #endregion ' Services '

            #region ' Repositories '

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion ' Repositories '

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
