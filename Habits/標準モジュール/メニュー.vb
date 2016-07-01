'システム名 ： HABITS
'概要　　　 ：
'説明　　　 ： メニュー
'履歴　　　 ： 2010/04/01　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module メニュー

    '概要 ： Men_システムの終了
    '引数 ： なし
    '説明 ： システムの終了

    Public Function Men_システムの終了() As Long

        If (MsgBox("お疲れさまでした。　" & Chr(13) & Chr(13) & _
                   "システムを終了してもよろしいですか？　", Clng_Ynqub2, TTL) = vbNo) Then
            a0200_メイン.btn来店.Focus()
            Exit Function
        End If
        M01.DialogResult = System.Windows.Forms.DialogResult.Cancel
        M01.Close()
    End Function
End Module
