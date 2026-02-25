using Microsoft.AspNetCore.Http;
using Personal.Application.Dtos;

namespace PersonalBlog.Application.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string CoverImageAddress { get; set; }
        public ICollection<ContentBlocksDto> PostContents { get; set; }
    }
}
