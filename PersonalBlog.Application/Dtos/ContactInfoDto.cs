using PersonalBlog.Domain.Enums;

namespace PersonalBlog.Application.Dtos
{
    public class ContactInfoDto : BaseContactInfoDto
    {
        public byte PersonalInformationId { get; set; }
        public int Id { get; set; }
    }

    public class BaseContactInfoDto
    {
        public ContactWayType ContactWayType { get; set; }
        public string ContactWay { get; set; }
    }
}
