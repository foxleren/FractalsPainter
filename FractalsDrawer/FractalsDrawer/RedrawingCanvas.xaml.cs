using System;
using System.Windows;

namespace FractalsDrawer
{
    partial class MainWindow
    {
        /// <summary>
        /// Актуальная ширина блока ScrollViewer.
        /// </summary>
        private double ScrollViewerWidth { get; set; }

        /// <summary>
        /// Актуальная высота блока ScrollViewer.
        /// </summary>
        private double ScrollViewerHeight { get; set; }

        /// <summary>
        /// Счетчик кол-ва секунд до обновления Canvas.
        /// </summary>
        private int _timerCounter = 3;

        /// <summary>
        /// Событие изменения размера экрана.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetTimerForReloading();
        }

        /// <summary>
        /// Запуск таймера перед обновлением Canvas.
        /// </summary>
        private void SetTimerForReloading()
        {
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }

        /// <summary>
        /// Событие тика каждую секунду.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="eventArgs">Информация о событии</param>
        private void Ticker(object? sender, EventArgs eventArgs)
        {
            _timerCounter--;
            switch (_timerCounter)
            {
                case 2:
                    LoadingTextBlock.Visibility = Visibility.Visible;
                    ProgressBar.Visibility = Visibility.Visible;
                    LoadingTextBlock.Text = "Canvas будет обновлен через: " + _timerCounter;
                    break;
                case 1:
                    AdoptCanvas();
                    LoadingTextBlock.Text = "Canvas будет обновлен через: " + _timerCounter;
                    break;
                case 0:
                    GetFractal();
                    _timerCounter = 3;
                    LoadingTextBlock.Visibility = Visibility.Hidden;
                    ProgressBar.Visibility = Visibility.Hidden;
                    _timer.Stop();
                    break;
            }
        }

        /// <summary>
        /// Метод перерисовки Canvas.
        /// </summary>
        private void AdoptCanvas()
        {
            ScrollViewerWidth = ActualWidth;
            ScrollViewerHeight = ActualHeight;
            double actualScrollViewerWidth = CanvasScrollViewer.ActualWidth;
            double actualScrollViewerHeight = CanvasScrollViewer.ActualHeight;

            if (Math.Abs(actualScrollViewerWidth - ScrollViewerWidth) > double.Epsilon ||
                Math.Abs(actualScrollViewerHeight - ScrollViewerHeight) > double.Epsilon)
            {
                MyCanvas.Children.Clear();
                double minSize = Math.Min(actualScrollViewerWidth, actualScrollViewerHeight);
                MyCanvas.Width = minSize - 30;
                MyCanvas.Height = minSize - 30;
            }
        }
    }
}