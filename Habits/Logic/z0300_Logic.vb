#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�ڋq������ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class z0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>�ڋq���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq���</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerInfo(v_param)
        End Function

        ''' <summary>���ʖ��̈ꗗ�擾</summary>
        ''' <returns>���ʃ��X�g</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_����()
        End Function

        ''' <summary>�o�^�敪���̎擾</summary>
        ''' <returns>�o�^�敪�����X�g</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_�o�^�敪()
        End Function

        ''' <summary>�S���Җ��ꗗ�擾</summary>
        ''' <returns>�S���҃��X�g</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function

    End Class
End Namespace

