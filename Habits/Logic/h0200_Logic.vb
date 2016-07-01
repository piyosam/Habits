#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�f�[�^���o�i�m�F�j��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class h0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "h0200_�m�F"

        ''' <summary>W_�o�͑ΏۍX�V</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Function �I��ύX(ByVal outputFlag As Boolean, ByVal customer As String) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Dim param As New Habits.DB.DBParameter
            Try
                param.Add("@�I��", outputFlag)
                param.Add("@�ڋq�ԍ�", customer)
                builSQL.Append("UPDATE W_�ڋq���o SET �I�� = @�I��")
                If Not String.IsNullOrEmpty(customer) AndAlso customer <> "" Then
                    builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")
                End If
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�o�͑Ώۈꗗ�擾</summary>
        ''' <returns>�o�͑Ώۃ��X�g</returns>
        ''' <remarks></remarks>
        Function Q_h0200_�o�͑Ώۈꗗ() As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" �I��")
                builSQL.Append(" ,�ڋq�ԍ�")
                builSQL.Append(" ,��")
                builSQL.Append(" ,��")
                builSQL.Append(" ,���J�i")
                builSQL.Append(" ,���J�i")
                builSQL.Append(" ,case ���ʔԍ� when 1 then '��' else '�j' end AS ����")
                builSQL.Append(" ,[�Z��1]")
                builSQL.Append(" ,ISNULL ( [�Z��2], '') + ISNULL ( [�Z��3], '') AS �Z��2")
                builSQL.Append(" ,D_�S����.�S���Җ� AS �ŏI�S����")
                builSQL.Append(" FROM W_�ڋq���o")
                builSQL.Append(" LEFT OUTER JOIN D_�S����")
                builSQL.Append(" ON W_�ڋq���o.��S���Ҕԍ� = D_�S����.�S���Ҕԍ�")
                builSQL.Append(" ORDER BY ���J�i,���J�i,�ڋq�ԍ� ASC")
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�f�[�^���o�o�̓p�X�̎擾</summary>
        ''' <returns>�f�[�^���o�o�̓p�X</returns>
        ''' <remarks>Excel�o�͐�̃f�t�H���g�t�H���_���擾����</remarks>
        Protected Friend Function select_ASY() As String
            Dim rtn As String
            rtn = getPath(2)
            Return rtn
        End Function

        ''' <summary>�f�[�^���o�o�̓p�X�̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�f�[�^���o�o�̓p�X��/@�ύX����</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks>Excel�o�͐�̃f�t�H���g�t�H���_���X�V����</remarks>
        Protected Friend Function update_ASY(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Try
                str_sql = "UPDATE A_�V�X�e�� SET �f�[�^���o�o�̓p�X�� = @�f�[�^���o�o�̓p�X�� , �ύX���� = @�ύX����"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                str_sql = "UPDATE system SET data_output_path=" & VbSQLNStr(v_param.GetValue("@�f�[�^���o�o�̓p�X��")) & _
                        ", update_date = " & VbSQLStr(v_param.GetValue("@�ύX����")) & _
                        " WHERE shop_code=" & VbSQLNStr(sShopcode)
                InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�o�͑Ώۈꗗ�擾</summary>
        ''' <returns>�o�͑Ώۃ��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W�o�͑Ώ�() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" �ڋq�ԍ�")
                builSQL.Append(" ,��")
                builSQL.Append(" ,��")
                builSQL.Append(" ,���J�i")
                builSQL.Append(" ,���J�i")
                builSQL.Append(" ,case ���ʔԍ� when 1 then '��' else '�j' end AS ����")
                builSQL.Append(" ,�X�֔ԍ�")
                builSQL.Append(" ,�s���{��")
                builSQL.Append(" ,�Z��1")
                builSQL.Append(" ,ISNULL(�Z��2, '') + ' ' + ISNULL(�Z��3, '') AS �Z��2")
                builSQL.Append(" ,�d�b�ԍ�")
                builSQL.Append(" ,D_�S����.�S���Җ� AS �ŏI�S����")
                builSQL.Append(" ,CONVERT(char,�O�񗈓X��,111) AS �ŏI���X��")
                builSQL.Append(" ,���X��")
                builSQL.Append(" ,CONVERT(char,���N����,111) AS ���N����")
                builSQL.Append(" ,Email�A�h���X")
                builSQL.Append(" ,B_����敪.����敪")
                builSQL.Append(" ,�敪���v���z")
                builSQL.Append(" FROM W_�ڋq���o")
                builSQL.Append(" LEFT JOIN D_�S���� ON ��S���Ҕԍ� = D_�S����.�S���Ҕԍ�")
                builSQL.Append(" LEFT OUTER JOIN B_����敪 ON W_�ڋq���o.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" WHERE �I�� = 'True'")
                builSQL.Append(" ORDER BY ���J�i ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

    End Class
End Namespace

