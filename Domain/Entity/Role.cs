namespace Personal.Domain.Entity
{
    public class Role : Common<Guid>
    {
        public string Name { get; set; } = default!; 

        #region ' Relations '
        public ICollection<User> Users { get; set; } = new List<User>();
        #endregion ' Relations '

    }
}
