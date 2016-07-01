#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�X�^�b�t�I����ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a0800_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0800_�X�^�b�t�I��"

#Region "���X�^�b�t�o�^�i�������񎞁j"
        ''' <summary>���X�^�b�t�o�^�i�������񎞁j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�폜�t���O</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>W_�S���҃e�[�u����D_�S���҂̍폜�t���O��False�̃f�[�^��S�C���T�[�g</remarks>
        Protected Friend Function insert_W_�S����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_�S����")
                builSQL.Append(" SELECT *")
                builSQL.Append(" FROM D_�S����")
                builSQL.Append(" WHERE �폜�t���O = @�폜�t���O")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "���X�^�b�t�o�^�i�Đݒ�j"
        ''' <summary>���X�^�b�t�o�^�i�Đݒ�j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�폜�t���O</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>W_�S���҃e�[�u����W_�X�^�b�t�ɑ��݂��Ȃ�D_�S���҂̍폜�t���O��False�̃f�[�^��S�C���T�[�g</remarks>
        Protected Friend Function insert_W_�S����_again(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_�S����")
                builSQL.Append(" SELECT * FROM D_�S����")
                builSQL.Append(" WHERE �S���Ҕԍ� NOT IN")
                builSQL.Append(" (SELECT �S���Ҕԍ� FROM W_�X�^�b�t)")
                builSQL.Append(" AND �폜�t���O= @�폜�t���O")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�o�΃X�^�b�t�o�^�i�S���j"
        ''' <summary>�o�΃X�^�b�t�o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�폜�t���O</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>W_�X�^�b�t�e�[�u����D_�S���҂̍폜�t���O��False�̃f�[�^��S�C���T�[�g</remarks>
        Protected Friend Function insert_W_�X�^�b�t(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_�X�^�b�t")
                builSQL.Append(" SELECT *")
                builSQL.Append(" FROM D_�S����")
                builSQL.Append(" WHERE �폜�t���O = @�폜�t���O")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "���X�^�b�t�폜�i�S���j"
        ''' <summary>W_�S���ҍ폜�i�S���j</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_�S����() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_�S����"
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�o�΃X�^�b�t�폜�i�S���j"
        ''' <summary>W_�X�^�b�t�폜�i�S���j</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_�X�^�b�t() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_�X�^�b�t"
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "���X�^�b�t�ꗗ�擾"
        ''' <summary>W_�S���Ҏ擾</summary>
        ''' <returns>�S���҃��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W_�S����() As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �S���Ҕԍ�,�S���Җ�,�\����,�폜�t���O,�o�^��,�X�V�� FROM W_�S���� ORDER BY �\����,�S���Ҕԍ�"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�o�΃X�^�b�t�ꗗ�擾"
        ''' <summary>�o�΃X�^�b�t�ꗗ�擾</summary>
        ''' <returns>�X�^�b�t���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W_�X�^�b�t() As DataTable
            Return MyBase.W_�X�^�b�t()
        End Function
#End Region

#Region "���X�^�b�t�폜�i�S���ҁj"
        ''' <summary>W_�S���ҍ폜</summary>
        ''' <param name="v_param">SQL�p�����[�^:@�S���Ҕԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_part_W_�S����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_�S���� WHERE �S���Ҕԍ� = @�S���Ҕԍ�"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�o�΃X�^�b�t�폜�i�S���ҁj"
        ''' <summary>W_�X�^�b�t�폜�i�S���ҁj</summary>
        ''' <param name="v_param">SQL�p�����[�^:@�S���Ҕԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_part_W_�X�^�b�t(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_�X�^�b�t WHERE �S���Ҕԍ� = @�S���Ҕԍ�"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "���X�^�b�t�o�^�i�S���ҁj"
        ''' <summary>���X�^�b�t�o�^�i�S���ҁj</summary>
        ''' <param name="v_param">SQL�p�����[�^:@�S���Ҕԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_part_W_�S����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "INSERT INTO W_�S���� SELECT * FROM W_�X�^�b�t WHERE �S���Ҕԍ� = @�S���Ҕԍ�"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�o�΃X�^�b�t�o�^�i�S���ҁj"
        ''' <summary>W_�X�^�b�t�o�^�i�j</summary>
        ''' <param name="v_param">SQL�p�����[�^:@�S���Ҕԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_part_W_�X�^�b�t(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "INSERT INTO W_�X�^�b�t SELECT * FROM W_�S���� WHERE �S���Ҕԍ� = @�S���Ҕԍ�"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�c�Ɠ����X�V"
        ''' <summary>�c�Ɠ����X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^:@�X�^�b�t��/@�X�V��/@�c�Ɠ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_�c�Ɠ��X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                str_sql = "UPDATE E_�c�Ɠ� SET �X�^�b�t��=@�X�^�b�t��,�X�V��=@�X�V�� WHERE �c�Ɠ�=@�c�Ɠ�"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                Dim builSQL As New StringBuilder()
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE business_day SET")
                builSQL.Append(" staff_count=" & VbSQLStr(v_param.GetValue("@�X�^�b�t��")))      '�X�^�b�t��     (smallint)
                builSQL.Append(", update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))         '�X�V��         (datetime)
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@�c�Ɠ�")))           '�c�Ɠ�         (datetime)
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '�X�܃R�[�h     (varchar)
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�L���ȒS���ҏ��擾"
        ''' <summary>�L���ȒS���ҏ��擾</summary>
        ''' <returns>�S���ҏ�񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_D_�S����() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function
#End Region

#Region "�c�Ɠ��擾"
        ''' <summary>�c�Ɠ��擾</summary>
        ''' <returns>�S���ҏ�񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_�c�Ɠ�(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.E_�c�Ɠ�(v_param)
        End Function
#End Region
    End Class
End Namespace