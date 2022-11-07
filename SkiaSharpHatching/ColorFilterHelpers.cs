﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiaSharpHatching
{
    internal class ColorFilterHelpers
    {
        public static SKColorFilter GetMaskColorFilter(SKColor foreground, SKColor background)
        {
            float redDifference = foreground.Red - background.Red;
            float greenDifference = foreground.Green - background.Green;
            float blueDifference = foreground.Blue - background.Blue;
            float alphaDifference = foreground.Alpha - background.Alpha;

            // See https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/effects/color-filters for an explanation of this matrix
            // 
            // Essentially, this matrix maps all gray colours to a line from `background.Value` to `foreground`. Black and white are at the extremes on this line, 
            // so they get mapped to `background.Value` and `foreground` respectively
            var mat = new float[] {
                redDifference / 255, 0, 0, 0, background.Red / 255.0f,
                0, greenDifference / 255, 0, 0, background.Green / 255.0f,
                0, 0, blueDifference / 255, 0, background.Blue / 255.0f,
                alphaDifference / 255, 0, 0, 0, background.Alpha / 255.0f,
            };

            var filter = SKColorFilter.CreateColorMatrix(mat);
            return filter;
        }
    }
}
