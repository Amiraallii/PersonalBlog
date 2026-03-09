using Personal.Domain.Entity;
using PersonalBlog.Domain.Enums;

namespace PersonalBlog.Domain.Entity
{
    public class ContactInfo : Common<int>
    {
        public byte PersonalInformationId { get; set; }
        public ContactWayType ContactWayType { get; set; }
        public string ContactWay { get; set; }
    }
}
