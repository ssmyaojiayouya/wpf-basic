   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   m iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting 5	   	   J F智能排队机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:智能排队机智能排队机 5   	      智能排队机.menu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   }Chrmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5	   	   /localclr-namespace:智能排队机     5   	     � Title$  排队机系统��5   	   $	��450��6   $	��800��6$   .��5      � -   5        $��0,0,125.6,-3q�5       J� RenderTransformOrigin$ 0.521,0.618&�6!    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      .+�5   
   �� -   5         ��Name$ label��5      $��2��6   $��基本功能��63   $
��Left=�6B   $��	32,22,0,0q�6]   $	��Top=�6p   �� 5   
   -   5         ��Name$ button��5      $��2��6!   $��开始取号��65   $
��Left=�6D   $��	32,53,0,0q�6_   $	��Top=�6r   $	��216��6�   6�   �� 5   
   -   5        $ button1��5      $��2��6"   $��暂停取号��66   $
��Left=�6E   $��
248,53,0,0q�6`   $	��Top=�6t   $	��191��6�   6�   �� 5   
   -   5        $ button2��5      $��2��6"   $��叫号��66   $
��Left=�6C   $��
439,53,0,0q�6^   $	��Top=�6r   $	��191��6�   6�   �� 5   
   -   5        $ label1��5      $��2��6    $��消息功能��64   $
��Left=�6C   $��
32,103,0,0q�6^   $	��Top=�6r   �� 5   
   -   5         ��Name$ textBox��5      $��2��6#   $
��Left=�67   $��36��6R   $��
32,134,0,0q�6^    �� TextWrapping$
 Wrap=�6r   $9��3例：当前办理人数过多，请耐心等待...��6�   $	��Top=�6�   $	��460��6�   �� 5   
   -   5        $ button3��5      $��2��6"   $��发送消息��66   $
��Left=�6E   $��497,134,0,0q�6`   $	��Top=�6u   $	��133��6�   $��36��6�   6�   �� 5   
   -	   5        $ label2��5      $��2��6    $��排队情况��64   $
��Left=�6C   $��
32,180,0,0q�6^   $	��Top=�6r   �� 5   
   -
   5        $ button4��5      $��2��6"   $��导出图表数据��66   $
��Left=�6G   $��555,197,0,0q�6b   $	��Top=�6w   $��75��6�   6�   �� 5   
   -   5        $ button5��5      $��2��6"   $��导入图表数据��66   $
��Left=�6G   $��555,220,0,0q�6b   $	��Top=�6w   $��75��6�   6�   �� 5   
   -   5        $ label3��5      $��2��6    $��当前正在排队��64   $
��Left=�6E   $��520,262,0,0q�6`   $	��Top=�6u   $ 1.692,1.223&�6�   $��Arial Black)�6�   $��20(�6�   �� 5   
   -   5        $ textBox1��5      $��2��6$   $
��Left=�68   $��31��6S   $��538,306,0,0q�6_   $
 Wrap=�6t   $��例：5��6�   $	��Top=�6�   $��68��6�   $��20(�6�   �� 5   
   -   5        $ label4��5      $��2��6    $	��人��64   $
��Left=�6@   $��611,302,0,0q�6[   $	��Top=�6p   $��20(�6�   7   1System.Windows.Forms.Integration.WindowsFormsHost  5!   
   -   5          Name$ WFHost_HistoryFlow��5!      $
��Left=�67   $��
32,206,0,0q�6R   $	��Top=�6f   $��2��6~   $	��207��6�   $	��445��6�      Child. 5"      ;  5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        
chart1��	   	BackColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$	 
WhiteSmoke 5"   Z   6q   5#      �� 5$   
   -   5        $ button6��5$      $��2��6"   $��返回菜单��66   $
��Left=�6E   $��699,34,-106,0q�6`   $	��Top=�6w   $��75��6�   6�   5'      5(      