using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using Personal.Domain.Entity;
using Personal.Infrastructure.Context;

namespace Personal.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddUserAsync(Users user, CancellationToken ct)
        {
            await context.AddAsync(user, ct);
        }

        public async Task<IQueryable<Users>> GetAllUsers(CancellationToken ct)
        {
            return context.Users
                .Include(x=> x.Role)
                .AsNoTracking();
        }

        public async Task<Roles> GetRoleByNameAsync(string roleName, CancellationToken ct)
        {
            return await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, ct);
        }

        public async Task<Users> GetUserByEmailAsync(string email, CancellationToken ct)
        {
            return await context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.Email == email, ct);
        }

        public async Task<Users> GetUserByUserNameAsync(string userName, CancellationToken ct)
        {
            return await context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.UserName == userName, ct);
        }

        public async Task<Users> GetUserByIdAsync(Guid id, CancellationToken ct)
        {
            return await context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        public async Task DeleteUserByIdAsync(Guid id, CancellationToken ct)
        {
            await context.Users.Where(x=> x.Id == id).ExecuteDeleteAsync(ct);
                                
        }

        public async Task UpdateUserAsync(Users model, CancellationToken ct)
        {
            context.Update(model);
            
        }

        public async Task<bool> IsEmailOrUsernameTakenAsync(Guid userId, string email, string userName, CancellationToken ct)
        {
            return await context.Users
                .AnyAsync(x => x.Id != userId && (x.Email == email || x.UserName == userName), ct);
        }
    }
}
