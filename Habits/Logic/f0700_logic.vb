#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>���[�J�[��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class f0700_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0700_���[�J�["

        ''' <summary>���[�J�[�ꗗ�擾</summary>
        ''' <returns>���[�J�[���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_maker() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT ���[�J�[�ԍ� AS �ԍ�, ���[�J�[��, �\����,")
                builSQL.Append(" CASE WHEN �폜�t���O = 'False'")
                builSQL.Append(" THEN '  ' ELSE '�~' END AS �\��")
                builSQL.Append(" FROM C_���[�J�[")
                builSQL.Append(" ORDER BY �\����,���[�J�[�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���[�J�[�ԍ����݃`�F�b�N</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���[�J�[�ԍ�</param>
        ''' <returns>���[�J�[�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_number(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT ���[�J�[�ԍ�")
                builSQL.Append(" FROM C_���[�J�[")
                builSQL.Append(" WHERE ���[�J�[�ԍ� = @���[�J�[�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���[�J�[�����݃`�F�b�N</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���[�J�[��</param>
        ''' <returns>���[�J�[��</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_makername(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT ���[�J�[��")
                builSQL.Append(" FROM C_���[�J�[")
                builSQL.Append(" WHERE ���[�J�[�� = @���[�J�[��")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���[�J�[���o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���[�J�[�ԍ�/@���[�J�[��/@�\����/@�폜�t���O/@�o�^��/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_makerinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("INSERT INTO C_���[�J�[(")
                builSQL.Append(" ���[�J�[�ԍ�,")
                builSQL.Append(" ���[�J�[��,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �폜�t���O,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��)")

                builSQL.Append(" VALUES(@���[�J�[�ԍ�, @���[�J�[��, @�\����, @�폜�t���O, @�o�^��, @�X�V��)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO maker(")
                builSQL.Append(" shop_code,")       '�X�܃R�[�h
                builSQL.Append(" code,")            '���[�J�[�ԍ�
                builSQL.Append(" name,")            '���[�J�[��
                builSQL.Append(" display_order,")   '�\����
                builSQL.Append(" delete_flag,")     '�폜�t���O
                builSQL.Append(" insert_date,")     '�o�^��
                builSQL.Append(" update_date)")     '�X�V��
                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@���[�J�[�ԍ�")) & ", ")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@���[�J�[��")) & ", ")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�\����")) & ", ")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�o�^��")) & ", ")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�X�V��")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>��Ǝ��ԏ��X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���[�J�[��/@�\����/@�폜�t���O/@�X�V��/@���[�J�[�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_makerinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("UPDATE C_���[�J�[ SET")
                builSQL.Append(" ���[�J�[�� = @���[�J�[��,")
                builSQL.Append(" �\���� = @�\����,")
                builSQL.Append(" �폜�t���O = @�폜�t���O,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ���[�J�[�ԍ� = @���[�J�[�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE maker SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@���[�J�[��")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@���[�J�[�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�ő僁�[�J�[�ԍ��擾</summary>
        ''' <returns>���[�J�[�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_nextnum() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(���[�J�[�ԍ�) AS �ő僁�[�J�[�ԍ� FROM C_���[�J�["
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace