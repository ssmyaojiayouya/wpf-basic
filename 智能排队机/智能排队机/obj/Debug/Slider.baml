   M S B A M L   `   `   `  ����J  F智能排队机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:智能排队机智能排队机  5   	       智能排队机.Slider   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:智能排队机     5   	     � Title$  Slider��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   �� -   5         ��Name$ slider1��5
      $
��Left=�6"   $��27��6=   $��288,262,0,0q�6I   $	��Top=�6^   $	��285��6v    � Maximum$ 50Q�6�    � LargeChange$ 5Q�6�   �� 5   
   -   5        $ slider2��5      $
��Left=�6"   $��27��6=   $��288,304,0,0q�6I   $	��Top=�6^   $	��285��6v   $ 50Q�6�   $ 5Q�6�   �� 5   
   -   5         ��Name$ label��5      $��舵机��6   $
��Left=�6,   $��
344,55,0,0q�6G   $	��Top=�6[    J� RenderTransformOrigin$ 0.595,1.078&�6s   �� 5   
   -   5        $ label1��5      $��当前水平角度：��6    $
��Left=�62   $��254,141,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ label2��5      $��当前垂直角度：��6    $
��Left=�62   $��254,191,0,0q�6M   $	��Top=�6b   �� 5   
   -   5         ��Name$ textBox1��5      $
��Left=�6$   $��23��6?   $��353,141,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   $ 
0.642,0.53&�6�   �� 5   
   -   5        $ textBox2��5      $
��Left=�6$   $��23��6?   $��353,191,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $ label3��5      $��水平��6    $
��Left=�6-   $��216,262,0,0q�6H   $	��Top=�6]   �� 5   
   -	   5        $ label4��5      $��垂直��6    $
��Left=�6-   $��216,304,0,0q�6H   $	��Top=�6]   �� 5   
   -
   5         ��Name$ button��5      $��返回菜单��6!   $
��Left=�60   $��	27,25,0,0q�6K   $	��Top=�6^   $��75��6v   6�   5      5      