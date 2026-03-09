using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x=> x.Summary)
                .HasMaxLength(1000)
                .IsRequired(true);

            builder.Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired(true);

            builder.Property(x => x.Owner)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.Property(x => x.StartDate)
                .IsRequired(true);

            builder.Property(x => x.EndDate)
                .IsRequired(false);
        }
    }
}
