Namespace Habits.Logic
    ''' <summary>��ԍ��I����ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class z0200_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>��ԍ��擾</summary>
        ''' <returns>��ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function z_��ԍ��擾() As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ��ԍ�,�ڋq�� FROM W_��ԍ� ORDER BY ��ԍ�"
                rtn = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>��ԍ��X�V</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function ��ԍ��ꗗ�X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "INSERT INTO W_��ԍ� (��ԍ�,�ڋq��) VALUES(@��ԍ�,'���g�p')"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param, 0)

            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>�ڋq�ԍ��擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n�ڋq�ԍ�/@�I���ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ����X�g</returns>
        ''' <remarks>�J�n�ڋq�ԍ�����I���ڋq�ԍ��܂ł̌ڋq�ԍ����X�g�擾</remarks>
        Protected Friend Function �ڋq�ԍ��擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerNum(v_param)
        End Function

        ''' <summary>��ԍ��폜</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function ��ԍ��폜() As Integer
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                str_sql = "DELETE W_��ԍ� FROM W_��ԍ�;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�V�K�ڋq�ԍ��擾</summary>
        ''' <returns>�ő�ڋq�ԍ��{1</returns>
        ''' <remarks></remarks>
        Protected Friend Function �ŏ���ԍ�() As String
            Return MyBase.NewCustomerNumber()
        End Function

    End Class
End Namespace
