#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ÚqõæÊWbNNX</summary>
    ''' <remarks></remarks>
    Public Class z0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>Úqîñæ¾</summary>
        ''' <param name="v_param">SQLp[^F@ÚqÔ</param>
        ''' <returns>Úqîñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerInfo(v_param)
        End Function

        ''' <summary>«Ê¼Ìêæ¾</summary>
        ''' <returns>«ÊXg</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_«Ê()
        End Function

        ''' <summary>o^æª¼Ìæ¾</summary>
        ''' <returns>o^æª¼Xg</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_o^æª()
        End Function

        ''' <summary>SÒ¼êæ¾</summary>
        ''' <returns>SÒXg</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function

    End Class
End Namespace

