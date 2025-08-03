using Personal.Domain.Enums;

namespace Personal.Domain.Entity
{
    public class PostContentBlock : Common<Guid>
    {
        public Guid PostId { get; set; }
        public Posts Post { get; set; }
        public int Order { get; set; } 
        public ContentTypeEnum BlockType { get; set; } 
        public string Content { get; set; }
    }
}
