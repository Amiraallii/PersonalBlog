using MediatR;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Posts.Command.AddPost;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Posts.Command.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string CoverImageName { get; set; }
        public DateTime PublishDate { get; set; }
        public Stream CoverImage { get; set; }
        public ICollection<ContentBlockCommand> PostContents { get; set; }
        public string CoverImageAddress { get; set; }
    }
}
