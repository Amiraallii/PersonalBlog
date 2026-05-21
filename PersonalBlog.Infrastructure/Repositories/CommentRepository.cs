using Microsoft.EntityFrameworkCore;
using PersonalBlog.Domain.Entity;
using PersonalBlog.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class CommentRepository(ApplicationDbContext _context) : ICommentRepository
    {
        public async Task AddComment(Comment model, CancellationToken ct)
        {
            await _context.Comments
                .AddAsync(model, ct);
        }

        public async Task<int> DeleteComment(Guid id, CancellationToken ct)
        {
            return await _context.Comments
                .Where(x=> x.Id == id)
                .ExecuteDeleteAsync(ct);
        }

        public async Task<int> DeleteReplies(Guid parentId, CancellationToken ct)
        {
            return await _context.Comments
                .Where(x=> x.ParentId == parentId)
                .ExecuteDeleteAsync(ct);
        }

        public IQueryable<Comment> GetAllComments()
        {
            return _context.Comments
                .AsNoTracking();
        }

        public async Task<Comment> GetCommentById(Guid id, CancellationToken ct)
        {
            return await _context.Comments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task<Comment?> GetCommentByIdForUpdate(Guid id, CancellationToken ct)
        {
            return await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public IQueryable<Comment> GetReplies(Guid parentId)
        {
            return _context.Comments
                .AsNoTracking()
                .Where(x=> x.ParentId == parentId);
        }

        public async Task UpdateComment(Comment model, CancellationToken ct)
        {
            _context.Comments
                .Update(model);
        }
    }
}
