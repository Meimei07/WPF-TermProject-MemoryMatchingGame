   M S B A M L   `   `   `  ����U  QWPF-TermProject-MemoryGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WPF_TermProject_MemoryGameWPF_TermProject_MemoryGame  5   	   0    *WPF_TermProject_MemoryGame.frmConfirmation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:WPF_TermProject_MemoryGame     5   	     � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Confirmation��5   	   $	��150��6   $	��300��6+    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� 
TargetType��%�   '��       �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��Center=�6+   $��Center=�5   '   5      5      5      5      .��5      �� $	��1.5q�6   
�������
�������
 �� CornerRadius$
 8��5"      ._�5$   
   �  � RowDefinitions 5%      �� 5&      $��0.35* �6    �� 5'      �� 5(      $
��0.6* �6    .+�5,      �� $��Confirmation��6    �� Padding$ 6,4,0,0q�6,   �� 5/      $��1��6   
������� �� Orientation$ 
Horizontal=�51      .+�52      �� $��/Images/questionMark.png��53      $��26��54      $��26��55      $��50,0,7,5q�56      �� 58      $ ��Do you want to play again?��59      $��13(�5:      $��Center=�5;      $
��0,27q�5<      5>      �� 5A      $��2��6   $ 
Horizontal=�6&   $��Right=�6?   .+�5B      �� -   5        $��
btnRestart��5B      $
��10,0q�5E      .��5F      �� $��/Images/restart.png��5G      $��26��5H      $��26��5I      5K      �� 5L      -   5        $��btnContinue��5L      $
��10,0q�5O      .��5P      �� $��/Images/continue.png��5Q      $��26��5R      $��26��5S      5U      �� 5V      -   5        $��btnClose��5V      $
��10,0q�5Y      .��5Z      �� $��/Images/close.png��5[      $��28��5\      $��28��5]      5_      5`      5a      5c      5d      