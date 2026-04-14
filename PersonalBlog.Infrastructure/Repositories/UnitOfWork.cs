using Personal.Domain.Contracts;
using Personal.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace Personal.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IPersonalInformationRepository PersonalInformationRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IProjectRepository projectRepository,
            IPersonalInformationRepository personalInformationRepository
            )
        {
            _context = context;
            UserRepository = userRepository;
            PostRepository = postRepository;
            ProjectRepository = projectRepository;
            PersonalInformationRepository = personalInformationRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
