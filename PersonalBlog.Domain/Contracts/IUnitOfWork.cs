using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IProjectRequestRepository ProjectRequestRepository { get; }
        IPersonalInformationRepository PersonalInformationRepository { get; }
        ICommentRepository CommentRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
