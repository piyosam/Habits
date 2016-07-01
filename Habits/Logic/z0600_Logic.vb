#Region "ƒCƒ“ƒ|[ƒg"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>—X•Ö”Ô†ŒŸõ‰æ–ÊƒƒWƒbƒN</summary>
    ''' <remarks></remarks>
    Public Class z0600_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>“s“¹•{Œ§–¼ˆê——‚Ìæ“¾</summary>
        ''' <returns>“s“¹•{Œ§–¼ƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_“s“¹•{Œ§–¼() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable

            Try
                builSQL.Append("SELECT B_—X•Ö”Ô†.“s“¹•{Œ§–¼")
                builSQL.Append(" FROM B_—X•Ö”Ô†")
                builSQL.Append(" GROUP BY B_—X•Ö”Ô†.“s“¹•{Œ§–¼")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>s‹æ’¬‘º–¼ˆê——æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@“s“¹•{Œ§–¼</param>
        ''' <returns>s‹æ’¬‘ºƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_s‹æ’¬‘º–¼(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable

            Try
                builSQL.Append("SELECT s‹æ’¬‘º–¼")
                builSQL.Append(" FROM B_—X•Ö”Ô†")
                builSQL.Append(" WHERE “s“¹•{Œ§–¼ = @“s“¹•{Œ§–¼")
                builSQL.Append(" GROUP BY s‹æ’¬‘º–¼")
                builSQL.Append(" ORDER BY s‹æ’¬‘º–¼")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>A_ƒVƒXƒeƒ€‚Ìs‹æ’¬‘ºæ“¾</summary>
        ''' <returns>s‹æ’¬‘ºî•ñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT “s“¹•{Œ§,s‹æ’¬‘º FROM A_ƒVƒXƒeƒ€"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>’¬ˆæˆê——æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@“ª•¶š</param>
        ''' <returns>’¬ˆæƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_YUU(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT V—X•Ö”Ô†•\¦—p, ’¬ˆæ–¼")
                builSQL.Append(" FROM B_—X•Ö”Ô†")
                builSQL.Append(" WHERE s‹æ’¬‘º–¼ = @s‹æ’¬‘º–¼ AND ’¬ˆæ–¼ƒJƒi LIKE @“ª•¶š ")
                builSQL.Append(" ORDER BY ’¬ˆæ–¼ƒJƒi")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace