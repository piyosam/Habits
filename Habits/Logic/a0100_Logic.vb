#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>���[�h�����W�b�N�N���X</summary>
    ''' <remarks>�}�X�^�_�E�����[�h�`�F�b�N����</remarks>
    Public Class a0100_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>�ŏI�_�E�����[�h���Ԏ擾</summary>
        ''' <returns>M_����M���R�[�h</returns>
        ''' <remarks></remarks>
        Protected Friend Function selectDownloadDate() As DataTable
            Return MyBase.GetDownloadDate()
        End Function

        '#Region "�_�E�����[�h�f�[�^���e�[�u���ɔ��f"
        '        ''' <summary>�_�E�����[�h�f�[�^����e�[�u���X�V</summary>
        '        ''' <remarks></remarks>
        '        Sub updateMiura()
        '            Dim builSQL As New StringBuilder()
        '            Dim str_sql As String
        '            Dim dt As DataTable
        '            Try
        '                dt = A_System()
        '                If dt Is Nothing OrElse Not dt.Rows(0).Item("�\��2").Equals("True") Then
        '                    Exit Sub
        '                End If
        '                ' �g�����U�N�V�����J�n
        '                DBA.TransactionStart()

        '                str_sql = "UPDATE Z_SQL���s���� SET SQL1='INSERT INTO cash_book(shop_code,date,code,cash_division_code,amount,basis_staff_code,summary,insert_date) VALUES(N''miura'',''2012/06/23'',''1'',''2'',''2889'',''4'',N''�򉻑����|��  '',''2012/06/23 17:33:04'')' WHERE �����ԍ�='1056' AND ���ID='d0500_�������o���o�^'"
        '                rtn = DBA.ExecuteNonQuery(str_sql)

        '                str_sql = "UPDATE A_�V�X�e�� SET �ʐM���t���O='1',�\��2='2012/06/26'"
        '                rtn = DBA.ExecuteNonQuery(str_sql)

        '                str_sql = "UPDATE system SET Dummy2=" & VbSQLNStr("2012/06/26") & " where shop_code=" & VbSQLNStr(sShopcode)
        '                rtn = InsertZSqlExecHis("�f�[�^�C��2012/6/26", str_sql)
        '                ' �R�~�b�g
        '                DBA.TransactionCommit()

        '            Catch ex As Exception
        '                ' ���[���o�b�N
        '                DBA.TransactionRollBack()
        '                Throw ex
        '            End Try
        '        End Sub
        '#End Region

#Region "�_�E�����[�h�f�[�^���e�[�u���ɔ��f"
        ''' <summary>�_�E�����[�h�f�[�^����e�[�u���X�V</summary>
        ''' <remarks></remarks>
        Sub updateKurihama()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                'str_sql = "SELECT COUNT(*) FROM D_�ڋq where �ڋq�ԍ� ='0'"

                'dt = DBA.ExecuteDataTable(str_sql)
                'If Integer.Parse(dt.Rows(0).Item(0).ToString()) = 0 Then
                '    '�Ή��ς̂��ߏI��
                '    Exit Sub
                'End If

                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                str_sql = "delete from E_���X�� where �ڋq�ԍ� ='0'"
                rtn = DBA.ExecuteNonQuery(str_sql)

                str_sql = "delete from D_�ڋq where �ڋq�ԍ� ='0'"
                rtn = DBA.ExecuteNonQuery(str_sql)

                'str_sql = "UPDATE [E_����] SET [�����x��]=ISNULL((SELECT ROUND(SUM([����]*[���z]-[�T�[�r�X])* "
                'str_sql += " (CASE WHEN ���X��>='1989/4/1' AND ���X��<'1997/4/1' THEN 1.03 WHEN ���X��>='1997/4/1' THEN 1.05 ELSE 0 END),0) "
                'str_sql += " FROM E_���㖾�� WHERE [E_����].���X�� =E_���㖾��.���X�� AND [E_����].���X�Ҕԍ� =E_���㖾��.���X�Ҕԍ� "
                'str_sql += " AND [E_����].�ڋq�ԍ� =E_���㖾��.�ڋq�ԍ� GROUP BY E_���㖾��.���X��,E_���㖾��.���X�Ҕԍ�,E_���㖾��.�ڋq�ԍ�),0)"
                'str_sql += " ,[���a��]=ISNULL((SELECT ROUND(SUM([����]*[���z]-[�T�[�r�X])*"
                'str_sql += " (CASE WHEN ���X��>='1989/4/1' AND ���X��<'1997/4/1' THEN 1.03 WHEN ���X��>='1997/4/1' THEN 1.05	ELSE 0 END),0)"
                'str_sql += " FROM E_���㖾�� WHERE [E_����].���X�� =E_���㖾��.���X�� AND [E_����].���X�Ҕԍ� =E_���㖾��.���X�Ҕԍ�"
                'str_sql += " AND [E_����].�ڋq�ԍ� =E_���㖾��.�ڋq�ԍ� GROUP BY E_���㖾��.���X��,E_���㖾��.���X�Ҕԍ�,E_���㖾��.�ڋq�ԍ�),0)"
                'str_sql += " ,[�����]=ISNULL((SELECT ROUND(SUM([����]*[���z]-[�T�[�r�X])*"
                'str_sql += " (CASE WHEN ���X��>='1989/4/1' AND ���X��<'1997/4/1' THEN 0.03 WHEN ���X��>='1997/4/1' THEN 0.05	ELSE 0 END),0)"
                'str_sql += " FROM E_���㖾�� WHERE [E_����].���X�� =E_���㖾��.���X�� AND [E_����].���X�Ҕԍ� =E_���㖾��.���X�Ҕԍ�"
                'str_sql += " AND [E_����].�ڋq�ԍ� =E_���㖾��.�ڋq�ԍ� GROUP BY E_���㖾��.���X��,E_���㖾��.���X�Ҕԍ�,E_���㖾��.�ڋq�ԍ�),0)"
                'str_sql += " WHERE E_����.���X��<'2012/6/11'"
                'rtn = DBA.ExecuteNonQuery(str_sql)

                'str_sql = "UPDATE A_�V�X�e�� SET �\��2='2012/9/29'"
                'rtn = DBA.ExecuteNonQuery(str_sql)

                str_sql = "DELETE FROM visit where basis_customer_code = ''0'' AND shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis("�f�[�^�C��", str_sql)

                str_sql = "DELETE FROM basis_customer where code = ''0'' AND shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis("�f�[�^�C��", str_sql)

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                Throw ex
                ' ���[���o�b�N
                DBA.TransactionRollBack()
            End Try
        End Sub
#End Region

    End Class
End Namespace
