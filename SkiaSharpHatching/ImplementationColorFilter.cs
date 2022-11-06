using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaSharpHatching
{
    internal class ImplementationColorFilter
    {
        private static SKBitmap CreateBitmap()
        {
            var bitmap = new SKBitmap(20, 50);

            using var paint = new SKPaint() { Color = SKColors.White };
            using var path = new SKPath();
            using var canvas = new SKCanvas(bitmap);

            canvas.Clear(SKColors.Black);
            canvas.DrawRect(new SKRect(0, 0, 20, 20), paint);

            return bitmap;
        }
        
        public readonly static SKBitmap Bitmap = CreateBitmap();

        public static SKShader GetShader(SKColor hatchColor, SKColor backgroundColor, StripeDirection stripeDirection = StripeDirection.Horizontal)
        {
            var rotationMatrix = stripeDirection switch
            {
                StripeDirection.DiagonalUp => SKMatrix.CreateRotationDegrees(-45),
                StripeDirection.DiagonalDown => SKMatrix.CreateRotationDegrees(45),
                StripeDirection.Horizontal => SKMatrix.Identity,
                StripeDirection.Vertical => SKMatrix.CreateRotationDegrees(90),
                _ => throw new NotImplementedException(nameof(StripeDirection))
            };

            var shader = SKShader.CreateBitmap(
                Bitmap,
                SKShaderTileMode.Repeat,
                SKShaderTileMode.Repeat,
                SKMatrix.CreateScale(0.25f, 0.25f)
                    .PostConcat(rotationMatrix));

            return shader.WithColorFilter(ColorFilterHelpers.GetMaskColorFilter(hatchColor, backgroundColor));
        }
    }
}
