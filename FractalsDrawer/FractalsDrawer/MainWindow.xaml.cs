using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using FractalsDrawer.FractalMethods;
using Microsoft.Win32;

namespace FractalsDrawer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Выбранная итерация фрактала.
        /// </summary>
        private int _selectedIteration = 1;

        /// <summary>
        /// Выбранный уровень зума Canvas.
        /// </summary>
        private int _selectedZoom = 1;

        /// <summary>
        /// Объект используется для изменения зума Canvas.
        /// </summary>
        private readonly ScaleTransform _myScaleTransform = new();

        /// <summary>
        /// Список всех цветов градиента, используемых при построении фрактала.
        /// </summary>
        private List<Color> _listOfColors = new();

        /// <summary>
        /// Началось ли построение фрактала.
        /// </summary>
        private bool IsDrawingStarted { get; set; }

        /// <summary>
        /// Индекс выбранного фрактала.
        /// </summary>
        private int IndexOfChosenFractal { get; set; }

        /// <summary>
        /// Отношение отрезков для "Пифагорова дерева".
        /// </summary>
        private double _linesRelation = 0.7;

        /// <summary>
        /// Угол наклона левой ветви "Пифагорова дерева".
        /// </summary>
        private int _leftBranchAngle = -50;

        /// <summary>
        /// Угол наклона правой ветви "Пифагорова дерева".
        /// </summary>
        private int _rightBranchAngle = 30;

        /// <summary>
        /// Расстояние между прямыми для "Множества Кантора".
        /// </summary>
        private int _lineDistance = 30;

        /// <summary>
        /// Таймер обновления Canvas.
        /// </summary>
        private readonly DispatcherTimer _timer = new();

        /// <summary>
        /// Конструктор класса MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.LayoutTransform = _myScaleTransform;
            _timer.Tick += Ticker;
            MinWidth = SystemParameters.PrimaryScreenWidth / 2;
            MinHeight = SystemParameters.PrimaryScreenHeight / 2;
        }

        /// <summary>
        /// Установка базовых параметров для Canvas.
        /// </summary>
        private void SetDefaultSettings()
        {
            ZoomSlider.Value = 1;
            IterationSlider.Value = 1;
            IsDrawingStarted = false;
        }

        /// <summary>
        /// Очистка Canvas и генерация цветов для фрактала.
        /// </summary>
        private void SetDefaultCanvas()
        {
            MyCanvas.Children.Clear();
            ChangeColor();
        }

        /// <summary>
        /// Событие нажатия кнопки "Построение фрактала".
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
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

        /// <summary>
        /// Очистка Canvas и вызов метода в зависимости от выбранного CheckBox.
        /// </summary>
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

        /// <summary>
        /// Метод создания объекта и вызов метода для построения "Пифагорова дерева".
        /// </summary>
        private void GetPythagorasTree()
        {
            PythagorasTree myPythagorasTree = new PythagorasTree(MyCanvas, _selectedIteration, _listOfColors,
                _linesRelation, _leftBranchAngle, _rightBranchAngle);
            myPythagorasTree.CreateFractal();
        }

        /// <summary>
        /// Метод создания объекта и вызов метода для построения "Кривой Коха".
        /// </summary>
        private void GetKochSnowFlake()
        {
            KochCurve myKochCurve = new KochCurve(MyCanvas, _selectedIteration, _listOfColors);
            myKochCurve.CreateFractal();
        }

        /// <summary>
        /// Метод создания объекта и вызов метода для построения "Множества Кантора".
        /// </summary>
        private void GetCantorSet()
        {
            CantorSet myCantorSet = new(MyCanvas, _selectedIteration, _listOfColors, _lineDistance);
            myCantorSet.CreateFractal();
        }

        /// <summary>
        /// Метод создания объекта и вызов метода для построения "Треугольника Серпинского".
        /// </summary>
        private void GetSierpinskiTriangle()
        {
            SierpinskiTriangle mySierpinskiTriangle = new(MyCanvas, _selectedIteration, _listOfColors);
            mySierpinskiTriangle.CreateFractal();
        }

        /// <summary>
        /// Метод создания объекта и вызов метода для построения "Ковра Серпинского".
        /// </summary>
        private void GetSierpinskiCarpet()
        {
            SierpinskiCarpet mySierpinskiCarpet = new SierpinskiCarpet(MyCanvas, _selectedIteration, _listOfColors);
            mySierpinskiCarpet.CreateFractal();
        }

        /// <summary>
        /// Выбран CheckBox ""
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void OptionPythagorasTree_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 1;
            IterationSlider.Maximum = 12;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        /// <summary>
        /// Выбран CheckBox ""
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void OptionKochSnowFlake_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 2;
            IterationSlider.Maximum = 5;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        /// <summary>
        /// Выбран CheckBox "Треугольник Серпинского".
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void OptionSierpinskiTriangle_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 3;
            IterationSlider.Maximum = 8;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        /// <summary>
        /// Выбран CheckBox "Ковер Серпинского"
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void OptionSierpinskiCarpet_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 4;
            IterationSlider.Maximum = 6;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        /// <summary>
        /// Выбран CheckBox "Множество Кантора".
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void OptionCantorSet_OnChecked(object sender, RoutedEventArgs e)
        {
            IndexOfChosenFractal = 5;
            IterationSlider.Maximum = 6;
            SetDefaultSettings();
            SetDefaultCanvas();
        }

        /// <summary>
        /// Событие изменения значения IterationSlider.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void IterationSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _selectedIteration = (int)IterationSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        /// <summary>
        /// Событие изменения значения ZoomSlider.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void ZoomSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _selectedZoom = (int)ZoomSlider.Value;
            _myScaleTransform.ScaleX = _selectedZoom;
            _myScaleTransform.ScaleY = _selectedZoom;
        }

        /// <summary>
        /// Событие изменения значения LinesRelationSlider.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void LinesRelationSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _linesRelation = LinesRelationSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        /// <summary>
        /// Событие изменения значения LeftBranchAngleSlider.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void LeftBranchAngleSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _leftBranchAngle = (int)LeftBranchAngleSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        /// <summary>
        /// Событие изменения значения RightBranchAngleSlider.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void RightBranchAngleSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _rightBranchAngle = (int)RightBranchAngleSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        /// <summary>
        /// Событие изменения значения DistanceSlider.
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void DistanceSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _lineDistance = (int)DistanceSlider.Value;
            if (IsDrawingStarted)
            {
                SetDefaultCanvas();
                GetFractal();
            }
        }

        /// <summary>
        /// Событие нажатия кнопки "SaveImageButton".
        /// </summary>
        /// <param name="sender">Издатель</param>
        /// <param name="e">Информация о событии</param>
        private void SaveImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog mySaveFileDialog = new();
                mySaveFileDialog.Filter = "Image|*.PNG";
                if (mySaveFileDialog.ShowDialog() == true)
                {
                    RenderTargetBitmap bmp = new RenderTargetBitmap((int) MyCanvas.ActualWidth,
                        (int) MyCanvas.ActualHeight,
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
            catch(Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении файла: {ex.Message}");
            }
        }

        /// <summary>
        /// Генерация списка цветов для градиента.
        /// </summary>
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
                listOfColors.Add(Color.FromRgb((byte)rAverage, (byte)gAverage, (byte)bAverage));
            }

            _listOfColors = listOfColors;
        }
    }
}