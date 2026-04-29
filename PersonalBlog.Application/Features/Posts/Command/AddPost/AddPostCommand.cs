using MediatR;
using PersonalBlog.Application.Dtos;
using Personal.Domain.Enums;

namespace PersonalBlog.Application.Features.Posts.Command.AddPost
{
    public class AddPostCommand : IRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public Guid AuthorId { get; set; }
        public string CoverImageName { get; set; }
        public DateTime PublishDate { get; set; }
        public Stream CoverImage { get; set; }
        public ICollection<ContentBlockCommand> PostContents { get; set; }
    }

    public class ContentBlockCommand
    {
        public Stream? Media { get; set; }
        public string? FileName { get; set; }
        public string? Content { get; set; }
        public int Order { get; set; }
        public ContentTypeEnum ContentType { get; set; }
    }
}
