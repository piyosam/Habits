#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>��Ǝ��Ԑݒ�i�H���ʁj��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a1500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1500_��Ǝ��Ԑݒ�"

        ''' <summary>�X�^�b�t�ꗗ�擾</summary>
        ''' <returns>�X�^�b�t���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function �X�^�b�t�ꗗ() As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@�c�Ɠ�", USER_DATE)
            Return MyBase.W_�X�^�b�tPlus_E_����(param)
        End Function

        ''' <summary>�|�C���g�f�[�^�ǉ�</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>W_�|�C���gInsert</remarks>
        Protected Friend Function pointAdd_W(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                sb.Append("INSERT INTO W_�|�C���g(")
                sb.Append(" ���X��,")
                sb.Append("���X�Ҕԍ�,")
                sb.Append(" �ڋq�ԍ�,")
                sb.Append(" ����ԍ�,")
                sb.Append(" ����敪�ԍ�,")
                sb.Append(" ���ޔԍ�,")
                sb.Append(" ���i�ԍ�,")
                sb.Append(" �H���ԍ�,")
                sb.Append(" �H����,")
                sb.Append(" �|�C���g,")
                sb.Append(" �S���҃R�[�h)")
                sb.Append(" VALUES (")
                sb.Append(" @���X��,")
                sb.Append(" @���X�Ҕԍ�,")
                sb.Append(" @�ڋq�ԍ�,")
                sb.Append(" @����ԍ�,")
                sb.Append(" @����敪�ԍ�,")
                sb.Append(" @���ޔԍ�,")
                sb.Append(" @���i�ԍ�,")
                sb.Append(" @�H���ԍ�,")
                sb.Append(" @�H����,")
                sb.Append(" @�|�C���g,")
                sb.Append(" 0)")

                str_sql = sb.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>�|�C���g�f�[�^�ǉ�</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>E_�|�C���gInsert</remarks>
        Protected Friend Function pointAdd(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                sb.Append("INSERT INTO E_�|�C���g(")
                sb.Append(" ���X��,")
                sb.Append(" ���X�Ҕԍ�,")
                sb.Append(" �ڋq�ԍ�,")
                sb.Append(" ����ԍ�,")
                sb.Append(" ����敪�ԍ�,")
                sb.Append(" ���ޔԍ�,")
                sb.Append(" ���i�ԍ�,")
                sb.Append(" �H���ԍ�,")
                sb.Append(" �H����,")
                sb.Append(" �|�C���g,")
                sb.Append(" �S���҃R�[�h,")
                sb.Append(" �S���Җ�,")
                sb.Append(" �X�V�� )")

                sb.Append(" VALUES (")
                sb.Append(" @���X��,")
                sb.Append(" @���X�Ҕԍ�,")
                sb.Append(" @�ڋq�ԍ�,")
                sb.Append(" @����ԍ�,")
                sb.Append(" @����敪�ԍ�,")
                sb.Append(" @���ޔԍ�,")
                sb.Append(" @���i�ԍ�,")
                sb.Append(" @�H���ԍ�,")
                sb.Append(" @�H����,")
                sb.Append(" @�|�C���g,")
                sb.Append(" @�S���҃R�[�h,")
                sb.Append(" @�S���Җ�, ")
                sb.Append(" @�X�V�� )")

                str_sql = sb.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                sb.Length = 0
                sb.Append("INSERT INTO staff_point(")
                sb.Append("shop_code,")             '�X�܃R�[�h(varchar
                sb.Append(" visit_date,")           '���X��(datetime)
                sb.Append(" visit_number,")         '���X�Ҕԍ�(smallint)
                sb.Append(" basis_customer_code,")  '�ڋq�ԍ�(int)
                sb.Append(" sales_details_code,")   '����ԍ�(smallint)
                sb.Append(" sales_division_code,")  '����敪�ԍ�(smallint)
                sb.Append(" class_code,")           '���ޔԍ�(smallint)
                sb.Append(" goods_code,")           '���i�ԍ�(smallint)
                sb.Append(" process_code,")         '�H���ԍ�(smallint)
                sb.Append(" process_name,")         '�H����(nvarchar)
                sb.Append(" point,")                '�|�C���g(smallint)
                sb.Append(" basis_staff_code,")     '�S���҃R�[�h(smallint)
                sb.Append(" basis_staff_name,")     '�S���Җ�(nvarchar)
                sb.Append(" update_date )")         '�X�V��(datetime)

                sb.Append(" VALUES (")
                sb.Append(VbSQLNStr(sShopcode) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@���X��")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@����ԍ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@����敪�ԍ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@���ޔԍ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@���i�ԍ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@�H���ԍ�")) & ",")
                sb.Append(VbSQLNStr(v_param.GetValue("@�H����")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@�|�C���g")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@�S���҃R�[�h")) & ",")
                sb.Append(VbSQLNStr(v_param.GetValue("@�S���Җ�")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@�X�V��")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, sb.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>�H�����擾</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�H����񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H�����e�擾(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT C_���i�H��.�H���ԍ�,B_�H��.�H����,B_�H��.�|�C���g")
                sb.Append(" FROM C_���i�H�� JOIN B_�H�� ON  C_���i�H��.�H���ԍ� = B_�H��.�H���ԍ�")
                sb.Append(" WHERE C_���i�H��.����敪�ԍ� = @����敪�ԍ�")
                sb.Append(" AND C_���i�H��.���ޔԍ� = @���ޔԍ�")
                sb.Append(" AND C_���i�H��.���i�ԍ� = @���i�ԍ�")
                sb.Append(" AND B_�H��.�폜�t���O = 'FALSE'")
                sb.Append(" ORDER BY C_���i�H��.�\����")

                str_sql = sb.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>�|�C���g���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�|�C���g���</returns>
        ''' <remarks></remarks>
        Protected Friend Function �|�C���g����(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT P.����敪�ԍ�, P.���ޔԍ�, P.���i�ԍ�, P.�H���ԍ�")
                sb.Append(" ,P.�H����, P.���X��, P.���X�Ҕԍ�, P.�ڋq�ԍ�, P.����ԍ�")
                sb.Append(" ,P.�|�C���g AS �|�C���g, P.�S���҃R�[�h, P.�S���Җ�")
                sb.Append(" ,P.�X�V��")
                sb.Append(" FROM E_�|�C���g AS P")
                sb.Append(" LEFT OUTER JOIN C_���i�H��")
                sb.Append(" ON P.����敪�ԍ� = C_���i�H��.����敪�ԍ�")
                sb.Append(" AND P.���ޔԍ� = C_���i�H��.���ޔԍ�")
                sb.Append(" AND P.���i�ԍ� = C_���i�H��.���i�ԍ�")
                sb.Append(" AND P.�H���ԍ� = C_���i�H��.�H���ԍ�")
                sb.Append(" WHERE P.���X�� = @���X��")
                sb.Append(" AND P.���X�Ҕԍ� = @���X�Ҕԍ�")
                sb.Append(" AND P.�ڋq�ԍ� = @�ڋq�ԍ�")
                sb.Append(" AND P.����ԍ� = @����ԍ�")
                sb.Append(" AND P.����敪�ԍ� = @����敪�ԍ�")
                sb.Append(" AND P.���ޔԍ� = @���ޔԍ�")
                sb.Append(" AND P.���i�ԍ� = @���i�ԍ�")
                sb.Append(" ORDER BY C_���i�H��.�\����")

                str_sql = sb.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>W_�|�C���g�ꊇ�폜</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_�|�C���g() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                str_sql = "DELETE W_�|�C���g FROM W_�|�C���g"

                rtn = DBA.ExecuteNonQuery(str_sql)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>�|�C���g���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�|�C���g���</returns>
        ''' <remarks>W_�|�C���g</remarks>
        Function select_W(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT ����敪�ԍ�,���ޔԍ�,���i�ԍ�,�H���ԍ�,�H����,���X��,")
                sb.Append(" ���X�Ҕԍ�,�ڋq�ԍ�,����ԍ�,�|�C���g,�S���҃R�[�h,�S���Җ�")
                sb.Append(" FROM W_�|�C���g")
                sb.Append(" WHERE ���X�� = @���X��")
                sb.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                sb.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")
                sb.Append(" AND ����ԍ� = @����ԍ�")
                sb.Append(" AND ����敪�ԍ� = @����敪�ԍ�")
                sb.Append(" AND ���ޔԍ� = @���ޔԍ�")
                sb.Append(" AND ���i�ԍ� = @���i�ԍ�")

                str_sql = sb.ToString
                rtn = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�|�C���g���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�|�C���g���</returns>
        ''' <remarks>E_�|�C���g</remarks>
        Function selectPoint(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT ����敪�ԍ�,���ޔԍ�,���i�ԍ�,�H���ԍ�,�H����,���X��,")
                sb.Append(" ���X�Ҕԍ�,�ڋq�ԍ�,����ԍ�,�|�C���g,�S���҃R�[�h,�S���Җ�,�X�V��")
                sb.Append(" FROM E_�|�C���g")
                sb.Append(" WHERE ���X�� = @���X��")
                sb.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                sb.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")
                sb.Append(" AND ����ԍ� = @����ԍ�")
                sb.Append(" AND ����敪�ԍ� = @����敪�ԍ�")
                sb.Append(" AND ���ޔԍ� = @���ޔԍ�")
                sb.Append(" AND ���i�ԍ� = @���i�ԍ�")
                sb.Append(" AND �H���ԍ� = @�H���ԍ�")

                str_sql = sb.ToString
                rtn = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>W_�|�C���g�폜</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_�|�C���g(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim dt As Integer
            Dim sb As New StringBuilder()

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                sb.Append("DELETE FROM W_�|�C���g")
                sb.Append(" WHERE ���X�� = @���X��")
                sb.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                sb.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")
                sb.Append(" AND ����ԍ� = @����ԍ�")
                sb.Append(" AND ����敪�ԍ� = @����敪�ԍ�")
                sb.Append(" AND ���ޔԍ� = @���ޔԍ�")
                sb.Append(" AND ���i�ԍ� = @���i�ԍ�")
                sb.Append(" AND �H���ԍ� = @�H���ԍ�")

                str_sql = sb.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>E_�|�C���g�폜</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_E_�|�C���g(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim dt As Integer
            Dim sb As New StringBuilder()

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                sb.Length = 0
                sb.Append("DELETE FROM E_�|�C���g")
                sb.Append(" WHERE ���X�� = @���X��")
                sb.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                sb.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")
                sb.Append(" AND ����敪�ԍ� = @����敪�ԍ�")
                sb.Append(" AND ���ޔԍ� = @���ޔԍ�")
                sb.Append(" AND ���i�ԍ� = @���i�ԍ�")
                sb.Append(" AND �H���ԍ� = @�H���ԍ�")

                str_sql = sb.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                sb.Length = 0
                sb.Append("DELETE FROM staff_point")

                sb.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@���X��")))
                sb.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                sb.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                sb.Append(" AND sales_division_code=" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                sb.Append(" AND class_code=" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                sb.Append(" AND goods_code=" & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                sb.Append(" AND process_code=" & VbSQLStr(v_param.GetValue("@�H���ԍ�")))
                sb.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, sb.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���㖾�ׂ̍�Ǝ��ԍX�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function ��Ǝ��Ԑݒ�(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim dt As Boolean
            Dim sb As New StringBuilder()

            Try
                sb.Append("UPDATE E_���㖾�� ")
                sb.Append(" SET ��ƊJ�n = @��ƊJ�n, ��ƏI�� = @��ƏI�� ,�X�V�� = @�X�V��")
                sb.Append(" WHERE ���X�� = @���X��")
                sb.Append(" AND ���X�Ҕԍ� = @���X�Ҕԍ�")
                sb.Append(" AND �ڋq�ԍ� = @�ڋq�ԍ�")
                sb.Append(" AND ����ԍ� = @����ԍ�")
                sb.Append(" AND �X�V�� = @�X�V��")
                str_sql = sb.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                sb.Length = 0
                sb.Append("UPDATE sales_details ")
                sb.Append(" SET start_date=" & VbSQLStr(v_param.GetValue("@��ƊJ�n")))
                sb.Append(", end_date=" & VbSQLStr(v_param.GetValue("@��ƏI��")))
                sb.Append(", update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                sb.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@���X��")))
                sb.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                sb.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                sb.Append(" AND code=" & VbSQLStr(v_param.GetValue("@����ԍ�")))
                sb.Append(" AND update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")))
                sb.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, sb.ToString)
            Catch ex As Exception
                ''��O���̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���㖾�ׂ̍�Ǝ��ԍX�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_starttime(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT ��ƊJ�n, ��ƏI�� FROM E_���X�� WHERE ���X�� = @���X�� AND ���X�Ҕԍ� = @���X�Ҕԍ� "
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���i���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>���i��񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_skillItem(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT ���i.���i��,���i.����敪�ԍ�,���i.���ޔԍ�,���i.���i�ԍ�,C_����.���ޖ�,����ԍ�,���� FROM ( ")
                builSQL.Append(" SELECT C_���i.���i��,���㖾��.����敪�ԍ�,���㖾��.���ޔԍ�,���㖾��.���i�ԍ�,���㖾��.����ԍ�,���㖾��.���� FROM ( ")
                builSQL.Append(" SELECT ����敪�ԍ�,���ޔԍ�,���̔ԍ�  AS ���i�ԍ� ,����ԍ�,���� FROM E_���㖾�� ")
                builSQL.Append(" WHERE ���X�Ҕԍ� = @���X�Ҕԍ� AND ���X�� = @���X�� AND �ڋq�ԍ� = @�ڋq�ԍ�) AS ���㖾��")
                builSQL.Append(" INNER JOIN C_���i ON ���㖾��.����敪�ԍ� = C_���i.����敪�ԍ�")
                builSQL.Append(" AND ���㖾��.���ޔԍ� = C_���i.���ޔԍ�")
                builSQL.Append(" AND ���㖾��.���i�ԍ� = C_���i.���i�ԍ�) AS ���i")
                builSQL.Append(" INNER JOIN C_���� ON ���i.���ޔԍ� = C_����.���ޔԍ�")
                builSQL.Append(" AND ���i.����敪�ԍ� = C_����.����敪�ԍ�")
                builSQL.Append(" WHERE C_����.�X�̑Ώۃt���O = 'False'")
                builSQL.Append(" AND C_����.�폜�t���O = 'False'")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace