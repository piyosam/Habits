#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>メイン画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1900_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1900_メッセージ一覧"

#Region "データ取得"

#Region "ダウンロードデータ格納パス取得"
        ''' <summary>ダウンロードデータ格納パス取得</summary>
        ''' <returns>データ格納パス名</returns>
        ''' <remarks></remarks>
        Function getStockPath() As String
            Return MyBase.getDataStockPath()
        End Function
#End Region

#End Region

    End Class
End Namespace
