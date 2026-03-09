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

        public async Task DeletePost(Guid id, CancellationToken ct)
        {
            var rows = await _context.Posts
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(ct);

            if (rows == 0)
            {
                throw new KeyNotFoundException();
            }
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _context.Posts
                .AsNoTracking();

        }

        public async Task<Post> GetPostById(Guid id, CancellationToken ct)
        {
            var entity = await _context.Posts
                .Include(x => x.PostContents)
                .FirstOrDefaultAsync(x => x.Id == id, ct);
            if (entity == null)
                throw new KeyNotFoundException();

            return entity;

        }

        public async Task<Post> GetPostByIdNoTracking(Guid id, CancellationToken ct)
        {
            var entity = await _context.Posts
                .Include(x => x.PostContents
                .OrderBy(x => x.Order))
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, ct);
            if (entity == null)
                throw new KeyNotFoundException();

            return entity;
        }


    }
}
