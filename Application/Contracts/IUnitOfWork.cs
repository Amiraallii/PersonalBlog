namespace Personal.Application.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
