   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   G CProductStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProductStoreProductStore 5   	   C&clr-namespace:ProductStore.CommonClassProductStore.CommonClass 5   	   ?$clr-namespace:ProductStore.ConverterProductStore.Converter 5	   	      ProductStore.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ProductStore     5   	   9common&clr-namespace:ProductStore.CommonClass     5   	   :	converter$clr-namespace:ProductStore.Converter     5	   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5         trueFalseEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� Type,  &ProductStore.CommonClass.TrueFalseEnum/  )ProductStore.Converter.TrueFalseConverter  trueFalseConverter��%�   &	        &	 [     S� 5   
   $ 	GetValues��63   "  6J    5      M� 5      "  6   5        5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��0��6   .��5      � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5       .+�5"      �� $��0��6   $��0��6-   $��2��6:    �� Orientation$ 
Horizontal=�6N   .+�5#      �� $��
Product Id��6   $��20(�61   �� 5$      	 � ToolTip$	 
Product Id��6   $��30(�64   $	��150��6�   ��6B   �� *	ProductID+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5%      �� 5&      $��0��6   $��2��6&   $
��Save��6V   ��66   �� *SaveCommand+6V   �� 5'      $��0��6   $��3��6&   $��Search��6]   ��66   �� *ShowProductCommand+6]   5(      5)      &   System.Windows.Controls.DataGrid  5*   
   -   5        $��dg��5*      
��� ���$��5q�62   $��1��6F   $��0��6S      AutoGenerateColumns . ��6c   �� *ProductCollection+$
 TwoWay=�$ PropertyChanged=� �� SelectedItem 5+      �� *SelectedProduct+52      53      54      