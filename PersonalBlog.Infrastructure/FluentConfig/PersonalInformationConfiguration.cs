using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class PersonalInformationConfiguration : IEntityTypeConfiguration<PersonalInformation>
    {
        public void Configure(EntityTypeBuilder<PersonalInformation> builder)
        {
            builder.ToTable("PersonalInformations", "Info");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x=> x.LastName)
                .HasMaxLength(150)
                .IsRequired(true);

            builder.Property(x=> x.JobTitle)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.Property(x => x.AboutMe)
                .HasMaxLength(1000)
                .IsRequired(true);

            builder.HasMany(x=> x.ContactInfos)
                .WithOne(x=> x.PersonalInformation)
                .HasForeignKey(x=>x.PersonalInformationId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
