Namespace Habits.Logic
    ''' <summary>売上担当画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class c0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>主担当者一覧取得</summary>
        ''' <returns>スタッフリスト</returns>
        ''' <remarks>W_スタッフより取得</remarks>
        Protected Friend Function Q_共通_スタッフ一覧() As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@営業日", USER_DATE)
            Return MyBase.W_スタッフPlus_E_売上(param)
        End Function

    End Class
End Namespace

