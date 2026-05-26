using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    internal class ProjectRequestConfiguration : IEntityTypeConfiguration<ProjectRequest>
    {
        

        public void Configure(EntityTypeBuilder<ProjectRequest> builder)
        {
            builder.ToTable("ProjectRequests", "Project");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Summary)
                .HasMaxLength(1000)
                .IsRequired(true);

            builder.Property(x => x.Title)
                    .HasMaxLength(150)
                    .IsRequired(true);

            builder.Property(x => x.Location)
                    .HasMaxLength(150)
                    .IsRequired(true);

            builder.Property(x => x.PhoneNumber)
                    .HasMaxLength(15)
                    .IsRequired(true);
        }
    }
}
