namespace Personal.Application.IServices
{
    public interface IAuthService
    {
        Task<string> Login(string username, string password);
        Task Register(string username, string password);
    }
}
