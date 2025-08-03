namespace Personal.Domain.Entity
{
    public class Roles : Common<Guid>
    {
        public string Name { get; set; } = default!; 

        #region ' Relations '
        public ICollection<Users> Users { get; set; } = new List<Users>();
        #endregion ' Relations '

    }
}
