using Personal.Application.Dtos;

namespace Personal.Application.IServices
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(FileDto file, CancellationToken ct);
    }
}
