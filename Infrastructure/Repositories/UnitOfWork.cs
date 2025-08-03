using Personal.Domain.Contracts;
using Personal.Infrastructure.Context;

namespace Personal.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IUserRepository userRepository, IPostRepository postRepository)
        {
            _context = context;

            UserRepository = userRepository;
            PostRepository = postRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
