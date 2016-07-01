#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�J���e��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a1300_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1300_�J���e"

        ''' <summary>�J���e�ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_day_name(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT ���X��,�S���Җ� AS �o�^�X�^�b�t,�J���e,���X�Ҕԍ�,�ڋq�ԍ�")
                builSQL.Append(" FROM E_�J���e")
                builSQL.Append(" INNER JOIN D_�S����")
                builSQL.Append(" ON E_�J���e.�o�^�Ҕԍ� = D_�S����.�S���Ҕԍ�")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")
                builSQL.Append(" ORDER BY ���X�� DESC,���X�Ҕԍ� DESC")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�S���҈ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�폜�t���O</param>
        ''' <returns>�S���҃��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_name(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append(" SELECT �S���Җ�, �S���Ҕԍ�")
                builSQL.Append(" FROM D_�S����")
                builSQL.Append(" WHERE �폜�t���O = @�폜�t���O")
                builSQL.Append(" ORDER BY �\����,�S���Ҕԍ�")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�J���e���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�/@���X��/@���X�Ҕԍ�</param>
        ''' <returns>�J���e���</returns>
        ''' <remarks></remarks>
        Protected Friend Function exist_check(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT ���X��,���X�Ҕԍ�,�ڋq�ԍ�,�J���e,�o�^�Ҕԍ�,�o�^����,�ύX����")
                builSQL.Append(" FROM E_�J���e")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")
                builSQL.Append(" AND ���X�� = @���X��")
                builSQL.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�J���e�o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_E_�J���e(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append(" INSERT INTO E_�J���e")
                builSQL.Append(" VALUES(@���X��,@���X�Ҕԍ�,@�ڋq�ԍ�,@�J���e,@�o�^�Ҕԍ�,@�o�^����,@�ύX����)")
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append(" INSERT INTO chart")
                builSQL.Append(" (shop_code")
                builSQL.Append(",visit_date")
                builSQL.Append(",visit_number")
                builSQL.Append(",basis_customer_code")
                builSQL.Append(",chart")
                builSQL.Append(",basis_staff_code")
                builSQL.Append(",insert_date")
                builSQL.Append(",update_date")
                builSQL.Append(" ) VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�J���e")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�o�^�Ҕԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�o�^����")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�ύX����")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�J���e�X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_�J���e(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE E_�J���e")
                builSQL.Append(" SET �ύX���� =@�ύX����, �J���e = @�J���e ")
                builSQL.Append(" WHERE ���X�� = @���X�� ")
                builSQL.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ� ")
                builSQL.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� UPDATE
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE chart")
                builSQL.Append(" SET update_date =" & VbSQLStr(v_param.GetValue("@�ύX����")))
                builSQL.Append(", chart = " & VbSQLNStr(v_param.GetValue("@�J���e")))
                builSQL.Append(" WHERE visit_date = " & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" AND visit_number = " & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" AND basis_customer_code = " & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
    End Class
End Namespace