using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Query.GetAllPostComments
{
    public class GetAllPostCommentsCommand : ResultFilter, IRequest<IReadOnlyList<CommentDto>>
    {
        public Guid PostId { get; set; }
    }
}
