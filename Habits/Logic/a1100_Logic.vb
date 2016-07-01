#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>�ڕW�z��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a1100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1100_�ڕW�z"

#Region "B_����敪�擾"
        ''' <summary>B_����敪�擾</summary>
        ''' <returns>����敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function ����敪Plus_E_�ڕW�z(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Try

                builSQL.Append("SELECT ����敪�ԍ�")
                builSQL.Append(" ,����敪")
                builSQL.Append(" ,�\����")
                builSQL.Append(" FROM B_����敪")
                builSQL.Append(" WHERE �폜�t���O = 'false'")

                builSQL.Append(" UNION SELECT E_�ڕW�z.����敪�ԍ�")
                builSQL.Append(" ,B_����敪.����敪")
                builSQL.Append(" ,B_����敪.�\����")
                builSQL.Append(" FROM E_�ڕW�z")
                builSQL.Append(" LEFT OUTER JOIN B_����敪")
                builSQL.Append(" ON E_�ڕW�z.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" WHERE E_�ڕW�z.�Ώ۔N��>=@�ߋ��N��")

                builSQL.Append(" ORDER BY �\����,����敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "B_����敪�擾"
        ''' <summary>E_�ڕW�z�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@�Ώ۔N��</param>
        ''' <returns>�ڕW�z</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_�ڕW�z�擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ����敪�ԍ�,�Ώ۔N��,�ڕW�z,�c�Ɠ���,�X�V�� FROM E_�ڕW�z WHERE ����敪�ԍ�=@����敪�ԍ� AND �Ώ۔N��=@�Ώ۔N��"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�ڕW�ꗗ�擾"
        ''' <summary>�ڕW�ꗗ�f�[�^�̎擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ߋ��N��</param>
        ''' <returns>�ڕW�z���</returns>
        ''' <remarks></remarks>
        Protected Friend Function �ڕW�ꗗ�擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT E_�ڕW�z.�Ώ۔N��,")
                builSQL.Append(" E_�ڕW�z.����敪�ԍ�,")
                builSQL.Append(" B_����敪.����敪,")
                builSQL.Append(" E_�ڕW�z.�ڕW�z,")
                builSQL.Append(" E_�ڕW�z.�c�Ɠ��� AS ����")
                builSQL.Append(" FROM E_�ڕW�z LEFT JOIN B_����敪 ON E_�ڕW�z.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" WHERE E_�ڕW�z.�Ώ۔N��>=@�ߋ��N��")
                builSQL.Append(" ORDER BY E_�ڕW�z.�Ώ۔N�� DESC, B_����敪.�\����,E_�ڕW�z.����敪�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "E_�ڕW�z�e�[�u���X�V"
        ''' <summary>E_�ڕW�z�e�[�u���X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_�ڕW�z�X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE E_�ڕW�z SET")
                builSQL.Append(" ����敪�ԍ�=@����敪�ԍ�,")
                builSQL.Append(" �Ώ۔N��=@�Ώ۔N��,")
                builSQL.Append(" �ڕW�z=@�ڕW�z,")
                builSQL.Append(" �c�Ɠ���=@�c�Ɠ���,")
                builSQL.Append(" �X�V��=@�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ�=@����敪�ԍ�")
                builSQL.Append(" AND �Ώ۔N��=@�Ώ۔N��")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� UPDATE
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE target_figure SET")
                builSQL.Append(" sales_division_code=" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")) & ",")
                builSQL.Append(" ym=" & VbSQLStr(v_param.GetValue("@�Ώ۔N��")) & ",")
                builSQL.Append(" amount=" & VbSQLStr(v_param.GetValue("@�ڕW�z")) & ",")
                builSQL.Append(" days=" & VbSQLStr(v_param.GetValue("@�c�Ɠ���")) & ",")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE sales_division_code=" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND ym=" & VbSQLStr(v_param.GetValue("@�Ώ۔N��")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function
#End Region

#Region "E_�ڕW�z�e�[�u���ǉ�"
        ''' <summary>E_�ڕW�z�e�[�u���ǉ�</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@�Ώ۔N��/@�ڕW�z/@�c�Ɠ���/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_�ڕW�z�ǉ�(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO E_�ڕW�z")
                builSQL.Append(" (����敪�ԍ�,")
                builSQL.Append(" �Ώ۔N��,")
                builSQL.Append(" �ڕW�z,")
                builSQL.Append(" �c�Ɠ���,")
                builSQL.Append(" �X�V��)")
                builSQL.Append(" VALUES")
                builSQL.Append(" (@����敪�ԍ�,")
                builSQL.Append(" @�Ώ۔N��,")
                builSQL.Append(" @�ڕW�z,")
                builSQL.Append(" @�c�Ɠ���,")
                builSQL.Append(" @�X�V��)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO target_figure")
                builSQL.Append(" (shop_code,")
                builSQL.Append(" sales_division_code,")
                builSQL.Append(" ym,")
                builSQL.Append(" amount,")
                builSQL.Append(" days,")
                builSQL.Append(" update_date")
                builSQL.Append(" ) VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@����敪�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�Ώ۔N��")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�ڕW�z")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�c�Ɠ���")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�X�V��")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace
