   M S B A M L   `   `   `  ����E  ASharpTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SharpTests
SharpTests  5   	       SharpTests.TestWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SharpTests     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ 
TestWindow��5
   	   $	��600��6   $	��500��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      �� 5      $��0.25* �6   �� 5      $��0.25* �6   �� 5      $
��0.2* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0.25* �6   �� 5      $��0.25* �6   .+�5   
   �� -   5         ��Name$ titleTextBox��5      $��0��6(   $��18(�68   $��50��6F   $
��15 5q�6R    %  !MaterialDesignFloatingHintTextBox#��[  5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название��5      �� 5   
   -   5         ��Name$ levelComboBox��5      $��1��6*   $��18(�6:   $��50��6H   $
��15 5q�6T    & "MaterialDesignFloatingHintComboBox#��[ 5      $��2��6N   $ Уровень��5      .@�5       �� $��1��6   �� 5!      $��2��6   �� 5"      $��3��6   �� 5#      $��4��6   �� 5$      $��Задания��6   5%      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ questionsGrid��5'         
IsReadOnly . $��1��6<   $��2��6I   $��3��5(      	   AutoGenerateColumns	 .  
   Columns
 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ Вопросы��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Text+6O   5-      �� 5/   
   -   5         ��Name$ addQuestionButton��5/      $��2��6,   $��2��69   $��+��6I   $��60��6U   $��60��6a   $��40(�50      ��51      �� 52       �� 
TargetType" ��6"   .R�53      � .+�54      A� ���#673AB76"   �� 55      $��Center=�6+   $	��Top=�6H   56      57      59      �� 5;   
   -   5        $ deleteTestButton��5;      $��3��6+   $��2��68   $��-��6H   $��60��6T   $��60��6`   $��40(�5<      ��5=      �� 5>      " ��6"   .R�5?      � .+�5@      A� ���#673AB76"   �� 5A      $��Center=�6+   $	��Top=�6H   5B      5C      5E      �� 5G   
   -   5        $ 
testButton��5G      $��4��6%   $��3��62   $	��150��6F   $��OK��5H      5I      5J      