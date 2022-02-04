using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsDrawer.FractalMethods
{
    /// <summary>
    /// Класс для фрактала "Множество Кантора".
    /// </summary>
    internal class CantorSet : BasicFractal
    {
        /// <summary>
        /// Расстояние между отрезками.
        /// </summary>
        private int LineDistance { get; set; }
        
        /// <summary>
        /// Констуктор.
        /// </summary>
        /// <param name="myCanvas">Объект Canvas</param>
        /// <param name="iteration">Выбранная итерация</param>
        /// <param name="listOfColors">Список цветов для градиента</param>
        /// <param name="lineDistance">Расстояние между отрезками</param>
        public CantorSet(Canvas myCanvas, int iteration, List<Color> listOfColors, int lineDistance) : base(myCanvas, iteration,
            listOfColors)
        {
            LineDistance = lineDistance;
        }

        /// <summary>
        /// Метод для начала отрисовки элементов фрактала.
        /// </summary>
        public override void CreateFractal()
        {
            DrawFractal(1, 0, WidthOfCanvas, 5, WidthOfCanvas);
        }

        /// <summary>
        /// Метод отрисовки элементов фрактала.
        /// </summary>
        /// <param name="iteration">Текущая итерация</param>
        /// <param name="x1">Начальная координата по x</param>
        /// <param name="x2">Конечная координата по x</param>
        /// <param name="y">Координата y</param>
        /// <param name="width">Ширина отрезка</param>
        private void DrawFractal(int iteration, double x1, double x2, double y, double width)
        {
            MyCanvas.Children.Add(new Line()
            {
                X1 = x1, Y1 = y, X2 = x2, Y2 = y,
                Stroke = new SolidColorBrush(ListOfColors[iteration - 1]), StrokeThickness = 15
            });
            if (iteration != TotalIteration)
            {
                DrawFractal(iteration + 1, x1, x1 + width / 3, y + LineDistance, width / 3);
                DrawFractal(iteration + 1, x2 - width / 3, x2, y + LineDistance, width / 3);
            }
        }
    }
}