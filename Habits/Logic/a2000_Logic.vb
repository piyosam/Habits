#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    Public Class a2000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a2000_���[�h�ύX"

        ''' <summary>�Ǘ��҃��[�h�p�X���[�h�m�F</summary>
        ''' <returns>True�F�p�X���[�h��v,False�F�s��v</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetManagementMode(ByVal pwd As String) As Boolean
            Dim rtn As Boolean = False
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT �\��3 FROM A_�V�X�e��"
                dt = DBA.ExecuteDataTable(str_sql)
                If Not dt Is Nothing AndAlso dt.Rows.Count = 1 AndAlso dt.Rows(0).Item("�\��3").ToString() = pwd Then
                    rtn = True
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function

    End Class
End Namespace