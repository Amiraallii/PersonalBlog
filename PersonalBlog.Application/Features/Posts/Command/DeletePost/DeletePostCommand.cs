using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Posts.Command.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
