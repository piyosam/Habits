#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>��v��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class d0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "d0500_�������o���o�^"

        ''' <summary>���̓��o���ԍ��i�ő�l+1�j���擾</summary>
        ''' <param name="v_date">���o����("yyyy/MM/dd")</param>
        ''' <returns>���o���ԍ�</returns>
        ''' <remarks>�����̓��o���ԍ�=1�Ƃ���</remarks>
        Protected Friend Function E_�����o���ԍ��擾(ByVal v_date As Date) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim param As New Habits.DB.DBParameter

            Dim const_�J�n���o���ԍ� As Integer = 1
            Dim rtn As Integer = -1

            Try
                param.Clear()
                param.Add("@���o����", v_date)

                builSQL.Append("SELECT MAX(���o���ԍ�) AS ���o���ԍ�")
                builSQL.Append(" FROM E_���o��")
                builSQL.Append(" WHERE DATEDIFF(d, @���o����, ���o����) = 0")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

                If dt.Rows.Count = 0 Then
                    rtn = const_�J�n���o���ԍ�
                Else
                    If IsDBNull(dt.Rows(0).Item("���o���ԍ�")) Then
                        rtn = const_�J�n���o���ԍ�
                    Else
                        rtn = Integer.Parse(dt.Rows(0)("���o���ԍ�").ToString) + 1
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function


        ''' <summary>���o���̐V�K�o�^</summary>
        ''' <param name="v_hashtable">
        ''' SQL�p�����[�^(Hashtable)�F@���o����/@���o���ԍ�/@���o���敪�ԍ�/@���z
        '''                /@�S���Ҕԍ�/@�E�v/@�o�^��
        ''' </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ReceivingAndMakingPaymentsInsert(ByRef v_hashtable As Hashtable) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim tmp_int As Integer = 0

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                ' E_���o���e�[�u���o�^�p�����[�^
                param.Clear()
                param.Add("@���o����", v_hashtable("@���o����"))
                param.Add("@���o���ԍ�", v_hashtable("@���o���ԍ�"))
                param.Add("@���o���敪�ԍ�", v_hashtable("@���o���敪�ԍ�"))
                param.Add("@���z", v_hashtable("@���z"))
                param.Add("@�S���Ҕԍ�", v_hashtable("@�S���Ҕԍ�"))
                param.Add("@�E�v", v_hashtable("@�E�v"))
                param.Add("@�o�^��", v_hashtable("@�o�^��"))

                ' E_���o�Ƀe�[�u���Ƀf�[�^��o�^
                builSQL.Append("INSERT INTO E_���o�� (")
                builSQL.Append(" ���o����,")
                builSQL.Append(" ���o���ԍ�,")
                builSQL.Append(" ���o���敪�ԍ�,")
                builSQL.Append(" ���z,")
                builSQL.Append(" �S���Ҕԍ�,")
                builSQL.Append(" �E�v,")
                builSQL.Append(" �o�^�� )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @���o����,")
                builSQL.Append(" @���o���ԍ�,")
                builSQL.Append(" @���o���敪�ԍ�,")
                builSQL.Append(" @���z,")
                builSQL.Append(" @�S���Ҕԍ�,")
                builSQL.Append(" @�E�v,")
                builSQL.Append(" @�o�^�� )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO cash_book(")
                builSQL.Append(" shop_code,")
                builSQL.Append(" date,")
                builSQL.Append(" code,")
                builSQL.Append(" cash_division_code,")
                builSQL.Append(" amount,")
                builSQL.Append(" basis_staff_code,")
                builSQL.Append(" summary,")
                builSQL.Append(" insert_date)")

                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@���o����")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@���o���ԍ�")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@���o���敪�ԍ�")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@���z")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@�S���Ҕԍ�")) & ", ")
                builSQL.Append(VbSQLNStr(param.GetValue("@�E�v")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@�o�^��")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>���o���������擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���o���N��(yyyyMMdd)</param>
        ''' <returns>���o����񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSelectedPaymentsHistory(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_���o��.���o���� AS ���o����,")
                builSQL.Append(" CONVERT(varchar, E_���o��.���o���ԍ�) AS �ԍ�,")
                builSQL.Append(" E_���o��.���o���敪�ԍ� AS ���o���敪�ԍ�,")
                builSQL.Append(" CASE E_���o��.���o���敪�ԍ�")
                builSQL.Append(" WHEN 1 THEN E_���o��.���z")
                builSQL.Append(" END AS ����,")
                builSQL.Append(" CASE E_���o��.���o���敪�ԍ�")
                builSQL.Append(" WHEN 2 THEN E_���o��.���z")
                builSQL.Append(" END AS �o��,")
                builSQL.Append(" D_�S����.�S���Җ� AS �S���Җ�,")
                builSQL.Append(" E_���o��.�E�v AS �E�v")
                builSQL.Append(" FROM E_���o�� INNER JOIN D_�S���� ON E_���o��.�S���Ҕԍ� = D_�S����.�S���Ҕԍ�")
                builSQL.Append(" WHERE E_���o��.���o����")
                builSQL.Append(" BETWEEN @�����J�n��")
                builSQL.Append(" AND @�����I����")
                builSQL.Append(" ORDER BY E_���o��.���o���� ASC, E_���o��.���o���ԍ� ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function


        ''' <summary>E_���o���e�[�u���̓��o���ԍ����݊m�F</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���o����/@���o���ԍ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function IsExistPaymentsNumber(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 1")
                builSQL.Append(" FROM E_���o��")
                builSQL.Append(" WHERE ���o���� = @���o����")
                builSQL.Append(" AND ���o���ԍ� = @���o���ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>���o���������폜</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���o�����A@���o���ԍ�</param>
        ''' <remarks></remarks>
        Protected Friend Sub DeletePaymentsHistory(ByVal v_param As Habits.DB.DBParameter)
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Dim param As New Habits.DB.DBParameter

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '------------------------------
                'E_���o�� DELETE
                '------------------------------
                str_sql = "DELETE FROM E_���o�� WHERE ���o���� = @���o���� AND ���o���ԍ� = @���o���ԍ�"

                DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM cash_book")
                builSQL.Append(" WHERE shop_code =" & VbSQLNStr(sShopcode))
                builSQL.Append(" AND date =" & VbSQLStr(v_param.GetValue("@���o����")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@���o���ԍ�")))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub

        ''' <summary>�����o�̓p�X�擾</summary>
        ''' <returns>�����o�̓p�X</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As String
            Dim rtn As String
            rtn = getPath(1)
            Return rtn
        End Function

        ''' <summary>�����o�̓p�X�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�����o�̓p�X��/@�ύX����</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_ASY(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Dim str_sql As String
            Try
                str_sql = "UPDATE A_�V�X�e�� SET �����o�̓p�X�� = @�����o�̓p�X�� , �ύX���� = @�ύX����"
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                str_sql = "UPDATE system SET order_output_path=" & VbSQLNStr(v_param.GetValue("@�����o�̓p�X��")) & _
                        ", update_date = " & VbSQLStr(v_param.GetValue("@�ύX����")) & " WHERE shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

    End Class
End Namespace
