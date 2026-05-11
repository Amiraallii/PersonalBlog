namespace PersonalBlog.Domain.Entity
{
    public class Post : Common<Guid>
    {
        #region ' Consructor '

        private Post() { }

        public Post(string title, string summary, Guid authorId, string coverImageAdd, DateTime publishDate)
        {
            Title = title;
            Summary = summary;
            AuthorId = authorId;
            CoverImageAdd = coverImageAdd;
            PublishDate = publishDate;
        }

        #endregion ' Consructor '

        public string Title { get; private set; }
        public string Summary { get; private set; }
        public Guid AuthorId { get; private set; }
        public string CoverImageAdd { get; private set; }
        public DateTime PublishDate { get; private set; }
        #region ' Relations '
        public ICollection<Comment> Comments { get; private set; } 
        public User Author { get; private set; }
        public ICollection<PostContentBlock> PostContents { get; private set; } = new List<PostContentBlock>();
        #endregion ' Relations '

        #region ' Actions '

        public void AddContentBlock(PostContentBlock block)
        {
            PostContents.Add(block);
        }

        public void UpdatePost(string title, string summary, string coverImageAdd, DateTime publishDate)
        {
            Title = title;
            Summary = summary;
            CoverImageAdd = coverImageAdd;
            PublishDate = publishDate;
        }

        #endregion ' Actions '

    }
}
