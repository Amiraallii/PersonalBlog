using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal.Domain.Entity;

namespace Personal.Infrastructure.FluentConfig
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.ToTable("Commnets", "Post");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.AuthorName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Content)
                .IsRequired();

            builder.Property(c => c.IsApproved)
                .HasDefaultValue(false);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
