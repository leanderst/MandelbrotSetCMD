using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinMandelbrotSetVersuch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double depth;
                Console.CursorVisible = true;
                do
                {
                    Console.Write("Depth: ");
                    string stringDepth = Console.ReadLine();
                    double.TryParse(stringDepth, out depth);
                    Console.Clear();
                }
                while (depth == 0);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    MandelbrotSet.DeciamlMatrix();
                    for (MandelbrotSet.CordY = 0; MandelbrotSet.CordY < Console.WindowHeight; MandelbrotSet.CordY++)
                    {
                        for (MandelbrotSet.CordX = 0; MandelbrotSet.CordX < Console.WindowWidth; MandelbrotSet.CordX++)
                        {
                            try
                            {
                                Console.CursorVisible = false;
                                MandelbrotSet.PixelColor(MandelbrotSet.MandelbrotMatrix[MandelbrotSet.CordX, MandelbrotSet.CordY, 0], MandelbrotSet.MandelbrotMatrix[MandelbrotSet.CordX, MandelbrotSet.CordY, 1], (double) depth);
                                Console.SetCursorPosition(MandelbrotSet.CordX, MandelbrotSet.CordY);
                                //Console.WriteLine(CordXCounter + " | " + CordYCounter);
                                Console.Write(" ");
                            }
                            catch { }
                        }
                        Console.WriteLine();
                    }
                }
                Console.Clear();
            }
        }
    }
    class MandelbrotSet
    {
        public static double[,,] MandelbrotMatrix;
        public static int CordX = 0, CordY = 0;
        public static void PixelColor(double CordX, double CordY, double depth)
        {
            int interation = 0;
            try
            {
                double zReal = 0, zImaginary = 0;
                while (interation < depth && zReal * zReal + zImaginary * zImaginary <= 4)
                {
                    double temp = zReal * zReal - zImaginary * zImaginary + CordX;
                    zImaginary = 2 * zReal * zImaginary - CordY;
                    zReal = temp;
                    interation++;
                }
            }
            catch { }
            //Console.ReadKey();
            try
            {
                switch (interation)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 4:
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case 5:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 6:
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 7:
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        break;
                    case 8:
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        break;
                    case 9:
                        Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    case 10:
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case 11:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        break;
                    case 12:
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }
            }
            catch { }
        }
        private static double WindowWindowWidth = 0, WindowHightCounter = 0;
        public static void DeciamlMatrix()
        {
            MandelbrotMatrix = new double[Console.WindowWidth, Console.WindowHeight, 2];
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                for (int x = 0; x < Console.WindowWidth - 1; x++)
                {
                    try
                    {
                        MandelbrotMatrix[x, y, 0] = -2 + WindowWindowWidth;
                        WindowWindowWidth += (double)3 / Console.WindowWidth;
                        MandelbrotMatrix[x, y, 1] = -1 + WindowHightCounter;
                        //Console.Write("X:" + MandelbrotMatrix[x, y, 0] + " Y:" + MandelbrotMatrix[x, y, 1] + " | ");
                    }
                    catch { }
                }
                try
                {
                    WindowWindowWidth = 0;
                    WindowHightCounter += (double)2 / Console.WindowHeight;
                    //Console.WriteLine();
                }
                catch { }
            }
        }
    }
}