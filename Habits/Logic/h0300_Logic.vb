#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ΪqζΚWbNNX</summary>
    ''' <remarks></remarks>
    Public Class h0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>ΪqξρκζΎ</summary>
        ''' <param name="v_param">SQLp[^F@Τ§ΐγ/@Τ§ΐΊ</param>
        ''' <param name="num">\¦</param>
        ''' <param name="regKbn">o^ζͺ</param>
        ''' <param name="prevFlag">True:iή{^ΊAFalseFίι{^Ί</param>
        ''' <returns>ΪqξρXg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customerinfo(ByVal v_param As Habits.DB.DBParameter, ByVal num As Integer, ByVal regKbn As String, ByVal prevFlag As Boolean) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT TOP ")
                builSQL.Append(num)
                builSQL.Append(" D_Ϊq.ΪqΤ AS Τ, D_Ϊq.© + '  ' + ISNULL(D_Ϊq.Ό,'') AS Ό ,")
                builSQL.Append(" D_Ϊq.©Ji + '  ' + ISNULL(D_Ϊq.ΌJi,'') AS Ji,")
                builSQL.Append(" B_«Κ.«Κ ,D_Ϊq.ΆNϊ, D_Ϊq.XΦΤ AS '§', D_Ϊq.sΉ{§,")
                builSQL.Append(" ISNULL(D_Ϊq.Z1,'') + ISNULL(D_Ϊq.Z2,'') + ISNULL(D_Ϊq.Z3,'') AS Z,")
                builSQL.Append(" D_Ϊq.dbΤ, D_Ϊq.EmailAhX")
                builSQL.Append(" FROM D_Ϊq")
                builSQL.Append(" LEFT JOIN B_«Κ ON D_Ϊq.«ΚΤ = B_«Κ.«ΚΤ")
                builSQL.Append(" WHERE ")

                'iή{^Aί·{^Ί»θ
                If prevFlag = True Then
                    builSQL.Append(" D_Ϊq.ΪqΤ >= @υJnΤ ")
                    builSQL.Append(" AND D_Ϊq.ΪqΤ <= @υIΉΤ ")
                Else
                    builSQL.Append(" D_Ϊq.ΪqΤ < @υJnΤ ")
                End If

                'o^ζͺέθ
                If regKbn <> "" Then
                    builSQL.Append(" AND D_Ϊq.o^ζͺΤ = ")
                    builSQL.Append(regKbn)
                End If

                'iή{^Aί·{^Ί»θ
                If prevFlag = True Then
                    builSQL.Append(" ORDER BY D_Ϊq.ΪqΤ")
                Else
                    builSQL.Append(" ORDER BY D_Ϊq.ΪqΤ DESC ")
                End If

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>Ε¬AΕεΪqΤζΎ</summary>
        ''' <returns>Ε¬AΕεΪqΤ</returns>
        ''' <remarks></remarks>
        Protected Friend Function selectMinMaxCustomerId() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT")

                builSQL.Append(" ISNULL(Ε¬ΪqΤ,0) AS Ε¬ΪqΤ, ISNULL(ΕεΪqΤ,0) AS ΕεΪqΤ,")
                builSQL.Append(" ISNULL(Ε¬ΪqΤ_Όo^,0) AS Ε¬ΪqΤ_Όo^, ISNULL(ΕεΪqΤ_Όo^,0) AS ΕεΪqΤ_Όo^,")
                builSQL.Append(" ISNULL(Ε¬ΪqΤ_o^Ο,0) AS Ε¬ΪqΤ_o^Ο, ISNULL(ΕεΪqΤ_o^Ο,0) AS ΕεΪqΤ_o^Ο")
                builSQL.Append(" FROM")
                builSQL.Append(" (SELECT MIN(ΪqΤ) AS Ε¬ΪqΤ,MAX(ΪqΤ) AS ΕεΪqΤ FROM D_Ϊq WHERE ΪqΤ < @t[ΪqΤ) AS A")
                builSQL.Append(" ,(SELECT MIN(ΪqΤ) AS Ε¬ΪqΤ_Όo^,MAX(ΪqΤ) AS ΕεΪqΤ_Όo^ FROM D_Ϊq WHERE o^ζͺΤ = '0' AND ΪqΤ < @t[ΪqΤ) AS B")
                builSQL.Append(" ,(SELECT MIN(ΪqΤ) AS Ε¬ΪqΤ_o^Ο,MAX(ΪqΤ) AS ΕεΪqΤ_o^Ο FROM D_Ϊq WHERE o^ζͺΤ = '1' AND ΪqΤ < @t[ΪqΤ) AS C")
                param.Add("@t[ΪqΤ", Clng_STFreeNo)

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>o^ζͺκζΎ</summary>
        ''' <returns>o^ζͺXg</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Dim dt As New DataTable
            Dim dt_rtn As New DataTable
            Dim i As Integer
            dt_rtn.Columns.Add("o^ζͺΤ")
            dt_rtn.Columns.Add("o^ζͺ")

            dt_rtn.Rows.Add("", "SΔ")
            dt = MyBase.B_o^ζͺ()
            If dt.Rows.Count <> 0 Then
                i = 0
                While i < dt.Rows.Count
                    dt_rtn.Rows.Add(dt.Rows(i)("o^ζͺΤ"), dt.Rows(i)("o^ζͺ"))
                    i += 1
                End While
            End If


            Return dt_rtn
        End Function

    End Class
End Namespace
