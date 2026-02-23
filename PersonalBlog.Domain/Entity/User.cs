namespace Personal.Domain.Entity
{
    public class User : Common<Guid>
    {

        #region ' Consructor '

        private User() { }

        public User(string email, string userName, string passwordHash, string fullName, Guid roleId, Role role)
        {
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
            FullName = fullName;
            RoleId = roleId;
            Role = role;
        }



        #endregion ' Consructor '

        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string FullName { get; private set; }
        public Guid RoleId { get; private set; }

        #region ' Relations '
        public Role Role { get; private set; }
        #endregion ' Relations '


        #region ' Actions '

        public void UpdateUserInfo(string email, string userName, string fullName, Guid roleId)
        {
            Email = email;
            UserName = userName;
            FullName = fullName;
            RoleId = roleId;
        }

        public void UpdateUserPassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
        
        #endregion ' Actions '

    }
}
