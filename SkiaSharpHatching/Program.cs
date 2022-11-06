using SkiaSharp;
using System.Diagnostics;
//using static SkiaSharpHatching.Implementation;
using static SkiaSharpHatching.ImplementationColorFilter;

namespace SkiaSharpHatching
{
    internal class Program
    {


        public static void Main(string[] args)
        {
            //var bmp = CreateBitmap(SKColors.Red, SKColors.Blue);
            //WriteBitmapToFile(bmp, "tile.png");

            //var shader = GetShader(SKColors.Red, SKColors.Blue);
            var shader = GetShader(SKColors.Red, SKColors.Blue, StripeDirection.DiagonalUp);
            using var bmp = new SKBitmap(128, 128);
            using var canvas = new SKCanvas(bmp);
            using var paint = new SKPaint()
            {
                Shader = shader
            };

            canvas.DrawRect(new(0, 0, 128, 128), paint);
            Common.WriteBitmapToFile(bmp, "hatch.png");
        }
    }
}