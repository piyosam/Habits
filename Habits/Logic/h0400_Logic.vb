#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>���o�^�҉�ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class h0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "h0400_���o�^��"

        ''' <summary>�Z�����o�^�̌ڋq�擾�i�o�^�ς̂݁j</summary>
        ''' <returns>�ڋq���X�g</returns>
        ''' <remarks></remarks>
        Function ���o�^�҈ꗗ() As DataTable
            Return getCustomerList(True)
        End Function

        ''' <summary>�Z�����o�^�̌ڋq�擾�i���o�^�܂ށj</summary>
        ''' <returns>�ڋq���X�g</returns>
        ''' <remarks></remarks>
        Function ���o�^�܂ޖ��o�^�ꗗ() As DataTable
            Return getCustomerList(False)
        End Function

        ''' <summary>�S���Җ��擾</summary>
        ''' <returns>�S���Җ����X�g</returns>
        ''' <remarks></remarks>
        Function ChargeTanyouPerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>�Z�����o�^�̌ڋq���X�g�擾</summary>
        ''' <param name="RegistedFlg">True:�o�^�ρAFalse�F���o�^</param>
        ''' <returns>�ڋq���X�g</returns>
        ''' <remarks></remarks>
        Function getCustomerList(ByVal RegistedFlg As Boolean) As DataTable
            Dim rtn As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT �ڋq�ԍ�, ��, ��,")
                builSQL.Append(" CONVERT(nvarchar(11), �o�^��, 111) AS �o�^��")
                builSQL.Append(" FROM D_�ڋq ")
                builSQL.Append(" WHERE ( (�s���{�� IS NULL OR �s���{��='')")
                builSQL.Append(" OR ((�Z��1 IS NULL OR �Z��1='') AND (�Z��2 IS NULL OR �Z��2='')))")
                builSQL.Append(" AND �ڋq�ԍ� < ")
                builSQL.Append(Clng_STFreeNo)
                If (RegistedFlg) Then
                    builSQL.Append(" AND �o�^�敪�ԍ� = '1'")
                End If
                builSQL.Append(" ORDER BY �ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>�ڋq���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�ڋq���</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT D_�ڋq.�ڋq�ԍ� ,D_�ڋq.�� ,D_�ڋq.�� ,D_�ڋq.���J�i ,D_�ڋq.���J�i")
                builSQL.Append(" ,D_�ڋq.���ʔԍ� ,B_����.���� ,D_�ڋq.���N���� ,D_�ڋq.�X�֔ԍ�")
                builSQL.Append(" ,D_�ڋq.�s���{�� ,D_�ڋq.�Z��1 ,D_�ڋq.�Z��2 ,D_�ڋq.�Z��3")
                builSQL.Append(" ,D_�ڋq.�d�b�ԍ� ,D_�ڋq.Email�A�h���X ,D_�ڋq.�Ƒ��� ,D_�ڋq.�")
                builSQL.Append(" ,D_�ڋq.�D���Șb�� ,D_�ڋq.�����Șb�� ,D_�ڋq.�`���t���O ,D_�ڋq.����")
                builSQL.Append(" ,D_�ڋq.�Љ�� ,D_�ڋq.�O�񗈓X�� ,D_�ڋq.���X��N_1 ,D_�ڋq.���X��N_2")
                builSQL.Append(" ,D_�ڋq.���X�� ,D_�ڋq.��S���Ҕԍ� ,D_�S����.�S���Җ� ,D_�ڋq.�o�^�敪�ԍ�")
                builSQL.Append(" ,B_�o�^�敪.�o�^�敪,D_�ڋq.�o�^�� ,D_�ڋq.�X�V��")
                builSQL.Append(" FROM D_�ڋq LEFT JOIN B_���� ON D_�ڋq.���ʔԍ� = B_����.���ʔԍ�")
                builSQL.Append(" LEFT JOIN D_�S���� ON D_�ڋq.��S���Ҕԍ� = D_�S����.�S���Ҕԍ�")
                builSQL.Append(" LEFT JOIN B_�o�^�敪 ON D_�ڋq.�o�^�敪�ԍ� = B_�o�^�敪.�o�^�敪�ԍ�")
                builSQL.Append(" WHERE D_�ڋq.�ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            v_param.Clear()
            Return dt
        End Function

        ''' <summary>�ڋq���̍X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�o�^�敪�ԍ�/@�X�V��/@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function ���o�^����(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE D_�ڋq SET")
                builSQL.Append(" �o�^�敪�ԍ� = '0',")
                builSQL.Append(" �X�V�� = @�X�V��")
                builSQL.Append(" WHERE �ڋq�ԍ� = @�ڋq�ԍ�")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE basis_customer SET ")
                builSQL.Append("register_code =''0''")
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>���ʖ��̈ꗗ�擾</summary>
        ''' <returns>���ʃ��X�g</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_����()
        End Function

        ''' <summary>�o�^�敪�ꗗ�擾</summary>
        ''' <returns>�o�^�敪���X�g</returns>
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

        ''' <summary>�o�^�敪�ԍ��擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�o�^�敪�ԍ�</returns>
        ''' <remarks></remarks>
        Function �o�^�ϔԍ��m�F(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �o�^�敪�ԍ� FROM D_�ڋq WHERE �ڋq�ԍ� = @�ڋq�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace

