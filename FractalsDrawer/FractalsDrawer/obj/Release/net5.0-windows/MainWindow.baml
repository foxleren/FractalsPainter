   M S B A M L   `   `   `  ����   FractalsDrawer    Fractals.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  Fractals��   MaterialDesignBody#���     MaterialDesignPaper#���  $��Medium"�$��14(�*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�
���   � � WindowStartupLocation$ CenterScreen=���:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��� ���#0d324d � ColumnDefinitions �� $
��0.3* �$	��230��$	��230���� $
��0.7* �.+��� $��0��$��Visible=�$��Disabled=�.���� $��0�����#0d324d$	��215��.+��� $%��Выберите фрактал�����#fff$��5 10 5 0q�$
��Bold"��� $��5 5 5 0q�.+�	� -   $'��!Обдуваемое дерево�����#fff	� -   $��Кривая Коха�����#fff	� -   $'��!Ковер Серпинского�����#fff	� -   $3��-Треугольник Серпинского�����#fff	� -   $'��!Множество Кантора�����#fff�� $��Итерация�����#fff$��5 5 5 5q�$
��Bold"��� -    ��Name$ IterationSlider��$	��200��$��5 12 5 0q�$
��Left=� � Maximum$ 10Q� � Minimum$ 1Q� � Value$ 3Q� �� IsSnapToTickEnabled$
 True��	 �� TickFrequency$	 1Q�
 �� AutoToolTipPlacement$
 TopLeft=��� $��	0  10 0 0q�.+��� -     MaterialDesignRaisedButton#��[ $	��180��$��5 10 5 0q�+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��$��Center=�{���  �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.���� $'��!Построить фрактал���� $��Градиент�����#fff$��5 10 5 0q�$
��Bold"��� $)��#Начальное значение��$��5 5 5 0q����#fff$��10(�$��SemiBold"�*  $MaterialDesignThemes.Wpf.ColorPicker  -	     Name$ StartingColorSlider��$	��200��$��0 0 5 0q�$
��Left=�   Color$	 Red���� $'��!Конечное значение��$��5 5 5 0q����#fff$��10(�$��SemiBold"�  -
   $ EndingColorSlider��$	��200��$��0 0 5 0q�$
��Left=�$
 Blue���� $��Приближение��$��5 0 5 0q����#fff$��10(�$��SemiBold"��� -   $ 
ZoomSlider��$	��200��$��5 12 5 0q�$
��Left=�$ 1Q�$ 5Q�$ 1Q�$
 True��$	 1Q�$
 TopLeft=��� $)��#Отношение отрезков��$��5 15 5 0q����#fff$��10(�$��SemiBold"��� -   $ LinesRelationSlider��$	��200��$��5 12 5 0q�$
��Left=�$ 4Q�$	 7.5Q�$ 7Q�$
 True��$		 0.5Q�$
 TopLeft=��� $$��Угол левой ветви��$��5 15 5 0q����#fff$��10(�$��SemiBold"��� -   $ LeftBranchAngleSlider��$	��200��$��5 12 5 0q�$
��Left=�$	 -90Q�$ 90Q�$	 -50Q�$
 True��$	 10Q�$
 TopLeft=��� $&�� Угол правой ветви��$��5 15 5 0q����#fff$��10(�$��SemiBold"��� -   $ RightBranchAngleSlider��$	��200��$��5 12 5 0q�$
��Left=�$	 -90Q�$ 90Q�$ 30Q�$
 True��$	 10Q�$
 TopLeft=��� $:��4Расстояние между итерациями��$��5 15 5 0q����#fff$��10(�$��SemiBold"��� -   $ DistanceSlider��$	��200��$��5 12 5 0q�$
��Left=�$ 20Q�$ 50Q�$ 30Q�$
 True��$	 10Q�$
 TopLeft=��� -    ��Name$ SaveImageButton��#��[ $ 10��$��60��$��Center=�$��
 5 20 5 10q� � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��{���  �� *FindAncestor+
 Window.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ FileDownloadOutline=��� $��1�����#0a283e$��3q�._��  � RowDefinitions �� $
��0.9* ��� $
��0.1* ��� $
��0.1* �.+��� -    ��Name$ CanvasScrollViewer��$��0��$��Visible=�$��Visible=�.���� -    ��Name$ MyCanvas��$��Center=�$��Center=�$	��475��$	��475��$
}�True��� -    �Name$ ProgressBar��$��1�� � IsIndeterminate$
 True��$y�Hidden=�$��0 5 0 5q��� -    ��Name$ LoadingTextBlock��$��2��$N��HИзображение будет перерисовано через: 3��$��Center=����#fff$��15(�$
��Bold"�$y�Hidden=�