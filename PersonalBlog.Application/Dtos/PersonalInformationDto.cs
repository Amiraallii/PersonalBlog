namespace PersonalBlog.Application.Dtos
{
    public class PersonalInformationDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string AboutMe { get; set; }
        public List<ContactInfoDto> ContactInfo { get; set; }
    }

   
}
