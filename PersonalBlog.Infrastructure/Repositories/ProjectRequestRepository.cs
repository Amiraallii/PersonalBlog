using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;
using PersonalBlog.Infrastructure.Context;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class ProjectRequestRepository(ApplicationDbContext _context) : IProjectRequestRepository
    {
        public async Task AddProjectRequestAsync(ProjectRequest project, CancellationToken ct)
        {
            await _context.AddAsync(project, ct);
        }
    }
}
