using Personal.Domain.Contracts;
using PersonalBlog.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IProjectRequestRepository ProjectRequestRepository { get; }
        public IPersonalInformationRepository PersonalInformationRepository { get; }

        public ICommentRepository CommentRepository { get; }

        public UnitOfWork(
            ApplicationDbContext context,
            IUserRepository userRepository,
            IPostRepository postRepository,
            IProjectRepository projectRepository,
            IPersonalInformationRepository personalInformationRepository,
            ICommentRepository commentRepository,
            IProjectRequestRepository projectRequestRepository
            )
        {
            _context = context;
            UserRepository = userRepository;
            PostRepository = postRepository;
            ProjectRepository = projectRepository;
            PersonalInformationRepository = personalInformationRepository;
            CommentRepository = commentRepository;
            ProjectRequestRepository = projectRequestRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
