#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>管理者用パスワード登録画面ロジック</summary>
    ''' <remarks></remarks>
    Public Class z0700_Logic
        Inherits Habits.Logic.LogicBase

#Region "管理者用パスワード登録"
        ''' <summary>管理者用パスワード登録</summary>
        ''' <remarks></remarks>
        Sub updateA_Pwd(ByVal pwd As String)
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                param.Add("@pwd", pwd)
                str_sql = "UPDATE A_システム SET 予備3=@pwd"
                rtn = DBA.ExecuteNonQuery(str_sql, param)

                UpDateForSever_System()

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region
    End Class
End Namespace