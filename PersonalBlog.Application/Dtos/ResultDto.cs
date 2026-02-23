namespace Personal.Application.Dtos
{
    public class ResultDto<T> : ResultDto
    {
        public T Value { get; set; }
    }

    public class ResultDto
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = true;
        public int Code { get; set; }
        public DateTime Date { get; set; }
    }
}
