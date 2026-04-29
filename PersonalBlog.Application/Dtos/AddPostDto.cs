using Microsoft.AspNetCore.Http;

namespace PersonalBlog.Application.Dtos
{
    public class AddPostDto
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile CoverImage { get; set; }
        public ICollection<AddContentBlocksDto> PostContents { get; set; }
    }
}
