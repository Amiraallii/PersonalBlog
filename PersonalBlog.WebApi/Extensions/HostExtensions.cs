using Microsoft.EntityFrameworkCore;
using Personal.Infrastructure.Context;

namespace Personal.WebApi.Extensions
{
    public static class HostExtensions 
    {
        public static IHost MigrateDatabase(this IHost host) 
        {
            using (var scope = host.Services.CreateScope()) 
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<ApplicationDbContext>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {

                    var logger = services.GetRequiredService<ILogger<Program>>(); 
                }
            }
            return host;
        }
    }
}