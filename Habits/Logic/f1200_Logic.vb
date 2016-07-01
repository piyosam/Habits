#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�|�C���g������ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class f1200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1200_�|�C���g����"

        ''' <summary>B_�|�C���g�����擾</summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_�|�C���g�����擾() As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT �|�C���g�����ԍ� AS �ԍ�, �|�C���g������, �\����,")
                builSQL.Append(" CASE WHEN �폜�t���O = 'False' THEN '  ' ELSE '�~' END AS �\��,")
                builSQL.Append(" �o�^��,�X�V��")
                builSQL.Append(" FROM B_�|�C���g����")
                builSQL.Append(" ORDER BY �\����,�|�C���g�����ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' �|�C���g�����ԍ��ő�擾�擾
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function �|�C���g����_�ő�ԍ��擾() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(�|�C���g�����ԍ�) AS �ő�ԍ� FROM B_�|�C���g����"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        Protected Friend Function �I��B_�|�C���g�����擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "SELECT * FROM B_�|�C���g���� WHERE �|�C���g�����ԍ�=@�|�C���g�����ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' �|�C���g�������d���`�F�b�N�Ɏg�p
        ''' </summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function �I��B_�|�C���g�������擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "SELECT * FROM B_�|�C���g���� WHERE �|�C���g������=@�|�C���g������ AND �|�C���g�����ԍ�<>@�|�C���g�����ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' B_�|�C���g�����X�V
        ''' </summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_�|�C���g�����X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_�|�C���g���� SET")
                builSQL.Append(" �|�C���g������ = @�|�C���g������,")
                builSQL.Append(" �\���� = @�\����,")
                builSQL.Append(" �폜�t���O = @�폜�t���O,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE �|�C���g�����ԍ� = @�|�C���g�����ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE point_purchases SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@�|�C���g������")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@�|�C���g�����ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>
        ''' B_�|�C���g�����ǉ�
        ''' </summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_�|�C���g�����o�^(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_�|�C���g����")
                builSQL.Append(" (�|�C���g�����ԍ�,")
                builSQL.Append(" �|�C���g������,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �폜�t���O,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��)")

                builSQL.Append(" VALUES")
                builSQL.Append(" (@�|�C���g�����ԍ�,")
                builSQL.Append(" @�|�C���g������,")
                builSQL.Append(" @�\����,")
                builSQL.Append(" @�폜�t���O,")
                builSQL.Append(" @�o�^��,")
                builSQL.Append(" @�X�V��)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO point_purchases(")
                builSQL.Append(" shop_code,")       '�X�܃R�[�h
                builSQL.Append(" code,")            '�|�C���g�����ԍ�
                builSQL.Append(" name,")            '�|�C���g������
                builSQL.Append(" display_order,")   '�\����
                builSQL.Append(" delete_flag,")     '�폜�t���O
                builSQL.Append(" insert_date,")     '�o�^��
                builSQL.Append(" update_date)")     '�X�V��
                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�|�C���g�����ԍ�")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@�|�C���g������")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�o�^��")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�X�V��")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ''��O�����̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace
