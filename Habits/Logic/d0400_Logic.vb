#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>XÒæÊWbNNX</summary>
    ''' <remarks></remarks>
    Public Class d0400_logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>XÒêæ¾</summary>
        ''' <param name="v_param">SQLp[^</param>
        ''' <returns>XÒîñXg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT E_ã.ÚqÔ")
                builSQL.Append(" ,(E_XÒ.© + '  ' + ISNULL(E_XÒ.¼,'')) AS ¼")
                builSQL.Append(" ,B_«Ê.«Ê")
                builSQL.Append(" ,B_Xæª.Xæª")
                builSQL.Append(" ,CASE WHEN E_ã.w¼ = 'True' THEN 'w¼' ELSE '  ' END w¼")
                builSQL.Append(" ,D_SÒ.SÒ¼")
                builSQL.Append(" ,CASE WHEN (E_ã.J[hx¥>0 OR E_ã.»Ì¼x¥>0) AND E_ã.|Cgøx¥>0 THEN '»à¼ Îß²ÝÄ'")
                builSQL.Append(" WHEN (E_ã.J[hx¥>0 OR E_ã.»Ì¼x¥>0) THEN '»à¼'")
                builSQL.Append(" WHEN E_ã.|Cgøx¥>0 THEN 'Îß²ÝÄ' END AS x¥")
                builSQL.Append(" ,ã¾×.ã - E_ã.T[rXàz AS ãàz")
                builSQL.Append(" ,ã¾×.T[rX + E_ã.T[rXàz AS T[rX")
                builSQL.Append(" ,E_ã.ÁïÅ AS ÁïÅ")
                'builSQL.Append(" ,(ã¾×.ã+E_ã.ÁïÅ) AS Å")
                builSQL.Append(" ,E_ã.XÒÔ")

                builSQL.Append(" FROM E_ã")

                builSQL.Append(" INNER JOIN E_XÒ")
                builSQL.Append(" ON E_ã.Xú = E_XÒ.Xú AND E_ã.XÒÔ = E_XÒ.XÒÔ")
                builSQL.Append(" AND E_ã.ÚqÔ = E_XÒ.ÚqÔ")

                builSQL.Append(" INNER JOIN (SELECT Xú,XÒÔ,ÚqÔ,SUM(Ê * àz - T[rX) AS ã,SUM(T[rX) AS T[rX")
                builSQL.Append(" FROM E_ã¾× WHERE Xú = @I¹ú AND ïvÏ = 'True' GROUP BY Xú,XÒÔ,ÚqÔ) AS ã¾×")
                builSQL.Append(" ON E_ã.Xú = ã¾×.Xú AND E_ã.XÒÔ = ã¾×.XÒÔ AND E_ã.ÚqÔ = ã¾×.ÚqÔ")

                builSQL.Append(" INNER JOIN B_«Ê ON E_ã.«ÊÔ = B_«Ê.«ÊÔ")
                builSQL.Append(" INNER JOIN B_Xæª ON E_ã.XæªÔ = B_Xæª.XæªÔ")
                builSQL.Append(" INNER JOIN D_SÒ ON E_ã.åSÒÔ = D_SÒ.SÒÔ")
                builSQL.Append(" INNER JOIN D_Úq ON E_ã.ÚqÔ = D_Úq.ÚqÔ")

                builSQL.Append(" WHERE E_ã.Xú = @I¹ú")
                builSQL.Append(" ORDER BY E_ã.XÒÔ ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace