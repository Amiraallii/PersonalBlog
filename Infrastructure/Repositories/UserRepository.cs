using Microsoft.EntityFrameworkCore;
using Personal.Application.Contracts;
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

        public async Task AddUserAsync(User user, CancellationToken ct)
        {
            await context.AddAsync(user, ct);
        }

        public async Task<Role> GetRoleByNameAsync(string roleName, CancellationToken ct)
        {
            return await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, ct);
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken ct)
        {
            return await context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.Email == email, ct);
        }

        public async Task<User> GetUserByUserNameAsync(string userName, CancellationToken ct)
        {
            return await context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.UserName == userName, ct);
        }
    }
}
