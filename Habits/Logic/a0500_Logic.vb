Namespace Habits.Logic

    ''' <summary>�ڋq�ԍ��ݒ��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a0500_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>�ڋq�ԍ����݃`�F�b�N</summary>
        ''' <param name="v_param">SQL�p�����[�^:@�ڋq�ԍ�</param>
        ''' <returns>True:���݁AFalse�F���݂��Ȃ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_a0500_�ڋq�ԍ�(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim str_sql As String
            Dim dt As DataTable
            Dim rtn As Boolean
            rtn = False
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM D_�ڋq WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
                If (dt.Rows.Count > 0) Then
                    rtn = True
                End If
            Catch ex As Exception
                ''��O���̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace