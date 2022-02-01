using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;

namespace Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private int _selectedIteration = 1;

        private int _selectedZoom = 1;

        private readonly ScaleTransform _myScaleTransform = new();

        private List<Color> _listOfColors = new();
        private bool IsDrawingStarted { get; set; }
        private int IndexOfChosenFractal { get; set; }

        private double _linesRelation = 0.7;

        private int _leftBranchAngle = -50;

        private int _rightBranchAngle = 30;

        private readonly DispatcherTimer _timer = new();

        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.LayoutTransform = _myScaleTransform;
            _timer.Tick += Ticker;
        }

        private void SetDefaultSettings()
        {
            ZoomSlider.Value = 1;
            IterationSlider.Value = 1;
            IsDrawingStarted = false;
        }


        private void SetDefaultCanvas()
        {
            MyCanvas.Children.Clear();
            ChangeColor();
        }

        private void CreateFractalClick(object sender, RoutedEventArgs e)
        {
            if (IndexOfChosenFractal != 0)
            {
                IsDrawingStarted = true;
                GetFractal();
            }
            else
            {
                MessageBox.Show("Выберите, пожалуйста, фрактал для отрисовки.");
            }
        }


        private void GetFractal()
        {
            SetDefaultCanvas();
            switch (IndexOfChosenFractal)
            {
                case 1:
                    GetPythagorasTree();
                    break;
                case 2:
                    GetKochSnowFlake();
                    break;
                case 3:
                    GetSierpinskiTriangle();
                    break;
                case 4:
                    GetSierpinskiCarpet();
                    break;
                case 5:
                    GetCantorSet();
                    break;
            }
        }

        private void GetPythagorasTree()
        {
            PythagorasTree myPythagorasTree = new PythagorasTree(MyCanvas, _selectedIteration, _listOfColors,
                _linesRelation, _leftBranchAngle, _rightBranchAngle);
            myPythagorasTree.CreateFractal();
        }

        private void GetKochSnowFlake()
        {
            KochSnowFlake myKochSnowFlake = new KochSnowFlake(MyCanvas, _selectedIteration, _listOfColors);
            myKochSnowFlake.CreateFractal();
        }

        private void GetCantorSet()
        {
            CantorSet myCantorSet = new(MyCanvas, _selectedIteration, _listOfColors);
            myCantorSet.CreateFractal();
        }

        private void GetSierpinskiTriangle()
        {
            SierpinskiTriangle mySierpinskiTriangle = new(MyCanvas, _selectedIteration, _listOfColors);
            mySierpinskiTriangle.CreateFractal();
        }

        private void GetSierpinskiCarpet()
        {
            SierpinskiCarpet mySierpinskiCarpet = new SierpinskiCarpet(MyCanvas, _selectedIteration, _listOfColors);
            mySierpinskiCarpet.CreateFractal();
        }

        private void OptionPythagorasTree_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 1;
            IterationSlider.Maximum = 12;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        private void OptionKochSnowFlake_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 2;
            IterationSlider.Maximum = 5;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        private void OptionSierpinskiTriangle_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 3;
            IterationSlider.Maximum = 8;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        private void OptionSierpinskiCarpet_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 4;
            IterationSlider.Maximum = 6;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        private void OptionCantorSet_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 5;
            IterationSlider.Maximum = 6;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        private void IterationSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _selectedIteration = (int) IterationSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        public void ChangeColor()
        {
            int rMin = StartingColorSlider.Color.R;
            int gMin = StartingColorSlider.Color.G;
            int bMin = StartingColorSlider.Color.B;

            int rMax = EndingColorSlider.Color.R;
            int gMax = EndingColorSlider.Color.G;
            int bMax = EndingColorSlider.Color.B;

            var listOfColors = new List<Color>();
            for (int i = 0; i < _selectedIteration; i++)
            {
                var rAverage = rMin + (rMax - rMin) * i / _selectedIteration;
                var gAverage = gMin + (gMax - gMin) * i / _selectedIteration;
                var bAverage = bMin + (bMax - bMin) * i / _selectedIteration;
                listOfColors.Add(Color.FromRgb((byte) rAverage, (byte) gAverage, (byte) bAverage));
            }

            _listOfColors = listOfColors;
        }

        private void ZoomSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _selectedZoom = (int) ZoomSlider.Value;
            _myScaleTransform.ScaleX = _selectedZoom;
            _myScaleTransform.ScaleY = _selectedZoom;
        }

        private void LinesRelationSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _linesRelation = LinesRelationSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        private void LeftBranchAngleSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _leftBranchAngle = (int) LeftBranchAngleSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        private void RightBranchAngleSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _rightBranchAngle = (int) RightBranchAngleSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        private void SaveImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new();
            if (mySaveFileDialog.ShowDialog() == true)
            {
                mySaveFileDialog.DefaultExt = ".PNG";
                mySaveFileDialog.Filter = "Image (.PNG)|*.PNG";

                RenderTargetBitmap bmp = new RenderTargetBitmap((int) MyCanvas.ActualWidth, (int) MyCanvas.ActualHeight,
                    96d, 96d, PixelFormats.Pbgra32);
                MyCanvas.Measure(new Size((int) MyCanvas.ActualWidth, (int) MyCanvas.ActualHeight));
                MyCanvas.Arrange(new Rect(new Size((int) MyCanvas.ActualWidth, (int) MyCanvas.ActualHeight)));
                bmp.Render(MyCanvas);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                using (FileStream file = File.Create(mySaveFileDialog.FileName))
                {
                    encoder.Save(file);
                }
            }
        }
    }
}