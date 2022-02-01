using System.Collections.Generic;
using System.Windows.Controls;
using Color = System.Windows.Media.Color;

namespace Fractals
{
    abstract class BasicFractal
    {
        private protected Canvas MyCanvas { get; set; }
        private protected int TotalIteration { get; set; }
        private protected List<Color> ListOfColors { get; set; }
        private protected double WidthOfCanvas { get; set; }
        private protected double HeightOfCanvas { get; set; }
 
        protected BasicFractal(Canvas myCanvas, int iteration, List<Color> listOfColors)
        {
            MyCanvas = myCanvas;
            TotalIteration = iteration;
            ListOfColors = listOfColors;
            WidthOfCanvas = myCanvas.ActualWidth;
            HeightOfCanvas = myCanvas.ActualHeight;
        }

        public abstract void CreateFractal();

    }
}
