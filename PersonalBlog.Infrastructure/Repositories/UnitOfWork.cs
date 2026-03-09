using Personal.Domain.Contracts;
using Personal.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;

namespace Personal.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }
        public IProjectRepository ProjectRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IProjectRepository projectRepository
            )
        {
            _context = context;
            UserRepository = userRepository;
            PostRepository = postRepository;
            ProjectRepository = projectRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
