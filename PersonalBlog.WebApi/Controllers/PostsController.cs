using MediatR;
using Microsoft.AspNetCore.Mvc;
using Personal.Application.Dtos;
using Personal.Application.Features.Post.Command.AddPost;
using PersonalBlog.Application.Features.Post.Query.GetAllPosts;

namespace Personal.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromForm] AddPostDto post)
        {
            var command = new AddPostCommand
            {
                Title = post.Title,
                CoverImageName = post.CoverImage?.FileName,
                PublishDate = post.PublishDate,
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
            var result = await mediator.Send(command);

            if (result.Code == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts(int skip, int size)
        {
            var query = new GetAllPostsQuery
            {
                Skip = skip,
                Size = size,
            };
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
