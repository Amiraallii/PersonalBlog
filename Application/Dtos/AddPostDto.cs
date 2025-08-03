using Microsoft.AspNetCore.Http;

namespace Personal.Application.Dtos
{
    public class AddPostDto
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile CoverImage { get; set; }
        public ICollection<ContentBlocksDto> ContentBlocks { get; set; }
    }
}
