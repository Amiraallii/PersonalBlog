using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Personal.Application.Dtos;
using Personal.Application.IServices;
using System.IO;

namespace Personal.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> SaveFileAsync(FileDto file, CancellationToken ct)
        {
            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var uploadsPath = Path.Combine(_hostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(uploadsPath)) 
            {
                Directory.CreateDirectory(uploadsPath);
            }
            var filePath = Path.Combine(uploadsPath, uniqueFileName);
            await using(var newFileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.FileStream.CopyToAsync(newFileStream, ct);
            }
            return $"/uploads/{uniqueFileName}";

        }
    }
}
