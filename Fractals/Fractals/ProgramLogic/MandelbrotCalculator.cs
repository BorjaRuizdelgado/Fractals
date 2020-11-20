using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MandelbrotSet.ProgramLogic
{
    public class MandelbrotCalculator
    { 
        struct Complex
        {
            public double real;
            public double imaginary;
        }

        const int N = 2;
        private double scaleReal;
        private double scaleImaginary;

        public MandelbrotCalculator()
        {
            
        }

        public Bitmap Compute(int height = 23170, int width = 23170,
            double realMin = -2, double realMax = 2, double imaginaryMin = -2,
            double imaginaryMax = 2, int maxIterations = 1000)
        {

            Bitmap bitmap = new Bitmap(height, width);
            scaleReal = (realMax - realMin) / width;
            scaleImaginary = (imaginaryMax - imaginaryMin) / width;

            double[,] result = new double[height, width];

            var colors = (from c in Enumerable.Range(0, 256)
                          select Color.FromArgb((c >> 5) * 36, (c >> 3 & 7) * 36, (c & 3) * 85)).ToArray();


            Parallel.For(0, height, (row) =>
            {
                for (int col = 0; col < width; ++col)
                {
                    Complex z = new Complex(); ;
                    Complex c = new Complex(); ;

                    z.real = 0.0;
                    z.imaginary = 0.0;

                    c.real = realMin + col * scaleReal;
                    c.imaginary = imaginaryMin + (height - 1 - row) * scaleImaginary;

                    int divergenceIterator = 0;

                    double temp;
                    double lengthsq;

                    do
                    {
                        temp = z.real * z.real - z.imaginary * z.imaginary + c.real;
                        z.imaginary = 2 * z.real * z.imaginary + c.imaginary;
                        z.real = temp;
                        lengthsq = z.real * z.real + z.imaginary * z.imaginary;
                        ++divergenceIterator;
                    }
                    while (lengthsq < (N * N) && divergenceIterator < maxIterations);
                    bitmap.SetPixel(row, col, colors[divergenceIterator * 255 / maxIterations]);
                }
            });
            return bitmap;
        }
    }
}
