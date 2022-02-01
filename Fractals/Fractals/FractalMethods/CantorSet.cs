using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    internal class CantorSet : BasicFractal
    {
        public CantorSet(Canvas myCanvas, int iteration, List<Color> listOfColors) : base(myCanvas, iteration,
            listOfColors)
        {
        }

        public override void CreateFractal()
        {
            DrawFractal(1, 0, WidthOfCanvas, 5, WidthOfCanvas);
        }

        private void DrawFractal(int iteration, double x1, double x2, double y, double width)
        {
            MyCanvas.Children.Add(new Line()
            {
                X1 = x1, Y1 = y, X2 = x2, Y2 = y,
                Stroke = new SolidColorBrush(ListOfColors[iteration - 1]), StrokeThickness = 15
            });
            if (iteration != TotalIteration)
            {
                DrawFractal(iteration + 1, x1, x1 + width / 3, y + 50, width / 3);
                DrawFractal(iteration + 1, x2 - width / 3, x2, y + 50, width / 3);
            }
        }
    }
}