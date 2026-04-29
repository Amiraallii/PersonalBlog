using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "Account");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
