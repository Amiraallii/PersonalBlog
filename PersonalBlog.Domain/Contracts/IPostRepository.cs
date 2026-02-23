using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IPostRepository
    {
        Task AddPost(Post post, CancellationToken ct);
    }
}
