using Personal.Domain.Entity;

namespace Personal.Application.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<User> GetUserByUserNameAsync(string userName, CancellationToken ct);
        Task AddUserAsync(User user, CancellationToken ct);
        Task<Role> GetRoleByNameAsync(string roleName, CancellationToken ct); 
    }
}
