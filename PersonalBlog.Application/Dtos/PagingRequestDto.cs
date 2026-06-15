namespace PersonalBlog.Application.Dtos
{
    public class PagingRequestDto
    {
        public int PageSize { get; set; } = 10;

        public int Skip { get; set; } = 0;
    }
}
