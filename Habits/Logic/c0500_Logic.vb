#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�����ݒ��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class c0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0500_�����ݒ�"

        ''' <summary>�����f�[�^�X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�X�V��/@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_c0500_����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As Integer
            Try
                builSQL.Append("UPDATE D_�ڋq")
                builSQL.Append(" SET ���� = @����, �`���t���O = @�`���t���O,�X�V�� = @�X�V��")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE basis_customer")
                builSQL.Append(" SET memo =" & VbSQLNStr(v_param.GetValue("@����")))
                builSQL.Append(",message_flag =" & VbSQLStr(v_param.GetValue("@�`���t���O")))
                builSQL.Append(",update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                ''��O���̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>�����f�[�^�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>����</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_c0500_����_Select(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT D_�ڋq.���� FROM D_�ڋq WHERE �ڋq�ԍ�=@�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace