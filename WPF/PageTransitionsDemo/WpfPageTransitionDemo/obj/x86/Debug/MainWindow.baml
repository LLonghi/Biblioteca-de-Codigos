   M S B A M L   `   `   `  ����M  IWpfPageTransitions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitionsWpfPageTransitions  5       WpfPageTransitionDemo&    WpfPageTransitionDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   XpageTransitions<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitions     5      @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      � ���	#FF474747 � RowDefinitions 5	   
   �� 5
      �� 5      $��23 �6   .+�5   
   '   !WpfPageTransitions.PageTransition  -   5          Name$ pageTransitionControl��5   )   $��0,50,0,0q�6H      TransitionType$ SlideAndFade=�6Z   ���	#FF535353 J� OpacityMask
 �   �6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $y�Hidden=�6W   $	��370��6k   .+�5      �� -   5         ��Name$ cmbTransitionTypes��5      $��5q�63   $	��200��6>   6J   �� 5      -   5         ��Name$ btnNextPage��5       $��5q�6   $��	Next Page��65   $	��150��6c   5      �� 5   
   -   5        $ button��5      $
��Home��6!   $
��Left=�60   $	��Top=�6K   $��66��6c   $��50��6n    � Cursor$
 None��6z   $��0q�6�   ���	#FF474747
���������6�   Z� 6�   �� 5   
   -   5        $ button_Copy��5      $��Cadastro��6&   $
��Left=�69   $	��Top=�6T   $	��109��6l   $��50��6x   $
 None��6�   $��0q�6�   ���	#FF474747$��66,0,0,0q�6�   
���������6�   Z� 6   �� 5   
   -   5        $ button_Copy1��5      $��Paginas aleatorias��6'   $
��Left=�6D   $	��Top=�6_   $	��111��6w   $��50��6�   $
 None��6�   $��0q�6�   ���	#FF474747$��	175,0,0,0q�6�   
���������6�   Z� 6  5      5      