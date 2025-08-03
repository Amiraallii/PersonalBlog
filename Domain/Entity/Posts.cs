namespace Personal.Domain.Entity
{
    public class Posts : Common<Guid>
    {
        public string Title { get; set; } = default!;
        public string CoverImageAdd { get; set; } = default!;
        public DateTime PublishDate { get; set; }
        #region ' Relations '
        public ICollection<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<PostContentBlock> ContentBlocks { get; set; } = new List<PostContentBlock>();
        #endregion ' Relations '

    }
}
