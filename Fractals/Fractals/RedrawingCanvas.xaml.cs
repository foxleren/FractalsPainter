using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fractals
{
    partial class MainWindow
    {
        private double ScrollViewerWidth { get; set; }
        
        private double ScrollViewerHeight { get; set; }
        
        private int _timerCounter = 3;

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetTimerForReloading();
        }

        private void SetTimerForReloading()
        {
            if (IsDrawingStarted)
            {
                _timer.Interval = new TimeSpan(0, 0, 1);
                _timer.Start();
            }
        }

        private void Ticker(object? sender, EventArgs eventArgs)
        {
            _timerCounter--;
            switch (_timerCounter)
            {
                case 2:
                    LoadingTextBlock.Visibility = Visibility.Visible;
                    ProgressBar.Visibility = Visibility.Visible;
                    LoadingTextBlock.Text = "Изображение будет обновлено через: " + _timerCounter;
                    break;
                case 1:
                    AdoptCanvas();
                    LoadingTextBlock.Text = "Изображение будет обновлено через: " + _timerCounter;
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