namespace Personal.Domain.Entity
{
    public class Role : Common<Guid>
    {
        #region ' Consructor '

        private Role() { }
        public Role(string name) 
        {
            Name = name;
        }

        #endregion ' Consructor '

        public string Name { get; private set; } = default!; 

        #region ' Relations '
        public ICollection<User> Users { get; private set; } = new List<User>();
        #endregion ' Relations '

    }
}
