#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>顧客検索画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class z0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>顧客情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerInfo(v_param)
        End Function

        ''' <summary>性別名称一覧取得</summary>
        ''' <returns>性別リスト</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_性別()
        End Function

        ''' <summary>登録区分名称取得</summary>
        ''' <returns>登録区分名リスト</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_登録区分()
        End Function

        ''' <summary>担当者名一覧取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function

    End Class
End Namespace

