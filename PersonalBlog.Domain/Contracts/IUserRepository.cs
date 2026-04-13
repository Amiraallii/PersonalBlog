using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<User> GetUserByUserNameAsync(string userName, CancellationToken ct);
        Task AddUserAsync(User user, CancellationToken ct);
        Task<Role> GetRoleByNameAsync(string roleName, CancellationToken ct);
        Task<IQueryable<User>> GetAllUsers(CancellationToken ct);
        Task<User> GetUserByIdAsync(Guid id, CancellationToken ct);
        Task<User> GetUserByRefreshTokenAsync(string token, CancellationToken ct);
        Task DeleteUserByIdAsync(Guid id, CancellationToken ct);
        Task UpdateUserAsync(User model);
        Task<bool> IsEmailOrUsernameTakenAsync(Guid userId, string email, string userName, CancellationToken ct);
    }
}
