using Personal.Domain.Entity;

namespace PersonalBlog.Domain.Entity
{
    public class PersonalInformation : Common<byte>
    {
        #region ' Consructors '
        private PersonalInformation() { }

        public PersonalInformation(string name, string lastName, string jobTitle, string aboutMe)
        {
            Name = name;
            LastName = lastName;
            JobTitle = jobTitle;
            AboutMe = aboutMe;
        }

        #endregion ' Consructors '

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string JobTitle { get; private set; }
        public string AboutMe { get; private set; }

        #region ' Relations '
        public ICollection<ContactInfo> ContactInfos { get; private set; } = new List<ContactInfo>();
        #endregion ' Relations '

        #region ' Actions '
        public void AddContactInfo(ContactInfo contactInfo)
        {
            ContactInfos.Add(contactInfo);
        }

        public void UpdatePersonalInformation(string name, string lastName, string jobTitle, string aboutMe)
        {
            Name = name;
            LastName = lastName;
            JobTitle = jobTitle;
            AboutMe = aboutMe;
            ContactInfos.Clear();
        }
        #endregion ' Actions '

    }
}
