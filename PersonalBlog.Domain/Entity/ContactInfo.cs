using Personal.Domain.Entity;
using PersonalBlog.Domain.Enums;

namespace PersonalBlog.Domain.Entity
{
    public class ContactInfo : Common<int>
    {
        #region ' Constuctor '
        private ContactInfo()
        {
        }

        public ContactInfo(ContactWayType contactWayType, string contactWay)
        {
            ContactWayType = contactWayType;
            ContactWay = contactWay;
        }


        #endregion ' Constuctor '


        public byte PersonalInformationId { get; private set; }
        public ContactWayType ContactWayType { get; private set; }
        public string ContactWay { get; private set; }

        #region ' Relation '
        public PersonalInformation PersonalInformation { get; private set; }
        #endregion ' Relation '

    }
}
