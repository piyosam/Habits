Namespace Habits.Logic
    ''' <summary>�`��������ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a0900_Logic
        Inherits Habits.Logic.LogicBase ''���W�b�N�x�[�X���p��

        ''' <summary>�`�������擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�`������</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_a0900_�`������(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ���� FROM D_�ڋq WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                ''��O���̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace

