using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    /// <summary>
    /// Calculates a brightness matrix based on lightness of maximum and minimum values.
    /// </summary>
    class BrightnessLightness: Brightness
    {
        public BrightnessLightness(string pathToBitmap): base(pathToBitmap)
        {
        }

        public override int CalculateBrightness(int R, int G, int B)
        {
            // Could also use Linq for this, using Enumerable.Max here
            int valueHigh = new[] { R, G, B }.Max();
            int valueLow = new[] { R, G, B }.Min();

            return (valueHigh + valueLow) / 2;
        }
    }
}
