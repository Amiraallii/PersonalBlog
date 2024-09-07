using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Models;


namespace PersonalBlog.Data.Context
{
    public class PersonalBlogContext: IdentityDbContext
    {
        public PersonalBlogContext(DbContextOptions options) : base(options) { }
       // public PersonalBlogContext() : base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

    }
}
