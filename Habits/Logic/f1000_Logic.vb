#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ìÆÔÝèi{pÔjæÊWbNNX</summary>
    ''' <remarks></remarks>
    Public Class f1000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1000_Hö"
        Private Enum gdsPrcsNmb As Integer
            dispOrd = 0
            dispOrd1 = 1
            dispOrd2 = 2
        End Enum

        ''' <summary>¤iHöîñæ¾</summary>
        ''' <param name="v_param">SQLp[^F@ãæªÔ/@ªÞÔ/@¤iÔ</param>
        ''' <returns>¤iHöîñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function XVàe(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT C_¤iHö.HöÔ AS Ô,B_Hö.Hö¼,")
                builSQL.Append(" B_Hö.|Cg,C_¤iHö.\¦,")
                builSQL.Append(" B_Hö.\¦ AS }X^\¦")
                builSQL.Append(" FROM C_¤iHö")
                builSQL.Append(" JOIN B_Hö ON  C_¤iHö.HöÔ = B_Hö.HöÔ")
                builSQL.Append(" WHERE C_¤iHö.ãæªÔ = @ãæªÔ")
                builSQL.Append(" AND C_¤iHö.ªÞÔ = @ªÞÔ")
                builSQL.Append(" AND C_¤iHö.¤iÔ = @¤iÔ")
                builSQL.Append(" ORDER BY C_¤iHö.\¦")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>C_¤iHöf[^í</summary>
        ''' <param name="v_param">SQLp[^F@XVú/@ãæªÔ/@ªÞÔ/@¤iÔ/@HöÔ</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function C_¤iHöí(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' gUNVJn
                DBA.TransactionStart()
                builSQL.Length = 0
                builSQL.Append("DELETE FROM C_¤iHö")
                builSQL.Append(" WHERE ãæªÔ = @ãæªÔ")
                builSQL.Append(" AND ªÞÔ = @ªÞÔ")
                builSQL.Append(" AND ¤iÔ = @¤iÔ")
                builSQL.Append(" AND HöÔ = @HöÔ")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQLÀsð INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlDelGoods_process(v_param))

                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>Höîñêæ¾</summary>
        ''' <returns>HöXg</returns>
        ''' <remarks></remarks>
        Protected Friend Function àeXV() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT HöÔ AS Ô,Hö¼,|Cg,\¦ FROM W_Hö ORDER BY \¦,Ô"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>W_Höf[^ÇÁ</summary>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_Hö}X^() As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_Hö")
                builSQL.Append(" SELECT HöÔ,")
                builSQL.Append(" Hö¼,|Cg,")
                builSQL.Append(" \¦")
                builSQL.Append(" FROM B_Hö")
                builSQL.Append(" WHERE ítO = 'false'")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>W_Höf[^í</summary>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_WHö() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' gUNVJn
                DBA.TransactionStart()
                str_sql = "DELETE W_Hö FROM W_Hö"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>C_¤iHöf[^ÇÁ</summary>
        ''' <param name="v_param">SQLp[^F@ãæªÔ/@ªÞÔ/@¤iÔ/@HöÔ/@XVú</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function HöÇÁtoC_¤iHö(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_¤iHö(")
                builSQL.Append(" ãæªÔ,")
                builSQL.Append(" ªÞÔ,")
                builSQL.Append(" ¤iÔ,")
                builSQL.Append(" HöÔ,")
                builSQL.Append(" \¦,")
                builSQL.Append(" XVú )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @ãæªÔ,")
                builSQL.Append(" @ªÞÔ,")
                builSQL.Append(" @¤iÔ,")
                builSQL.Append(" @HöÔ,")
                builSQL.Append(" @\¦,")
                builSQL.Append(" @XVú )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀsð INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1Ýè
                builSQL.Append("INSERT INTO goods_process(")
                builSQL.Append(" shop_code,")               'XÜR[h
                builSQL.Append(" sales_division_code,")     'ãæªÔ
                builSQL.Append(" class_code,")              'ªÞÔ
                builSQL.Append(" goods_code,")              '¤iÔ
                builSQL.Append(" process_code,")            'HöÔ
                builSQL.Append(" display_order,")           '\¦
                builSQL.Append(" update_date )")            'XVú
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@ãæªÔ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@ªÞÔ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@¤iÔ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@HöÔ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@\¦")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@XVú")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                '' áO­¶Í[obN
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>W_Höf[^ÇÁ</summary>
        ''' <param name="v_param">SQLp[^F@HöÔ/@Hö¼/@|Cg</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function HöÇÁtoW_Hö(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO W_Hö(")
                builSQL.Append(" HöÔ,")
                builSQL.Append(" Hö¼,")
                builSQL.Append(" |Cg,")
                builSQL.Append(" \¦)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @HöÔ,")
                builSQL.Append(" @Hö¼,")
                builSQL.Append(" @|Cg,")
                builSQL.Append(" @}X^\¦)")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)
                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                '' áO­¶Í[obN
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>W_Höf[^í</summary>
        ''' <param name="v_param">SQLp[^F@HöÔ/@Hö¼/@|Cg</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function HöífromW_Hö(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append(" DELETE FROM W_Hö")
                builSQL.Append(" WHERE HöÔ = @HöÔ")
                builSQL.Append(" AND Hö¼ = @Hö¼")
                builSQL.Append(" AND |Cg = @|Cg")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>W_Höf[^í</summary>
        ''' <param name="v_param">SQLp[^F@ãæªÔ/@ªÞÔ/@¤iÔ</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function }X^²®(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As Integer

            Try
                ' gUNVJn
                DBA.TransactionStart()
                builSQL.Append(" DELETE FROM W_Hö")
                builSQL.Append(" WHERE HöÔ IN(")
                builSQL.Append(" SELECT HöÔ FROM C_¤iHö")
                builSQL.Append(" WHERE ãæªÔ = @ãæªÔ")
                builSQL.Append(" AND ªÞÔ = @ªÞÔ")
                builSQL.Append(" AND ¤iÔ = @¤iÔ)")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>C_¤iHöf[^\¦ÏX</summary>
        ''' <param name="v_param">SQLp[^F@ãæªÔ/@ªÞÔ/@¤iÔ1/@\¦1/@¤iÔ2/@\¦2</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function Hö\¦ÏX(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim rtn As Boolean = False
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' gUNVJn
                DBA.TransactionStart()

                ' Iðµ½R[h
                builSQL.Append("UPDATE C_¤iHö SET")
                builSQL.Append(" \¦ = @\¦1,")
                builSQL.Append(" XVú = @XVú")
                builSQL.Append(" WHERE ãæªÔ = @ãæªÔ")
                builSQL.Append(" AND ªÞÔ = @ªÞÔ")
                builSQL.Append(" AND ¤iÔ = @¤iÔ")
                builSQL.Append(" AND HöÔ = @HöÔ1")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQLÀsð INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd1))

                builSQL.Length = 0
                builSQL.Append("UPDATE C_¤iHö SET")
                builSQL.Append(" \¦ = @\¦2,")
                builSQL.Append(" XVú = @XVú")
                builSQL.Append(" WHERE ãæªÔ = @ãæªÔ")
                builSQL.Append(" AND ªÞÔ = @ªÞÔ")
                builSQL.Append(" AND ¤iÔ = @¤iÔ")
                builSQL.Append(" AND HöÔ = @HöÔ2")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQLÀsð INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd2))

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                '' áO­¶Í[obN
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>C_¤iHöf[^\¦ÏX</summary>
        ''' <param name="salesDiv">ãæªÔ</param>
        ''' <param name="classCd">ªÞÔ</param>
        ''' <param name="goodsCd">¤iÔ</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function Hö\¦ÏX_ALL(ByVal salesDiv As String, ByVal classCd As String, ByVal goodsCd As String) As Boolean
            Dim rtn As Boolean = False
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim v_param As New Habits.DB.DBParameter
            Dim dt As New DataTable
            Dim i As Integer = 0

            builSQL.Append("UPDATE C_¤iHö SET")
            builSQL.Append(" \¦ = @\¦,")
            builSQL.Append(" XVú = @XVú")
            builSQL.Append(" WHERE ãæªÔ = @ãæªÔ")
            builSQL.Append(" AND ªÞÔ = @ªÞÔ")
            builSQL.Append(" AND ¤iÔ = @¤iÔ")
            builSQL.Append(" AND HöÔ = @HöÔ")
            str_sql = builSQL.ToString

            Try
                ' gUNVJn
                DBA.TransactionStart()

                ' ¤iÌSHöR[hæ¾
                v_param.Add("@ãæªÔ", salesDiv)
                v_param.Add("@ªÞÔ", classCd)
                v_param.Add("@¤iÔ", goodsCd)
                dt = XVàe(v_param)

                Do While i < dt.Rows.Count
                    v_param.Clear()
                    v_param.Add("@\¦", i + 1)
                    v_param.Add("@XVú", Now)
                    v_param.Add("@ãæªÔ", salesDiv)
                    v_param.Add("@ªÞÔ", classCd)
                    v_param.Add("@¤iÔ", goodsCd)
                    v_param.Add("@HöÔ", dt.Rows(i)(0).ToString)
                    str_sql = builSQL.ToString

                    rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                    'Z_SQLÀsð INSERT
                    InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd))

                    i += 1
                Loop

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                '' áO­¶Í[obN
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>[C_¤iHö]Åå\¦æ¾</summary>
        ''' <param name="v_param">SQLp[^F@ãæªÔ/@ªÞÔ/@¤iÔ</param>
        ''' <returns>¤iHöîñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetMaxCount_¤iHö(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As DataTable
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(\¦)")
                builSQL.Append(" FROM C_¤iHö")
                builSQL.Append(" WHERE C_¤iHö.ãæªÔ = @ãæªÔ")
                builSQL.Append(" AND C_¤iHö.ªÞÔ = @ªÞÔ")
                builSQL.Append(" AND C_¤iHö.¤iÔ = @¤iÔ")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            If dt.Rows.Count > 0 AndAlso Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString()) Then
                rtn = dt.Rows(0)(0)
            End If
            Return rtn
        End Function

        ''' <summary>Z_SQLÀsðÌSQL1¶¬(goods_processÌDelete)</summary>
        ''' <param name="v_param">SQLp[^F@ãæªÔ/@ªÞÔ/@¤iÔ/@HöÔ</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Private Function getSqlDelGoods_process(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQLÀsð SQL1
                builSQL.Length = 0
                builSQL.Append(" DELETE FROM goods_process")
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@ãæªÔ")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@ªÞÔ")))
                builSQL.Append(" AND goods_code =" & VbSQLStr(v_param.GetValue("@¤iÔ")))
                builSQL.Append(" AND process_code =" & VbSQLStr(v_param.GetValue("@HöÔ")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>Z_SQLÀsðÌSQL1¶¬(goods_processÌUpdate)</summary>
        ''' <param name="v_param">SQLp[^F@\¦/@XVú/@ãæªÔ/@ªÞÔ/@¤iÔ/@HöÔ</param>
        ''' <param name="v_kbn">\¦AHöÔÌp[^æª</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdGoods_process(ByVal v_param As Habits.DB.DBParameter, ByVal v_kbn As gdsPrcsNmb) As String
            Dim builSQL As New StringBuilder()
            Dim dispName As String = "@\¦"
            Dim prsName As String = "@HöÔ"
            Try
                Select Case v_kbn
                    Case gdsPrcsNmb.dispOrd
                        dispName = "@\¦"
                        prsName = "@HöÔ"
                    Case gdsPrcsNmb.dispOrd1
                        dispName = "@\¦1"
                        prsName = "@HöÔ1"
                    Case gdsPrcsNmb.dispOrd2
                        dispName = "@\¦2"
                        prsName = "@HöÔ2"
                End Select

                'Z_SQLÀsð SQL1
                builSQL.Length = 0
                builSQL.Append("UPDATE goods_process SET")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue(dispName)))
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@XVú")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@ãæªÔ")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@ªÞÔ")))
                builSQL.Append(" AND goods_code =" & VbSQLStr(v_param.GetValue("@¤iÔ")))
                builSQL.Append(" AND process_code =" & VbSQLStr(v_param.GetValue(prsName)))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
