using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FractalsDrawer.FractalMethods
{
     /// <summary>
     /// Класс фрактала "Пифагорова дерева".
     /// </summary>
    internal class PythagorasTree : BasicFractal
    {
        /// <summary>
        /// Отношение отрезков.
        /// </summary>
        private double LineRelation { get; set; }
        
        /// <summary>
        /// Угол поворота левой ветви.
        /// </summary>
        private int LeftBranchAngle { get; set; }
        
        /// <summary>
        /// Угол поворота правой ветви.
        /// </summary>
        private int RightBranchAngle { get; set; }
        
        /// <summary>
        /// Констуктор.
        /// </summary>
        /// <param name="myCanvas">Объект Canvas</param>
        /// <param name="iteration">Выбранная итерация</param>
        /// <param name="listOfColors">Список цветов для градиента</param>
        /// <param name="lineRelation">Отношение отрезков</param>
        /// <param name="leftBranchAngle">Угол поворота левой ветви</param>
        /// <param name="rightBranchAngle">Угол поворота правой ветви</param>
        public PythagorasTree(Canvas myCanvas, int iteration, List<Color> listOfColors, double lineRelation, int leftBranchAngle, int rightBranchAngle) : base(myCanvas, iteration,
            listOfColors)
        {
            LineRelation = lineRelation;
            LeftBranchAngle = leftBranchAngle;
            RightBranchAngle = rightBranchAngle;
        }
        
        /// <summary>
        /// Метод для начала отрисовки элементов фрактала.
        /// </summary>
        public override void CreateFractal()
        {
            DrawFractal(1, 100, WidthOfCanvas / 2, HeightOfCanvas / 5, 0);
        }

        /// <summary>
        /// Метод отрисовки элементов фрактала.
        /// </summary>
        /// <param name="iteration">Текущая итерация</param>
        /// <param name="length">Длина отрезка</param>
        /// <param name="x1">Начальная координата по x</param>
        /// <param name="y1">Начальная координата по y</param>
        /// <param name="angle">Угол поворота</param>
        private void DrawFractal(int iteration, double length, double x1, double y1, double angle)
        {
            length *= LineRelation/10;
            double x2 = x1 + length * Math.Sin(angle / 360 * Math.PI * 2);
            double y2 = y1 + length * Math.Cos(angle / 360 * Math.PI * 2);

            MyCanvas.Children.Add(new Line()
            {
                X1 = x1, Y1 = HeightOfCanvas - y1, X2 = x2, Y2 = HeightOfCanvas - y2,
                Stroke = new SolidColorBrush(ListOfColors[iteration - 1]), StrokeThickness = 2
            });

            if (iteration != TotalIteration)
            {
                DrawFractal(iteration + 1, length, x2, y2, angle + RightBranchAngle);
                DrawFractal(iteration + 1, length, x2, y2, angle + LeftBranchAngle);
            }
        }
    }
}