using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    internal class SierpinskiCarpet : BasicFractal
    {
        public SierpinskiCarpet(Canvas myCanvas, int iteration, List<Color> listOfColors) : base(myCanvas, iteration,
            listOfColors)
        {
        }

        public override void CreateFractal()
        {
            DrawFractal(1, CreateCarpet(1, 0, 0, WidthOfCanvas, HeightOfCanvas));
        }

        private void DrawFractal(int iteration, Rectangle carpet)
        {
            if (iteration == TotalIteration)
            {
                MyCanvas.Children.Add(carpet);
            }
            else
            {
                double width = carpet.Width / 3;
                double height = carpet.Height / 3;

                double x1 = Canvas.GetLeft(carpet);
                double x2 = x1 + width;
                double x3 = x1 + 2 * width;

                double y1 = Canvas.GetTop(carpet);
                double y2 = y1 + height;
                double y3 = y1 + 2 * height;

                DrawFractal(iteration + 1, CreateCarpet(iteration, x1, y1, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x2, y1, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x3, y1, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x1, y2, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x3, y2, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x1, y3, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x2, y3, width, height));
                DrawFractal(iteration + 1, CreateCarpet(iteration, x3, y3, width, height));

                //Rectangle rectangleFromPreviousIteration = new Rectangle()
                //{
                //    Width = width,
                //    Height = height,
                //    Fill = new SolidColorBrush(ListOfColors[iteration - 1])
                //};
                //Canvas.SetLeft(rectangleFromPreviousIteration, x2);
                //Canvas.SetTop(rectangleFromPreviousIteration, y2);
                
                //MyCanvas.Children.Add(rectangleFromPreviousIteration);
            }
        }

        private Rectangle CreateCarpet(int iteration, double x, double y, double width, double height)
        {
            Rectangle newCarpet = new()
            {
                Width = width, Height = height,
                Fill = new SolidColorBrush(ListOfColors[iteration - 1])
            };

            Canvas.SetTop(newCarpet, x);
            Canvas.SetLeft(newCarpet, y);

            return newCarpet;
        }
    }
}