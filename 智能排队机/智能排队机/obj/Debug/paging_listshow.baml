   M S B A M L   `   `   `  ����J  F智能排队机, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:智能排队机智能排队机  5   	   %    智能排队机.paging_listshow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:智能排队机     5   	     � Title$  paging_listshow��5   	   $	��450��6!   $	��800��6.   .��5	      � -   5        .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $	��264��6@   $��
114,30,0,0q�6M   $	��Top=�6a   $	��542��6y   �� 5   
   -   5         ��Name$ label1��5      $��当前页：��6    $
��Left=�6/   $��
42,332,0,0q�6J   $	��Top=�6^   �� 5   
   -   5        $ LblCurrentPage��5      $��Label��6(   $
��Left=�68   $��100,332,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ label3��5      $��共计条数：��6    $
��Left=�60   $��179,332,0,0q�6K   $	��Top=�6`   �� 5   
   -   5        $ LblTotalPage��5      $��Label��6&   $
��Left=�66   $��254,333,0,0q�6Q   $	��Top=�6f   �� 5   
   -   5         ��Name$ FirstPagBtn��5      $��首页��6&   $
��Left=�63   $��324,336,0,0q�6N   $	��Top=�6c   $��75��6{    J� RenderTransformOrigin$ 0.371,0.587&�6�   6�   �� 5   
   -   5        $ UpPagBtn��5      $��	上一页��6#   $
��Left=�61   $��439,336,0,0q�6L   $	��Top=�6a   $��75��6y   6�   �� 5   
   -	   5        $ 
NextPagBtn��5      $��	下一页��6%   $
��Left=�63   $��543,336,0,0q�6N   $	��Top=�6c   $��75��6{   6�   �� 5   
   -
   5        $ 
LastPagBtn��5      $��尾页��6%   $
��Left=�62   $��645,336,0,0q�6M   $	��Top=�6b   $��75��6z   6�   5      5      