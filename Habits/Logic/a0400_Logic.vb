#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>��Ǝ��Ԑݒ�i�{�p���ԁj��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0400_��Ǝ��Ԑݒ�"

        ''' <summary>��Ǝ��ԏ��X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_a0400_��Ǝ��Ԑݒ�(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '------------------------------
                'E_���X�� UPDATE
                '------------------------------
                builSQL.Append("UPDATE E_���X�� ")
                builSQL.Append(" SET ��ƊJ�n = @��ƊJ�n, ��ƏI�� = @��ƏI��, �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ���X�� = @���X��")
                builSQL.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE visit SET")
                builSQL.Append(" start_date=" & VbSQLStr(v_param.GetValue("@��ƊJ�n")))     '��ƊJ�n       (datetime)
                builSQL.Append(",end_date=" & VbSQLStr(v_param.GetValue("@��ƏI��")))       '��ƏI��       (datetime)
                builSQL.Append(",update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))      '�X�V��         (datetime)
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@���X��")))       '���X��         (datetime)
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))   '���X�ԍ�       (smallint)
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))  '�ڋq�ԍ�       (int)
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '�X�܃R�[�h     (varchar)
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                DBA.TransactionCommit()
            Catch ex As Exception
                ''��O���̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace