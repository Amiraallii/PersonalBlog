using Personal.Domain.Entity;

namespace PersonalBlog.Domain.Entity
{
    public class PersonalInformation : Common<byte>
    {
        #region ' Constructor '
        private PersonalInformation()
        {
        }

        public PersonalInformation(string name, string lastName, string jobTitle, string aboutMe, List<ContactInfo> contactInfos)
        {
            Name = name;
            LastName = lastName;
            JobTitle = jobTitle;
            AboutMe = aboutMe;
            ContactInfos = contactInfos;
        }

        #endregion ' Constructor '

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string JobTitle { get; private set; }
        public string AboutMe { get; private set; }

        #region ' Relation '
        public ICollection<ContactInfo> ContactInfos { get; private set; } = new List<ContactInfo>();
        #endregion ' Relation '

        #region ' Action '
        

        public void UpdatePersonalInfo(string name, string lastName, string jobTitle, string aboutMe, List<ContactInfo> contactInfos)
        {
            Name = name;
            LastName = lastName;
            JobTitle = jobTitle;
            AboutMe = aboutMe;
            ContactInfos.Clear();
            ContactInfos = contactInfos;
        }
        #endregion ' Action '
    }
}
