using Microsoft.AspNetCore.Http;
using Personal.Application.Dtos;

namespace PersonalBlog.Application.Dtos
{
    public class UpdatePostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public IFormFile CoverImage { get; set; }
        public ICollection<AddContentBlocksDto> PostContents { get; set; }
    }
}
