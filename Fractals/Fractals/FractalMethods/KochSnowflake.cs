using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    internal class KochSnowFlake : BasicFractal
    {
        public KochSnowFlake(Canvas myCanvas, int iteration, List<Color> listOfColors) : base(myCanvas, iteration,
            listOfColors)
        {
        }

        public override void CreateFractal()
        {
            DrawFractal(1, WidthOfCanvas / 2 - 300, HeightOfCanvas / 2, WidthOfCanvas / 2 + 300, HeightOfCanvas / 2);
        }

        private void DrawFractal(int iteration, double x1, double y1, double x2, double y2)
        {
            if (iteration == TotalIteration)
            {
                MyCanvas.Children.Add(new Line()
                {
                    X1 = x1, Y1 = y1, X2 = x2, Y2 = y2,
                    Stroke = new SolidColorBrush(ListOfColors[iteration - 1]), StrokeThickness = 2
                });
            }
            else
            {
                MyCanvas.Children.Add(new Line()
                {
                    X1 = x1, Y1 = y1, X2 = x2, Y2 = y2, Stroke = new SolidColorBrush(Color.FromRgb(0x0d, 0x32, 0x4d)),
                    StrokeThickness = 2
                });

                double x3 = x1 + (x2 - x1) / 3;
                double y3 = y1 + (y2 - y1) / 3;

                double x4 = x1 + (x2 - x1) * 2 / 3;
                double y4 = y1 + (y2 - y1) * 2 / 3;

                double cos60 = 0.5;
                double sin60 = -0.866;

                double x5 = x3 + (x4 - x3) * cos60 - sin60 * (y4 - y3);
                double y5 = y3 + (x4 - x3) * sin60 + cos60 * (y4 - y3);

                DrawFractal(iteration + 1, x1, y1, x3, y3);
                DrawFractal(iteration + 1, x3, y3, x5, y5);
                DrawFractal(iteration + 1, x5, y5, x4, y4);
                DrawFractal(iteration + 1, x4, y4, x2, y2);
            }
        }
    }
}