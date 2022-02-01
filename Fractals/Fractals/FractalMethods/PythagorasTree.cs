using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Fractals
{
    internal class PythagorasTree : BasicFractal
    {
        private double LineRelation { get; set; }
        private int LeftBranchAngle { get; set; }
        private int RightBranchAngle { get; set; }
        public PythagorasTree(Canvas myCanvas, int iteration, List<Color> listOfColors, double lineRelation, int leftBranchAngle, int rightBranchAngle) : base(myCanvas, iteration,
            listOfColors)
        {
            LineRelation = lineRelation;
            LeftBranchAngle = leftBranchAngle;
            RightBranchAngle = rightBranchAngle;
        }
        
        public override void CreateFractal()
        {
            DrawFractal(1, 100, WidthOfCanvas / 2, HeightOfCanvas / 5, 0);
        }

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