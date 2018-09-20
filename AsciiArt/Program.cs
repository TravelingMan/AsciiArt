using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiArt
{
    class Program
    {
        static void Main(string[] args)
        {
            var art = new Art("C:\\Geezus.jpg");

            int[,] brightness = art.GetAverageBrightnessMatrix();
            int count = 0;

            for (int i = 0; i < brightness.GetLength(0); i++)
            {
                for (int j = 0; j < brightness.GetLength(1); j++)
                {
                    Console.WriteLine(brightness[i, j]);
                    count++;
                }
            }
            
            Console.WriteLine("=======\nProcessed " + count + " pixels");
            Console.ReadKey();
        }
    }
}
