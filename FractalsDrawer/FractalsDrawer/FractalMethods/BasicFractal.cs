using System.Collections.Generic;
using System.Windows.Controls;
using Color = System.Windows.Media.Color;

namespace FractalsDrawer.FractalMethods
{
    abstract class BasicFractal
    {
        /// <summary>
        /// Поле объекта Canvas.
        /// </summary>
        private protected Canvas MyCanvas { get; set; }

        /// <summary>
        /// Выбранное значение итерации.
        /// </summary>
        private protected int TotalIteration { get; set; }

        /// <summary>
        /// Список цветов для градиента.
        /// </summary>
        private protected List<Color> ListOfColors { get; set; }

        /// <summary>
        /// Ширина Canvas.
        /// </summary>
        private protected double WidthOfCanvas { get; set; }

        /// <summary>
        /// Высота Canvas.
        /// </summary>
        private protected double HeightOfCanvas { get; set; }

        /// <summary>
        /// Конструктор базового класса BasicFractal.
        /// </summary>
        /// <param name="myCanvas">Объект Canvas</param>
        /// <param name="iteration">Выбранная итерация</param>
        /// <param name="listOfColors">Список цветов для градиента</param>
        protected BasicFractal(Canvas myCanvas, int iteration, List<Color> listOfColors)
        {
            MyCanvas = myCanvas;
            TotalIteration = iteration;
            ListOfColors = listOfColors;
            WidthOfCanvas = myCanvas.ActualWidth;
            HeightOfCanvas = myCanvas.ActualHeight;
        }

        /// <summary>
        /// Метод для начала отрисовки элементов фрактала.
        /// </summary>
        public abstract void CreateFractal();
    }
}