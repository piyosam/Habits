Namespace Habits.Logic
    ''' <summary>����S����ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class c0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>��S���҈ꗗ�擾</summary>
        ''' <returns>�X�^�b�t���X�g</returns>
        ''' <remarks>W_�X�^�b�t���擾</remarks>
        Protected Friend Function Q_����_�X�^�b�t�ꗗ() As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@�c�Ɠ�", USER_DATE)
            Return MyBase.W_�X�^�b�tPlus_E_����(param)
        End Function

    End Class
End Namespace

