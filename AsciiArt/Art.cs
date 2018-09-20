using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    class Art
    {
        Bitmap bitmap;

        public Art(string path)
        {
            // TODO Exception handling and basic sanity of IO
            bitmap = new Bitmap(path);
        }

        public int[,] GetAverageBrightnessMatrix()
        {
            var colorMatrix = GetColorMatrix();
            int[,] brightnessMatrix = new int[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    // Average the values for a simplified average brightness
                    brightnessMatrix[i, j] = (
                        bitmap.GetPixel(i, j).R + bitmap.GetPixel(i, j).G + bitmap.GetPixel(i, j).B
                        ) / 3;
                }
            }

            return brightnessMatrix;
        }

        // TODO: Strategy pattern?
        private Color[,] GetColorMatrix()
        {
            Color[,] pixelMatrix = new Color[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    pixelMatrix[i, j] = bitmap.GetPixel(i, j);
                }
            }

            return pixelMatrix;
        }
    }
}
