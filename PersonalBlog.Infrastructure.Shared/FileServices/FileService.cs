using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Personal.Application.Dtos;
using Personal.Application.IServices;
using PersonalBlog.Application.IServices;

namespace PersonalBlog.Infrastructure.Shared.FileServices
{
    public class FileService(IWebHostEnvironment _hostEnvironment, IFileCompressorService _compressor) : IFileService
    {
        

        public async Task<string> SaveFileAsync(FileDto file, CancellationToken ct)
        {
            if (file?.FileStream == null || file.FileStream.Length == 0)
                throw new ArgumentException("فایل ارسال نشده یا خالی است.", nameof(file));

            var title = Guid.NewGuid().ToString("N");
            var fileName = $"{title}.webp";
            var uploadsPath = Path.Combine(_hostEnvironment.ContentRootPath, "uploads");

            using var compressed = await _compressor.CompressImageAsync(file.FileStream);
            if (compressed.CanSeek) compressed.Position = 0;


            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            var filePath = Path.Combine(uploadsPath, fileName);
            await using (var newFileStream = new FileStream(filePath, FileMode.Create))
            {
                await compressed.CopyToAsync(newFileStream, ct);
            }
            return $"/uploads/{fileName}";

        }
    }
}
