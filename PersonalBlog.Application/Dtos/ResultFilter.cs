namespace PersonalBlog.Application.Dtos
{
    public class ResultFilter
    {
        public int Size { get; set; } = 10;
        public int Skip { get; set; }
    }
}
