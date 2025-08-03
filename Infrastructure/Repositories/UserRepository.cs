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

        public async Task<List<Users>> GetAllUsers(CancellationToken ct)
        {
            return await context.Users
                .Include(x=> x.Role)
                .AsNoTracking()
                .ToListAsync(ct);
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
    }
}
