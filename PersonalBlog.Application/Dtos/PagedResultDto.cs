namespace PersonalBlog.Application.Dtos
{
    public class PagedResultDto<T>
    {
        public IReadOnlyList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
    }

}
