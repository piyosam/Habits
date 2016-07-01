#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>���o�Ƀ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a1400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1400_���o�ɓo�^"

        ''' <summary>����敪���ꗗ���擾</summary>
        ''' <returns>����敪</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSalesDivisionNames() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT ����敪�ԍ�, ����敪 FROM B_����敪 ")
                builSQL.Append(" WHERE B_����敪.�폜�t���O = 0")
                builSQL.Append(" AND EXISTS ( ")
                builSQL.Append(" SELECT * FROM C_����")
                builSQL.Append(" WHERE C_����.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" AND C_����.�X�̑Ώۃt���O = 1")
                builSQL.Append(" AND C_����.�폜�t���O = 0 )")
                builSQL.Append(" ORDER BY �\����,����敪�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>���ޖ��ꗗ���擾</summary>
        ''' <param name="v_number">SQL�p�����[�^�F@����敪�ԍ�</param>
        ''' <returns>���ޖ����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityDivisionNames(ByVal v_number As String) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT ���ޔԍ�, ���ޖ� FROM C_����")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND �X�̑Ώۃt���O = 1")
                builSQL.Append(" AND �폜�t���O = 0")
                builSQL.Append(" AND EXISTS ( ")
                builSQL.Append(" SELECT * FROM C_���i")
                builSQL.Append(" INNER JOIN C_���[�J�[ ON")
                builSQL.Append(" C_���i.���[�J�[�ԍ� = C_���[�J�[.���[�J�[�ԍ�")
                builSQL.Append(" AND C_���[�J�[.�폜�t���O = 0")
                builSQL.Append(" WHERE C_���i.����敪�ԍ� = C_����.����敪�ԍ�")
                builSQL.Append(" AND C_���i.���ޔԍ� = C_����.���ޔԍ�")
                builSQL.Append(" AND C_���i.�폜�t���O = 0 )")
                builSQL.Append(" ORDER BY �\����,���ޔԍ�")

                '' �p�����[�^�ݒ�
                param.Add("@����敪�ԍ�", v_number)
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>���[�J�[���ꗗ���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�</param>
        ''' <returns>���[�J�[��</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetBrandNames(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT ���[�J�[�ԍ�, ���[�J�[�� FROM C_���[�J�[")
                builSQL.Append(" WHERE �폜�t���O = 0")
                builSQL.Append(" AND EXISTS ( ")
                builSQL.Append(" SELECT * FROM C_���i")
                builSQL.Append(" WHERE C_���i.���[�J�[�ԍ� = C_���[�J�[.���[�J�[�ԍ�")
                builSQL.Append(" AND C_���i.����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND C_���i.���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND C_���i.�폜�t���O = 0 )")
                builSQL.Append(" ORDER BY �\����,���[�J�[�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>���i�ꗗ���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���[�J�[�ԍ�</param>
        ''' <returns>���i���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT")
                builSQL.Append(" C_���i.���i�ԍ� AS �ԍ�")
                builSQL.Append(" , C_���i.���i�� AS ���i��")
                builSQL.Append(" , C_���i.�݌ɐ� AS �݌ɐ�")
                builSQL.Append(" , E_���o��.���o�ɓ� AS �ŐV���o�ɓ�")
                builSQL.Append(" , E_���o��.���o�ɔԍ� AS ���o�ɔԍ�")
                builSQL.Append(" , D_�S����.�S���Җ� AS �X�^�b�t��")
                builSQL.Append(" , B_���o�ɋ敪.���o�ɋ敪 AS ���o��")
                builSQL.Append(" , B_���o�ɗ��R.���o�ɗ��R AS ���R")
                builSQL.Append(" , E_���o��.�R�����g AS �R�����g")

                builSQL.Append(" FROM E_���o��")
                builSQL.Append(" INNER JOIN ( ")
                builSQL.Append("   SELECT")
                builSQL.Append("   E_���o��.����敪�ԍ� AS ����敪�ԍ�")
                builSQL.Append("   , E_���o��.���ޔԍ� AS ���ޔԍ�")
                builSQL.Append("   , E_���o��.���i�ԍ� AS ���i�ԍ�")
                builSQL.Append("   , E_���o��.���o�ɓ� AS ���o�ɓ�")
                builSQL.Append("   , MAX(E_���o��.���o�ɔԍ�) AS ���o�ɔԍ�")
                builSQL.Append("   FROM E_���o��")
                builSQL.Append("   INNER JOIN (")
                builSQL.Append("     SELECT")
                builSQL.Append("     E_���o��.����敪�ԍ� AS ����敪�ԍ�")
                builSQL.Append("     , E_���o��.���ޔԍ� AS ���ޔԍ�")
                builSQL.Append("     , E_���o��.���i�ԍ� AS ���i�ԍ�")
                builSQL.Append("     , MAX(E_���o��.���o�ɓ�) AS ���o�ɓ�")
                builSQL.Append("     FROM E_���o��")
                builSQL.Append("     GROUP BY E_���o��.����敪�ԍ�,E_���o��.���ޔԍ�,E_���o��.���i�ԍ�")
                builSQL.Append("     ) SUB2_���o��")
                builSQL.Append("     ON E_���o��.����敪�ԍ� = SUB2_���o��.����敪�ԍ�")
                builSQL.Append("     AND E_���o��.���ޔԍ� = SUB2_���o��.���ޔԍ�")
                builSQL.Append("     AND E_���o��.���i�ԍ� = SUB2_���o��.���i�ԍ�")
                builSQL.Append("     AND E_���o��.���o�ɓ� = SUB2_���o��.���o�ɓ�")
                builSQL.Append("     GROUP BY E_���o��.����敪�ԍ�,E_���o��.���ޔԍ�,E_���o��.���i�ԍ�,E_���o��.���o�ɓ�")
                builSQL.Append("   ) SUB_���o��")
                builSQL.Append("   ON E_���o��.����敪�ԍ� = SUB_���o��.����敪�ԍ�")
                builSQL.Append("   AND E_���o��.���ޔԍ� = SUB_���o��.���ޔԍ�")
                builSQL.Append("   AND E_���o��.���i�ԍ� = SUB_���o��.���i�ԍ�")
                builSQL.Append("   AND E_���o��.���o�ɓ� = SUB_���o��.���o�ɓ�")
                builSQL.Append("   AND E_���o��.���o�ɔԍ� = SUB_���o��.���o�ɔԍ�")

                builSQL.Append(" RIGHT JOIN C_���i")
                builSQL.Append(" ON E_���o��.����敪�ԍ� = C_���i.����敪�ԍ�")
                builSQL.Append(" AND E_���o��.���ޔԍ� = C_���i.���ޔԍ�")
                builSQL.Append(" AND E_���o��.���i�ԍ� = C_���i.���i�ԍ�")

                builSQL.Append(" LEFT JOIN D_�S����")
                builSQL.Append(" ON E_���o��.�S���Ҕԍ� = D_�S����.�S���Ҕԍ�")

                builSQL.Append(" LEFT JOIN B_���o�ɋ敪")
                builSQL.Append(" ON E_���o��.���o�ɋ敪�ԍ� = B_���o�ɋ敪.���o�ɋ敪�ԍ�")

                builSQL.Append(" LEFT JOIN B_���o�ɗ��R")
                builSQL.Append(" ON E_���o��.���o�ɗ��R�ԍ� = B_���o�ɗ��R.���o�ɗ��R�ԍ�")

                builSQL.Append(" WHERE C_���i.����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND C_���i.���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND C_���i.���[�J�[�ԍ� = @���[�J�[�ԍ�")
                builSQL.Append(" AND C_���i.�폜�t���O = 0")

                builSQL.Append(" ORDER BY C_���i.�\���� ASC,C_���i.���i�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>���o�ɗ����i�I�����i�j���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���o�ɔN��(yyyyMM)/@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�</param>
        ''' <returns>���o�ɏ�񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSelectedStockHistory(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_���o��.���o�ɓ� AS ���o�ɓ�,")
                builSQL.Append(" E_���o��.���o�ɔԍ� AS �ԍ�,")
                builSQL.Append(" E_���o��.���o�ɋ敪�ԍ� AS ���o�ɋ敪�ԍ�,")
                builSQL.Append(" B_���o�ɋ敪.���o�ɋ敪 AS �敪,")
                builSQL.Append(" E_���o��.���o�ɗ��R�ԍ� AS ���o�ɗ��R�ԍ�,")
                builSQL.Append(" B_���o�ɗ��R.���o�ɗ��R AS ���R,")
                builSQL.Append(" E_���o��.����敪�ԍ� AS ����敪�ԍ�,")
                builSQL.Append(" B_����敪.����敪 AS ����敪,")
                builSQL.Append(" E_���o��.���ޔԍ� AS ���ޔԍ�,")
                builSQL.Append(" C_����.���ޖ� AS ���ޖ�,")
                builSQL.Append(" E_���o��.���i�ԍ� AS ���i�ԍ�,")
                builSQL.Append(" C_���i.���i�� AS ���i��,")
                builSQL.Append(" C_���[�J�[.���[�J�[�� AS ���[�J�[��,")
                builSQL.Append(" E_���o��.���o�ɐ� AS ����,")
                builSQL.Append(" E_���o��.������z AS ������z,")
                builSQL.Append(" E_���o��.�S���Ҕԍ� AS �S���Ҕԍ�,")
                builSQL.Append(" D_�S����.�S���Җ� AS �X�^�b�t��,")
                builSQL.Append(" E_���o��.�R�����g AS �R�����g,")
                builSQL.Append(" E_���o��.�o�^�� AS �o�^��")
                builSQL.Append(" FROM E_���o��")

                builSQL.Append(" LEFT JOIN B_����敪 ON")
                builSQL.Append(" E_���o��.����敪�ԍ� = B_����敪.����敪�ԍ�")

                builSQL.Append(" LEFT JOIN C_���� ON")
                builSQL.Append(" E_���o��.����敪�ԍ� = C_����.����敪�ԍ�")
                builSQL.Append(" AND E_���o��.���ޔԍ� = C_����.���ޔԍ�")

                builSQL.Append(" LEFT JOIN B_���o�ɋ敪 ON")
                builSQL.Append(" E_���o��.���o�ɋ敪�ԍ� = B_���o�ɋ敪.���o�ɋ敪�ԍ�")

                builSQL.Append(" LEFT JOIN B_���o�ɗ��R ON")
                builSQL.Append(" E_���o��.���o�ɗ��R�ԍ� = B_���o�ɗ��R.���o�ɗ��R�ԍ�")

                builSQL.Append(" LEFT JOIN C_���i ON")
                builSQL.Append(" E_���o��.����敪�ԍ� = C_���i.����敪�ԍ�")
                builSQL.Append(" AND E_���o��.���ޔԍ� = C_���i.���ޔԍ�")
                builSQL.Append(" AND E_���o��.���i�ԍ� = C_���i.���i�ԍ�")

                builSQL.Append(" LEFT JOIN C_���[�J�[ ON")
                builSQL.Append(" C_���i.���[�J�[�ԍ� IS NOT NULL")
                builSQL.Append(" AND C_���i.���[�J�[�ԍ� = C_���[�J�[.���[�J�[�ԍ�")

                builSQL.Append(" LEFT JOIN D_�S���� ON")
                builSQL.Append(" E_���o��.�S���Ҕԍ� = D_�S����.�S���Ҕԍ�")

                builSQL.Append(" WHERE @���o�ɔN�� = SUBSTRING(CONVERT(varchar, E_���o��.���o�ɓ�, 112), 1, 6)")
                builSQL.Append(" AND E_���o��.����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND E_���o��.���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND E_���o��.���i�ԍ� = @���i�ԍ�")
                builSQL.Append(" ORDER BY E_���o��.���o�ɓ� DESC, E_���o��.���o�ɔԍ� DESC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>���o�ɋ敪�ꗗ���擾</summary>
        ''' <returns>���o�ɋ敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStockDivision() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT B_���o�ɋ敪.���o�ɋ敪�ԍ� AS ���o�ɋ敪�ԍ�,")
                builSQL.Append(" B_���o�ɋ敪.���o�ɋ敪 AS ���o�ɋ敪")
                builSQL.Append(" FROM B_���o�ɋ敪")
                builSQL.Append(" ORDER BY B_���o�ɋ敪.���o�ɋ敪�ԍ� ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>���o�ɗ��R�ꗗ���擾</summary>
        ''' <param name="v_number">���o�ɋ敪�ԍ�</param>
        ''' <returns>���o�ɗ��R���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStockReason(ByVal v_number As String) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT B_���o�ɗ��R.���o�ɗ��R�ԍ� AS ���o�ɗ��R�ԍ�,")
                builSQL.Append(" B_���o�ɗ��R.���o�ɗ��R AS ���o�ɗ��R,")
                builSQL.Append(" B_���o�ɗ��R.�R�����g�`�F�b�N AS �R�����g�`�F�b�N")
                builSQL.Append(" FROM B_���o�ɗ��R")
                builSQL.Append(" WHERE B_���o�ɗ��R.���o�ɋ敪�ԍ� = @���o�ɋ敪�ԍ�")
                builSQL.Append(" AND B_���o�ɗ��R.�蓮�ݒ�t���O = 'True'")
                builSQL.Append(" ORDER BY B_���o�ɗ��R.���o�ɗ��R�ԍ� ASC")

                param.Add("@���o�ɋ敪�ԍ�", v_number)
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>�S���҈ꗗ���擾</summary>
        ''' <returns>�X�^�b�t���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStaff() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT �S���Ҕԍ�,�S���Җ�")
                builSQL.Append(" FROM D_�S����")
                builSQL.Append(" WHERE �폜�t���O = 'false'")
                builSQL.Append(" ORDER BY �\���� ASC,�S���Ҕԍ� ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>E_���o�Ƀe�[�u���̓��o�ɔԍ����݊m�F</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���o�ɓ�/@���o�ɔԍ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function IsExistStockNumber(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 1")
                builSQL.Append(" FROM E_���o��")
                builSQL.Append(" WHERE ���o�ɓ� = @���o�ɓ�")
                builSQL.Append(" AND ���o�ɔԍ� = @���o�ɔԍ�")

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

        ''' <summary>���o�ɂ̐V�K�o�^</summary>
        ''' <param name="v_hashtable">
        ''' SQL�p�����[�^(Hashtable)�F@���o�ɓ�/@���o�ɔԍ�/@���o�ɋ敪�ԍ�/@���o�ɗ��R�ԍ�
        '''                /@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�/@���o�ɐ�/@������z
        '''                /@�S���Ҕԍ�/@�R�����g/@�o�^��
        ''' </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function StockInsert(ByRef v_hashtable As Hashtable) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim tmp_int As Integer = 0

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '' E_���o�Ƀe�[�u���o�^�p�����[�^
                param.Clear()
                param.Add("@���o�ɓ�", v_hashtable("@���o�ɓ�"))
                param.Add("@���o�ɔԍ�", v_hashtable("@���o�ɔԍ�"))
                param.Add("@���o�ɋ敪�ԍ�", v_hashtable("@���o�ɋ敪�ԍ�"))
                param.Add("@���o�ɗ��R�ԍ�", v_hashtable("@���o�ɗ��R�ԍ�"))
                param.Add("@����敪�ԍ�", v_hashtable("@����敪�ԍ�"))
                param.Add("@���ޔԍ�", v_hashtable("@���ޔԍ�"))
                param.Add("@���i�ԍ�", v_hashtable("@���i�ԍ�"))
                param.Add("@���o�ɐ�", v_hashtable("@���o�ɐ�"))
                param.Add("@������z", v_hashtable("@������z"))
                param.Add("@�S���Ҕԍ�", v_hashtable("@�S���Ҕԍ�"))
                param.Add("@�R�����g", v_hashtable("@�R�����g"))
                param.Add("@�o�^��", v_hashtable("@�o�^��"))

                '' E_���o�Ƀe�[�u���Ƀf�[�^��o�^
                builSQL.Append("INSERT INTO E_���o�� (")
                builSQL.Append(" ���o�ɓ�,")
                builSQL.Append(" ���o�ɔԍ�,")
                builSQL.Append(" ���o�ɋ敪�ԍ�,")
                builSQL.Append(" ���o�ɗ��R�ԍ�,")
                builSQL.Append(" ����敪�ԍ�,")
                builSQL.Append(" ���ޔԍ�,")
                builSQL.Append(" ���i�ԍ�,")
                builSQL.Append(" ���o�ɐ�,")
                builSQL.Append(" ������z,")
                builSQL.Append(" �S���Ҕԍ�,")
                builSQL.Append(" �R�����g,")
                builSQL.Append(" �o�^�� )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @���o�ɓ�,")
                builSQL.Append(" @���o�ɔԍ�,")
                builSQL.Append(" @���o�ɋ敪�ԍ�,")
                builSQL.Append(" @���o�ɗ��R�ԍ�,")
                builSQL.Append(" @����敪�ԍ�,")
                builSQL.Append(" @���ޔԍ�,")
                builSQL.Append(" @���i�ԍ�,")
                builSQL.Append(" @���o�ɐ�,")
                builSQL.Append(" @������z,")
                builSQL.Append(" @�S���Ҕԍ�,")
                builSQL.Append(" @�R�����g,")
                builSQL.Append(" @�o�^�� )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO receive_ship(")
                builSQL.Append("shop_code,")
                builSQL.Append("date,")
                builSQL.Append("code,")
                builSQL.Append("receive_ship_division_code,")
                builSQL.Append("receive_ship_reason_code,")
                builSQL.Append("sales_division_code,")
                builSQL.Append("class_code,")
                builSQL.Append("goods_code,")
                builSQL.Append("count,")
                builSQL.Append("amount,")
                builSQL.Append("basis_staff_code,")
                builSQL.Append("comment,")
                builSQL.Append("insert_date)")

                builSQL.Append("VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���o�ɓ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���o�ɔԍ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���o�ɋ敪�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���o�ɗ��R�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@����敪�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���ޔԍ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���i�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@���o�ɐ�")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@������z")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@�S���Ҕԍ�")) & ",")
                builSQL.Append(VbSQLNStr(param.GetValue("@�R�����g")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@�o�^��")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)


                ''�݌ɐ�����
                tmp_int = Integer.Parse(v_hashtable("@���o�ɐ�").ToString)
                If String.Equals(v_hashtable("@���o�ɋ敪�ԍ�").ToString, "2") Then
                    ''2:�o�ɂ̏ꍇ
                    tmp_int *= -1
                End If

                '' C_���i�e�[�u���X�V�p�����[�^
                param.Clear()
                param.Add("@���o�ɐ�", tmp_int)
                param.Add("@�X�V��", v_hashtable("@�o�^��"))
                param.Add("@����敪�ԍ�", v_hashtable("@����敪�ԍ�"))
                param.Add("@���ޔԍ�", v_hashtable("@���ޔԍ�"))
                param.Add("@���i�ԍ�", v_hashtable("@���i�ԍ�"))

                '' C_���i�e�[�u���̃f�[�^��o�^
                builSQL.Length = 0
                builSQL.Append("UPDATE C_���i SET")
                builSQL.Append(" �݌ɐ� = �݌ɐ�  + (@���o�ɐ�),")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")

                str_sql = builSQL.ToString
                rtnCnt += DBA.ExecuteNonQuery(str_sql, param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" stock = stock  + (" & param.GetValue("@���o�ɐ�").ToString & "),")
                builSQL.Append(" update_date =" & VbSQLStr(param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND class_code =" & VbSQLStr(param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND code =" & VbSQLStr(param.GetValue("@���i�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
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
    End Class
End Namespace
