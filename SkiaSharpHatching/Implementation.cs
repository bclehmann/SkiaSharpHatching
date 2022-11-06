using SkiaSharp;
using System.Diagnostics;

namespace SkiaSharpHatching
{
    internal class Implementation 
    {
        public static SKBitmap CreateBitmap(SKColor hatchColor, SKColor backgroundColor)
        {
            var bitmap = new SKBitmap(20, 50);

            using var paint = new SKPaint() { Color = hatchColor };
            using var path = new SKPath();
            using var canvas = new SKCanvas(bitmap);

            canvas.Clear(backgroundColor);
            canvas.DrawRect(new SKRect(0, 0, 20, 20), paint);

            return bitmap;
        }

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

            return SKShader.CreateBitmap(
                CreateBitmap(hatchColor, backgroundColor),
                SKShaderTileMode.Repeat,
                SKShaderTileMode.Repeat,
                SKMatrix.CreateScale(0.25f, 0.25f)
                    .PostConcat(rotationMatrix));
        }
    }
}