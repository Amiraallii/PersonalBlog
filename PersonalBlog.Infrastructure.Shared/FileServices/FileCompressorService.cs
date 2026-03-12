using PersonalBlog.Application.IServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace PersonalBlog.Infrastructure.Shared.FileServices
{
    public class FileCompressorService : IFileCompressorService
    {
        public async Task<Stream> CompressImageAsync(Stream inputStream, int quality = 80, int maxWidth = 1920)
        {
            inputStream.Position = 0;
            var image = await Image.LoadAsync(inputStream);
            image.Mutate(x => x.AutoOrient());
            if (image.Width > maxWidth)
            {
                double scale = (double)maxWidth / image.Width;
                int newHeight = (int)(image.Height * scale);
                image.Mutate(x => x.Resize(maxWidth, newHeight));
            }
            var outPut = new MemoryStream();
            var encoder = new WebpEncoder
            {
                Quality = quality,
                Method = WebpEncodingMethod.BestQuality
            };

            await image.SaveAsync(outPut, encoder);
            outPut.Position = 0;
            return outPut;
        }
    }
}
