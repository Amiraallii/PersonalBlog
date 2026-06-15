using MediatR;
using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.Features.Comments.Query.GetAllPostComments
{
    public class GetAllPostCommentsCommand : PagingRequestDto, IRequest<PagedResultDto<CommentDto>>
    {
        public Guid PostId { get; set; }
    }
}
