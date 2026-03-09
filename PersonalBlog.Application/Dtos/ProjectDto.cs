namespace PersonalBlog.Application.Dtos
{
    public class ProjectDto : UpdateProjectDto
    {
    }

    public class UpdateProjectDto : BaseProjectDto
    {
        public int Id { get; set; }
    }


    public class BaseProjectDto
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Owner { get; set; }
        public string Link { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
