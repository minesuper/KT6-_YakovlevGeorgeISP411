   M S B A M L   `   `   `  ����B  >PetShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PetShop.PagesPetShop.Pages  5          PetShop.Pages.AddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PetShop.Pages     5        N� Title$  AddEditPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      6   �� 5      $��60 �6   6*   .+�5   
   � $��0��6   $��Center=�6   $��Center=�68    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%    5      �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   .+�5      �� -   5         ��Name$ IdLabel��5   ?   $	��Id:��6   $��0��6"   $��0��6/   $��Right=�5       $��Center=�60   6M   �� 5!      $��Наименование:��6   $��1��6,   $��0��69   $��Right=�5"      $��Center=�60   6M   �� 5#      $��Категория:��6   $��2��6)   $��0��66   $��Right=�5$      $��Center=�60   6M   �� 5%      $-��'Количество на складе:��6   $��3��64   $��0��6A   $��Right=�5&      $��Center=�60   6M   �� 5'      $(��"Единица измерения:��6   $��4��61   $��0��6>   $��Right=�5(      $��Center=�60   6M   �� 5)      $��Поставщик:��6   $��5��6)   $��0��66   $��Right=�5*      $��Center=�60   6M   �� 5+      $-��'Стоимость за единицу:��6   $��1��64   $��2��6A   $��Right=�5,      $��Center=�60   6M   �� 5-      $��Описание:��6   $��2��6(   $��2��65   $��2��6E   $��Right=�5.      $��Center=�60   6M   �� 5/      $��Изображение:��6   $��4��6+   $��2��68   $��2��6H   $��Right=�50      $��Center=�60   6M   �� 52      -   5         ��Name$ 	IdTextBox��52      $��0��6)   $��1��66   $	��180��53      $��40��6"   $��Center=�6.   $
��Left=�54      $��10q�61    �� 
IsReadOnly . 6Q   �� 55      -   5        $ NameTextBox��55      $��1��6+   $��1��68   $	��180��56      $��40��6"   $��Center=�6.   $
��Left=�57      $��10q�61   6?   �� 58      -   5         ��Name$ CategoryComboBox��58      $��2��61   $��1��6>   $	��180��59      $��40��6"   $��Center=�6.   $
��Left=�5:      $
��10 0q�61    �� DisplayMemberPath$
 Name��6?   6Z   �� 5;      -   5        $ CountTextBox��5;      $��3��6,   $��1��69   $	��180��5<      $��40��6"   $��Center=�6.   $
��Left=�5=      $
��10 0q�61   6A   �� 5>      -   5        $ UnitTextBox��5>      $��4��6+   $��1��68   $	��180��5?      $��40��6"   $��Center=�6.   $
��Left=�5@      $
��10 0q�61   6A   �� 5A      -   5        $ SupplierTextBox��5A      $��5��6/   $��1��6<   $	��180��5B      $��40��6"   $��Center=�6.   $
��Left=�5C      $
��10 0q�61   6A   �� 5D      -   5        $ PriceTextBox��5D      $��1��6,   $��3��69   $	��180��5E      $��40��6"   $��Center=�6.   $
��Left=�5F      $
��10 0q�61   6A   �� 5G      -	   5        $ DescriptionTextBox��5G      $��2��62   $��3��6?   $��2��6O   $	��180��5H      $	��100��6"   $��Center=�6/   $
��Left=�5I      $
��10 0q�61    �� TextWrapping$
 Wrap=�6?   $	��Top=�5J      67   �� 5K      -
   5        	 ��Name$	 ImageElement��5M      $��4��5K      $��3��6!   $��2��61   $	��140��6B   $	��100��6N   $��Center=�5L      $��Center=�6/   $��10q�5M   *   ��5N      �� 5O      
 �� Path$
 ProductPhoto�6    �� TargetNullValue 5P      �� 5Q       �� 	UriSource$  /Resources/placeholder.png?�6*   5S      5U      5W      5X      �� 5Y   
   -   5         ��Name$ SaveChangesButton��5Y      $��1��6,   $��Right=�69   $��Center=�5Z      $��10q�6,   $	��200��68   $��40��6D   $��Сохранить��5[      6G   �� 5\   
   -   5        $ 
BackButton��5\      $��1��6%   $
��Left=�62   $��Center=�5]      $��10q�6,   $	��200��68   $��40��6D   $��
Назад��5^      6<   5_      5`      