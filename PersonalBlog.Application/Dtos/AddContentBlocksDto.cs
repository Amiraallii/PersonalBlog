using Microsoft.AspNetCore.Http;
using Personal.Domain.Enums;

namespace PersonalBlog.Application.Dtos
{
    public class AddContentBlocksDto
    {
        public IFormFile? Media { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public ContentTypeEnum ContentType { get; set; }
    }
}
