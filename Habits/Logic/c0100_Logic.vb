#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�����ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class c0100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0100_����"

#Region "������擾"
        ''' <summary>������擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>������</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_����.���X��")
                builSQL.Append(" ,E_����.���X�Ҕԍ�")
                builSQL.Append(" ,E_����.�ڋq�ԍ�")
                builSQL.Append(" ,E_����.���ʔԍ�")
                builSQL.Append(" ,E_����.�N��")
                builSQL.Append(" ,E_����.��S���Ҕԍ�")
                builSQL.Append(" ,E_����.���X�敪�ԍ�")
                builSQL.Append(" ,E_����.�w��")
                builSQL.Append(" ,E_����.�J�[�h�x��")
                builSQL.Append(" ,E_����.�J�[�h��Дԍ�")
                builSQL.Append(" ,E_����.�����x��")
                builSQL.Append(" ,E_����.���a��")
                builSQL.Append(" ,E_����.�����")
                builSQL.Append(" ,E_����.���̑��x��")
                builSQL.Append(" ,E_����.�|�C���g�����ԍ�")
                builSQL.Append(" ,E_����.�|�C���g�����x��")
                builSQL.Append(" ,E_���X��.�T�[�r�X�ԍ�")
                builSQL.Append(" ,E_���X��.�T�[�r�X�敪")
                builSQL.Append(" ,E_���X��.�T�[�r�X���z")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" LEFT OUTER JOIN E_���X��")
                builSQL.Append(" ON E_���X��.���X��=E_����.���X��")
                builSQL.Append(" AND E_���X��.���X�Ҕԍ�=E_����.���X�Ҕԍ�")
                builSQL.Append(" AND E_���X��.�ڋq�ԍ�=E_����.�ڋq�ԍ�")
                builSQL.Append(" WHERE E_����.�ڋq�ԍ�=@�ڋq�ԍ�")
                builSQL.Append(" AND E_����.���X��=@���X��")
                builSQL.Append(" AND E_����.���X�Ҕԍ�=@���X�Ҕԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���O�o�͗p������擾"
        ''' <summary>������擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>������</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesInfoForLog(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT CONVERT(varchar, E_���X��.���X��,111),E_���X��.���X�Ҕԍ�,E_���X��.�ڋq�ԍ�")
                builSQL.Append(" ,�� +' '+�� AS �ڋq��,�S���Җ� AS ��S���Җ�,ISNULL(����,0)")
                builSQL.Append(" FROM (SELECT ���X��,���X�Ҕԍ�,�ڋq�ԍ�,SUM(���� * ���z - �T�[�r�X) AS ����")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE �ڋq�ԍ�=@�ڋq�ԍ� AND ���X��=@���X�� AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�,�ڋq�ԍ�")
                builSQL.Append(" ) AS SALES")
                builSQL.Append(" RIGHT OUTER JOIN E_���X��")
                builSQL.Append("  ON SALES.���X��= E_���X��.���X��")
                builSQL.Append("  AND SALES.���X�Ҕԍ�= E_���X��.���X�Ҕԍ�")
                builSQL.Append(" LEFT OUTER JOIN D_�S����")
                builSQL.Append("  ON D_�S����.�S���Ҕԍ�= E_���X��.��S���Ҕԍ�")
                builSQL.Append(" WHERE E_���X��.�ڋq�ԍ�=@�ڋq�ԍ� AND E_���X��.���X��=@���X�� AND E_���X��.���X�Ҕԍ�=@���X�Ҕԍ�")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���X�g�f�[�^�擾"

#Region "���X�敪���X�g�擾"
        '''<summary>���X�敪���X�g�擾</summary>
        ''' <returns>���X�敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function getVisitDiv() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ���X�敪�ԍ�,���X�敪 FROM B_���X�敪 ORDER BY ���X�敪�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "����敪���X�g�擾"
        '''<summary>����敪���X�g�擾</summary>
        ''' <returns>�L���Ȕ���敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDivList() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT ����敪�ԍ�,����敪 FROM B_����敪 WHERE �폜�t���O = 'False' ORDER BY �\����,����敪�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���[�J�[���X�g�擾"
        ''' <summary>���[�J�[�ꗗ�擾</summary>
        ''' <returns>���[�J�[���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function getMakerList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT ���[�J�[�ԍ�,���[�J�[��")
                builSQL.Append(" FROM C_���[�J�[")
                builSQL.Append(" WHERE ���[�J�[�ԍ� IN ")
                builSQL.Append(" (SELECT DISTINCT ���[�J�[�ԍ�")
                builSQL.Append(" FROM C_���i")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND �폜�t���O = 'False')")
                builSQL.Append(" ORDER BY �\����")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���i���X�g�擾"
        ''' <summary>���i���X�g�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���[�J�[�ԍ�</param>
        ''' <returns>���i�̔����z���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function getGoods(ByVal v_param As Habits.DB.DBParameter, ByVal makerFlag As Boolean) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT ���i�ԍ�,���i��,�̔����z,���z�Ǘ��敪")
                builSQL.Append(" FROM C_���i")
                builSQL.Append(" WHERE (����敪�ԍ� = @����敪�ԍ�)")
                builSQL.Append(" AND (���ޔԍ� = @���ޔԍ�)")
                If (makerFlag) Then
                    builSQL.Append(" AND (���[�J�[�ԍ� = @���[�J�[�ԍ�)")
                End If
                builSQL.Append(" AND (�폜�t���O='False')")
                builSQL.Append(" ORDER BY �\����,���i�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#End Region

#Region "�f�[�^�X�V"

#Region "�ڋq�f�[�^�X�V"
        ''' <summary>D_�ڋq�f�[�^�X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_�ڋq�f�[�^�X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '' D_�ڋq�Ƀf�[�^���X�V
                builSQL.Append("UPDATE D_�ڋq")
                builSQL.Append(" SET ���ʔԍ�=@���ʔԍ�,��S���Ҕԍ�=@��S���Ҕԍ�,�X�V��=@�X�V��")
                builSQL.Append(" WHERE �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE basis_customer")
                builSQL.Append(" SET gender_code=" & VbSQLStr(v_param.GetValue("@���ʔԍ�")))
                builSQL.Append(",main_staff_code=" & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")))
                builSQL.Append(",update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "���X�҃f�[�^�X�V�i��ʂ̃f�[�^�ێ��j"
        ''' <summary>���X�҃f�[�^�X�V�i��ʂ̃f�[�^�ێ��j</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>������o�^���A��ʂ̒l��E_���X�҂ɐݒ肷��</remarks>
        Protected Friend Function E_���X�҃f�[�^�ێ�(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                '' E_���X�҂Ƀf�[�^��o�^
                builSQL.Append("UPDATE E_���X��")
                builSQL.Append(" SET ��S���Ҕԍ�=@��S���Ҕԍ�")
                builSQL.Append(" ,�w��=@�w��,�X�V��=@�X�V��")
                builSQL.Append(" ,�|�C���g�����ԍ�=@�|�C���g�����ԍ�")
                builSQL.Append(" ,�|�C���g�����x��=@�|�C���g�����x��")
                builSQL.Append(" ,�T�[�r�X�ԍ�=@�T�[�r�X�ԍ�")
                builSQL.Append(" ,�T�[�r�X�敪=@�T�[�r�X�敪")
                builSQL.Append(" ,�T�[�r�X���z=@�T�[�r�X���z")
                builSQL.Append(" WHERE �ڋq�ԍ�=@�ڋq�ԍ�")
                builSQL.Append("  AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append("  AND ���X��=@���X��")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE visit")
                builSQL.Append(" SET main_staff_code=" & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")))
                builSQL.Append(",designated_flag=" & VbSQLStr(v_param.GetValue("@�w��")))
                builSQL.Append(",update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(",point_purchases_code=" & VbSQLStr(v_param.GetValue("@�|�C���g�����ԍ�")))
                builSQL.Append(",point_purchases=" & VbSQLStr(v_param.GetValue("@�|�C���g�����x��")))
                builSQL.Append(",service_code=" & VbSQLStr(v_param.GetValue("@�T�[�r�X�ԍ�")))
                builSQL.Append(",service_type=" & VbSQLStr(v_param.GetValue("@�T�[�r�X�敪")))
                builSQL.Append(",service_amount=" & VbSQLStr(v_param.GetValue("@�T�[�r�X���z")))
                builSQL.Append(" WHERE basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" AND date=" & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "���㖾�׍폜"
        '''<summary>E_���㖾�ׂ�E_�|�C���g�̍폜</summary>
        ''' <param name="v_param">@����ԍ�/@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�/@�S���Ҕԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function ���㖾�׍폜(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                'E_���㖾�׍폜
                builSQL.Length = 0
                builSQL.Append("DELETE FROM E_���㖾��")
                builSQL.Append(" WHERE ����ԍ�=@����ԍ�")
                builSQL.Append(" AND ���X��=@���X��")
                builSQL.Append(" AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM sales_details")
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@����ԍ�")))
                builSQL.Append(" AND visit_date=" & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                'E_�|�C���g�폜
                �|�C���g�폜(v_param, PAGE_TITLE)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#End Region

#Region "���㖾�׎擾"
        ''' <summary>E_���㖾�׎擾</summary>
        ''' <param name="v_param">@����ԍ�/@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>���㖾��</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_���㖾�׎擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT * FROM E_���㖾��")
                builSQL.Append(" WHERE ����ԍ�=@����ԍ�")
                builSQL.Append(" AND ���X��=@���X��")
                builSQL.Append(" AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

    End Class
End Namespace
