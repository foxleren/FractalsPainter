using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    internal class SierpinskiTriangle : BasicFractal
    {
        public SierpinskiTriangle(Canvas myCanvas, int iteration, List<Color> listOfColors) : base(myCanvas, iteration,
            listOfColors)
        {
        }

        public override void CreateFractal()
        {
            DrawFractal(1,
                new Point(WidthOfCanvas / 2, 0),
                new Point(0, HeightOfCanvas * 2.5 / 3),
                new Point(WidthOfCanvas, HeightOfCanvas * 2.5 / 3));
        }

        private void DrawFractal(int iteration, Point topPoint, Point leftPoint, Point rightPoint)
        {
            if (iteration == TotalIteration)
            {
                MyCanvas.Children.Add(new Polygon
                {
                    Points = {topPoint, leftPoint, rightPoint}, 
                    Stroke = new SolidColorBrush(ListOfColors[iteration - 1])
                });
            }
            else
            {
                Point leftMiddlePoint = new Point((topPoint.X + leftPoint.X) / 2, (topPoint.Y + leftPoint.Y) / 2);
                Point rightMiddlePoint = new Point((topPoint.X + rightPoint.X) / 2, (topPoint.Y + rightPoint.Y) / 2);
                Point topMiddlePoint = new Point((leftPoint.X + rightPoint.X) / 2, (leftPoint.Y + rightPoint.Y) / 2);

                DrawFractal(iteration + 1, topPoint, leftMiddlePoint, rightMiddlePoint);
                DrawFractal(iteration + 1, leftMiddlePoint, leftPoint, topMiddlePoint);
                DrawFractal(iteration + 1, rightMiddlePoint, topMiddlePoint, rightPoint);
            }
        }
    }
}