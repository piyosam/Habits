'システム名 ： HABITS
'概要　　　 ：
'説明　　　 ： テーブル
'履歴　　　 ： 2010/04/01　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module テーブル

    '概要 ： DataTableのSelect結果の有無を返す
    '引数 ： dataTable ,In ,DataTable  ,データ
    '　　　　filterExpression ,In ,String   ,条件文
    '説明 ： DataTableをSelectし、結果が1件以上ならTrueを返す
    Public Function DataTableSelect(ByRef dataTable As DataTable, ByVal filterExpression As String) As Boolean

        Dim dr() As DataRow

        dr = dataTable.Select(filterExpression)

        If dr.Length > 0 Then
            DataTableSelect = True
        Else
            DataTableSelect = False
        End If
    End Function

    '概要 ： GetNextSequence
    '引数 ： dataTable ,In ,DataTable  ,データ
    '        columnName ,In ,String  ,列名（数値型）
    '        columnName ,In ,String  ,列名（数値型）
    '説明 ： 指定した数値型の列の最大値+1を返す
    Public Function GetNextSequence(ByRef dataTable As DataTable, ByVal columnName As String, _
        Optional ByVal defaultSauence As Integer = 1) As Integer

        Dim nums As Integer() = New Integer() {}
        Dim tmp As Object
        Dim index As Integer
        Dim NextSeqence As Integer

        '数値列の作成
        index = 0
        For i As Integer = 0 To dataTable.Rows.Count - 1
            Do
                tmp = dataTable.Rows(i).Item(columnName)
                If IsDBNull(tmp) Then Exit Do
                If Not IsNumeric(tmp) Then Exit Do

                ReDim Preserve nums(index)
                nums(index) = tmp
                index = index + 1
            Loop Until True
        Next

        If nums.Length <= 0 Then
            GetNextSequence = defaultSauence
            Exit Function
        End If

        '数値列をソート
        Array.Sort(nums)

        '次の連番(最大値+1)を取得
        NextSeqence = nums(nums.Length - 1) + 1
        GetNextSequence = NextSeqence
    End Function
End Module
