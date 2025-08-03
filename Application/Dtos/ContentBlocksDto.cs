using Microsoft.AspNetCore.Http;
using Personal.Domain.Enums;

namespace Personal.Application.Dtos
{
    public class ContentBlocksDto
    {
        public IFormFile? Media { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public ContentTypeEnum ContetntType { get; set; }
    }
}
