#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    Public Class a1800_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1800_�ʐM�ݒ�"

        ''' <summary></summary>
        ''' <returns>�ʐM���t���O�擾</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetConnectFlag() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT �ʐM���t���O FROM A_�V�X�e��"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary></summary>
        ''' <returns>�ʐM���t���O�X�V</returns>
        ''' <remarks></remarks>
        Protected Friend Function UpdateConnectFlag(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "UPDATE A_�V�X�e�� SET �ʐM���t���O = @�ʐM���t���O"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

                str_sql = "UPDATE system SET network_flag=" & VbSQLStr(v_param.GetValue("@�ʐM���t���O")) & _
                        " WHERE shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function


    End Class
End Namespace