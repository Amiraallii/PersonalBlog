using Personal.Domain.Enums;

namespace Personal.Domain.Entity
{
    public class PostContentBlock : Common<Guid>
    {
        #region ' Consructor '

        private PostContentBlock() { }

        public PostContentBlock(int order, ContentTypeEnum blockType, string content)
        {
            Order = order;
            ContentType = blockType;
            Content = content;
        }

        #endregion ' Consructor '
        public Guid PostId { get; private set; }
        public Post Post { get; private set; }
        public int Order { get; private set; } 
        public ContentTypeEnum ContentType { get; private set; } 
        public string Content { get; private set; }

        #region ' Actions '



        #endregion ' Actions '

    }
}
