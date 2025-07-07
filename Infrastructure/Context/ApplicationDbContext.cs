using Microsoft.EntityFrameworkCore;
using Personal.Domain.Entity;

namespace Personal.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<PostImage> PostImages => Set<PostImage>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), 
                    Name = "User",
                    CreateDate = DateTime.UtcNow 
                },
                new Role
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), 
                    Name = "Admin",
                    CreateDate = DateTime.UtcNow
                }
            );
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
