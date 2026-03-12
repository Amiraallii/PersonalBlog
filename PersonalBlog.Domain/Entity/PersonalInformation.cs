using Personal.Domain.Entity;

namespace PersonalBlog.Domain.Entity
{
    public class PersonalInformation : Common<byte>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string AboutMe { get; set; }

    }
}
