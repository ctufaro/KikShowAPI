using ImageMagick;
using KikShowAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KikShowAPI.Models
{
    public class GifGenerate : IGifGenerate
    {
        public async Task<System.IO.Stream> GenerateGif(List<Snap> files, IAzureStorage storage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var azstream = await storage.DownloadFromStorage(files[i].FileName);
                    MagickImage mImage = new MagickImage(azstream);
                    mImage.Format = MagickFormat.Jpg;
                    collection.Add(mImage);
                    collection[i].AnimationDelay = 13;
                }

                // Optionally reduce colors
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                // Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write(ms, MagickFormat.Gif);
                ms.Position = 0;
                return ms;
            }            
        }
    }
}
