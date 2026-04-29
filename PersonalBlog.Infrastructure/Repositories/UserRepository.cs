using Microsoft.EntityFrameworkCore;
using Personal.Domain.Contracts;
using PersonalBlog.Domain.Entity;
using PersonalBlog.Infrastructure.Context;

namespace PersonalBlog.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext _context) : IUserRepository
    {
        

        public async Task AddUserAsync(User user, CancellationToken ct)
        {
            await _context.AddAsync(user, ct);
        }

        public async Task<IQueryable<User>> GetAllUsers(CancellationToken ct)
        {
            return _context.Users
                .Include(x=> x.Role)
                .AsNoTracking();
        }

        public async Task<Role> GetRoleByNameAsync(string roleName, CancellationToken ct)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName, ct);
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken ct)
        {
            return await _context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.Email == email, ct);
        }

        public async Task<User> GetUserByUserNameAsync(string userName, CancellationToken ct)
        {
            return await _context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.UserName == userName, ct);
        }

        public async Task<User> GetUserByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Users
                                .Include(u => u.Role)
                                .FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        public async Task DeleteUserByIdAsync(Guid id, CancellationToken ct)
        {
            await _context.Users.Where(x=> x.Id == id).ExecuteDeleteAsync(ct);
                                
        }

        public async Task UpdateUserAsync(User model)
        {
            _context.Update(model);
            
        }

        public async Task<bool> IsEmailOrUsernameTakenAsync(Guid userId, string email, string userName, CancellationToken ct)
        {
            return await _context.Users
                .AnyAsync(x => x.Id != userId && (x.Email == email || x.UserName == userName), ct);
        }

        public async Task<User> GetUserByRefreshTokenAsync(string token, CancellationToken ct)
        {
            return await _context.Users
                                .FirstOrDefaultAsync(u => u.RefreshToken == token, ct);
        }
    }
}
