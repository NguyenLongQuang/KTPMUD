   M S B A M L   `   `   `  ����A  =KTPMUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KTPMUDKTPMUD  5   	       KTPMUD.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:KTPMUD     5   	     � Title$  Quan ly lien he��5   	   $	��450��6!   $	��800��6.    � 	Resources 5	       �� 
TargetType �� Property �� Value��%U   '��       �� 5
   
   " ��6   .�5      ��  � �� �#f806+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   � -   5         �Name$ Banner��5      ���#60f � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ MainCaption��5      $��Center=�5      ���#fff$
��Bold"�5      .��6&   	CAPTION6/   �� 5      -   5        	 ��Name$	 MainActions��5      $��1��5      
 �� Orientation$
 
Horizontal=�5       $��Right=�5!      $��Center=�5"      $��5q�5#      .+�5&      �� -   5         ��Name$ Contact��5&      $��2q�6*   $
��10 5q�65   .��6D   LienHe6L   �� 5'      -   5        $ Group��5'      $��2q�6(   $
��10 5q�63   .��6B   Nhom6H   5(      5)      �� 5*   
   -   5         ��Name$ MainContent��5*      $��1��6&   5,      5-      5.      