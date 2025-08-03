using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using Personal.Infrastructure.Context;

namespace Personal.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPost(Posts post, CancellationToken ct)
        {
            await _context.Posts.AddAsync(post, ct);
        }
    }
}
