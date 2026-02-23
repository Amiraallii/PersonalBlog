namespace Personal.Domain.Entity
{
    public class Users : Common<Guid>
    {
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public Guid RoleId { get; set; }

        #region ' Relations '
        public Roles Role { get; set; } = default!;
        #endregion ' Relations '

    }
}
