   M S B A M L   `   `   `  ����O  KMarketDataDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MarketDataDownloader.HelperMarketDataDownloader.Helper  5   	   .    (MarketDataDownloader.StockDataMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <helper)clr-namespace:MarketDataDownloader.Helper     5   	      OrangeBrush#��[  5   	     � Title$  Symbol Data��5   	   $	��313��6   $	��200��6*    � Icon$ StockInfo.ico��66    � DataContext 5   	   �� *Main+  Locator �� Source# [  � 	Resources 5      7   1MarketDataDownloader.Helper.NullableDateConverter  DateConverter��%   &	         5
   
   6'   5      .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��Symbols��6   .@�5      m� $��Force Load All��6    m� Command 63   �� *ForceFetchSymbols+5      5      � 5   
    � RowDefinitions 5      �� 5      $��31 �6    �� 5       � ColumnDefinitions 5      �� 5      �� 5       $	��100 �6#   .+�5"      �� $��Fetch��6   $
��Left=�6&   $��48,4,0,0q�6A   $	��Top=�5#      $��47��6)   $��1��6W   $��23��6g     MaroonBrush#��[ 5$      
���������5#   4   �� *FetchSymbols+{�5$   Q   �� *	IsNotBusy+�� 5%      -   5         ��Name$ 	txtSymbol��5%      $��Stretch=�6)   $��23��6G   	 �� TextWrapping$
	 Wrap=�6S   $	��Top=�6g   $��4,4,4,4q�5&        
WheatBrush#��[ 6$   ��5%      �� *Filter+
 �� Mode$
 TwoWay=�5&   M   �� 5'      $	��Add��6   $
��Left=�6$   $��4,4,0,0q�6?   $	��Top=�6P   $��38��6h   $��1��6s   $��23��6�   #��[ 5)      
�������{�5(      �� *	IsNotBusy+��5)   N   �� *AddSymbolToWatched+��5*      ��  �� ElementName$ 	txtSymbol�� �� Path$
 Text��� 5+      $��2��6   $��4,0,4,4q�6-   $��1��6>   #��[ 6L   ��5,      �� *FilteredSymbols.View+��5-      �� 5.      .R�5/      ��  �� Orientation$ 
Horizontal=�6%   .+�50      �� $��50��6>   ��6(   �� *Name+6>   �� 51      ��6(   �� *LastUpdated+ �� 	Converter# [ �� 52      $��	LeftParen��6D   $	��- (��6(   $��4,0,0,0q�63   ���	#FF5959596U   �� 53      $��NumberOfEntries��6I   ���	#FF595959��6(   �� *NumberOfEntries+6a   �� 54      $��
RightParen��61   $��)��6(   ���	#FF5959596C   55       �� Triggers 56      �� 57       �� Value$ 0��6O    �� Binding 6+   �� *NumberOfEntries+.a�58   "   ��  �� 
TargetName$ 	LeftParen��6*    �� Property � y� �� Value$ 	Collapsed=�6W   �� 59   "   $ NumberOfEntries��6*    � y�$ 	Collapsed=�6]   �� 5:   "   $ 
RightParen��6*    � y�$ 	Collapsed=�6X   5;      5=      5?      5A      5B      5C      