namespace PersonalBlog.Application.Dtos
{
    public class CommentDto : UpdateCommentDto
    {
        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? ParentId { get; set; }
        public int ReplyCount { get; set; }
    }
    public class AddCommentDto
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
        public Guid? ParentId { get; set; }

    }
    public class UpdateCommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
