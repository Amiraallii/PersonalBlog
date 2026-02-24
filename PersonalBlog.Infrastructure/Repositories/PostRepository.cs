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

        public Task<Post> GetPostById(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task GetPostByIdNoTracking(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
