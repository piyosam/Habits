#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�c�Ɠ���ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class d0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "d0200_�c�Ɠ�"

        ''' <summary>Q_d0200_�c�Ɠ��ꗗ���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���N�O</param>
        ''' <returns>�c�Ɠ����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_d0200_�c�Ɠ��ꗗ(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_�c�Ɠ�.�c�Ɠ�,")
                builSQL.Append(" �c�Ɠ� AS ���t,")
                builSQL.Append(" B_�V��.�V��,")
                builSQL.Append(" RIGHT(Space(4) + �X�^�b�t��,4) + '�l�@' AS ���̐�,")
                builSQL.Append(" ���W���z AS ڼދ��z")
                builSQL.Append(" FROM E_�c�Ɠ�")
                builSQL.Append(" INNER JOIN B_�V��")
                builSQL.Append(" ON E_�c�Ɠ�.�V��ԍ�=B_�V��.�V��ԍ�")
                builSQL.Append(" WHERE E_�c�Ɠ�.�c�Ɠ� >= @���N�O")
                builSQL.Append(" ORDER BY E_�c�Ɠ�.�c�Ɠ� DESC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>E_�c�Ɠ��擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�c�Ɠ�</param>
        ''' <returns>�c�Ɠ����</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_�c�Ɠ��擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.E_�c�Ɠ�(v_param)
        End Function

        ''' <summary>B_�V��擾</summary>
        ''' <returns>�V�󃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function B_�V��擾() As DataTable
            Return MyBase.B_�V��()
        End Function

        ''' <summary>E_�c�Ɠ��X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�V��ԍ�,@�X�^�b�t��,@���W���z,@�X�V��,@�c�Ɠ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_�c�Ɠ��X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                ''SQL������
                builSQL.Append("UPDATE E_�c�Ɠ�")
                builSQL.Append(" SET �V��ԍ�=@�V��ԍ�")
                builSQL.Append(" ,�X�^�b�t��=@�X�^�b�t��")
                builSQL.Append(" ,���W���z=@���W���z")
                builSQL.Append(" ,�X�V��=@�X�V��")
                builSQL.Append(" WHERE �c�Ɠ�=@�c�Ɠ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE business_day")
                builSQL.Append(" SET weather_code=" & VbSQLStr(v_param.GetValue("@�V��ԍ�")))
                builSQL.Append(" ,staff_count=" & VbSQLStr(v_param.GetValue("@�X�^�b�t��")))
                builSQL.Append(" ,cash_of_register=" & VbSQLStr(v_param.GetValue("@���W���z")))
                builSQL.Append(" ,update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@�c�Ɠ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace
