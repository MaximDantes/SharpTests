   M S B A M L   `   `   `  ����E  ASharpTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SharpTests
SharpTests  5   	       SharpTests.AuthWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SharpTests     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�6.    � Title$ Авторизация��5
   	   $	��450��6   $	��600��6*    � Icon$ 
spells.png��5      .��5      � .+�5   
   �� -   5         ��Name$ 
tabControl��5      $��0q�6)   .@�5      �� $y�	Collapsed=�6   .��5      �  � RowDefinitions 5      �� 5      $
��0.7* �6(   �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��Авторизация��6    $��2��63   $��20(�6G   $��Center=�5       $��Center=�6;   �� 5      -   5         ��Name$ loginTextBox��5      $��1��64   $��2��6A   $��18(�6U   $��52��6c   $	��500��6o    %  !MaterialDesignFloatingHintTextBox#��[  5       )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
логин��5!      G� 5#      -   5        	 G�Name$	 passwordTextBox��5#   "   $��2��6;   $��2��6H   $��18(�6\   $��52��6j   $	��500��6v    ) %MaterialDesignFloatingHintPasswordBox#��[ 5$   "   $ пароль��5%   "   �� 5'      -   5        
 ��Name$
 signUpButton��5'      $��3��63   $	��200��6@   $*��$Зарагистрироваться��6O   5(      �� 5*      -   5        $
 signInButton��5*      $��3��63   $��1��6@   $	��200��6P   $��
Войти��6_   5+      5,      5-      �� 5/      $y�	Collapsed=�6   .��50      �  51      �� 52      �� 53      �� 54      �� 55       57      �� 58      �� 59      .+�5<      �� -   5        $ newLoginTextBox��5<      $��2��67   $��18(�6K   $��52��6Y   $	��500��6e   #��[  5=      $ 
логин��5>      G� 5@      -   5        $	 newPasswordTextBox��5@   "   $��1��6>   $��2��6K   $��18(�6_   $��52��6m   $	��500��6y   #��[ 5A   "   $ пароль��5B   "   G� 5D      -	   5        $	 RepeatedPasswordTextBox��5D   "   $��2��6C   $��2��6P   $��18(�6d   $��52��6r   $	��500��6~   #��[ 5E   "   $% повторите пароль��5F   "   �� 5H      -
   5        $
 
backButton��5H      $��3��61   $	��200��6>   $��
Назад��6M   5I      �� 5K      -   5        $
 signUpConfirmButton��5K      $��3��6:   $��1��6G   $	��200��6W   $*��$Зарагистрироваться��5L      6:   5M      5N      5P      5Q      5R      