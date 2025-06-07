namespace Personal.Domain.Entity
{
    public class PostImage : Common<Guid>
    {
        public Guid PostId { get; set; }
        public string Url { get; set; } = default!;

        #region ' Relations '
        public Post Post { get; set; } = default!;
        #endregion ' Relations '

    }
}
