using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Personal.Infrastructure.Context;

namespace Personal.Infrastructure;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ApplicationDbContext;Integrated Security=True;TrustServerCertificate=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
