using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    class Program
    {
        enum BrightnessAlgorithms
        {
            Average,
            Lightness
        }

        static void Main(string[] args)
        {
            string path = @"C:\Geezus.jpg";

            IBrightnessStrategy strategy = GetStrategy(BrightnessAlgorithms.Lightness, path);
            strategy.PrintPixelValues();
                        
            Console.ReadKey();
        }

        static IBrightnessStrategy GetStrategy(BrightnessAlgorithms algorithm, string path)
        {
            switch (algorithm)
            {
                case BrightnessAlgorithms.Average:
                    return new BrightnessAverage(path);
                case BrightnessAlgorithms.Lightness:
                    return new BrightnessLightness(path);
                default:
                    return new BrightnessAverage(path);
            }
        }
    }
}
