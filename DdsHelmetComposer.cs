using BCnEncoder.Decoder;
using BCnEncoder.Encoder;
using BCnEncoder.ImageSharp;
using BCnEncoder.Shared.ImageFiles;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.IO;

public class HelmetComposer
{
    public static void Compose(string basePath, string sponsorPath, string outputPath)
    {
        var decoder = new BcDecoder();
        Image<Rgba32> baseImage;
        using (var baseStream = File.OpenRead(basePath))
        {
            baseImage = decoder.DecodeToImageRgba32(baseStream);
        }

        // Load the sponsor overlay DDS
        Image<Rgba32> sponsorImage;
        using (var sponorStream = File.OpenRead(sponsorPath))
        {
            sponsorImage = decoder.DecodeToImageRgba32(sponorStream);
        }
        // Resize sponsor to match base if needed
        sponsorImage.Mutate(ctx => ctx.Resize(baseImage.Width, baseImage.Height));

        // Apply alpha blending
        baseImage.Mutate(ctx => ctx.DrawImage(sponsorImage, 1f));

        // Encode to DDS with mipmaps
        var encoder = new BcEncoder(BCnEncoder.Shared.CompressionFormat.Bc3)
        {
            OutputOptions = {
                GenerateMipMaps = true,
                Quality = CompressionQuality.Balanced,
                DdsPreferDxt10Header = false
            }
        };
        var ddsFile = encoder.EncodeToDds(baseImage);
        var mipmapcount = ddsFile.header.dwMipMapCount;
        using var outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
        ddsFile.Write(outputStream);

    }
}
