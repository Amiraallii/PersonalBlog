namespace Personal.Domain.Entity
{
    public class Post : Common<Guid>
    {
        #region ' Consructor '

        private Post() { }

        public Post(string title, string coverImageAdd, DateTime publishDate) 
        {
            Title = title;
            CoverImageAdd = coverImageAdd;
            PublishDate = publishDate;
        }

        #endregion ' Consructor '

        public string Title { get; private set; }
        public string CoverImageAdd { get; private set; }
        public DateTime PublishDate { get; private set; }
        #region ' Relations '
        public ICollection<Comment> Comments { get; private set; } = new List<Comment>();
        public ICollection<PostContentBlock> PostContents { get; private set; } = new List<PostContentBlock>();
        #endregion ' Relations '

        #region ' Actions '

        public void AddContentBlock(PostContentBlock block)
        {
            PostContents.Add(block);
        }

        #endregion ' Actions '

    }
}
