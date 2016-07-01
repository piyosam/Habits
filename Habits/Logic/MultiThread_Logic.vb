Namespace Habits.Logic
    ''' <summary>���ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class MultiThread_Logic

        ''�}���`�X���b�h�ɂ��邽�߁A���̃��W�b�N�ƃR�l�N�V����������K�v����

#Region "�A�b�v���[�h�f�[�^�i�[�p�X�擾"
        ''' <summary>�A�b�v���[�h�f�[�^�i�[�p�X�擾</summary>
        ''' <returns>�f�[�^�i�[�p�X��</returns>
        ''' <remarks></remarks>
        Function select_ASY() As DataTable
            Dim dt As DataTable
            Dim v_param As New Habits.DB.DBParameter
            Dim str_sql As String
            Try
                str_sql = "SELECT �f�[�^�i�[�p�X�� FROM A_�V�X�e��"
                dt = DBA2.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�ʐM���G���[�񐔎擾"
        ''' <summary></summary>
        ''' <returns>�ʐM���G���[�񐔎擾</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetConnectError() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT �ʐM���G���[�� FROM M_����M"
                dt = DBA2.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "Z_SQL���s�����擾"
        ''' <summary>Z_SQL���s�����擾</summary>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_SQLHistory() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �����ԍ�,SQL1 FROM Z_SQL���s���� WHERE �����ԍ� = (SELECT MIN(�����ԍ�) FROM Z_SQL���s����)"
                dt = DBA2.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "Z_SQL���s�����폜"
        ''' <summary>Z_SQL���s�����폜</summary>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_SQLHistory(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String

            Try
                ' �g�����U�N�V�����J�n
                DBA2.TransactionStart()

                'Z_SQL���s�����폜
                str_sql = "DELETE FROM Z_SQL���s���� WHERE �����ԍ� =@�����ԍ�"
                rtn = DBA2.ExecuteNonQuery(str_sql, v_param)

                ' �R�~�b�g
                DBA2.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA2.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "�ʐM���G���[�񐔍X�V"
        ''' <summary>�ʐM���G���[�񐔍X�V</summary>
        ''' <returns>��������</returns>
        ''' <remarks></remarks>
        Protected Friend Function UpdateConnectError(ByVal v_param As Habits.DB.DBParameter) As Long
            Dim str_sql As String
            Try
                str_sql = "UPDATE M_����M SET �ʐM���G���[�� = @�ʐM���G���[��"
                rtn = DBA2.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

    End Class
End Namespace

