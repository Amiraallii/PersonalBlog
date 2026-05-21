using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Comments.Command.AddComment;
using PersonalBlog.Application.Features.Comments.Command.DeleteComment;
using PersonalBlog.Application.Features.Comments.Command.UpdateComment;
using PersonalBlog.Application.Features.Comments.Query.GetAllComment;
using PersonalBlog.Application.Features.Comments.Query.GetAllPostComments;
using PersonalBlog.Application.Features.Comments.Query.GetCommentById;

namespace PersonalBlog.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController(IMediator mediatR) : PersonalController
    {
        [Authorize]
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(AddCommentDto dto, CancellationToken ct)
        {
            var command = new AddCommentCommand
            {
                AuthorId = CurrentUserId,
                Content = dto.Content,
                PostId = dto.PostId,
                ParentId = dto.ParentId
            };

            await mediatR.Send(command, ct);
            return Ok();
        }
        [HttpPost("ReplyComment")]
        public async Task<IActionResult> ReplyComment(AddCommentDto dto, CancellationToken ct)
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
        [HttpPut("UpdateComment")]
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
        [HttpDelete("DeleteComment")]
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


        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAllComments(CancellationToken ct)
        {
            var command = new GetAllCommentCommand {};

            var comments = await mediatR.Send(command, ct);
            return Ok(comments);
        }

        [HttpGet("GetAllPostComments")]
        public async Task<IActionResult> GetAllPostComments([FromQuery]GetAllPostCommentsCommand dto, CancellationToken ct)
        {
            var comments = await mediatR.Send(dto, ct);
            return Ok(comments);
        }

        [Authorize]
        [HttpGet("GetCommentById")]
        public async Task<IActionResult> GetCommentById([FromQuery]Guid id, CancellationToken ct)
        {
            var command = new GetCommentByIdCommand { Id = id };

            var comment = await mediatR.Send(command, ct);
            return Ok(comment);
        }
    }
}
