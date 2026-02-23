namespace Personal.Domain.Entity
{
    public class Comment : Common<Guid>
    {
        public Guid PostId { get; private set; }
        public string AuthorName { get; private set; } = default!;
        public string Content { get; private set; } = default!;
        public bool IsApproved { get; private set; } = false;

        #region ' Relations '
        public Post Post { get; private set; } = default!;
        #endregion ' Relations '
    }
}
