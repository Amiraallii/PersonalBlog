using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.ToTable("ContactInfo", "Info");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContactWay)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.ContactWayType)
                .IsRequired(true);
        }
    }
}
