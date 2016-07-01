#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>���i�}�X�^�ҏW���W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class f0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0500_����"

#Region "�f�[�^�擾"

#Region "����敪���X�g�擾"
        ''' <summary>B_����敪�e�[�u�����甄��敪���ꗗ���擾</summary>
        ''' <returns>����敪�����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSalesDivisionNames() As DataTable
            Return MyBase.getSalesDiv()
        End Function
#End Region

#Region "����敪���ꗗ�擾"
        ''' <summary>B_����敪�e�[�u�����甄��敪�ꗗ���擾</summary>
        ''' <returns>����敪��񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSalesDivision() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" ����敪�ԍ� AS �ԍ�,")
                builSQL.Append(" ����敪,")
                builSQL.Append(" �\����,")
                builSQL.Append(" (CASE WHEN B_����敪.�폜�t���O = 'True' THEN '�~' ELSE '' END) AS �\��,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��")
                builSQL.Append(" FROM B_����敪")
                builSQL.Append(" ORDER BY �\����,����敪�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���ރ��X�g�擾"
        ''' <summary>C_���ރe�[�u�����番�ޖ��ꗗ���擾</summary>
        ''' <param name="v_number">SQL�p�����[�^�F@����敪�ԍ�</param>
        ''' <returns>���ޖ����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityDivisionNames(ByVal v_number As String) As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@����敪�ԍ�", v_number)

            Return getClass_exclude(param)
        End Function
#End Region

#Region "���ޏ��ꗗ�擾"
        ''' <summary>C_���ރe�[�u�����甄��敪�ʕ��ވꗗ���擾</summary>
        ''' <param name="v_number">SQL�p�����[�^�F@����敪�ԍ�</param>
        ''' <returns>���ޏ�񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityDivision(ByVal v_number As String) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" ���ޔԍ� AS �ԍ�,")
                builSQL.Append(" ���ޖ�,")
                builSQL.Append(" �\����,")
                builSQL.Append(" (CASE WHEN C_����.�X�̑Ώۃt���O = 'True' THEN '��' ELSE '' END) AS �X�̑Ώ�,")
                builSQL.Append(" (CASE WHEN C_����.�폜�t���O = 'True' THEN '�~' ELSE '' END) AS ��\��,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��")
                builSQL.Append(" FROM C_����")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
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
#End Region

#Region "���i���ꗗ�擾"
        ''' <summary>C_���i�e�[�u�����珤�i�ꗗ���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�</param>
        ''' <returns>���i���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodity(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" C_���i.���i�ԍ� AS No")
                builSQL.Append(" ,C_���i.���i�� AS ���i��")
                builSQL.Append(" ,C_���i.���[�J�[�ԍ� AS ���[�J�[�ԍ�")
                builSQL.Append(" ,C_���[�J�[.���[�J�[�� AS ���[�J�[��")
                builSQL.Append(" ,C_���i.�W������ AS �W������")
                builSQL.Append(" ,C_���i.�d�����z AS �d�����z")
                builSQL.Append(" ,C_���i.�̔����z AS �̔����z")
                builSQL.Append(" ,C_���i.�݌ɐ� AS �݌ɐ�")
                builSQL.Append(" ,C_���i.�����_ AS �����_")
                builSQL.Append(" ,C_���i.�K��݌ɐ� AS ���萔")
                builSQL.Append(" ,C_���i.�\���� AS �\����")
                builSQL.Append(" ,(CASE WHEN (SELECT DISTINCT ����敪�ԍ� FROM C_���i�H��")
                builSQL.Append(" WHERE C_���i.����敪�ԍ� = C_���i�H��.����敪�ԍ� AND C_���i.���ޔԍ� = C_���i�H��.���ޔԍ�")
                builSQL.Append(" AND C_���i.���i�ԍ� = C_���i�H��.���i�ԍ�)")
                builSQL.Append(" IS NULL THEN '' ELSE '��' END) AS �H��")
                builSQL.Append(" ,(CASE WHEN C_���i.�폜�t���O = 'True' THEN '�~' ELSE '' END) AS �\��")
                builSQL.Append(" ,C_���i.�o�^�� AS �o�^��")
                builSQL.Append(" ,C_���i.�X�V�� AS �X�V��")
                builSQL.Append(" ,(CASE WHEN C_���i.���z�Ǘ��敪 = '1' THEN '�{��' ELSE '�ō�' END) AS �Ǘ�")
                builSQL.Append(" FROM (C_���i LEFT JOIN C_���[�J�[ ON C_���i.���[�J�[�ԍ� = C_���[�J�[.���[�J�[�ԍ�)")
                builSQL.Append(" WHERE C_���i.����敪�ԍ� = @����敪�ԍ� AND C_���i.���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" ORDER BY �\����,C_���i.���i�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���[�J�[���X�g�擾"
        ''' <summary>C_���[�J�[�e�[�u�����烁�[�J�[���ꗗ���擾</summary>
        ''' <returns>�L���ȃ��[�J�[���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetBrandNames() As DataTable
            Return MyBase.getMaker_exclude
        End Function
#End Region

#Region "����敪����"
        ''' <summary>����敪�̌���</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪</param>
        ''' <returns>����敪</returns>
        ''' <remarks>�V�K�o�^���A������敪�ł̓o�^�h�~�p</remarks>
        Protected Friend Function checkDuplicate_SalesDiv(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ����敪�ԍ�,����敪 FROM B_����敪 WHERE ����敪 = @����敪"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ޖ�����"
        ''' <summary>���ޖ��̌���</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����</param>
        ''' <returns>����</returns>
        ''' <remarks>�V�K�o�^���A������敪�ł̓o�^�h�~�p</remarks>
        Protected Friend Function checkDuplicate_Class(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ����敪�ԍ�,���ޔԍ�,���ޖ� FROM C_���� WHERE ���ޖ� = @���ޖ� AND ����敪�ԍ� = @����敪"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ޏ��擾"
        ''' <summary>���ޏ��̎擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�</param>
        ''' <returns>����</returns>
        ''' <remarks>�Ώۃ��R�[�h�o��</remarks>
        Protected Friend Function getClassData(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ���ޔԍ�,���ޖ�,�X�̑Ώۃt���O FROM C_���� WHERE ����敪�ԍ� = @����敪�ԍ� AND ���ޔԍ� = @���ޔԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���i������"
        ''' <summary>���i���̎擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i��</param>
        ''' <returns>���i��</returns>
        ''' <remarks>�V�K�o�^���A������敪�A�����ޔԍ��A�����i���ł̓o�^�h�~�p</remarks>
        Protected Friend Function checkDuplicate(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ���i�ԍ�,���i�� FROM C_���i WHERE ����敪�ԍ� = @����敪�ԍ� AND ���ޔԍ� = @���ޔԍ� AND ���i�� = @���i��"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#End Region

#Region "�f�[�^�X�V"

#Region "����敪�V�K�o�^"
        ''' <summary>����敪�̐V�K�o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@����敪/@�\����/@�폜�t���O/@�o�^��.@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function SalesDivisionInsert(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_����敪 (")
                builSQL.Append(" ����敪�ԍ�,")
                builSQL.Append(" ����敪,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �폜�t���O,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V�� )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @����敪�ԍ�,")
                builSQL.Append(" @����敪,")
                builSQL.Append(" @�\����,")
                builSQL.Append(" @�폜�t���O,")
                builSQL.Append(" @�o�^��,")
                builSQL.Append(" @�X�V�� )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO sales_division (")
                builSQL.Append(" shop_code,")
                builSQL.Append(" code,")
                builSQL.Append(" name,")
                builSQL.Append(" display_order,")
                builSQL.Append(" delete_flag,")
                builSQL.Append(" insert_date,")
                builSQL.Append(" update_date )")

                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@����敪�ԍ�")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@����敪")) & ",")
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
#End Region

#Region "����敪�X�V"
        ''' <summary>����敪�̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪/@�\����/@�폜�t���O/@�X�V��/@����敪�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function SalesDivisionUpdate(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_����敪 SET")
                builSQL.Append(" ����敪 = @����敪,")
                builSQL.Append(" �\���� = @�\����,")
                builSQL.Append(" �폜�t���O = @�폜�t���O,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE sales_division SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@����敪")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '�X�܃R�[�h     (varchar)
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function
#End Region

#Region "���ސV�K�o�^"
        ''' <summary>���ނ̐V�K�o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityDivisionInsert(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_���� (")
                builSQL.Append(" ����敪�ԍ�,")
                builSQL.Append(" ���ޔԍ�,")
                builSQL.Append(" ���ޖ�,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �X�̑Ώۃt���O,")
                builSQL.Append(" �폜�t���O,")
                builSQL.Append(" �o�^��,")
                builSQL.Append(" �X�V��)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @����敪�ԍ�,")
                builSQL.Append(" @���ޔԍ�,")
                builSQL.Append(" @���ޖ�,")
                builSQL.Append(" @�\����,")
                builSQL.Append(" @�X�̑Ώۃt���O,")
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
                builSQL.Append("INSERT INTO class (")
                builSQL.Append(" shop_code,")
                builSQL.Append(" sales_division_code,")
                builSQL.Append(" code,")
                builSQL.Append(" name,")
                builSQL.Append(" display_order,")
                builSQL.Append(" stock_manage_flag,")
                builSQL.Append(" delete_flag,")
                builSQL.Append(" insert_date,")
                builSQL.Append(" update_date)")
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@����敪�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@���ޔԍ�")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@���ޖ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�X�̑Ώۃt���O")) & ",")
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
#End Region

#Region "���ލX�V"
        ''' <summary>���ނ̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityDivisionUpdate(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE C_���� SET")
                builSQL.Append(" ���ޖ� = @���ޖ�,")
                builSQL.Append(" �\���� = @�\����,")
                builSQL.Append(" �X�̑Ώۃt���O = @�X�̑Ώۃt���O,")
                builSQL.Append(" �폜�t���O = @�폜�t���O,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE class SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@���ޖ�")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@�\����")) & ",")
                builSQL.Append(" stock_manage_flag =" & VbSQLStr(v_param.GetValue("@�X�̑Ώۃt���O")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '�X�܃R�[�h     (varchar)
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
#End Region

#Region "���i�V�K�o�^"
        ''' <summary>���i�̐V�K�o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <param name="v_stckFlag">True:�݌ɊǗ����� / False:�݌ɊǗ��Ȃ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityInsert(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_���i (")
                builSQL.Append(" ����敪�ԍ�")
                builSQL.Append(" ,���ޔԍ�")
                builSQL.Append(" ,���i�ԍ�")
                builSQL.Append(" ,���i��")
                builSQL.Append(" ,�̔����z")
                builSQL.Append(" ,�\����")
                builSQL.Append(" ,�폜�t���O")
                builSQL.Append(" ,�o�^��")
                builSQL.Append(" ,�X�V��")
                builSQL.Append(" ,�K��݌ɐ�")
                builSQL.Append(" ,���z�Ǘ��敪")
                If v_stckFlag Then
                    builSQL.Append(" ,���[�J�[�ԍ�")
                    builSQL.Append(" ,�d�����z")
                    builSQL.Append(" ,�݌ɐ�")
                    builSQL.Append(" ,�����_")
                Else
                    builSQL.Append(" ,�W������")
                End If

                builSQL.Append(" )VALUES (")
                builSQL.Append(" @����敪�ԍ�")
                builSQL.Append(" ,@���ޔԍ�")
                builSQL.Append(" ,@���i�ԍ�")
                builSQL.Append(" ,@���i��")
                builSQL.Append(" ,@�̔����z")
                builSQL.Append(" ,@�\����")
                builSQL.Append(" ,@�폜�t���O")
                builSQL.Append(" ,@�o�^��")
                builSQL.Append(" ,@�X�V��")
                If v_stckFlag Then
                    builSQL.Append(" ,@����݌ɐ�")
                Else
                    builSQL.Append(" ,0")
                End If
                builSQL.Append(" ,@���z�Ǘ��敪")
                If v_stckFlag Then
                    builSQL.Append(" ,@���[�J�[�ԍ�")
                    builSQL.Append(" ,@�d�����z")
                    builSQL.Append(" ,@�݌ɐ�")
                    builSQL.Append(" ,@�����_")
                Else
                    builSQL.Append(" ,@�W������")
                End If
                builSQL.Append(" )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlInsGoods(v_param, v_stckFlag))

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function
#End Region

#Region "���i�X�V"
        ''' <summary>���i�i�X�̑Ώہj�̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <param name="v_stckFlag">True:�݌ɊǗ����� / False:�݌ɊǗ��Ȃ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityUpdate(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE C_���i SET")
                builSQL.Append(" ���i�� = @���i��")
                builSQL.Append(" ,�̔����z = @�̔����z")
                builSQL.Append(" ,�\���� = @�\����")
                builSQL.Append(" ,�폜�t���O = @�폜�t���O")
                builSQL.Append(" ,�X�V�� = @�X�V��")
                builSQL.Append(" ,���z�Ǘ��敪 = @���z�Ǘ��敪")
                If v_stckFlag Then
                    builSQL.Append(" ,���[�J�[�ԍ� = @���[�J�[�ԍ�")
                    builSQL.Append(" ,�d�����z = @�d�����z")
                    builSQL.Append(" ,�݌ɐ� = @�݌ɐ�")
                    builSQL.Append(" ,�����_ = @�����_")
                    builSQL.Append(" ,�K��݌ɐ� = @����݌ɐ�")
                Else
                    builSQL.Append(" ,�W������ = @�W������")
                End If
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods(v_param, v_stckFlag))

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function
#End Region

#Region "���i�폜"
        ''' <summary>���i�폜</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function goodsDelete(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("DELETE FROM C_���i")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlDltGoods(v_param))

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function
#End Region

#End Region

#Region "Z_SQL���s�����iINSERT GOODS�j"
        ''' <summary>Z_SQL���s������SQL1����(INSERT GOODS)</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <param name="v_stckFlag">True:�݌ɊǗ����� / False:�݌ɊǗ��Ȃ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlInsGoods(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL���s���� SQL1
                builSQL.Length = 0
                builSQL.Append("INSERT INTO goods (")
                builSQL.Append(" shop_code")               '�X�܃R�[�h
                builSQL.Append(" ,sales_division_code")    '����敪�ԍ�
                builSQL.Append(" ,class_code")             '���ޔԍ�
                builSQL.Append(" ,code")                   '���i�ԍ�
                builSQL.Append(" ,name")                   '���i��
                If v_stckFlag Then
                    builSQL.Append(" ,maker_code")         '���[�J�[�ԍ�
                    builSQL.Append(" ,cost_price")         '�d�����z
                End If
                builSQL.Append(" ,salling_price")          '�̔����z
                If v_stckFlag Then
                    builSQL.Append(" ,stock")              '�݌ɐ�
                    builSQL.Append(" ,order_point")        '�����_
                Else
                    builSQL.Append(" ,basic_time")         '�W������
                End If
                builSQL.Append(" ,display_order")          '�\����
                builSQL.Append(" ,delete_flag")            '�폜�t���O
                builSQL.Append(" ,insert_date")            '�o�^��
                builSQL.Append(" ,update_date")            '�X�V��
                builSQL.Append(" ,regular_stock")          '����݌ɐ�
                builSQL.Append(" ,management_tax")         '���z�Ǘ��敪

                builSQL.Append(" )VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@���i��")))
                If v_stckFlag Then
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@���[�J�[�ԍ�")))
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@�d�����z")))
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�̔����z")))

                If v_stckFlag Then
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@�݌ɐ�")))
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@�����_")))
                Else
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@�W������")))
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�\����")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�폜�t���O")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�o�^��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�X�V��")))
                If v_stckFlag Then
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@����݌ɐ�")))
                Else
                    builSQL.Append(" ,0")
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���z�Ǘ��敪")))
                builSQL.Append(" )")


                Return builSQL.ToString

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "Z_SQL���s�����iUPDATE GOODS�j"
        ''' <summary>Z_SQL���s������SQL1����(UPDATE GOODS)</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <param name="v_stckFlag">True:�݌ɊǗ����� / False:�݌ɊǗ��Ȃ�</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdGoods(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL���s���� SQL1
                builSQL.Length = 0

                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@���i��")))
                builSQL.Append(", salling_price =" & VbSQLStr(v_param.GetValue("@�̔����z")))
                If v_stckFlag Then
                    builSQL.Append(", maker_code =" & VbSQLStr(v_param.GetValue("@���[�J�[�ԍ�")))
                    builSQL.Append(", cost_price =" & VbSQLStr(v_param.GetValue("@�d�����z")))
                    builSQL.Append(", stock =" & VbSQLStr(v_param.GetValue("@�݌ɐ�")))
                    builSQL.Append(", order_point =" & VbSQLStr(v_param.GetValue("@�����_")))
                    builSQL.Append(", regular_stock =" & VbSQLStr(v_param.GetValue("@����݌ɐ�")))
                Else
                    builSQL.Append(", basic_time =" & VbSQLStr(v_param.GetValue("@�W������")))
                End If
                builSQL.Append(", display_order =" & VbSQLStr(v_param.GetValue("@�\����")))
                builSQL.Append(", delete_flag =" & VbSQLStr(v_param.GetValue("@�폜�t���O")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(", management_tax =" & VbSQLStr(v_param.GetValue("@���z�Ǘ��敪")))

                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "Z_SQL���s�����iDELETE GOODS�j"
        ''' <summary>Z_SQL���s������SQL1����(DELETE GOODS)</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlDltGoods(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL���s���� SQL1
                builSQL.Length = 0

                builSQL.Append("DELETE FROM goods")
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace
