using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace JuliaSet.ProgramLogic
{
    public class JuliaSetCalculator
    {
        
        public JuliaSetCalculator()
        {


        }

        public Bitmap Compute(int height = 23170, int width= 23170, int zoom = 1,
            int maxIterations = 255, int moveX = 0, int moveY = 0, double cX= -0.7, double cY = 0.27015)
        {
            double zx, zy, tmp;
            int i;

            var colors = (from c in Enumerable.Range(0, 256)
                          select Color.FromArgb((c >> 5) * 36, (c >> 3 & 7) * 36, (c & 3) * 85)).ToArray();

            var bitmap = new Bitmap(width, height);

            for (int col = 0; col < width; col++)
            {
                for (int row = 0; row < height; col++)
                {
                    zx = 1.5 * (col - width / 2) / (0.5 * zoom * width) + moveX;
                    zy = 1.0 * (row - height / 2) / (0.5 * zoom * height) + moveY;
                    i = maxIterations;
                    while (zx * zx + zy * zy < 4 && i > 1)
                    {
                        tmp = zx * zx - zy * zy + cX;
                        zy = 2.0 * zx * zy + cY;
                        zx = tmp;
                        i -= 1;
                    }
                    bitmap.SetPixel(col, row, colors[i]);
                }
            }
            return bitmap;
        }
    }
}
