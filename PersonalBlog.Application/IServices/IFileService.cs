using PersonalBlog.Application.Dtos;

namespace PersonalBlog.Application.IServices
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(FileDto file, CancellationToken ct);
        Task DeleteFile(string filePath, CancellationToken ct);
    }
}
