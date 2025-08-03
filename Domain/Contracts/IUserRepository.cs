using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<Users> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<Users> GetUserByUserNameAsync(string userName, CancellationToken ct);
        Task AddUserAsync(Users user, CancellationToken ct);
        Task<Roles> GetRoleByNameAsync(string roleName, CancellationToken ct);
        Task<List<Users>> GetAllUsers(CancellationToken ct);
    }
}
