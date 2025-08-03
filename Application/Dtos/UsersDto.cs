namespace Personal.Application.Dtos
{
    public class UsersDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; } 
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
