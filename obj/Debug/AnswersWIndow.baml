   M S B A M L   `   `   `  ����E  ASharpTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SharpTests
SharpTests  5   	       SharpTests.AnswersWIndow   5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SharpTests     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ AnswersWIndow��5
   	   $	��450��6   $	��800��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��0.15* �6   .+�5   
   �� -   5        $��questionTextBox��5      $��80��6)   $��18(�65   $��10q�6C    �� TextWrapping$
 Wrap=�5      $��2��6&    !  MaterialDesignOutlinedTextBox#��[  5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Вопрос��5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��answersGrid��5      $��1��6&      AutoGenerateColumns .     
IsReadOnly . $��3��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Ответ��6=   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 1* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Key+6L   4  .System.Windows.Controls.DataGridCheckBoxColumn  5!      $	 Правильный��5"   )    5!   )   �� *Value+ �� Mode$ OneWay=�5"   )   5$      �� 5&   
   -   5         ��Name$ addAnswertButton��5&      $��2��6+   $��1��68   $��+��6H   $��60��6T   $��60��6`   $��40(�5'      ��5(      �� 5)       �� 
TargetType" ��6"   .R�5*      � .+�5+      A� ���#673AB76"   �� 5,      $��Center=�6+   $	��Top=�6H   5-      5.      50      �� 52   
   -   5        $ deleteAnswerButton��52      $��3��6-   $��1��6:   $��-��6J   $��60��6V   $��60��6b   $��40(�53      ��54      �� 55      " ��6"   .R�56      � .+�57      A� ���#673AB76"   �� 58      $��Center=�6+   $	��Top=�6H   59      5:      5<      �� 5>   
   -   5        $ answersButton��5>      $��4��6(   $��2��65   $	��150��6I   $��OK��6U   5?      5@      