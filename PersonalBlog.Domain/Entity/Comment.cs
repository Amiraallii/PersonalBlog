namespace PersonalBlog.Domain.Entity
{
    public class Comment : Common<Guid>
    {
        #region ' Constuctor '
        private Comment()
        {
        }

        public Comment(Guid postId, Guid authorId, string content, bool isApproved)
        {
            PostId = postId;
            AuthorId = authorId;
            Content = content;
            IsApproved = isApproved;
        }
        #endregion ' Constuctor '

        public Guid PostId { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; } 
        public bool IsApproved { get; private set; } = true;

        #region ' Actions '
        public void ApprovedState()
        {
            IsApproved = !IsApproved;
        }
        public void UpdateContent(string content)
        {
            Content = content;
        }
        #endregion ' Actions '

        #region ' Relations '
        public Post Post { get; private set; }
        public User User { get; private set; } 
        #endregion ' Relations '

    }
}
