using Microsoft.EntityFrameworkCore;
using Personal.Domain.Entity;
using BCrypt.Net;
using Personal.Domain.Contracts;

namespace Personal.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<PostContentBlock> PostContentBlocks => Set<PostContentBlock>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminPasswordHash = "$2a$11$4LXh430wl/OwVD2LZ6M81OsxLK1MHjFS1j5kS.SzvQgRzucn3FL7y";

            var adminRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var userRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001"); 
            modelBuilder.Entity<Role>().HasData(
                new 
                {
                    Id = userRoleId,
                    Name = "User",
                    CreateDate = new DateTime(2025, 7, 8, 0, 0, 0, DateTimeKind.Utc)
                },
                new 
                {
                    Id = adminRoleId, 
                    Name = "Admin",
                    CreateDate = new DateTime(2025, 7, 8, 0, 0, 0, DateTimeKind.Utc)
                }
            );
            modelBuilder.Entity<User>().HasData(
                new 
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Email = "amiraliaghaei69@gmail.com",
                    CreateDate = new DateTime(2025, 7, 8, 0, 0, 0, DateTimeKind.Utc),
                    FullName = "Amirali",
                    UserName = "Amirali",
                    PasswordHash = adminPasswordHash,
                    RoleId = adminRoleId

                }
            );
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
