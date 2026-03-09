using MediatR;
using Microsoft.AspNetCore.Mvc;
using Personal.Application.Dtos;
using Personal.Application.Features.Post.Command.AddPost;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.Features.Post.Command.UpdatePost;
using PersonalBlog.Application.Features.Post.Query.GetAllPosts;
using PersonalBlog.Application.Features.Post.Query.GetPostById;
using PersonalBlog.WebApi.Controllers;
using System.Security.Claims;

namespace Personal.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController(IMediator mediator) : PersonalController
    {


        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromForm] AddPostDto post)
        {
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

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var query = new GetPostByIdQuery { Id = id };

            var result = await mediator.Send(query);

            return Ok(result);

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

            return BadRequest(result);

        }
    }
}

