using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Commnets", "Post");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.AuthorId)
                .IsRequired(true);

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
