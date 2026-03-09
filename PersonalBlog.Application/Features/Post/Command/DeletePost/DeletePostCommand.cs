using MediatR;
using Personal.Application.Dtos;

namespace PersonalBlog.Application.Features.Post.Command.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
