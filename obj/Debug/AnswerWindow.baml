   M S B A M L   `   `   `  ����E  ASharpTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SharpTests
SharpTests  5   	       SharpTests.AnswerWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SharpTests     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ AnswerWindow��5
   	   $	��250��6   $	��600��6+   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��0.3* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0.25* �6   .+�5   
   �� -   5         ��Name$ answerTextBox��5      $��80��6)   $��18(�65   $��15q�6C    �� TextWrapping$
 Wrap=�5       !  MaterialDesignOutlinedTextBox#��[  5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Ответ��5      �� 5   
   $��Правильный��6   $��1��6&   $��Center=�66   $
��0 45q�5      $��16(�6"   �� 5   
   -   5         ��Name$ answerCheckBox��5      $��1��6+   $��Center=�6;   $��Center=�5      �� 5    
   -   5         ��Name$ answerButton��5       $��1��6'   $��2��64   $	��150��5!      $��OK��6    5#      5$      