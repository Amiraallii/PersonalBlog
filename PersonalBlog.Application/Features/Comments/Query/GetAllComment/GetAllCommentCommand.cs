using MediatR;
using PersonalBlog.Application.Dtos;
using System.Collections.Generic;

namespace PersonalBlog.Application.Features.Comments.Query.GetAllComment
{
    public class GetAllCommentCommand : IRequest<IReadOnlyList<CommentDto>>
    {
    }
}
