   M S B A M L   `   `   `  ����E  AFilesearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Filesearch
Filesearch  5   	       Filesearch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Filesearch     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��450��6)   $	��800��69   $	��250��6E    � 	Resources 5	         wrap �� 
TargetType �� Property �� Value��%�   &	        '�� S     �� 5
   
   " �6   .�5      ��  � ��$ 0,0,0,10q�6'   6:   5      �� 5   
   " ��6   .�5      ��  � ��$
 Left=�6;   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��10��6   $
��auto �6+   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10��6   $
��auto �6+    � ColumnDefinitions 5   
   �� 5      $��10��6   $
��auto �6-   �� 5      -   5         �Name$ gdcMid��5      $��* �6-   �� 5      $��10��6   $
��auto �6-   .+�5   
   ]� -   5        $��	dpContent��5      $��1��6%   $��1��62   ��.  .+�5      A� -   5        $��ugdUserEntries��5       A� Columns$ 1��60   	 A� Rows$	 2��6<   $	��Top=�6E   .+�5      �� -   5        $��spDirectory��5      $��0,0,0,0q�60   .+�5       �� $��WrapWithOverflow=�6    $��0,0,0,10q�6@   @>Bitte wählen Sie das Verzeichnis, in dem Sie suchen möchten:5"      � 5#      -   5        $��gdDirectory��5#      $��0,0,0,10q�6.    5$      �� 5%      $
��auto �6/   �� 5&      -   5        $ gdcDirectory��5&   /   $��* �6C    5(      �� 5)      �� 5*      .+�5,      �� -   5        $��btChoseDirectory��5,   !   $��0��69   $��0��6F   $��20��6V   $��20��6a   $��0,0,5,0q�6�   6�   � 5-      -   5        $��gdResize��5-   <   $��1��6   $��0��6/   .+�5.      �� -	   5        $��tbxDirectory��5.   &   $��20��6:   $��12(�6F   $	��750��6�   $��0,0,0,0q�6�   $
��Left=�6�   ��6T   �� 
 �� ElementName$
 gdResize�� �� Path$ ActualWidth�6�   5/      �� 50      -
   5        $��tbcDirectoryError��50   $   $y�	Collapsed=�6=   $��1��6T   $��1��6a   $��WrapWithOverflow=�6q   $��0,0,0,10q�6�   
���\\��%#Der eingegebene Pfad ist ungültig.52      53      54      �� 55      -   5        $��spSearch��55      .+�56      �� $��0,0,0,10q�6    Wonach möchten Sie suchen?58      �� 59      -   5        $��	tbxFilter��59      $��20��6/   $��12(�6;   $
��Left=�6�   $	��250��6�   $��0,0,0,0q�6�   ��6I   �� $
 spSearch��$ ActualWidth�6�   �� 5:      -   5        $��tbcSearchError��5:       $y�	Collapsed=�66   $��1��6M   $��0��6Z   $��2��6j   $��WrapWithOverflow=�6~   $��0,0,0,10q�6�   
���\\��)'Das eingegebene Suchwort ist ungültig.5<      5=      5>      � 5?      $	��Top=�6   $	��780��6b   $��0,0,0,10q�6q   $
��Left=�6�   ��6(   �� $
 	dpContent��$ ActualWidth�.+�5@      �� -   5        $��btStartSearch��5@      $��25��6J   $��75��6V   $��Right=�6a   .��6}   Suchen6�   5A      �� 5B      $	��Top=�6   $��3��6-   
�������$��10q�6O   $	��760��6�   $
��Left=�6�   ��6[   �� $
 	dpContent��$ ActualWidth�6�   � 5C      -   5        $��pbSearch��5C      $	��Top=�6*    � IsIndeterminate . $y�	Collapsed=�6V   $��25��6m   $	��780��6y   $
��Left=�6�   $��0,0,0,20q�6�   ��6�   �� $
 	dpContent��$ ActualWidth�6�   5F      ]� 5G   
   -   5        $��
dpFindings��5G      $	��Top=�6&   $��2��6;   $��1��6H   ��. .+�5H      �� -   5        $��
lvFindings��5H      $	��780��6)   $
��Left=�68   ��6S   �� $
 
dpFindings��$ ActualWidth���6�   �� $
 
dpFindings��$ ActualHeight� �� View 5I      �� 5J      -   5        gvcFoundPaths��.P�5K      �� $
��Pfad��6)    �� DisplayMemberBinding 67   �� $
 Path� �� Width 6b   �� $
 
lvFindings��$ ActualWidth�5L      5N      5O      5P      5Q      