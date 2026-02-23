using Microsoft.AspNetCore.Hosting;
using Personal.Application.Dtos;
using Personal.Application.IServices;

namespace PersonalBlog.Infrastructure.Shared.FileServices
{
    public class FileService(IWebHostEnvironment _hostEnvironment) : IFileService
    {
        

        public async Task<string> SaveFileAsync(FileDto file, CancellationToken ct)
        {
            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var uploadsPath = Path.Combine(_hostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            var filePath = Path.Combine(uploadsPath, uniqueFileName);
            await using (var newFileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.FileStream.CopyToAsync(newFileStream, ct);
            }
            return $"/uploads/{uniqueFileName}";

        }
    }
}
