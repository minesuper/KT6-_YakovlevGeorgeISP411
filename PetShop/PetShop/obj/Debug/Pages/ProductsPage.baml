   M S B A M L   `   `   `  ����B  >PetShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PetShop.PagesPetShop.Pages  5           PetShop.Pages.ProductsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PetShop.Pages     5        N� Title$  ProductsPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      6   �� 5      $��60 �6   6*   .+�5   
   �� $��0��6   $��Right=�6"   $��Center=�6>   $��10q�5       �� Orientation$ 
Horizontal=�6    .+�5      �� -   5         ��Name$ DisplayCountTextBlock��5   &   $��12(�6   $
��10 0q�5      6(   �� 5      -   5        $ FioTextBlock��5   &   $��12(�6   6>   5      �� 5   
   $��0��6   $
��Left=�6"   $ 
Horizontal=�6=   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��40��69   $
��10 0q�6E   5   @   	� 5      -   5         	�Name$ OrderUp��5      $!��По возрастанию��6+   $��Center=�6D   5   6   	� 5      -   5        $ 	OrderDown��5      $��По Убыванию��6-   $��Center=�6C   $
��10 0q�5   6   6F   �� 5      -   5         ��Name$ FactoryComboBox��5      $	��200��60   $��40��6<    �� DisplayMemberPath$
 Name��5   K   6f   5       �� 5!   
   -   5         ��Name$ ProductsListView��5!      $��1��6-   ��5"      �� 5#      .R�5$      � $��10q�6   $
��1100��6'   	 � ColumnDefinitions	 5%      �� 5&      $	��100 �6/   6=   �� 5'      $	��300 �6/   6=   �� 5(      $	��100 �6/   6=   �� 5)      $	��600 �6/   6=   .+�5+      �� $��0��6    ��5,      �� 5-   "   
 �� Path$
 ProductPhoto�6*    �� TargetNullValue 5.   &   �� 5/   *    �� 	UriSource$  /Resources/placeholder.png?�66   51   +   53   #   55      �� 56      $��1��6%   $ Vertical=�65   $
��Left=�6L   $��Center=�6g   $
��10 0q�57   %   .+�58      �� $
��Bold"�6J   ��6(   �� *ProductType.Name+6^   �� 59      $
��Wrap=�6L   $��40��6`   ��6(   �� *ProductDescription+6n   �� 5:      ��6(   �� *Manufacturers.Name+ �� StringFormat$% Производитель: {0}��6o   �� 5;      ��6(   �� *ProductCost+$ Цена: {0}��6_   5<      �� 5=      $��2��6$   $��Center=�64   $��Center=�6Q   �� 5>      �6"   �� *ProductQuantityInStock+$ На складе {0}��6i    �� 5?      �6"   �� *
Units.Name+6@   5@      �� 5A      $��3��6%   $ 
Horizontal=�65   $��Right=�6N   .+�5B      ��  ��Name$ 
EditButton��6%   -   5        $ ��Редактировать��5B   9   $	��200��5C   %   $��40��61   $��10q�6=   6K   �� 5D      $ RemoveButton��6%   -	   5        $��Удалить��5D   ;   $	��200��5E   %   $��40��61   6?   5F      5G      5H      ��5J      �� 5K       �� 
TargetType" ��6    �� Triggers 5L      �� 5M       �� Binding 6&   �� *ProductQuantityInStock+ �� Value 06Q   .a�5N      ��  �� Property � �� �� Value
 �����6J   5O      5Q      5S      �� 5T   
   -
   5        $ AddProductButton��5T      $��2��6+   $��Right=�68   $��Center=�5U      $��10q�6,   $	��200��68   $��40��6D   $%��Добавить продукт��5V      6M   �� 5W   
   -   5        $ 
BackButton��5W      $��2��6%   $
��Left=�62   $��Center=�5X      $��10q�6,   $	��200��68   $��40��6D   $��
Назад��5Y      6<   5Z      5[      