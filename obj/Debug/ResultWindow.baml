   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   E ASharpTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SharpTests
SharpTests 5   	      SharpTests.ResultWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   *localclr-namespace:SharpTests     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$3 -Результаты тестирования��5
   	   $	��450��6)   $	��700��66   .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
      LiveCharts.Wpf.PieChart  -   5        $��pieChart��5      &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 Left=�6'   $��2��5   .      DataTooltip 6   Z�    Series 5         LiveCharts.Wpf.PieSeries  -   5        $��correct��5          LiveCharts.Wpf.Series   Title$ Правильные��6/      Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 1 6B   	   
DataLabels	 . 
   
LabelPoint
 5       �� *
PointLabel+  5      -   5        $��semicorrect��5       $+ %Частично правильные��63   $ 1 6O   	 . 
 5       �� *
PointLabel+  5      -   5        $��	incorrect��5       $ Неправильные��61   $ 1 6F   	 . 
 5       �� *
PointLabel+5      �� 5!   
   -   5        $��confirmButton��5!      $��1��6&   $	��150��63   $��OK��6B   5"      �� 5#   
   -   5         ��Name$ timeTextBox��5#      $��1��6)   $��1��66   $
��22,2��6F   $��20(�6R   $��Center=�5$      $��Center=�6/   5%      5&      