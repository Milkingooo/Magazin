   M S B A M L   `   `   `  ����B  >Magazin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Magazin.View.WindowsMagazin.View.Windows  5   	   )    #Magazin.View.Windows.UserInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Magazin.View.Windows     5   	   -   5          � Title$2  ,Информация о покупателе��5   	   $	��400��6)   $	��600��66    � WindowStartupLocation$ CenterScreen=�6B   .��5	      � 
����+�� � RowDefinitions 5
   
   �� 5      $��60 �6   �� 5      .+�5   
   �� -   5         ��Name$ curuser��5      $	��450��6!   $
��Left=�6-   $��20(�6H   $��Calibry)�6V   �� 5   
   -   5         ��Name$ delbut��5      $-��'Удалить пользователя��6!   $	��150��6@   $��Right=�6L   6h   �� 5   
   -   5         ��Name$ lv��5       $��1��6   
������ 6,   5      5      