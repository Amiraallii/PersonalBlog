using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Hosting;
using PersonalBlog.Application.Dtos;
using PersonalBlog.Application.IServices;
using PersonalBlog.Application.IServices;
using PersonalBlog.Application.Options;

namespace PersonalBlog.Infrastructure.Shared.FileServices
{
    public class FileService(IWebHostEnvironment _hostEnvironment,
        IFileCompressorService _compressor,
        IAmazonS3 _s3,
        PersonalSettings settings) : IFileService
    {
        

        public async Task<string> SaveFileAsync(FileDto file, CancellationToken ct)
        {
            if (file?.FileStream == null || file.FileStream.Length == 0)
                throw new ArgumentException("فایل ارسال نشده یا خالی است.", nameof(file));

            var title = Guid.NewGuid().ToString("N");
            var fileName = $"{title}.webp";

            using var compressed = await _compressor.CompressImageAsync(file.FileStream);
            if (compressed.CanSeek) compressed.Position = 0;

            var key = Path.Combine("PersonalBlog", "uploads", fileName).Replace('\\', '/');

            

            var put = new PutObjectRequest
            {
                BucketName = settings.S3Storage.BucketName,
                Key = key,
                InputStream = compressed,
                ContentType = "image/webp",
                AutoCloseStream = false,
                AutoResetStreamPosition = true,
            };
            if (settings.S3Storage.PublicRead)
                put.CannedACL = S3CannedACL.PublicRead;

            _ = await _s3.PutObjectAsync(put);

            return key;
        }

        public async Task DeleteFile(string filePath, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;

            var key = filePath;
            var prefix = settings.S3Storage.BaseUrlWithBucket.TrimEnd('/') + "/";
            if (key.StartsWith("http", StringComparison.OrdinalIgnoreCase) &&
                key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                key = key[prefix.Length..];
            }
            key = key.TrimStart('/');
            _ = _s3.DeleteObjectAsync(settings.S3Storage.BucketName, key);
        }
    }


}
