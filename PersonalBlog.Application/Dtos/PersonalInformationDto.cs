namespace PersonalBlog.Application.Dtos
{
    public class PersonalInformationDto : BasePersonalInformationDto
    {
        public ICollection<ContactInfoDto> ContactInfos { get; set; }
    }

    public class CreatePersonalInformationDto : BasePersonalInformationDto
    {
        public ICollection<BaseContactInfoDto> ContactInfos { get; set; }

    }

    public class BasePersonalInformationDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string AboutMe { get; set; }

    }
}
