using Microsoft.EntityFrameworkCore;
using Personal.Domain.Entity;
using BCrypt.Net;
using Personal.Domain.Contracts;

namespace Personal.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Roles> Roles => Set<Roles>();
        public DbSet<Posts> Posts => Set<Posts>();
        public DbSet<Comments> Comments => Set<Comments>();
        public DbSet<PostContentBlock> PostContentBlocks => Set<PostContentBlock>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminPasswordHash = "$2a$11$4LXh430wl/OwVD2LZ6M81OsxLK1MHjFS1j5kS.SzvQgRzucn3FL7y";

            var adminRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var userRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001"); modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    Id = userRoleId,
                    Name = "User",
                    CreateDate = new DateTime(2025, 7, 8, 0, 0, 0, DateTimeKind.Utc)
                },
                new Roles
                {
                    Id = adminRoleId, 
                    Name = "Admin",
                    CreateDate = new DateTime(2025, 7, 8, 0, 0, 0, DateTimeKind.Utc)
                }
            );
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Email = "amiraliaghaei69@gmail.com",
                    CreateDate = new DateTime(2025, 7, 8, 0, 0, 0, DateTimeKind.Utc),
                    FullName = "Amirali",
                    UserName = "Amirali",
                    PasswordHash = adminPasswordHash, //
                    RoleId = adminRoleId

                }
            );
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
