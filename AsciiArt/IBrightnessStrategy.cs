using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    interface IBrightnessStrategy
    {
        int[,] GetBrightnessMatrix(Bitmap bitmap);
        void PrintPixelValues();
        string GetAsciiToPixelMap();
    }
}
