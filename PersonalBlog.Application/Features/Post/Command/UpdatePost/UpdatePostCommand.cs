using MediatR;
using Personal.Application.Dtos;
using Personal.Application.Features.Post.Command.AddPost;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Post.Command.UpdatePost
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
    }
}
