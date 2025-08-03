using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IPostRepository
    {
        Task AddPost(Posts post, CancellationToken ct);
    }
}
