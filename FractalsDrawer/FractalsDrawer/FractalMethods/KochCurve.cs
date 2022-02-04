using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsDrawer.FractalMethods
{
    /// <summary>
    /// Класс фрактала "Кривая Коха".
    /// </summary>
    internal class KochCurve : BasicFractal
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="myCanvas">Объект Canvas</param>
        /// <param name="iteration">Выбранная итерация</param>
        /// <param name="listOfColors">Список цветов для градиента</param>
        public KochCurve(Canvas myCanvas, int iteration, List<Color> listOfColors) : base(myCanvas, iteration,
            listOfColors)
        {
        }

        /// <summary>
        /// Метод для начала отрисовки элементов фрактала.
        /// </summary>
        public override void CreateFractal()
        {
            DrawFractal(1, WidthOfCanvas / 2 - 300, HeightOfCanvas / 2 + 100, WidthOfCanvas / 2 + 300, HeightOfCanvas / 2 + 100);
        }

        /// <summary>
        /// Метод отрисовки элементов фрактала.
        /// </summary>
        /// <param name="iteration">Текущая итерация</param>
        /// <param name="x1">Левая координата по x</param>
        /// <param name="y1">Левая координата по y</param>
        /// <param name="x2">Правая координата по x</param>
        /// <param name="y2">Правая координата по y</param>
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
                double cosAlpha = 0.5;
                double sinAlpha = -0.87;

                double x3 = x1 + (x2 - x1) / 3;
                double y3 = y1 + (y2 - y1) / 3;
                double x4 = x1 + (x2 - x1) * 2 / 3;
                double y4 = y1 + (y2 - y1) * 2 / 3;
                double x5 = x3 + cosAlpha * (x4 - x3) - sinAlpha * (y4 - y3);
                double y5 = y3 + sinAlpha * (x4 - x3) + cosAlpha * (y4 - y3);

                DrawFractal(iteration + 1, x1, y1, x3, y3);
                DrawFractal(iteration + 1, x3, y3, x5, y5);
                DrawFractal(iteration + 1, x5, y5, x4, y4);
                DrawFractal(iteration + 1, x4, y4, x2, y2);
            }
        }
    }
}