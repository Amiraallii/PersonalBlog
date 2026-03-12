using Personal.Domain.Entity;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Domain.Contracts
{
    public interface IProjectRepository
    {
        Task AddProjectAsync(Project project, CancellationToken ct);
        Task DeleteProjectAsync(int id, CancellationToken ct);
        IQueryable<Project> GetAllProject();
        Task<Project> GetProjectByIdAsync(int id, CancellationToken ct);
        Task<Project> GetProjectByIdNoTrackingAsync(int id, CancellationToken ct);
    }
}
