   M S B A M L   `   `   `  ����L  HAuctionHouse.View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AuctionHouseAuctionHouse  5   	   Q MAuctionHouse.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:AuctionHouse.ViewModel;assembly=AuctionHouse.ViewModelAuctionHouse.ViewModel 62       AuctionHouse.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AuctionHouse     5   	   Z	viewmodelDclr-namespace:AuctionHouse.ViewModel;assembly=AuctionHouse.ViewModel     62     � Title$  
MainWindow��5   	   $	��480��6   $	��800��6)   .��5      � $��
0,0,10,396q�6    � ColumnDefinitions 5   
   �� 5      $
��469* �6   �� 5      $
��321* �6   .+�5   
   c� $��10,0,-14,-26q�6   ���	#FF202225
�������$��2��6W   .@�5      �� -   5        ��5   *   ��  �� Path$ UserLoginBtn�{�6Q   �� $ 
IsLoggedIn�.��5      �� -   5         ��Name$ Login��5      $��Icons\icons8-login-64.png��6'   $	��32 ��6J   $��32��6W   6d   5      �� 5      $��24(�6W   ��6   �� $ CurrentUser.Username� �� StringFormat$ Hi {0}��6g   5      �� 5       $	��300��6.   ���	#FF202225
�������$
��Left=�6j   $��10,92,0,-324q�6�   $��2��6�   ��6�   �� *
Products+ �� SelectedItem 6�   �� *	Product+��5!      �� 5"      .R�5#      �  � Orientation$ 
Horizontal=�6   $��Stretch=�65   .+�5%      �� $��Name: ��6    60   �� 5&      ��6    �� $
 Name�6=   �� 5'      $��Price: ��6    61   �� 5(      ��6$   �� $ Price�6B   �� 5)      $��Last Offer: ��6$   6:   �� 5*      ��6$   �� $ 	LastOffer�6F   �� 5+      $��Last Bidder: ��6$   6;   �� 5,      ��6$   �� $ 
LastBidder�6G   �� 5-      $��Time Left: ��6$   69   �� 5.      ��6$   �� $
 Time�6A   5/      50      52      � 54   
   $��0,379,0,-395q�6   $��2��6*   .+�55      �� $	��Bid��6   ���	#FFF3F1F1���	#FF202225$	�� 24��6R   $	��183��6_   ��6k   �� $ 
BidCommand�{�6�   �� $ IsLoggedIn2�6�   �� 56      $��$��6   $��24(�6!   $��44��6/   6=   �� 57      -   5        $��Add Product��57      ���	#FFF3F1F1���	#FF202225$	�� 24��6Z   $	��183��6g   ��6s   �� {�6�   �� $ CurrentUser.IsAdmin�6�   �� 58      $��Remove Product��6   ���	#FFF3F1F1���	#FF202225$	�� 24��6]   $	��183��6j   ��6v   �� *DeleteCommand+{�6�   �� $ CurrentUser.IsAdmin�59      5:      5;      