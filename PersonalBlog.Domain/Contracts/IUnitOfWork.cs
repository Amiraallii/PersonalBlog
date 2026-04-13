using PersonalBlog.Domain.Contracts;

namespace Personal.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IPersonalInformationRepository PersonalInformationRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
