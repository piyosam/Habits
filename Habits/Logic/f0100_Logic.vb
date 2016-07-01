#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�ڋq�o�^��ʃ��W�b�N</summary>
    ''' <remarks></remarks>
    Public Class f0100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0100_�ڋq�o�^"

        ''' <summary>�s�撬���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�V�X�֔ԍ��\���p</param>
        ''' <returns>�s�撬�����</returns>
        ''' <remarks>�X�֔ԍ����s�撬�����擾����</remarks>
        Protected Friend Function select_placename(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT �s���{����, �s�撬����, ���於")
                builSQL.Append(" FROM B_�X�֔ԍ�")
                builSQL.Append(" WHERE �V�X�֔ԍ��\���p LIKE @�V�X�֔ԍ��\���p")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>���ʈꗗ�擾</summary>
        ''' <returns>���ʃ��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sex() As DataTable
            Return MyBase.B_����()
        End Function

        ''' <summary>�o�^�敪�ꗗ�擾</summary>
        ''' <returns>�o�^�敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_�o�^�敪() As DataTable
            Return MyBase.B_�o�^�敪()
        End Function

        ''' <summary>�S���҈ꗗ�擾</summary>
        ''' <returns>�S���҃��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_��S����() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>D_�ڋq�o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_customer_infomation(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                builSQL.Append("INSERT INTO D_�ڋq(")
                builSQL.Append(" �ڋq�ԍ�")
                builSQL.Append(" ,��")
                builSQL.Append(" ,��")
                builSQL.Append(" ,���J�i")
                builSQL.Append(" ,���J�i")
                builSQL.Append(" ,���ʔԍ�")
                builSQL.Append(" ,���N����")
                builSQL.Append(" ,�X�֔ԍ�")
                builSQL.Append(" ,�s���{��")
                builSQL.Append(" ,�Z��1")
                builSQL.Append(" ,�Z��2")
                builSQL.Append(" ,�Z��3")
                builSQL.Append(" ,�d�b�ԍ�")
                builSQL.Append(" ,Email�A�h���X")
                builSQL.Append(" ,�Ƒ���")
                builSQL.Append(" ,�")
                builSQL.Append(" ,�D���Șb��")
                builSQL.Append(" ,�����Șb��")
                builSQL.Append(" ,�`���t���O")
                builSQL.Append(" ,����")
                builSQL.Append(" ,�Љ��")
                builSQL.Append(" ,�O�񗈓X��")
                builSQL.Append(" ,���X��N_1")
                builSQL.Append(" ,���X��N_2")
                builSQL.Append(" ,���X��")
                builSQL.Append(" ,��S���Ҕԍ�")
                builSQL.Append(" ,�o�^�敪�ԍ�")
                builSQL.Append(" ,�o�^��")
                builSQL.Append(" ,�X�V��)")

                builSQL.Append(" VALUES (@�ڋq�ԍ�, @��, @��, @���J�i, @���J�i,@���ʔԍ�, @���N����,")
                builSQL.Append("  @�X�֔ԍ�,@�s���{��, @�Z��1,@�Z��2,@�Z��3,@�d�b�ԍ�,@�A�h���X,@�Ƒ���,")
                builSQL.Append(" @�, @�D���Șb��, @�����Șb��, @�`���t���O, @����,")
                builSQL.Append(" @�Љ��, @�O�񗈓X��, @���X��1,@���X��2, @���X��,")
                builSQL.Append(" @��S���Ҕԍ�, @�o�^�敪�ԍ�,@�o�^��, @�X�V��)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("INSERT INTO basis_customer(")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,code")
                builSQL.Append(" ,last_name")
                builSQL.Append(" ,first_name")
                builSQL.Append(" ,last_name_kana")
                builSQL.Append(" ,first_name_kana")
                builSQL.Append(" ,gender_code")
                builSQL.Append(" ,birthday")
                builSQL.Append(" ,post_code")
                builSQL.Append(" ,prefectures")
                builSQL.Append(" ,address1")
                builSQL.Append(" ,address2")
                builSQL.Append(" ,address3")
                builSQL.Append(" ,phone")
                builSQL.Append(" ,mail")
                builSQL.Append(" ,family")
                builSQL.Append(" ,hobby")
                builSQL.Append(" ,favorite_topic")
                builSQL.Append(" ,offensive_topic")
                builSQL.Append(" ,message_flag")
                builSQL.Append(" ,memo")
                builSQL.Append(" ,introducer")
                builSQL.Append(" ,last_visit_date")
                builSQL.Append(" ,one_before_last_visit_date")
                builSQL.Append(" ,two_before_last_visit_date")
                builSQL.Append(" ,visit_times")
                builSQL.Append(" ,main_staff_code")
                builSQL.Append(" ,register_code")
                builSQL.Append(" ,insert_date")
                builSQL.Append(" ,update_date)")
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & "," & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@��")) & "," & VbSQLNStr(v_param.GetValue("@��")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@���J�i")) & "," & VbSQLNStr(v_param.GetValue("@���J�i")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���ʔԍ�")) & "," & VbSQLStr(v_param.GetValue("@���N����")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�X�֔ԍ�")) & "," & VbSQLNStr(v_param.GetValue("@�s���{��")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�Z��1")) & "," & VbSQLNStr(v_param.GetValue("@�Z��2")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�Z��3")) & "," & VbSQLNStr(v_param.GetValue("@�d�b�ԍ�")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�A�h���X")) & "," & VbSQLNStr(v_param.GetValue("@�Ƒ���")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�")) & "," & VbSQLNStr(v_param.GetValue("@�D���Șb��")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@�����Șb��")) & "," & VbSQLStr(v_param.GetValue("@�`���t���O")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@����")) & "," & VbSQLNStr(v_param.GetValue("@�Љ��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�O�񗈓X��")) & "," & VbSQLStr(v_param.GetValue("@���X��1")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@���X��2")) & "," & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")) & "," & VbSQLStr(v_param.GetValue("@�o�^�敪�ԍ�")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@�o�^��")) & "," & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�ڋq�ԍ��ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n�ڋq�ԍ�/@�I���ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_customer_num(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerNum(v_param)
        End Function
    End Class
End Namespace