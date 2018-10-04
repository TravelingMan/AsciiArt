using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    abstract class Brightness: IBrightnessStrategy
    {
        Bitmap bitmap;

        public Brightness(string pathToBitmap)
        {
            bitmap = new Bitmap(pathToBitmap);
        }

        public virtual int[,] GetBrightnessMatrix(Bitmap bitmap)
        {
            var colorMatrix = GetColorMatrix();
            int[,] brightnessMatrix = new int[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    brightnessMatrix[i, j] = CalculateBrightness(
                        bitmap.GetPixel(i, j).R,
                        bitmap.GetPixel(i, j).G,
                        bitmap.GetPixel(i, j).B);
                }
            }

            return brightnessMatrix;
        }

        public abstract int CalculateBrightness(int R, int G, int B);

        public virtual Color[,] GetColorMatrix()
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

        /// <summary>
        /// Dumps each pixel coordinate and it's brightness value to the console.
        /// TODO: Refactor into simple string return.
        /// </summary>
        public virtual void PrintPixelValues()
        {
            var brightnessMatrix = GetBrightnessMatrix(bitmap);

            for (int i = 0; i < bitmap.Width; i++)
            {
                Console.WriteLine("---------------------- ROW " + i + "----------------------");
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Console.Write($"({i}, {j}): {brightnessMatrix[i,j]}, ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(Environment.NewLine + "Processing complete.");
        }

        public char Translate(int value)
        {
            string ascii = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

            int result = Scale(value, ascii.Length- 1, 255);
            return ascii[result];
        }

        /// <summary>
        /// Scales assume that minimum ascii and RGB values will be 0.
        /// </summary>
        /// <param name="unscaledNumber">The input that needs to be scaled</param>
        /// <param name="maxAsciiCode">The total number of ASCII characters</param>
        /// <param name="maxRGB">The maximum value of the RGB input, likely 255</param>
        /// <returns></returns>
        public int Scale(int unscaledNumber, int maxAsciiCode, int maxRGB)
        {
            return maxAsciiCode * unscaledNumber / maxRGB;
        }

        public string GetAsciiToPixelMap()
        {
            int[,] target = GetBrightnessMatrix(bitmap);            
            string[,] mappedAsciiResult = new string[bitmap.Width, bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    mappedAsciiResult[i, j] = Translate(target[i,j]).ToString();
                }
            }

            // Redundant stuff right down 'ere
            string result = "";

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    result += mappedAsciiResult[i, j];
                }

                result += Environment.NewLine;
            }

            return result;
        }
    }
}
