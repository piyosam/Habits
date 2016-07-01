#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>������͉�ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Class c0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0200_�������"

#Region "�ő唄��ԍ��擾"
        ''' <summary>�ő唄��ԍ����擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>����ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function get������ԍ�(ByVal v_param As Habits.DB.DBParameter) As String
            Dim rtn As String = "1"
            Dim obj As New Object
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(����ԍ�) + 1  AS ����ԍ�")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" WHERE ���X��=@���X��")
                builSQL.Append(" AND ���X�Ҕԍ�=@���X�Ҕԍ�")
                builSQL.Append(" AND �ڋq�ԍ�=@�ڋq�ԍ�")

                str_sql = builSQL.ToString
                obj = DBA.ExecuteScalar(str_sql, v_param)
                If Not IsDBNull(obj) Then
                    rtn = obj.ToString
                End If
            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("������ԍ��̎擾�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "���㖾�׌���"
        ''' <summary>E_���㖾�׌���</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@�ڋq�ԍ�</param>
        ''' <returns>�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_saleDetails(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �ڋq�ԍ� FROM E_���㖾�� WHERE �ڋq�ԍ� = @�ڋq�ԍ� AND ���X�� = @���X�� AND ���X�Ҕԍ� = @���X�Ҕԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("���㖾�׌����Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���㖾�ׂ̓o�^"
        ''' <summary>E_���㖾�ׂɃf�[�^��o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function InSertDataEUM(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '' E_���㖾�ׂɃf�[�^��o�^
                builSQL.Append("INSERT INTO E_���㖾�� (")
                builSQL.Append(" ���X��")
                builSQL.Append(" ,���X�Ҕԍ�")
                builSQL.Append(" ,�ڋq�ԍ�")
                builSQL.Append(" ,����ԍ�")
                builSQL.Append(" ,����敪�ԍ�")
                builSQL.Append(" ,����S���Ҕԍ�")
                builSQL.Append(" ,���ޔԍ�")
                builSQL.Append(" ,���̔ԍ�")
                builSQL.Append(" ,����")
                builSQL.Append(" ,���z")
                builSQL.Append(" ,�T�[�r�X�ԍ�")
                builSQL.Append(" ,�T�[�r�X")
                builSQL.Append(" ,��v��")
                builSQL.Append(" ,�X�V��")
                builSQL.Append(" ,�����")

                builSQL.Append(" )VALUES (")
                builSQL.Append(" @���X��")
                builSQL.Append(" ,@���X�Ҕԍ�")
                builSQL.Append(" ,@�ڋq�ԍ�")
                builSQL.Append(" ,@����ԍ�")
                builSQL.Append(" ,@����敪�ԍ�")
                builSQL.Append(" ,@����S���Ҕԍ�")
                builSQL.Append(" ,@���ޔԍ�")
                builSQL.Append(" ,@���̔ԍ�")
                builSQL.Append(" ,@����")
                builSQL.Append(" ,@���z")
                builSQL.Append(" ,@�T�[�r�X�ԍ�")
                builSQL.Append(" ,@�T�[�r�X")
                builSQL.Append(" ,@��v��")
                builSQL.Append(" ,@�X�V��")
                builSQL.Append(" ,@�����)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO sales_details (")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,visit_date")
                builSQL.Append(" ,visit_number")
                builSQL.Append(" ,basis_customer_code")
                builSQL.Append(" ,code")
                builSQL.Append(" ,sales_division_code")
                builSQL.Append(" ,sales_staff_code")
                builSQL.Append(" ,class_code")
                builSQL.Append(" ,goods_code")
                builSQL.Append(" ,count")
                builSQL.Append(" ,amount")
                builSQL.Append(" ,service_code")
                builSQL.Append(" ,service_amount")
                builSQL.Append(" ,paid_flag")
                builSQL.Append(" ,update_date")
                builSQL.Append(" ,tax")
                builSQL.Append(" )VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@���X��")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@���X�Ҕԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@�ڋq�ԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@����ԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@����敪�ԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@����S���Ҕԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@���ޔԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@���̔ԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@����")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@���z")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@�T�[�r�X�ԍ�")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@�T�[�r�X")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@��v��")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@�X�V��")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@�����")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("���㖾�ׂ̓o�^�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "�J���e�L���m�F"
        ''' <summary>�J���e�L���m�F</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X��/@���X�Ҕԍ�/@�ڋq�ԍ�</param>
        ''' <returns>�J���e</returns>
        ''' <remarks></remarks>
        Protected Friend Function chkExistChart(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT �J���e FROM E_�J���e WHERE ���X�� = @���X�� AND �ڋq�ԍ� = @�ڋq�ԍ� AND ���X�Ҕԍ� = @���X�Ҕԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("�J���e���L���m�F�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                "�������ēx�s���Ă��������B�@", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

    End Class
End Namespace