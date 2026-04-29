using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Domain.Contracts
{
    public interface ICommentRepository
    {
        Task AddComment(Comment model, CancellationToken ct);
        Task UpdateComment(Comment model, CancellationToken ct);
        IQueryable<Comment> GetAllComments(CancellationToken ct);
        Task<Comment> GetCommentById(Guid id, CancellationToken ct);
        Task<int> DeleteComment(Guid id, CancellationToken ct);
    }
}
