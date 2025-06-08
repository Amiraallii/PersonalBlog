namespace Personal.Domain.Entity
{
    public class User : Common<Guid>
    {
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public Guid RoleId { get; set; }

        #region ' Relations '
        public Role Role { get; set; } = default!;
        #endregion ' Relations '

    }
}
