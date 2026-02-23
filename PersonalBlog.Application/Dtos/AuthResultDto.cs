namespace Personal.Application.Dtos
{
    public class AuthResultDto
    {
        public string Token { get; set; } = string.Empty;
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}
