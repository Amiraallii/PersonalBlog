using Microsoft.EntityFrameworkCore;
using Personal.Infrastructure.Context;
using PersonalBlog.Domain.Contracts;
using PersonalBlog.Domain.Entity;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class ProjectRepository(ApplicationDbContext _context) : IProjectRepository
    {
        public async Task AddProjectAsync(Project project, CancellationToken ct)
        {
            await _context.AddAsync(project, ct);
        }

        public async Task DeleteProjectAsync(int id, CancellationToken ct)
        {
            var rows = await _context.Projects
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync(ct);
            if (rows == 0)
            {
                throw new KeyNotFoundException();
            }
        }

        public IQueryable<Project> GetAllProject()
        {
            return _context.Projects
                .AsNoTracking();
        }

        public async Task<Project> GetProjectByIdAsync(int id, CancellationToken ct)
        {
            var entity = await _context.Projects.FindAsync([id]);
            if (entity == null)
                return null;

            return entity;
        }

        public async Task<Project> GetProjectByIdNoTrackingAsync(int id, CancellationToken ct)
        {
            var entity = await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return null;

            return entity;
        }

        public async Task UpdateProject(Project project)
        {
            _context.Update(project);
        }
    }
}
