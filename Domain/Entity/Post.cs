namespace Personal.Domain.Entity
{
    public class Post : Common<Guid>
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;

        #region ' Relations '
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<PostImage> Images { get; set; } = new List<PostImage>();
        #endregion ' Relations '

    }
}
