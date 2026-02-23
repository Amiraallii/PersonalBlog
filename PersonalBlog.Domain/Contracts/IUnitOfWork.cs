namespace Personal.Domain.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
