using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaSharpHatching
{
    internal class Common
    {
        public static void WriteBitmapToFile(SKBitmap bitmap, string filename)
        {
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = new FileStream(filename, FileMode.OpenOrCreate);

            data.SaveTo(stream);
            OpenInPhotoViewer(filename);
        }

        public static void OpenInPhotoViewer(string filename)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = filename;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }
    }
}
