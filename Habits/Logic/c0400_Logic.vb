#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>��v��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class c0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0400_��v"

#Region "����敪�ʃ��X�g�擾 "
        ''' <summary>����敪�ʃ��X�g�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ����敪�ʔ��ナ�X�g�擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(E_���㖾��.���X��) AS ���X��")
                builSQL.Append(" ,MAX(E_���㖾��.���X�Ҕԍ�) AS ���X�Ҕԍ�")
                builSQL.Append(" ,MAX(E_���㖾��.�ڋq�ԍ�) AS �ڋq�ԍ�")
                builSQL.Append(" ,E_���㖾��.����敪�ԍ�")
                builSQL.Append(" ,MAX(B_����敪.����敪) AS ����敪")
                builSQL.Append(" ,SUM(E_���㖾��.����) AS ���v����")
                builSQL.Append(" ,SUM(E_���㖾��.���z * E_���㖾��.����) AS ���v���z")
                builSQL.Append(" ,SUM(E_���㖾��.�T�[�r�X *-1) AS �T�[�r�X")
                builSQL.Append(" ,SUM(E_���㖾��.�����) AS �����")
                builSQL.Append(" FROM E_���㖾�� LEFT OUTER JOIN")
                builSQL.Append(" B_����敪 ON E_���㖾��.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" WHERE (E_���㖾��.���X�� = @���X��)")
                builSQL.Append(" AND (E_���㖾��.�ڋq�ԍ� = @�ڋq�ԍ�)")
                builSQL.Append(" AND (E_���㖾��.���X�Ҕԍ� = @���X�Ҕԍ�)")
                builSQL.Append(" GROUP BY E_���㖾��.����敪�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_����擾"
        ''' <summary>E_����擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>������</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_����擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT * FROM E_����")
                builSQL.Append(" WHERE ���X�� = @���X��")
                builSQL.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_�ڋq�擾"
        ''' <summary>D_�ڋq�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>�ڋq���</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_�ڋq�擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT (�� + ' ' + ISNULL(��,'')) AS ����,(���J�i + ' ' + ISNULL(���J�i,'')) AS �����J�i,")
                builSQL.Append(" ���N����, �o�^�敪�ԍ�, �O�񗈓X��,�s���{��,�Z��1,���X��N_1,")
                builSQL.Append(" ���X��N_2,���X��,��S���Ҕԍ�,�o�^��,�X�V��")
                builSQL.Append(" FROM D_�ڋq")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("�ڋq���̎擾�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_���X�Ҏ擾"
        ''' <summary>E_���X�Ҏ擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>���X�ҏ��</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_���X�Ҏ擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT * FROM E_���X�� WHERE ���X�� = @���X�� AND ���X�Ҕԍ� = @���X�Ҕԍ� AND �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_����ǉ�"
        ''' <summary>E_����ǉ�</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_E_����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("INSERT INTO E_����(")
                builSQL.Append(" ���X��")
                builSQL.Append(" ,���X�Ҕԍ�")
                builSQL.Append(" ,�ڋq�ԍ�")
                builSQL.Append(" ,���ʔԍ�")
                builSQL.Append(" ,�N��")
                builSQL.Append(" ,��S���Ҕԍ�")
                builSQL.Append(" ,���X�敪�ԍ�")
                builSQL.Append(" ,�w��")
                builSQL.Append(" ,�J�[�h�x��")
                builSQL.Append(" ,�J�[�h��Дԍ�")
                builSQL.Append(" ,�����x��")
                builSQL.Append(" ,���a��")
                builSQL.Append(" ,�����")
                builSQL.Append(" ,�X�V��")
                builSQL.Append(" ,���̑��x��")
                builSQL.Append(" ,�|�C���g�����ԍ�")
                builSQL.Append(" ,�|�C���g�����x��")
                builSQL.Append(" ,�T�[�r�X�ԍ�")
                builSQL.Append(" ,�T�[�r�X���z")

                builSQL.Append(" )VALUES(")
                builSQL.Append(" @���X��")
                builSQL.Append(" ,@���X�Ҕԍ�")
                builSQL.Append(" ,@�ڋq�ԍ�")
                builSQL.Append(" ,@���ʔԍ�")
                builSQL.Append(" ,@�N��")
                builSQL.Append(" ,@��S���Ҕԍ�")
                builSQL.Append(" ,@���X�敪�ԍ�")
                builSQL.Append(" ,@�w��")
                builSQL.Append(" ,@�J�[�h�x��")
                builSQL.Append(" ,@�J�[�h��Дԍ�")
                builSQL.Append(" ,@�����x��")
                builSQL.Append(" ,@���a��")
                builSQL.Append(" ,@�����")
                builSQL.Append(" ,@�X�V��")
                builSQL.Append(" ,@���̑��x��")
                builSQL.Append(" ,@�|�C���g�����ԍ�")
                builSQL.Append(" ,@�|�C���g�����x��")
                builSQL.Append(" ,@�T�[�r�X�ԍ�")
                builSQL.Append(" ,@�T�[�r�X���z")
                builSQL.Append(" )")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO sales(")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,visit_date")
                builSQL.Append(" ,visit_number")
                builSQL.Append(" ,basis_customer_code")
                builSQL.Append(" ,gender_code")
                builSQL.Append(" ,age")
                builSQL.Append(" ,main_staff_code")
                builSQL.Append(" ,visit_division_code")
                builSQL.Append(" ,designated_flag")
                builSQL.Append(" ,credit_purchases")
                builSQL.Append(" ,card_corporation_code")
                builSQL.Append(" ,cash_purchases")
                builSQL.Append(" ,deposit")
                builSQL.Append(" ,tax")
                builSQL.Append(" ,update_date")
                builSQL.Append(" ,other_purchases")
                builSQL.Append(" ,point_purchases_code")
                builSQL.Append(" ,point_purchases")
                builSQL.Append(" ,service_code")
                builSQL.Append(" ,service_amount")

                builSQL.Append(" )VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���ʔԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�N��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���X�敪�ԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�w��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�J�[�h�x��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�J�[�h��Дԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�����x��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���a��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�����")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���̑��x��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�|�C���g�����ԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�|�C���g�����x��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�T�[�r�X�ԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�T�[�r�X���z")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("����f�[�^�̓o�^�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "E_����X�V"
        ''' <summary>E_����X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE E_���� SET")
                builSQL.Append(" ���X�� = @���X��")
                builSQL.Append(" ,���X�Ҕԍ� = @���X�Ҕԍ�")
                builSQL.Append(" ,�ڋq�ԍ� = @�ڋq�ԍ�")
                builSQL.Append(" ,���ʔԍ� = @���ʔԍ�")
                builSQL.Append(" ,�N�� = @�N��")
                builSQL.Append(" ,��S���Ҕԍ� = @��S���Ҕԍ�")
                builSQL.Append(" ,���X�敪�ԍ� = @���X�敪�ԍ�")
                builSQL.Append(" ,�w�� = @�w��")
                builSQL.Append(" ,�J�[�h�x�� = @�J�[�h�x��")
                builSQL.Append(" ,�J�[�h��Дԍ� = @�J�[�h��Дԍ�")
                builSQL.Append(" ,�����x�� = @�����x��")
                builSQL.Append(" ,���a�� = @���a��")
                builSQL.Append(" ,����� = @�����")
                builSQL.Append(" ,�X�V�� = @�X�V��")
                builSQL.Append(" ,���̑��x�� = @���̑��x��")
                builSQL.Append(" ,�|�C���g�����ԍ� = @�|�C���g�����ԍ�")
                builSQL.Append(" ,�|�C���g�����x�� = @�|�C���g�����x��")
                builSQL.Append(" ,�T�[�r�X�ԍ� = @�T�[�r�X�ԍ�")
                builSQL.Append(" ,�T�[�r�X���z = @�T�[�r�X���z")

                builSQL.Append(" WHERE ���X��=@���X��")
                builSQL.Append(" AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE sales SET")
                builSQL.Append(" visit_date =" & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" ,visit_number =" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" ,basis_customer_code =" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" ,gender_code =" & VbSQLStr(v_param.GetValue("@���ʔԍ�")))
                builSQL.Append(" ,age =" & VbSQLStr(v_param.GetValue("@�N��")))
                builSQL.Append(" ,main_staff_code =" & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")))
                builSQL.Append(" ,visit_division_code =" & VbSQLStr(v_param.GetValue("@���X�敪�ԍ�")))
                builSQL.Append(" ,designated_flag =" & VbSQLStr(v_param.GetValue("@�w��")))
                builSQL.Append(" ,credit_purchases =" & VbSQLStr(v_param.GetValue("@�J�[�h�x��")))
                builSQL.Append(" ,card_corporation_code =" & VbSQLStr(v_param.GetValue("@�J�[�h��Дԍ�")))
                builSQL.Append(" ,cash_purchases =" & VbSQLStr(v_param.GetValue("@�����x��")))
                builSQL.Append(" ,deposit =" & VbSQLStr(v_param.GetValue("@���a��")))
                builSQL.Append(" ,tax =" & VbSQLStr(v_param.GetValue("@�����")))
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" ,other_purchases =" & VbSQLStr(v_param.GetValue("@���̑��x��")))
                builSQL.Append(" ,point_purchases_code =" & VbSQLStr(v_param.GetValue("@�|�C���g�����ԍ�")))
                builSQL.Append(" ,point_purchases =" & VbSQLStr(v_param.GetValue("@�|�C���g�����x��")))
                builSQL.Append(" ,service_code =" & VbSQLStr(v_param.GetValue("@�T�[�r�X�ԍ�")))
                builSQL.Append(" ,service_amount =" & VbSQLStr(v_param.GetValue("@�T�[�r�X���z")))

                builSQL.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "�J�[�h��Ѓ��X�g�擾"
        ''' <summary>�J�[�h��Ѓ��X�g�擾</summary>
        ''' <returns>�J�[�h��Ѓ��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function �J�[�h��Ѓ��X�g�擾() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT")
                builSQL.Append(" C_�J�[�h���.�J�[�h��Дԍ�")
                builSQL.Append(" ,C_�J�[�h���.�J�[�h��Ж�")
                builSQL.Append(" FROM C_�J�[�h���")
                builSQL.Append(" WHERE C_�J�[�h���.�폜�t���O = 'False'")
                builSQL.Append(" ORDER BY C_�J�[�h���.�\����")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_�ڋq�X�V"
        '''<summary>D_�ڋq�X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_�ڋq�X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE D_�ڋq SET")
                builSQL.Append(" ���ʔԍ�=@���ʔԍ�,")
                builSQL.Append(" ��S���Ҕԍ�=@��S���Ҕԍ�,")
                builSQL.Append(" �o�^�敪�ԍ�=@�o�^�敪�ԍ�,")
                builSQL.Append(" �O�񗈓X��=@�O�񗈓X��,")
                builSQL.Append(" ���X��N_2=@���X���m�Q,")
                builSQL.Append(" ���X��N_1=@���X���m�P,")
                builSQL.Append(" �X�V��=@�X�V��,")
                builSQL.Append(" �`���t���O = 0")
                builSQL.Append(" WHERE �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" gender_code=" & VbSQLStr(v_param.GetValue("@���ʔԍ�")) & ",")
                builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")) & ",")
                builSQL.Append(" register_code=" & VbSQLStr(v_param.GetValue("@�o�^�敪�ԍ�")) & ",")
                builSQL.Append(" last_visit_date=" & VbSQLStr(v_param.GetValue("@�O�񗈓X��")) & ",")
                builSQL.Append(" two_before_last_visit_date=" & VbSQLStr(v_param.GetValue("@���X���m�Q")) & ",")
                builSQL.Append(" one_before_last_visit_date=" & VbSQLStr(v_param.GetValue("@���X���m�P")) & ",")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")) & ",")
                builSQL.Append(" message_flag = 0")
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "E_���X�ҍX�V"
        '''<summary>E_���X�ҍX�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@��S���Ҕԍ�/@��ƏI��/@�X�V��/@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_���X�ҍX�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE E_���X�� SET")
                builSQL.Append(" ��S���Ҕԍ�=@��S���Ҕԍ�,")
                builSQL.Append(" ���X�敪�ԍ� = @���X�敪�ԍ�,")
                builSQL.Append(" �w�� = @�w��,")
                builSQL.Append(" ��ƏI��=@��ƏI��,")
                builSQL.Append(" ��v��=1,")
                builSQL.Append(" �X�V��=@�X�V��")
                builSQL.Append(" WHERE ���X��=@���X��")
                builSQL.Append(" AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0

                builSQL.Append("UPDATE visit SET")
                builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")) & ",")
                builSQL.Append(" visit_division_code=" & VbSQLStr(v_param.GetValue("@���X�敪�ԍ�")) & ",")
                builSQL.Append(" designated_flag=" & VbSQLStr(v_param.GetValue("@�w��")) & ",")
                builSQL.Append(" end_date=" & VbSQLStr(v_param.GetValue("@��ƏI��")) & ",")
                builSQL.Append(" paid_flag=''1'',")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "�X�̑Ώۂ̔��㖾�ׂ̎擾"
        ''' <summary>�X�̑Ώۂ̔��㖾�ׂ̎擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>���㖾��</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_���㖾��_�X��(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT E_���㖾��.���X��,")
                builSQL.Append(" E_���㖾��.���X�Ҕԍ�,")
                builSQL.Append(" E_���㖾��.�ڋq�ԍ�,")
                builSQL.Append(" E_���㖾��.����ԍ�,")
                builSQL.Append(" E_���㖾��.����S���Ҕԍ�,")
                builSQL.Append(" E_���㖾��.����敪�ԍ�,")
                builSQL.Append(" E_���㖾��.���ޔԍ�,")
                builSQL.Append(" E_���㖾��.���̔ԍ�,")
                builSQL.Append(" E_���㖾��.����,")
                builSQL.Append(" E_���㖾��.���z,")
                builSQL.Append(" E_���㖾��.�T�[�r�X�ԍ�,")
                builSQL.Append(" E_���㖾��.�T�[�r�X,")
                builSQL.Append(" E_���㖾��.��v��,")
                builSQL.Append(" C_����.�X�̑Ώۃt���O")
                builSQL.Append(" FROM E_���㖾�� LEFT OUTER JOIN")
                builSQL.Append(" C_���� ON E_���㖾��.����敪�ԍ� = C_����.����敪�ԍ�")
                builSQL.Append(" AND E_���㖾��.���ޔԍ� = C_����.���ޔԍ�")
                builSQL.Append(" WHERE (C_����.�X�̑Ώۃt���O = 1)")
                builSQL.Append(" AND ���X��=@���X��")
                builSQL.Append(" AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("�X�̑Ώۂ̔��㖾�׎擾�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���o�Ƀf�[�^�̓o�^"
        ''' <summary>���o�Ƀf�[�^�̓o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_���o�ɒǉ�(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("INSERT INTO E_���o��(")
                builSQL.Append(" ���o�ɓ�,")
                builSQL.Append(" ���o�ɔԍ�,")
                builSQL.Append(" ���o�ɋ敪�ԍ�,")
                builSQL.Append(" ���o�ɗ��R�ԍ�,")
                builSQL.Append(" ����敪�ԍ�,")
                builSQL.Append(" ���ޔԍ�,")
                builSQL.Append(" ���i�ԍ�,")
                builSQL.Append(" ���o�ɐ�,")
                builSQL.Append(" �S���Ҕԍ�,")
                builSQL.Append(" �o�^��)")
                builSQL.Append(" VALUES(")
                builSQL.Append(" @���o�ɓ�,")
                builSQL.Append(" @���o�ɔԍ�,")
                builSQL.Append(" @���o�ɋ敪�ԍ�,")
                builSQL.Append(" @���o�ɗ��R�ԍ�,")
                builSQL.Append(" @����敪�ԍ�,")
                builSQL.Append(" @���ޔԍ�,")
                builSQL.Append(" @���i�ԍ�,")
                builSQL.Append(" @���o�ɐ�,")
                builSQL.Append(" @�S���Ҕԍ�,")
                builSQL.Append(" @�o�^��)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlInsReceive_ship(v_param, False))

            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("���o�Ƀf�[�^�̓o�^�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region


#Region "�݌ɐ��̍X�V"
        ''' <summary>�݌ɐ��̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function C_���i�݌ɐ��X�V(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE C_���i SET")
                builSQL.Append(" �݌ɐ�= @�݌ɐ�")
                builSQL.Append(" ,�X�V��=@�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ�=@����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ�=@���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ�=@���i�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" stock =" & VbSQLStr(v_param.GetValue("@�݌ɐ�")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

    End Class
End Namespace
