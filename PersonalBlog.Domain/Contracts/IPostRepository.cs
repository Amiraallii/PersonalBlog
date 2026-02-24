using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IPostRepository
    {
        Task AddPost(Post post, CancellationToken ct);
        IQueryable<Post> GetAllPosts();
        Task<Post> GetPostById(Guid id, CancellationToken ct);
        Task GetPostByIdNoTracking(Guid id, CancellationToken ct);
    }
}
