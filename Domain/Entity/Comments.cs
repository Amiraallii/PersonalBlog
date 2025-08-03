namespace Personal.Domain.Entity
{
    public class Comments : Common<Guid>
    {
        public Guid PostId { get; set; }
        public string AuthorName { get; set; } = default!;
        public string Content { get; set; } = default!;
        public bool IsApproved { get; set; } = false;

        #region ' Relations '
        public Posts Post { get; set; } = default!;
        #endregion ' Relations '
    }
}
