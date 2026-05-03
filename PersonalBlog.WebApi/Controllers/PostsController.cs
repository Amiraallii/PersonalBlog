using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Posts.Command.AddPost;
using PersonalBlog.Application.Features.Posts.Command.DeletePost;
using PersonalBlog.Application.Features.Posts.Command.UpdatePost;
using PersonalBlog.Application.Features.Posts.Query.GetAllPosts;
using PersonalBlog.Application.Features.Posts.Query.GetPostById;

namespace PersonalBlog.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController(IMediator mediator) : PersonalController
    {

        [Authorize(Roles = "Admin")]
        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromForm] AddPostDto post)
        {
            var claims = User.Claims.Select(x => new { x.Type, x.Value }).ToList();

            var x = CurrentUserId;
            var command = new AddPostCommand
            {
                Title = post.Title,
                CoverImageName = post.CoverImage?.FileName,
                PublishDate = post.PublishDate,
                Summary = post.Summary,
                AuthorId = CurrentUserId,
                CoverImage = post.CoverImage?.OpenReadStream(),
                PostContents = post.PostContents.Select(x => new ContentBlockCommand
                {
                    Content = x.Content,
                    ContentType = x.ContentType,
                    FileName = x.Media?.FileName,
                    Media = x.Media?.OpenReadStream(),
                    Order = x.Order,
                }).ToList(),
            };
            await mediator.Send(command);


            return Ok();

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromForm] UpdatePostDto post)
        {
            var command = new UpdatePostCommand
            {
                Id = post.Id,
                Title = post.Title,
                CoverImageName = post.CoverImage?.FileName,
                PublishDate = post.PublishDate,
                Summary = post.Summary,
                CoverImage = post.CoverImage?.OpenReadStream(),
                PostContents = post.PostContents.Select(x => new ContentBlockCommand
                {
                    Content = x.Content,
                    ContentType = x.ContentType,
                    FileName = x.Media?.FileName,
                    Media = x.Media?.OpenReadStream(),
                    Order = x.Order,
                }).ToList(),
            };
            await mediator.Send(command);


            return Ok();


        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var query = new DeletePostCommand { Id = id };

            await mediator.Send(query);

            return Ok();

        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts([FromQuery] ResultFilter filter)
        {
            var query = new GetAllPostsQuery
            {
                Skip = filter.Skip,
                Size = filter.Size,
            };
            var result = await mediator.Send(query);

            return Ok(result);

        }

        [HttpGet("GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var query = new GetPostByIdQuery { Id = id };

            var result = await mediator.Send(query);

            return Ok(result);


        }
    }
}

