   M S B A M L   `   `   `  ���� G  CSrtMacro_v02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SrtMacro_v02SrtMacro_v02      SrtMacro_v02.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:SrtMacro_v02     -   ���#a2a0a3  � Title$'  !예약 매크로 프로그램v_02�� � Icon$ /Icons/macro.ico��$	��800��$	��800��$
��1200�� � 	Resources  �� 
TargetType �� Property �� Value��%]   '��       �� " ��.���  � ��
 �������  � ��$ 60����  � ��
 �����.���  � RowDefinitions �� $��50 ��� .+��� ���#1f1c1c._���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ imgSelectIcon���� -   	 ��Name$	 txtSelectTitle��$��label��$��Center=�
�������$��15(�$��10 0 0 0q�� $��1��
 � ColumnDefinitions
 �� $	��130 ��� .+��� $��0�����#1f1c1c.+��� -    ��Name$ btnSRT��.���� $ 
Horizontal=�.+��� $��/Icons/srt_ico.ico��$	��100���� -   $ btnKTX��.���� $ 
Horizontal=�.+��� $��/Icons/KTX.ico��$	��130�� � -     �Name$ frame_content��$��1��  � NavigationUIVisibility$ Hidden=�