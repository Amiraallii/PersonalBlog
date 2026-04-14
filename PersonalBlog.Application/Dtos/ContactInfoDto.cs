using PersonalBlog.Domain.Enums;

namespace PersonalBlog.Application.Dtos
{
    public class ContactInfoDto
    {
        public byte PersonalInformationId { get; set; }
        public ContactWayType ContactWayType { get; set; }
        public string ContactWay { get; set; }
    }
}
