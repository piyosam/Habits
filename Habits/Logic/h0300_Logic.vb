#Region "ƒCƒ“ƒ|[ƒg"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ŒÚ‹q‰æ–ÊƒƒWƒbƒNƒNƒ‰ƒX</summary>
    ''' <remarks></remarks>
    Public Class h0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>ŒÚ‹qî•ñˆê——æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@”Ô†§ŒÀã/@”Ô†§ŒÀ‰º</param>
        ''' <param name="num">•\¦Œ”</param>
        ''' <param name="regKbn">“o˜^‹æ•ª</param>
        ''' <param name="prevFlag">True:i‚Şƒ{ƒ^ƒ“‰Ÿ‰ºAFalseF–ß‚éƒ{ƒ^ƒ“‰Ÿ‰º</param>
        ''' <returns>ŒÚ‹qî•ñƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customerinfo(ByVal v_param As Habits.DB.DBParameter, ByVal num As Integer, ByVal regKbn As String, ByVal prevFlag As Boolean) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT TOP ")
                builSQL.Append(num)
                builSQL.Append(" D_ŒÚ‹q.ŒÚ‹q”Ô† AS ”Ô†, D_ŒÚ‹q.© + '  ' + ISNULL(D_ŒÚ‹q.–¼,'') AS –¼ ,")
                builSQL.Append(" D_ŒÚ‹q.©ƒJƒi + '  ' + ISNULL(D_ŒÚ‹q.–¼ƒJƒi,'') AS ƒJƒi,")
                builSQL.Append(" B_«•Ê.«•Ê ,D_ŒÚ‹q.¶”NŒ“ú, D_ŒÚ‹q.—X•Ö”Ô† AS '§', D_ŒÚ‹q.“s“¹•{Œ§,")
                builSQL.Append(" ISNULL(D_ŒÚ‹q.ZŠ1,'') + ISNULL(D_ŒÚ‹q.ZŠ2,'') + ISNULL(D_ŒÚ‹q.ZŠ3,'') AS ZŠ,")
                builSQL.Append(" D_ŒÚ‹q.“d˜b”Ô†, D_ŒÚ‹q.EmailƒAƒhƒŒƒX")
                builSQL.Append(" FROM D_ŒÚ‹q")
                builSQL.Append(" LEFT JOIN B_«•Ê ON D_ŒÚ‹q.«•Ê”Ô† = B_«•Ê.«•Ê”Ô†")
                builSQL.Append(" WHERE ")

                'i‚Şƒ{ƒ^ƒ“A–ß‚·ƒ{ƒ^ƒ“‰Ÿ‰º”»’è
                If prevFlag = True Then
                    builSQL.Append(" D_ŒÚ‹q.ŒÚ‹q”Ô† >= @ŒŸõŠJn”Ô† ")
                    builSQL.Append(" AND D_ŒÚ‹q.ŒÚ‹q”Ô† <= @ŒŸõI—¹”Ô† ")
                Else
                    builSQL.Append(" D_ŒÚ‹q.ŒÚ‹q”Ô† < @ŒŸõŠJn”Ô† ")
                End If

                '“o˜^‹æ•ªİ’è
                If regKbn <> "" Then
                    builSQL.Append(" AND D_ŒÚ‹q.“o˜^‹æ•ª”Ô† = ")
                    builSQL.Append(regKbn)
                End If

                'i‚Şƒ{ƒ^ƒ“A–ß‚·ƒ{ƒ^ƒ“‰Ÿ‰º”»’è
                If prevFlag = True Then
                    builSQL.Append(" ORDER BY D_ŒÚ‹q.ŒÚ‹q”Ô†")
                Else
                    builSQL.Append(" ORDER BY D_ŒÚ‹q.ŒÚ‹q”Ô† DESC ")
                End If

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>Å¬AÅ‘åŒÚ‹q”Ô†æ“¾</summary>
        ''' <returns>Å¬AÅ‘åŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function selectMinMaxCustomerId() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT")

                builSQL.Append(" ISNULL(Å¬ŒÚ‹q”Ô†,0) AS Å¬ŒÚ‹q”Ô†, ISNULL(Å‘åŒÚ‹q”Ô†,0) AS Å‘åŒÚ‹q”Ô†,")
                builSQL.Append(" ISNULL(Å¬ŒÚ‹q”Ô†_‰¼“o˜^,0) AS Å¬ŒÚ‹q”Ô†_‰¼“o˜^, ISNULL(Å‘åŒÚ‹q”Ô†_‰¼“o˜^,0) AS Å‘åŒÚ‹q”Ô†_‰¼“o˜^,")
                builSQL.Append(" ISNULL(Å¬ŒÚ‹q”Ô†_“o˜^Ï,0) AS Å¬ŒÚ‹q”Ô†_“o˜^Ï, ISNULL(Å‘åŒÚ‹q”Ô†_“o˜^Ï,0) AS Å‘åŒÚ‹q”Ô†_“o˜^Ï")
                builSQL.Append(" FROM")
                builSQL.Append(" (SELECT MIN(ŒÚ‹q”Ô†) AS Å¬ŒÚ‹q”Ô†,MAX(ŒÚ‹q”Ô†) AS Å‘åŒÚ‹q”Ô† FROM D_ŒÚ‹q WHERE ŒÚ‹q”Ô† < @ƒtƒŠ[ŒÚ‹q”Ô†) AS A")
                builSQL.Append(" ,(SELECT MIN(ŒÚ‹q”Ô†) AS Å¬ŒÚ‹q”Ô†_‰¼“o˜^,MAX(ŒÚ‹q”Ô†) AS Å‘åŒÚ‹q”Ô†_‰¼“o˜^ FROM D_ŒÚ‹q WHERE “o˜^‹æ•ª”Ô† = '0' AND ŒÚ‹q”Ô† < @ƒtƒŠ[ŒÚ‹q”Ô†) AS B")
                builSQL.Append(" ,(SELECT MIN(ŒÚ‹q”Ô†) AS Å¬ŒÚ‹q”Ô†_“o˜^Ï,MAX(ŒÚ‹q”Ô†) AS Å‘åŒÚ‹q”Ô†_“o˜^Ï FROM D_ŒÚ‹q WHERE “o˜^‹æ•ª”Ô† = '1' AND ŒÚ‹q”Ô† < @ƒtƒŠ[ŒÚ‹q”Ô†) AS C")
                param.Add("@ƒtƒŠ[ŒÚ‹q”Ô†", Clng_STFreeNo)

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>“o˜^‹æ•ªˆê——æ“¾</summary>
        ''' <returns>“o˜^‹æ•ªƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Dim dt As New DataTable
            Dim dt_rtn As New DataTable
            Dim i As Integer
            dt_rtn.Columns.Add("“o˜^‹æ•ª”Ô†")
            dt_rtn.Columns.Add("“o˜^‹æ•ª")

            dt_rtn.Rows.Add("", "‘S‚Ä")
            dt = MyBase.B_“o˜^‹æ•ª()
            If dt.Rows.Count <> 0 Then
                i = 0
                While i < dt.Rows.Count
                    dt_rtn.Rows.Add(dt.Rows(i)("“o˜^‹æ•ª”Ô†"), dt.Rows(i)("“o˜^‹æ•ª"))
                    i += 1
                End While
            End If


            Return dt_rtn
        End Function

    End Class
End Namespace
