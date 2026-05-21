using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Domain.Contracts
{
    public interface ICommentRepository
    {
        Task AddComment(Comment model, CancellationToken ct);
        Task UpdateComment(Comment model, CancellationToken ct);
        IQueryable<Comment> GetAllComments();
        Task<Comment> GetCommentById(Guid id, CancellationToken ct);
        Task<int> DeleteComment(Guid id, CancellationToken ct);
        Task<int> DeleteReplies(Guid parentId, CancellationToken ct);
        IQueryable<Comment> GetReplies(Guid parentId);
        Task<Comment?> GetCommentByIdForUpdate(Guid id, CancellationToken ct);
    }
}
