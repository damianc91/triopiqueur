   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5
   	       WpfApp1.MainWindow   5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962af bMaterialDesignThemes.MahApps, Version=0.1.5.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   'localclr-namespace:WpfApp1     5
   	   -   5           MaterialDesignBody#���   5   
   $��Regular"�5   
   #��� ��5   
     � WindowStyle$
  None=�5   	    � WindowState$ 	Maximized=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��11* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5       $��3* �6   �� 5!      $��3* �6   �� 5"      $��3* �6   .+�5*   
   �� $��1��6   $��2��6$   $��
User Login��61   
������� �� TextAlignment$ Center=�6V   $��38(�6m   $��Great Vibes)�6{   $��Center=�6�   $��Center=�6�   5+      �� 5-   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��3��6>   $��Center=�6K   .+�5.      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6&   $��50��62   $��50��6=   
�������$��Center=�6\   $��Center=�6w   �� 5/      -   5         ��Name$ txtUsername��5/      $
��10 0q�6+   $��50��69   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Team's name��6E   
�������$	��150��6�   
�������	 �� 
CaretBrush	 �	#FFD94448
 �� SelectionBrush
 �	#FFD94448$��Center=�6�   $��20(�6�   50      �� 52   
   $ 
Horizontal=�6   $��1��6.   $��4��6>   $��Center=�6K   .+�53        $
 Lock=�6&   $��50��62   $��50��6=   
�������$��Center=�6\   $��Center=�6w   G� 54      -   5         G�Name$ txtPassword��54      $
��10 0q�6/   
�������$	��150��6Q   $��50��6]   
������� G� 
CaretBrush �	#FFD94448 G� SelectionBrush �	#FFD94448$��Center=�6�   $��20(�6�   55      �� 57   
   $��10q�6   $��Center=�6!   $��1��6>   $��5��6N   .+�58      �� -   5         ��Name$ btnLogin��59   M   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��58      $��2q�6C   ���#D94448���#28FC8B
������� � ToolTip$ Login��59   =   $	��140��6v   $��70��6�   .��5:        $	 Key=�6*   
���   �$��45��6H   $��45��6S   $��Center=�6_   $��Center=�6z   5;      5<      �� 5>   
   -   5        $ btnMinimize��5>   T   $��2��6'   $��0��67   $ Close��6D   
�������$	��Top=�6�   ��6   Z� .��5?        $ WindowMinimize=�6&   
�������$
��Auto��6O   $
��Auto��6\   5@      �� 5C   
   -   5        $ 
btnRestore��5C   T   $��3��6'   $��0��67   $ Close��6D   
�������$	��Top=�6�   ��6   Z� .��5D        $ WindowRestore=�6&   
�������$
��Auto��6N   $
��Auto��6[   5E      �� 5G   
   -   5        $ btnExit��5G   d    �� IsCancel . $��4��67   $��0��6G   $ Close��6T   
�������$	��Top=�6�   ��6   Z� .��5H        $ Power=�6&   
�������$
��Auto��6F   $
��Auto��6S   5I      5J      5K      