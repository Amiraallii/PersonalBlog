using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal.Domain.Entity;

namespace Personal.Infrastructure.FluentConfig
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.AuthorName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Content)
                .IsRequired();

            builder.Property(c => c.IsApproved)
                .HasDefaultValue(false);
        }
    }
}
