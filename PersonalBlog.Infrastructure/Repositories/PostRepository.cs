using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using Personal.Infrastructure.Context;
using PersonalBlog.Application.Dtos;

namespace Personal.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Post post, CancellationToken ct)
        {
            await _context.Posts.AddAsync(post, ct);
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _context.Posts
                .AsNoTracking()
                .Include(x => x.PostContents);

        }

        public async Task<Post> GetPostById(Guid id, CancellationToken ct)
        {
            var entity = await _context.Posts.FindAsync([id]);
            if (entity == null)
                return null;

            return entity;

        }

        public async Task<Post> GetPostByIdNoTracking(Guid id, CancellationToken ct)
        {
            var entity = await _context.Posts.Include(x=> x.PostContents).AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
            if (entity == null)
                return null;

            return entity;
        }
    }
}
