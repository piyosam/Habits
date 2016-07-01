#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�ڋq�ύX��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class z0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "z_0500_�ڋq�ύX"

        ''' <summary>�ڋq���̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_D_�ڋq(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE D_�ڋq SET")
                builSQL.Append(" �� = @��,")
                builSQL.Append(" �� = @��,")
                builSQL.Append(" ���J�i = @���J�i,")
                builSQL.Append(" ���J�i = @���J�i,")
                builSQL.Append(" ���ʔԍ� = ( SELECT ���ʔԍ� FROM B_���� WHERE ���� = @����), ")
                builSQL.Append(" ���N���� = @���N����,")
                builSQL.Append(" �X�֔ԍ� =@�X�֔ԍ�,")
                builSQL.Append(" �s���{�� = @�s���{��,")
                builSQL.Append(" �Z��1 = @�Z��1,")
                builSQL.Append(" �Z��2 = @�Z��2,")
                builSQL.Append(" �Z��3 = @�Z��3,")
                builSQL.Append(" �d�b�ԍ� = @�d�b�ԍ�,")
                builSQL.Append(" Email�A�h���X = @�A�h���X,")
                builSQL.Append(" �Ƒ��� = @�Ƒ���,")
                builSQL.Append(" � = @�,")
                builSQL.Append(" �D���Șb�� = @�D���Șb��,")
                builSQL.Append(" �����Șb�� = @�����Șb��,")
                builSQL.Append(" ���� = @����,")
                builSQL.Append(" �Љ�� = @�Љ��,")
                builSQL.Append(" ��S���Ҕԍ� = ( SELECT �S���Ҕԍ� FROM D_�S���� WHERE �S���Җ� = @�S���Җ�),")
                builSQL.Append(" �o�^�敪�ԍ� = ( SELECT �o�^�敪�ԍ� FROM B_�o�^�敪 WHERE �o�^�敪 = @�o�^�敪),")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdBasis_customer(v_param))

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>E_���X�҂̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@��/@���J�i/@��/@�Z��/@�X�V��/@�ڋq�ԍ�/@���X��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_���X��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Dim dt As DataTable
            Try
                '���X�҃��R�[�h���݃`�F�b�N
                builSQL.Append("SELECT * FROM E_���X��")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")
                builSQL.Append(" AND ���X�� = @���X��")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

                If (dt.Rows.Count > 0) Then
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_���X�� SET")
                    builSQL.Append(" �� = @��,")
                    builSQL.Append(" ���J�i = @���J�i,")
                    builSQL.Append(" �� = @��,")
                    builSQL.Append(" �Z�� = @�Z��,")
                    builSQL.Append(" �X�V��=@�X�V��,")
                    builSQL.Append(" ��S���Ҕԍ�=@��S���Ҕԍ�")
                    builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")
                    builSQL.Append(" AND ���X�� = @���X��")

                    str_sql = builSQL.ToString
                    rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                    '------------------------------
                    'Z_SQL���s���� INSERT
                    '------------------------------
                    builSQL.Length = 0
                    ' SQL1�ݒ�
                    builSQL.Append("UPDATE visit SET")
                    builSQL.Append(" last_name =" & VbSQLNStr(v_param.GetValue("@��")) & ",")
                    builSQL.Append(" last_name_kana =" & VbSQLNStr(v_param.GetValue("@���J�i")) & ",")
                    builSQL.Append(" first_name =" & VbSQLNStr(v_param.GetValue("@��")) & ",")
                    builSQL.Append(" address =" & VbSQLNStr(v_param.GetValue("@�Z��")) & ",")
                    builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@�X�V��")) & ",")
                    builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@��S���Ҕԍ�")))
                    builSQL.Append(" WHERE basis_customer_code =" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                    builSQL.Append(" AND date =" & VbSQLStr(v_param.GetValue("@���X��")))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)
                End If
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>���X�Ҕԍ��̎擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�/@���X��</param>
        ''' <returns>���X�Ҕԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_���X��(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ���X�Ҕԍ� FROM E_���X�� WHERE �ڋq�ԍ� = @�ڋq�ԍ� AND ���X�� = @���X��"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>D_�ڋq����ڋq���폜</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�V�X�֔ԍ��\���p</param>
        ''' <returns>�s�撬����</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_D_�ڋq(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM D_�ڋq WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                rtn += DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL���s���� INSERT
                str_sql = "DELETE FROM basis_customer WHERE code =" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")) & " AND shop_code=" & VbSQLNStr(sShopcode)
                rtn += InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>�X�֔ԍ��ɂĎs�撬������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�V�X�֔ԍ��\���p</param>
        ''' <returns>�s�撬����</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_placename(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.SearchAddress(v_param)
        End Function

        ''' <summary>�Z������X�֔ԍ�����</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�s���{��/@�s�撬����/@���於</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_postnumber(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT �V�X�֔ԍ��\���p")
                builSQL.Append(" FROM B_�X�֔ԍ�")
                builSQL.Append(" WHERE �s���{���� =@�s���{����")
                builSQL.Append(" AND �s�撬���� = @�s�撬���� AND ���於 = @���於")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>�ڋq�ԍ���E_�J���e�e�[�u��������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_record(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM E_�J���e WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�ڋq�ԍ���E_�|�C���g�e�[�u��������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_point(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM E_�|�C���g WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�ڋq�ԍ���E_����e�[�u��������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM E_���� WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�ڋq�ԍ���E_���㖾�׃e�[�u��������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sales_details(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM E_���㖾�� WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�ڋq�ԍ���E_���X�҃e�[�u��������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM E_���X�� WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�ڋq�ԍ���D_�ڋq�e�[�u��������</summary>
        ''' <returns>�ڋq���</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_D_�ڋq(ByVal customer_No As String) As DataTable
            Return MyBase.GetCustomerData(customer_No)
        End Function

        ''' <summary>���ʖ��̈ꗗ�擾</summary>
        ''' <returns>���ʃ��X�g</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_����()
        End Function

        ''' <summary>�o�^�敪���̎擾</summary>
        ''' <returns>�o�^�敪�����X�g</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_�o�^�敪()
        End Function

        ''' <summary>�S���Җ��ꗗ�擾</summary>
        ''' <returns>�S���҃��X�g</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function


        ''' <summary>�S���Җ��擾</summary>
        ''' <returns>�S���Җ����X�g</returns>
        ''' <remarks></remarks>
        Function ChargeTanyouPerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>�ڋq���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq���</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerInfo(v_param)
        End Function

        ''' <summary>Z_SQL���s������SQL1����(basis_customer��Update)</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdBasis_customer(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Dim objSexNmb As Object
            Dim objStfNmb As Object
            Dim objDivNmb As Object

            Try
                objSexNmb = getSexNmb(v_param)
                objStfNmb = getStaffNmb(v_param)
                objDivNmb = getDivNmb(v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" last_name =" & VbSQLNStr(v_param.GetValue("@��")) & ",")
                builSQL.Append(" first_name =" & VbSQLNStr(v_param.GetValue("@��")) & ",")
                builSQL.Append(" last_name_kana =" & VbSQLNStr(v_param.GetValue("@���J�i")) & ",")
                builSQL.Append(" first_name_kana =" & VbSQLNStr(v_param.GetValue("@���J�i")) & ",")
                builSQL.Append(" gender_code = " & VbSQLStr(objSexNmb) & ", ")
                builSQL.Append(" birthday =" & VbSQLStr(v_param.GetValue("@���N����")) & ",")
                builSQL.Append(" post_code =" & VbSQLNStr(v_param.GetValue("@�X�֔ԍ�")) & ",")
                builSQL.Append(" prefectures =" & VbSQLNStr(v_param.GetValue("@�s���{��")) & ",")
                builSQL.Append(" address1 =" & VbSQLNStr(v_param.GetValue("@�Z��1")) & ",")
                builSQL.Append(" address2 =" & VbSQLNStr(v_param.GetValue("@�Z��2")) & ",")
                builSQL.Append(" address3 =" & VbSQLNStr(v_param.GetValue("@�Z��3")) & ",")
                builSQL.Append(" phone =" & VbSQLNStr(v_param.GetValue("@�d�b�ԍ�")) & ",")
                builSQL.Append(" mail =" & VbSQLNStr(v_param.GetValue("@�A�h���X")) & ",")
                builSQL.Append(" family =" & VbSQLNStr(v_param.GetValue("@�Ƒ���")) & ",")
                builSQL.Append(" hobby =" & VbSQLNStr(v_param.GetValue("@�")) & ",")
                builSQL.Append(" favorite_topic =" & VbSQLNStr(v_param.GetValue("@�D���Șb��")) & ",")
                builSQL.Append(" offensive_topic =" & VbSQLNStr(v_param.GetValue("@�����Șb��")) & ",")
                builSQL.Append(" memo =" & VbSQLNStr(v_param.GetValue("@����")) & ",")
                builSQL.Append(" introducer =" & VbSQLNStr(v_param.GetValue("@�Љ��")) & ",")
                builSQL.Append(" main_staff_code = " & VbSQLStr(objStfNmb) & ",")
                builSQL.Append(" register_code = " & VbSQLStr(objDivNmb) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>���ʔԍ��擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����</param>
        ''' <returns>���ʔԍ�</returns>
        ''' <remarks></remarks>
        Private Function getSexNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT ���ʔԍ� FROM B_���� WHERE ���� = @����"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>�S���Ҕԍ��擾 </summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�S���Җ�</param>
        ''' <returns>�S���Ҕԍ�</returns>
        ''' <remarks></remarks>
        Private Function getStaffNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT �S���Ҕԍ� FROM D_�S���� WHERE �S���Җ� = @�S���Җ�"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>�o�^�敪�ԍ��擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�o�^�敪</param>
        ''' <returns>�o�^�敪�ԍ�</returns>
        ''' <remarks></remarks>
        Private Function getDivNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT �o�^�敪�ԍ� FROM B_�o�^�敪 WHERE �o�^�敪 = @�o�^�敪"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
