using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.FluentConfig
{
    public class PostContentBlockConfiguration : IEntityTypeConfiguration<PostContentBlock>
    {
        public void Configure(EntityTypeBuilder<PostContentBlock> builder)
        {
            builder.ToTable("PostContentBlocks", "Post");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x=> x.Order).IsRequired();
            builder.Property(x=> x.ContentType).IsRequired();

        }
    }
}
