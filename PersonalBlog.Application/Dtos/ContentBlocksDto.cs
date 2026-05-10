using Microsoft.AspNetCore.Http;
using Personal.Domain.Enums;

namespace PersonalBlog.Application.Dtos
{
    public class ContentBlocksDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
        public ContentTypeEnum ContentType { get; set; }
    }
}
