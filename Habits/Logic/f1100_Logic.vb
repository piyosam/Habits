#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�H���}�X�^��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class f1100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1100_�H���}�X�^"

        ''' <summary>�H���ꗗ�擾</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function ���e�X�V() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                '�f�[�^���擾
                builSQL.Append("SELECT �H���ԍ�,�H����,�|�C���g,�\����,")
                builSQL.Append(" CASE WHEN �폜�t���O = 'False' THEN '  ' ELSE '�~' END AS �\��")
                builSQL.Append(" FROM B_�H��")
                builSQL.Append(" ORDER BY �\����,�H���ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>B_�H���o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�H���ԍ�/@�H����/@�|�C���g/@�폜�t���O/@�o�^��/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���o�^(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_�H��(")
                builSQL.Append(" �H���ԍ�,")
                builSQL.Append(" �H����,")
                builSQL.Append(" �|�C���g,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �폜�t���O,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @�H���ԍ�,")
                builSQL.Append(" @�H����,")
                builSQL.Append(" @�|�C���g,")
                builSQL.Append(" @�\����,")
                builSQL.Append(" @�폜�t���O,")
                builSQL.Append(" @�o�^��,")
                builSQL.Append(" @�X�V��)")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO process(")
                builSQL.Append(" shop_code,")
                builSQL.Append(" code,")        '�H���ԍ�
                builSQL.Append(" name,")        '�H����
                builSQL.Append(" point,")       '�|�C���g
                builSQL.Append(" display_order,")   '�\����
                builSQL.Append(" delete_flag,")     '�폜�t���O
                builSQL.Append(" insert_date,")     '�o�^��
                builSQL.Append(" update_date)")     '�X�V��
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�H���ԍ�")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@�H����")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�|�C���g")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�o�^��")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�X�V��")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>B_�H���̃|�C���g�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�H���ԍ�</param>
        ''' <returns>�|�C���g</returns>
        ''' <remarks></remarks>
        Protected Friend Function �ԍ��m�F(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �|�C���g FROM B_�H�� WHERE �H���ԍ� = @�H���ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���i�i�X�̑ΏۊO�j�̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�H����/@�|�C���g/@�\����/@�폜�t���O/@�X�V��/@�H���ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���ύX(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_�H�� SET")
                builSQL.Append(" �H���� = @�H����,")
                builSQL.Append(" �|�C���g = @�|�C���g,")
                builSQL.Append(" �\���� = @�\����,")
                builSQL.Append(" �폜�t���O = @�폜�t���O,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE �H���ԍ� = @�H���ԍ� ")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE process SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@�H����")) & ",")
                builSQL.Append(" point =" & VbSQLStr(v_param.GetValue("@�|�C���g")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@�H���ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>�ő�H���ԍ��擾</summary>
        ''' <returns>�ő�H���ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function getMaxProcessNumber() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(�H���ԍ�) AS �ő�ԍ� FROM B_�H��"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

    End Class

End Namespace
