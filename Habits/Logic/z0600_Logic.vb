#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�X�֔ԍ�������ʃ��W�b�N</summary>
    ''' <remarks></remarks>
    Public Class z0600_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>�s���{�����ꗗ�̎擾</summary>
        ''' <returns>�s���{�������X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_�s���{����() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable

            Try
                builSQL.Append("SELECT B_�X�֔ԍ�.�s���{����")
                builSQL.Append(" FROM B_�X�֔ԍ�")
                builSQL.Append(" GROUP BY B_�X�֔ԍ�.�s���{����")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>�s�撬�����ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�s���{����</param>
        ''' <returns>�s�撬�����X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_�s�撬����(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable

            Try
                builSQL.Append("SELECT �s�撬����")
                builSQL.Append(" FROM B_�X�֔ԍ�")
                builSQL.Append(" WHERE �s���{���� = @�s���{����")
                builSQL.Append(" GROUP BY �s�撬����")
                builSQL.Append(" ORDER BY �s�撬����")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>A_�V�X�e���̎s�撬���擾</summary>
        ''' <returns>�s�撬�����</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT �s���{��,�s�撬�� FROM A_�V�X�e��"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>����ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@������</param>
        ''' <returns>���惊�X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_YUU(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT �V�X�֔ԍ��\���p, ���於")
                builSQL.Append(" FROM B_�X�֔ԍ�")
                builSQL.Append(" WHERE �s�撬���� = @�s�撬���� AND ���於�J�i LIKE @������ ")
                builSQL.Append(" ORDER BY ���於�J�i")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace