using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    /// <summary>
    /// Calculates the brightness by averaging each pixel elements total value
    /// </summary>
    class BrightnessAverage: Brightness
    {
        public BrightnessAverage(string pathToBitmap): base(pathToBitmap)
        {
        }
        
        public override int CalculateBrightness(int R, int G, int B)
        {
            return (R + G + B) / 3;
        }
    }
}
