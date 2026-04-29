using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Comments.Command.AddComment;
using PersonalBlog.Application.Features.Comments.Command.DeleteComment;
using PersonalBlog.Application.Features.Comments.Command.UpdateComment;

namespace PersonalBlog.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController(IMediator mediatR) : PersonalController
    {
        [Authorize]
        public async Task<IActionResult> AddComment(AddCommentDto dto, CancellationToken ct)
        {
            var command = new AddCommentCommand
            {
                AuthorId = CurrentUserId,
                Content = dto.Content,
                PostId = dto.PostId,
            };

            await mediatR.Send(command, ct);
            return Ok();
        }

        [Authorize]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto dto, CancellationToken ct)
        {
            var command = new UpdateCommentCommand
            {
                AuthorId = CurrentUserId,
                Content = dto.Content,
                Id = dto.Id,
            };

            await mediatR.Send(command, ct);
            return Ok();
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(Guid id, CancellationToken ct)
        {
            var command = new DeleteCommentCommand
            {
                AuthorId = CurrentUserId,
                Id = id,
            };

            await mediatR.Send(command, ct);
            return Ok();
        }

        //public async Task<IActionResult> GetAllComment(CancellationToken ct)
        //{
        //    var command = new getallc {};

        //    await mediatR.Send(command, ct);
        //    return Ok();
        //}
    }
}
