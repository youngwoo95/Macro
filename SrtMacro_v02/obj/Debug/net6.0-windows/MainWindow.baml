   M S B A M L   `   `   `  ����G  CSrtMacro_v02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SrtMacro_v02SrtMacro_v02  5   	       SrtMacro_v02.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SrtMacro_v02     5   	   -   5        ���#a2a0a3  � Title$'  !예약 매크로 프로그램v_02��5	   	    � Icon$ /Icons/macro.ico��5
   	   $	��800��5   	   $	��800��5   	   $
��1200��5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 60��6'   �� 5       � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   �� ���#1f1c1c._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5       �� -   5         ��Name$ imgSelectIcon��5       �� 5!      -   5        	 ��Name$	 txtSelectTitle��5!      $��label��60   $��Center=�6@   
�������$��15(�6u   $��10 0 0 0q�6�   5"      5#      � 5&   
   $��1��6   
 � ColumnDefinitions
 5'      �� 5(      $	��130 �6#   �� 5)      .+�5,      �� $��0��6   ���#1f1c1c.+�5-      �� -   5         ��Name$ btnSRT��5-      .��5.      �� $ 
Horizontal=�6!   .+�5/      �� $��/Icons/srt_ico.ico��6    $	��100��6<   50      51      �� 53      -   5        $ btnKTX��53      .��54      �� $ 
Horizontal=�6!   .+�55      �� $��/Icons/KTX.ico��6    $	��130��68   56      57      5:       � 5=      -   5          �Name$ frame_content��5=      $��1��6+     � NavigationUIVisibility$ Hidden=�6;   5>      5?      5A      