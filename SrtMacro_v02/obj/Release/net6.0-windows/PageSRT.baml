   M S B A M L   `   `   `  ���� G  CSrtMacro_v02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SrtMacro_v02SrtMacro_v02      SrtMacro_v02.PageSRT   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:SrtMacro_v02     -     N� 
Background
  ����� N� Title$ PageSRT��.���� $��10q�.+��� $��설정��
���   �$��1q�$
��Bold"�.���  � ColumnDefinitions �� �� �� $��30 ��� ��  � RowDefinitions �� �� �� .+��� $��	아이디��$��0��$��0��$��Medium"�$��0 5 0 0q��� $��비밀번호��$��3��$��0��$��Medium"�$��0 5 0 0q��� -    ��Name$ txtId��$��0��$��1��$��2��$��30��$��Center=�$��Medium"�G� -    G�Name$ txtPw��$��3��$��1��$��2��$��30��$��Center=�$��Medium"��� -    ��Name$ btnSave��$��0��$��2��$��저장��$��5��$��0 15 0 5q�$��30��$
��Bold"����#39385d
������� � 	Resources  �� 
TargetType	 �� Property
 �� Value��%9   '��       �� " ��.��� 	 �@��CornerRadius$
 5���� $��예매정보��
���   �$��1q�$
��Bold"�.���  �� �� �� $��30 ��� ��  �� �� �� �� �� �� .+��� $��0��$��0��$��날짜선택��$��Medium"�$��0 5 0 0q�(  "System.Windows.Controls.DatePicker  -     Name$ dpTime��$��0��$��1��$��Medium"��� $��3��$��0��$��새로고침 주기��$��Medium"�$��0 5 0 0q��� -    ��Name$ 
comboDelay��$��3��$��1��$��Medium"����� *	DelayTime+�� $��0��$��2��$��	출발지��$��Medium"�$��0 5 0 0q��� $��1��$��2��$��	도착지��$��Medium"�$��0 5 0 0q��� $��3��$��2��$��출발시간��$��Medium"�$��0 5 0 0q��� $��4��$��2��$��도착시간��$��Medium"�$��0 5 0 0q��� -   $ comboStartAddress��$��0��$��3��$��0 0 5 0q�$��Medium"����� *AddressList+�� -   $ comboStopAddress��$��1��$��3��$��0 0 5 0q�$��Medium"����� *AddressList+�� -	   $ comboStartTime��$��3��$��3��$��0 0 5 0q�$��Medium"����� *	StartList+�� -
   $ comboStopTime��$��4��$��3��$��0 0 5 0q�$��Medium"����� *	EndList+�� $��0��$��4��$��어른(명)��$��Medium"�$��0 5 0 0q��� $��1��$��4��$��어린이(명)��$��Medium"�$��0 5 0 0q��� -   $ 
comboAdult��$��0��$��5��$��0 0 5 0q�$��Medium"����� *	AdultList+�� -   $ 
comboChild��$��1��$��5��$��0 0 5 0q�$��Medium"����� *	ChildList+�  �� �� .+��� -   $ btnStart��$��시작��$��0��$
��Bold"�$��30�����#1785f2
�������$��0q�$��5q� ��%9   '��       �� " ��.��� 	 �@��CornerRadius$
 5���� -   $ btnStop��$��정지��$��1��$
��Bold"�$��30��
���  ��
�������$��0q�$��5q� ��%9   '��       �� " ��.��� 	 �@��CornerRadius$
 5���� -    ��Name$ txtLog�� �� 
IsReadOnly$
 True��" �� VerticalScrollBarVisibility$
 Auto=�$ �� HorizontalScrollBarVisibility$
 Auto=� ��%3   'J�       �� " J�.��� 	 �@��Margin$
 0q�