using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.ToTable("ContactInfos", "Info");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContactWay)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.Property(x => x.ContactWayType)
                .IsRequired(true);

            builder.HasOne(x=> x.PersonalInformation)
                .WithMany(x=> x.ContactInfos)
                .HasForeignKey(x=>x.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
