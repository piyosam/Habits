#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�J�[�h��Љ�ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class f0800_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0800_�J�[�h���"

        ''' <summary>�J�[�h��Јꗗ�擾</summary>
        ''' <returns>�J�[�h��Ѓ��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_cardinfo() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT �J�[�h��Дԍ� AS �ԍ�, �J�[�h��Ж�, �\����,")
                builSQL.Append(" CASE WHEN �폜�t���O = 'False' THEN '  ' ELSE '�~' END AS �\��")
                builSQL.Append(" FROM C_�J�[�h���")
                builSQL.Append(" ORDER BY �\����,�J�[�h��Дԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�J�[�h��Дԍ����݃`�F�b�N</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�[�h��Дԍ�</param>
        ''' <returns>�J�[�h��Дԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_number(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �J�[�h��Дԍ� FROM C_�J�[�h��� WHERE �J�[�h��Дԍ� = @�J�[�h��Дԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�J�[�h��Ж����݃`�F�b�N</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�[�h��Ж�</param>
        ''' <returns>�J�[�h��Ж�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_cardname(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �J�[�h��Ж� FROM C_�J�[�h��� WHERE �J�[�h��Ж� = @�J�[�h��Ж�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�J�[�h��Џ��o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�[�h��Дԍ�/@�J�[�h��Ж�/@�\����/@�폜�t���O/@�o�^��/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_cardinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("INSERT INTO C_�J�[�h��� (")
                builSQL.Append(" �J�[�h��Дԍ�,")
                builSQL.Append(" �J�[�h��Ж�,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �폜�t���O,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��)")

                builSQL.Append(" VALUES (@�J�[�h��Дԍ�,@�J�[�h��Ж�, @�\����, @�폜�t���O, @�o�^��, @�X�V��)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO card_corporation (")
                builSQL.Append(" shop_code,")       '�X�܃R�[�h
                builSQL.Append(" code,")            '�J�[�h��Дԍ�
                builSQL.Append(" name,")            '�J�[�h��Ж�
                builSQL.Append(" display_order,")   '�\����
                builSQL.Append(" delete_flag,")     '�폜�t���O
                builSQL.Append(" insert_date,")     '�o�^��
                builSQL.Append(" update_date)")     '�X�V��
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�J�[�h��Дԍ�")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@�J�[�h��Ж�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�o�^��")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�X�V��")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�J�[�h��Џ��X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�[�h��Дԍ�/@�J�[�h��Ж�/@�\����/@�폜�t���O/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_cardinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append(" UPDATE C_�J�[�h��� SET")
                builSQL.Append(" �J�[�h��Ж� = @�J�[�h��Ж�,")
                builSQL.Append(" �\���� = @�\����,")
                builSQL.Append(" �폜�t���O = @�폜�t���O,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE �J�[�h��Дԍ� = @�J�[�h��Дԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append(" UPDATE card_corporation SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@�J�[�h��Ж�")) & "")
                builSQL.Append(" ,display_order =" & VbSQLStr(v_param.GetValue("@�\����")) & "")
                builSQL.Append(" ,delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")) & "")
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@�J�[�h��Дԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�J�[�h��Дԍ��ő�擾�擾</summary>
        ''' <returns>�ő�J�[�h��Дԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function �J�[�h���_�ő�ԍ��擾() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(�J�[�h��Дԍ�) AS �ő�ԍ� FROM C_�J�[�h���"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace