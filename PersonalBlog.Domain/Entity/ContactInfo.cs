using Personal.Domain.Entity;
using PersonalBlog.Domain.Enums;

namespace PersonalBlog.Domain.Entity
{
    public class ContactInfo : Common<int>
    {
        #region ' Consructors '
        private ContactInfo() { }

        public ContactInfo(ContactWayType contactWayType, string contactWay)
        {
            ContactWayType = contactWayType;
            ContactWay = contactWay;
        }

        #endregion ' Consructors '

        public byte PersonalInformationId { get; set; }
        public ContactWayType ContactWayType { get; set; }
        public string ContactWay { get; set; }

        #region ' Relations '
        public PersonalInformation PersonalInformation { get; set; }
        #endregion ' Relations '
    }
}
