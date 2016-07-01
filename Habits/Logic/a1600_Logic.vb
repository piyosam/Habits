#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>������ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a1600_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1600_�������"

        ''' <summary>�����̕K�v��������̈ꗗ�擾</summary>
        ''' <returns>�����K�v���i���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function �����ꗗ() As DataTable
            Dim dt As DataTable
            Dim rtn As DataTable = New DataTable()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim amount As Integer

            Try
                builSQL.Append("SELECT DISTINCT")
                builSQL.Append(" C_���i.����敪�ԍ� AS ����敪�ԍ�")
                builSQL.Append(" ,C_���i.���ޔԍ� AS ���ޔԍ�")
                builSQL.Append(" ,C_����.���ޖ� AS ���ޖ�")
                builSQL.Append(" ,C_���i.���i�ԍ� AS ���i�ԍ�")
                builSQL.Append(" ,C_���i.���i�� AS ���i��")
                builSQL.Append(" ,C_���[�J�[.���[�J�[�� AS ���[�J�[��")
                builSQL.Append(" ,C_���i.���z�Ǘ��敪 AS ���z�Ǘ��敪")
                builSQL.Append(" ,C_���i.�d�����z AS �d�����z")
                builSQL.Append(" ,C_���i.�̔����z AS �̔����z")
                builSQL.Append(" ,C_���i.�݌ɐ� AS �݌ɐ�")
                builSQL.Append(" ,C_���i.�����_ AS �����_")
                builSQL.Append(" ,C_���i.�K��݌ɐ� AS ����݌ɐ�")
                builSQL.Append(" ,(C_���i.�K��݌ɐ� - C_���i.�݌ɐ�) AS �ڈ�������")
                builSQL.Append(" FROM  ((C_���i")
                builSQL.Append(" JOIN C_���� ON C_����.���ޔԍ� = C_���i.���ޔԍ� AND C_����.����敪�ԍ� = C_���i.����敪�ԍ�)")
                builSQL.Append(" JOIN C_���[�J�[ ON C_���i.���[�J�[�ԍ� = C_���[�J�[.���[�J�[�ԍ�)")
                builSQL.Append(" WHERE C_���i.�����_ >= C_���i.�݌ɐ�")
                builSQL.Append(" AND C_����.�X�̑Ώۃt���O = 'true'")
                builSQL.Append(" AND (C_���i.�K��݌ɐ� - C_���i.�݌ɐ�)<>0;")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

                '�e�[�u���C���X�^���X�쐬
                rtn.Columns.Add("����敪�ԍ�", Type.GetType("System.Int64"))
                rtn.Columns.Add("���ޔԍ�", Type.GetType("System.Int64"))
                rtn.Columns.Add("���ޖ�", Type.GetType("System.String"))
                rtn.Columns.Add("���i�ԍ�", Type.GetType("System.Int64"))
                rtn.Columns.Add("���i��", Type.GetType("System.String"))
                rtn.Columns.Add("���[�J�[��", Type.GetType("System.String"))
                rtn.Columns.Add("�d�����z", Type.GetType("System.Int64"))
                rtn.Columns.Add("�̔����z", Type.GetType("System.Int64"))
                rtn.Columns.Add("�݌ɐ�", Type.GetType("System.Int64"))
                rtn.Columns.Add("�����_", Type.GetType("System.Int64"))
                rtn.Columns.Add("����݌ɐ�", Type.GetType("System.Int64"))
                rtn.Columns.Add("�ڈ�������", Type.GetType("System.Int64"))

                For Each dr As DataRow In dt.Rows
                    Dim newRow As DataRow = rtn.NewRow()
                    rtn.Rows.Add(newRow)
                    newRow("����敪�ԍ�") = dr.Item("����敪�ԍ�")
                    newRow("���ޔԍ�") = dr.Item("���ޔԍ�")
                    newRow("���ޖ�") = dr.Item("���ޖ�")
                    newRow("���i�ԍ�") = dr.Item("���i�ԍ�")
                    newRow("���i��") = dr.Item("���i��")
                    newRow("���[�J�[��") = dr.Item("���[�J�[��")

                    If Integer.Parse(dr.Item("���z�Ǘ��敪")) = 1 Then
                        amount = Integer.Parse(dr.Item("�d�����z").ToString())
                        newRow("�d�����z") = amount + Sys_Tax(amount, USER_DATE, 0)
                        amount = Integer.Parse(dr.Item("�̔����z").ToString())
                        newRow("�̔����z") = amount + Sys_Tax(amount, USER_DATE, 0)
                    Else
                        newRow("�d�����z") = dr.Item("�d�����z")
                        newRow("�̔����z") = dr.Item("�̔����z")
                    End If
                    newRow("�݌ɐ�") = dr.Item("�݌ɐ�")
                    newRow("�����_") = dr.Item("�����_")
                    newRow("����݌ɐ�") = dr.Item("����݌ɐ�")
                    newRow("�ڈ�������") = dr.Item("�ڈ�������")
                Next

                Return rtn
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>�����o�̓p�X�擾</summary>
        ''' <returns>�����o�̓p�X</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As String
            Dim rtn As String = Nothing
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