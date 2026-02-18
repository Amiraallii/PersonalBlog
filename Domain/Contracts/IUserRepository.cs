using Personal.Domain.Entity;

namespace Personal.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<Users> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<Users> GetUserByUserNameAsync(string userName, CancellationToken ct);
        Task AddUserAsync(Users user, CancellationToken ct);
        Task<Roles> GetRoleByNameAsync(string roleName, CancellationToken ct);
        Task<IQueryable<Users>> GetAllUsers(CancellationToken ct);
        Task<Users> GetUserByIdAsync(Guid id, CancellationToken ct);
        Task DeleteUserByIdAsync(Guid id, CancellationToken ct);
        Task UpdateUserAsync(Users model, CancellationToken ct);
        Task<bool> IsEmailOrUsernameTakenAsync(Guid userId, string email, string userName, CancellationToken ct);
    }
}
