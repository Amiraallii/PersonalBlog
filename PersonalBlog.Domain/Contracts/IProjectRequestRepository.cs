using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Domain.Contracts
{
    public interface IProjectRequestRepository
    {
        Task AddProjectRequestAsync(ProjectRequest projectRequest, CancellationToken ct);

    }
}
