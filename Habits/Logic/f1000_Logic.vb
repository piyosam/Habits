#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>��Ǝ��Ԑݒ�i�{�p���ԁj��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class f1000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1000_�H��"
        Private Enum gdsPrcsNmb As Integer
            dispOrd = 0
            dispOrd1 = 1
            dispOrd2 = 2
        End Enum

        ''' <summary>���i�H�����擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�</param>
        ''' <returns>���i�H�����</returns>
        ''' <remarks></remarks>
        Protected Friend Function �X�V���e(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT C_���i�H��.�H���ԍ� AS �ԍ�,B_�H��.�H����,")
                builSQL.Append(" B_�H��.�|�C���g,C_���i�H��.�\����,")
                builSQL.Append(" B_�H��.�\���� AS �}�X�^�\����")
                builSQL.Append(" FROM C_���i�H��")
                builSQL.Append(" JOIN B_�H�� ON  C_���i�H��.�H���ԍ� = B_�H��.�H���ԍ�")
                builSQL.Append(" WHERE C_���i�H��.����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND C_���i�H��.���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND C_���i�H��.���i�ԍ� = @���i�ԍ�")
                builSQL.Append(" ORDER BY C_���i�H��.�\����")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>C_���i�H���f�[�^�폜</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�X�V��/@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�/@�H���ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function C_���i�H���폜(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                builSQL.Length = 0
                builSQL.Append("DELETE FROM C_���i�H��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")
                builSQL.Append(" AND �H���ԍ� = @�H���ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlDelGoods_process(v_param))

                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>�H�����ꗗ�擾</summary>
        ''' <returns>�H�����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function ���e�X�V() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �H���ԍ� AS �ԍ�,�H����,�|�C���g,�\���� FROM W_�H�� ORDER BY �\����,�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>W_�H���f�[�^�ǉ�</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_�H���}�X�^() As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_�H��")
                builSQL.Append(" SELECT �H���ԍ�,")
                builSQL.Append(" �H����,�|�C���g,")
                builSQL.Append(" �\����")
                builSQL.Append(" FROM B_�H��")
                builSQL.Append(" WHERE �폜�t���O = 'false'")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>W_�H���f�[�^�폜</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W�H��() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                str_sql = "DELETE W_�H�� FROM W_�H��"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>C_���i�H���f�[�^�ǉ�</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�/@�H���ԍ�/@�X�V��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���ǉ�toC_���i�H��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_���i�H��(")
                builSQL.Append(" ����敪�ԍ�,")
                builSQL.Append(" ���ޔԍ�,")
                builSQL.Append(" ���i�ԍ�,")
                builSQL.Append(" �H���ԍ�,")
                builSQL.Append(" �\����,")
                builSQL.Append(" �X�V�� )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @����敪�ԍ�,")
                builSQL.Append(" @���ޔԍ�,")
                builSQL.Append(" @���i�ԍ�,")
                builSQL.Append(" @�H���ԍ�,")
                builSQL.Append(" @�\����,")
                builSQL.Append(" @�X�V�� )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO goods_process(")
                builSQL.Append(" shop_code,")               '�X�܃R�[�h
                builSQL.Append(" sales_division_code,")     '����敪�ԍ�
                builSQL.Append(" class_code,")              '���ޔԍ�
                builSQL.Append(" goods_code,")              '���i�ԍ�
                builSQL.Append(" process_code,")            '�H���ԍ�
                builSQL.Append(" display_order,")           '�\����
                builSQL.Append(" update_date )")            '�X�V��
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@����敪�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@���ޔԍ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@���i�ԍ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�H���ԍ�")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@�\����")) & ",")
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

        ''' <summary>W_�H���f�[�^�ǉ�</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�H���ԍ�/@�H����/@�|�C���g</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���ǉ�toW_�H��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO W_�H��(")
                builSQL.Append(" �H���ԍ�,")
                builSQL.Append(" �H����,")
                builSQL.Append(" �|�C���g,")
                builSQL.Append(" �\����)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @�H���ԍ�,")
                builSQL.Append(" @�H����,")
                builSQL.Append(" @�|�C���g,")
                builSQL.Append(" @�}�X�^�\����)")

                str_sql = builSQL.ToString
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

        ''' <summary>W_�H���f�[�^�폜</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�H���ԍ�/@�H����/@�|�C���g</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���폜fromW_�H��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append(" DELETE FROM W_�H��")
                builSQL.Append(" WHERE �H���ԍ� = @�H���ԍ�")
                builSQL.Append(" AND �H���� = @�H����")
                builSQL.Append(" AND �|�C���g = @�|�C���g")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>W_�H���f�[�^�폜</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �}�X�^����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As Integer

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                builSQL.Append(" DELETE FROM W_�H��")
                builSQL.Append(" WHERE �H���ԍ� IN(")
                builSQL.Append(" SELECT �H���ԍ� FROM C_���i�H��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�)")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>C_���i�H���f�[�^�\�����ύX</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�1/@�\����1/@���i�ԍ�2/@�\����2</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���\�����ύX(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim rtn As Boolean = False
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                ' �I���������R�[�h
                builSQL.Append("UPDATE C_���i�H�� SET")
                builSQL.Append(" �\���� = @�\����1,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")
                builSQL.Append(" AND �H���ԍ� = @�H���ԍ�1")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd1))

                builSQL.Length = 0
                builSQL.Append("UPDATE C_���i�H�� SET")
                builSQL.Append(" �\���� = @�\����2,")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")
                builSQL.Append(" AND �H���ԍ� = @�H���ԍ�2")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd2))

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>C_���i�H���f�[�^�\�������ύX</summary>
        ''' <param name="salesDiv">����敪�ԍ�</param>
        ''' <param name="classCd">���ޔԍ�</param>
        ''' <param name="goodsCd">���i�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �H���\�����ύX_ALL(ByVal salesDiv As String, ByVal classCd As String, ByVal goodsCd As String) As Boolean
            Dim rtn As Boolean = False
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim v_param As New Habits.DB.DBParameter
            Dim dt As New DataTable
            Dim i As Integer = 0

            builSQL.Append("UPDATE C_���i�H�� SET")
            builSQL.Append(" �\���� = @�\����,")
            builSQL.Append(" �X�V�� = @�X�V��")
            builSQL.Append(" WHERE ����敪�ԍ� = @����敪�ԍ�")
            builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
            builSQL.Append(" AND ���i�ԍ� = @���i�ԍ�")
            builSQL.Append(" AND �H���ԍ� = @�H���ԍ�")
            str_sql = builSQL.ToString

            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                ' ���i�̑S�H�����R�[�h�擾
                v_param.Add("@����敪�ԍ�", salesDiv)
                v_param.Add("@���ޔԍ�", classCd)
                v_param.Add("@���i�ԍ�", goodsCd)
                dt = �X�V���e(v_param)

                Do While i < dt.Rows.Count
                    v_param.Clear()
                    v_param.Add("@�\����", i + 1)
                    v_param.Add("@�X�V��", Now)
                    v_param.Add("@����敪�ԍ�", salesDiv)
                    v_param.Add("@���ޔԍ�", classCd)
                    v_param.Add("@���i�ԍ�", goodsCd)
                    v_param.Add("@�H���ԍ�", dt.Rows(i)(0).ToString)
                    str_sql = builSQL.ToString

                    rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                    'Z_SQL���s���� INSERT
                    InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd))

                    i += 1
                Loop

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>[C_���i�H��]�ő�\�����擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�</param>
        ''' <returns>���i�H�����</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetMaxCount_���i�H��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As DataTable
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(�\����)")
                builSQL.Append(" FROM C_���i�H��")
                builSQL.Append(" WHERE C_���i�H��.����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND C_���i�H��.���ޔԍ� = @���ޔԍ�")
                builSQL.Append(" AND C_���i�H��.���i�ԍ� = @���i�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            If dt.Rows.Count > 0 AndAlso Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString()) Then
                rtn = dt.Rows(0)(0)
            End If
            Return rtn
        End Function

        ''' <summary>Z_SQL���s������SQL1����(goods_process��Delete)</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�/@�H���ԍ�</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Private Function getSqlDelGoods_process(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL���s���� SQL1
                builSQL.Length = 0
                builSQL.Append(" DELETE FROM goods_process")
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND goods_code =" & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                builSQL.Append(" AND process_code =" & VbSQLStr(v_param.GetValue("@�H���ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>Z_SQL���s������SQL1����(goods_process��Update)</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�\����/@�X�V��/@����敪�ԍ�/@���ޔԍ�/@���i�ԍ�/@�H���ԍ�</param>
        ''' <param name="v_kbn">�\�����A�H���ԍ��̃p�����[�^�敪</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdGoods_process(ByVal v_param As Habits.DB.DBParameter, ByVal v_kbn As gdsPrcsNmb) As String
            Dim builSQL As New StringBuilder()
            Dim dispName As String = "@�\����"
            Dim prsName As String = "@�H���ԍ�"
            Try
                Select Case v_kbn
                    Case gdsPrcsNmb.dispOrd
                        dispName = "@�\����"
                        prsName = "@�H���ԍ�"
                    Case gdsPrcsNmb.dispOrd1
                        dispName = "@�\����1"
                        prsName = "@�H���ԍ�1"
                    Case gdsPrcsNmb.dispOrd2
                        dispName = "@�\����2"
                        prsName = "@�H���ԍ�2"
                End Select

                'Z_SQL���s���� SQL1
                builSQL.Length = 0
                builSQL.Append("UPDATE goods_process SET")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue(dispName)))
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" AND goods_code =" & VbSQLStr(v_param.GetValue("@���i�ԍ�")))
                builSQL.Append(" AND process_code =" & VbSQLStr(v_param.GetValue(prsName)))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
