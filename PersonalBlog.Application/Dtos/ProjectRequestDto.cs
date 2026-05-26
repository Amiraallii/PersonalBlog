namespace PersonalBlog.Application.Dtos
{
    public class ProjectRequestDto : CreateProjectRequestDto
    {
        public int Id { get; set; }
    }

    public class CreateProjectRequestDto
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
    }
}
