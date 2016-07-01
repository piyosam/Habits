#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�X�W�v��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class d0300_Logic
        Inherits Habits.Logic.LogicBase

        Private builSQL As New StringBuilder()

#Region "�e�[�u���폜"
        ''' <summary>�폜�e�[�u���FW_�ڕW�AW_�x��</summary>
        ''' <remarks></remarks>
        Protected Friend Sub deleteWkTbl()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                'W_�ڕW�e�[�u���폜
                str_sql = "DELETE FROM W_�ڕW"
                DBA.ExecuteNonQuery(str_sql)

                'W_�x���e�[�u���폜
                str_sql = "DELETE FROM W_�x��"
                DBA.ExecuteNonQuery(str_sql)

                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region

#Region "���V�[�g���擾"
        ''' <summary>���V�[�g�Ɉ����������擾����</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���Z��</param>
        ''' <returns>���V�[�g���</returns>
        ''' <remarks></remarks>
        Protected Friend Function ���V�[�g�ړ�(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT")
                builSQL.Append(" 1 AS �f�[�^�^�C�v")
                builSQL.Append(" ,A_�V�X�e��.�X��1 AS �X��1")
                builSQL.Append(" ,A_�V�X�e��.�X��2 AS �X��2")
                builSQL.Append(" ,A_�V�X�e��.�X�Z��1 AS �X�Z��1")
                builSQL.Append(" ,A_�V�X�e��.�X�Z��2 AS �X�Z��2")
                builSQL.Append(" ,REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(A_�V�X�e��.�X�d�b�ԍ�,'9','�X'),")
                builSQL.Append(" '8','�W'),'7','�V'),'6','�U'),")
                builSQL.Append(" '5','�T'),'4','�S'),'3','�R'),")
                builSQL.Append(" '2','�Q'),'1','�P'),'0','�O') AS �X�d�b�ԍ�")
                builSQL.Append(" ,@���Z�� AS ���Z��")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_�x��.���q�{)),1),'.00','') AS �q��")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_�x��.�����{)),1),'.00','') AS ��������")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_�x��.�J�[�h�{)),1),'.00','') AS �����O����")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_�x��.���̑��{ + W_�x��.�|�C���g�����{)),1),'.00','') AS ���̑�")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_�x��.����Ŗ{)),1),'.00','') AS ��������")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_�x��.�����{ + W_�x��.�J�[�h�{ + W_�x��.���̑��{ + W_�x��.�|�C���g�����{ - W_�x��.����Ŗ{)),1),'.00','') AS ������")
                builSQL.Append(" FROM A_�V�X�e��,W_�x��")

                If (My.Settings.PrinterLogoFlag = 0) Then
                    builSQL.Append(" UNION SELECT 0 AS �f�[�^�^�C�v")
                    builSQL.Append(" ,@�Ж� AS �X��1")
                    builSQL.Append(" ,'' AS �X��2")
                    builSQL.Append(" ,'' AS �X�Z��1")
                    builSQL.Append(" ,'' AS �X�Z��2")
                    builSQL.Append(" ,'' AS �X�d�b�ԍ�")
                    builSQL.Append(" ,'' AS ���Z��")
                    builSQL.Append(" ,'' AS �q��")
                    builSQL.Append(" ,'' AS ��������")
                    builSQL.Append(" ,'' AS �����O����")
                    builSQL.Append(" ,'' AS ���̑�")
                    builSQL.Append(" ,'' AS ��������")
                    builSQL.Append(" ,'' AS ������")
                    builSQL.Append(" ORDER BY �f�[�^�^�C�v")
                End If

                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "����敪�ꗗ�擾"
        ''' <summary>����敪�ꗗ�擾</summary>
        ''' <returns>����敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDivList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.getSalesDiv(v_param)
        End Function
#End Region

#Region "�ڕW�z���擾"
        ''' <summary>�ڕW�z���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�Ώ۔N��</param>
        ''' <returns>�ڕW�z���</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_�ڕW�z(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append(" SELECT E_�ڕW�z.����敪�ԍ�,����敪,ISNULL(�ڕW�z,0) AS �ڕW�z,�c�Ɠ���")
                builSQL.Append(" FROM E_�ڕW�z")
                builSQL.Append(" INNER JOIN B_����敪 ON E_�ڕW�z.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" WHERE �Ώ۔N�� = @�Ώ۔N��")
                builSQL.Append(" ORDER BY B_����敪.�\����,B_����敪.����敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�ڕW�z���o�^"
        ''' <summary>�ڕW�z���o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@�Ώ۔N��/@�ڕW�z/@�c�Ɠ���/@�����/@����l��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_W_�ڕW(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Try
                builSQL.Length = 0
                builSQL.Append("INSERT INTO W_�ڕW (")
                builSQL.Append(" ����敪�ԍ�")
                builSQL.Append(" ,�Ώ۔N��")
                builSQL.Append(" ,�ڕW�z")
                builSQL.Append(" ,�c�Ɠ���)")

                builSQL.Append(" VALUES(")
                builSQL.Append("@����敪�ԍ�")
                builSQL.Append(",@�Ώ۔N��")
                builSQL.Append(",@�ڕW�z")
                builSQL.Append(",@�c�Ɠ���)")

                rtn = DBA.ExecuteNonQuery(builSQL.ToString, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "�ڕW�z���X�V"
        ''' <summary>�ڕW�z���X�V</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�����/@����l��/@����{/@����l�{/@����敪�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_W_�ڕW(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Dim str_sql As String
            Try
                str_sql = "UPDATE W_�ڕW SET ����� = @�����, ����l�� = @����l��,����{ = @����{,����l�{ = @����l�{ WHERE ����敪�ԍ� = @����敪�ԍ�"
                dt = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�ڕW�z���擾"
        ''' <summary>�ڕW�z���擾</summary>
        ''' <returns>�ڕW�z���</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W_�ڕW() As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT W_�ڕW.����敪�ԍ� ,����敪 ,ISNULL(�ڕW�z,0) AS �ڕW�z")
                builSQL.Append(" ,�c�Ɠ���,�����,����l��,����l�{")
                builSQL.Append(" FROM W_�ڕW")
                builSQL.Append(" INNER JOIN B_����敪")
                builSQL.Append(" ON W_�ڕW.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" ORDER BY B_����敪.�\����,B_����敪.����敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ʎw���q������擾"
        ''' <summary>���ʔ�����擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����/@���ʔԍ�</param>
        ''' <returns>���ʔ��ナ�X�g</returns>
        ''' <remarks>�j���ʎw��������W�v
        ''' ���ʎw������FE_������u�����x�� + �J�[�h�x�� + ���̑��x�� + �|�C���g�����x�� - ����Łv���W�v</remarks>
        Protected Friend Function select_nomination(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_����.�ڋq�ԍ�) AS �l��")
                builSQL.Append(" ,ISNULL(SUM(E_����.�����x�� + E_����.�J�[�h�x�� + E_����.���̑��x�� + E_����.�|�C���g�����x�� - E_����.�����),0) AS ����")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n��")
                builSQL.Append(" AND E_����.���X��<= @�I����")
                builSQL.Append(" AND E_����.�w��='True'")
                builSQL.Append(" AND E_����.���ʔԍ�=@���ʔԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ʗ��X�l���ꗗ�擾"
        ''' <summary>���ʗ��X�l���ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>���ʗ��X�l�����X�g</returns>
        ''' <remarks>�j���ʋq�����W�v</remarks>
        Protected Friend Function select_number_storecustomer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_����.���X�Ҕԍ�) AS �l��")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n��")
                builSQL.Append(" AND E_����.���X��<= @�I����")
                builSQL.Append(" AND E_����.���ʔԍ�=@���ʔԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ԓ��c�Ə��W�v"
        ''' <summary>���ԉc�Ə��W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>���ԉc�Ə��</returns>
        ''' <remarks>�c�Ɠ����A�X�^�b�t�����W�v</remarks>
        Protected Friend Function select_number_store_totalday(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_�c�Ɠ�.�c�Ɠ�) AS �c�Ɠ���")
                builSQL.Append(" ,ISNULL(SUM(E_�c�Ɠ�.�X�^�b�t��),0) AS �X�^�b�t��")
                builSQL.Append(" FROM E_�c�Ɠ�")
                builSQL.Append(" WHERE E_�c�Ɠ�.�c�Ɠ�>=@�J�n��")
                builSQL.Append(" AND E_�c�Ɠ�.�c�Ɠ�<= @�I����")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "1���̉c�Ə��擾"
        ''' <summary>1���̉c�Ə��擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�c�Ɠ�</param>
        ''' <returns>�c�Ə��g</returns>
        ''' <remarks>�����̓V��A�X�^�b�t�����擾(Q_d0300_�X�{��)</remarks>
        Protected Friend Function select_number_store_today(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT E_�c�Ɠ�.�X�^�b�t��, B_�V��.�V��")
                builSQL.Append(" FROM E_�c�Ɠ�")
                builSQL.Append(" INNER JOIN B_�V��")
                builSQL.Append(" ON E_�c�Ɠ�.�V��ԍ� = B_�V��.�V��ԍ�")
                builSQL.Append(" WHERE E_�c�Ɠ�.�c�Ɠ�=@�c�Ɠ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���X�Ґ��W�v"
        ''' <summary>���X�Ґ��W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>���X�Ґ�</returns>
        ''' <remarks>���q�����W�v</remarks>
        Protected Friend Function select_number_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_����.���X�Ҕԍ�) AS �l��")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n��")
                builSQL.Append(" AND E_����.���X��<= @�I���� ")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���X�敪�ʗ��X�Ґ��W�v"
        ''' <summary>���X�敪�ʗ��X�Ґ��W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����/@���X�敪�ԍ�</param>
        ''' <returns>���X�Ґ����X�g</returns>
        ''' <remarks>���X�敪�ʋq�����W�v</remarks>
        Protected Friend Function select_coming_store_division(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_����.���X�Ҕԍ�) AS �l��")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n��")
                builSQL.Append(" AND E_����.���X��<= @�I����")
                builSQL.Append(" AND E_����.���X�敪�ԍ�=@���X�敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ʗ��X�敪�ʗ��X�Ґ��W�v"
        ''' <summary>���ʗ��X�敪�ʗ��X�Ґ��W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����/@���ʔԍ�/@���X�敪�ԍ�</param>
        ''' <returns>���X�Ґ����X�g</returns>
        ''' <remarks>���X�敪�ʁA�j���ʗ��q�����W�v</remarks>
        Protected Friend Function selet_coming_division_sex(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_����.���X�Ҕԍ�) AS �l��")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")
                builSQL.Append(" AND E_����.���ʔԍ�=@���ʔԍ�")
                builSQL.Append(" AND E_����.���X�敪�ԍ�=@���X�敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "���ʔ���W�v"
        ''' <summary>���ʔ���W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���ʔԍ�/@�o�^�敪�ԍ�/@�J�n��/@�I����</param>
        ''' <returns>������</returns>
        ''' <remarks>����A�T�[�r�X�A�l���A�T�[�r�X�l����j���ʂɏW�v</remarks>
        Protected Friend Function select_sale_figue(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ISNULL(SUM(����敪.���� - ����敪.�T�[�r�X),0) AS ����")
                builSQL.Append(" ,ISNULL(SUM(����敪.�T�[�r�X),0) AS �T�[�r�X")
                builSQL.Append(" ,COUNT(����敪.����) AS �l��")
                builSQL.Append(" ,ISNULL(SUM(CASE WHEN ����敪.�T�[�r�X<>0 THEN 1 ELSE 0 END),0) AS �T�[�r�X�l��")
                builSQL.Append(" FROM (SELECT SUM(����*���z) AS ����")
                builSQL.Append(" ,SUM(E_���㖾��.�T�[�r�X) AS �T�[�r�X")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" INNER JOIN E_����")
                builSQL.Append(" ON E_���㖾��.���X�� = E_����.���X��")
                builSQL.Append(" AND E_���㖾��.���X�Ҕԍ� = E_����.���X�Ҕԍ�")
                builSQL.Append(" AND E_���㖾��.�ڋq�ԍ� = E_����.�ڋq�ԍ�")
                builSQL.Append(" WHERE E_����.���ʔԍ� = @���ʔԍ�")
                builSQL.Append(" AND E_���㖾��.����敪�ԍ� = @����敪�ԍ�")
                builSQL.Append(" AND E_���㖾��.��v�� = 'True'")
                builSQL.Append(" AND E_���㖾��.���X�� >= @�J�n��")
                builSQL.Append(" AND E_���㖾��.���X�� <= @�I����")
                builSQL.Append(" GROUP BY E_���㖾��.���X��, E_���㖾��.���X�Ҕԍ�,E_���㖾��.�ڋq�ԍ�")
                builSQL.Append(" ) ����敪")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���X�敪�A����敪�ʔ���W�v"
        ''' <summary>���X�敪�A����敪�ʔ���W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@���X�敪�ԍ�/@����敪�ԍ�/@�J�n��/@�I����</param>
        ''' <returns>������</returns>
        ''' <remarks>���Ԓ��̔���A�l���𗈓X�敪�Ɣ���敪�ʂɏW�v</remarks>
        Protected Friend Function sale_value_coming_storedivision(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ISNULL(SUM(���X�敪.����),0) AS ����")
                builSQL.Append(" ,COUNT(���X�敪.����) AS �l��")
                builSQL.Append(" FROM (SELECT SUM([����]*[���z] - �T�[�r�X) AS ����")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" INNER JOIN E_����")
                builSQL.Append(" ON E_���㖾��.�ڋq�ԍ� = E_����.�ڋq�ԍ�")
                builSQL.Append(" AND E_���㖾��.���X�Ҕԍ� = E_����.���X�Ҕԍ�")
                builSQL.Append(" AND E_���㖾��.���X�� = E_����.���X��")
                builSQL.Append(" WHERE E_����.���X�敪�ԍ�=@���X�敪�ԍ�")
                builSQL.Append(" AND E_���㖾��.����敪�ԍ�=@����敪�ԍ�")
                builSQL.Append(" AND E_���㖾��.��v��='True'")
                builSQL.Append(" AND E_���㖾��.���X��>=@�J�n��")
                builSQL.Append(" AND E_���㖾��.���X��<= @�I����")
                builSQL.Append(" GROUP BY E_���㖾��.���X��, E_���㖾��.���X�Ҕԍ�, E_���㖾��.�ڋq�ԍ�")
                builSQL.Append(" ) ���X�敪")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�x���z�W�v"
        ''' <summary>�x���z�W�v</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>�x���z���</returns>
        ''' <remarks>���Ɠ����̊e�x���z���W�v</remarks>
        Protected Friend Function select_pay(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT")
                builSQL.Append(" SUM(E_����.�����x��) AS �����x��")
                builSQL.Append(" ,SUM(E_����.�J�[�h�x��) AS �J�[�h�x��")
                builSQL.Append(" ,SUM(E_����.���̑��x��) AS ���̑��x��")
                builSQL.Append(" ,SUM(E_����.�|�C���g�����x��) AS �|�C���g�����x��")
                builSQL.Append(" ,SUM(E_����.�T�[�r�X���z) AS �T�[�r�X")
                builSQL.Append(" ,SUM(CASE WHEN E_����.�T�[�r�X���z>0 THEN 1 ELSE 0 END) AS �T�[�r�X�l��")
                builSQL.Append(" ,SUM(E_����.�����) AS �����")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "W_�x���̓o�^"
        ''' <summary>W_�x���̓o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�����{/@�J�[�h�{/@����Ŗ{/@������/@�J�[�h��/@����ŗ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_W_�x��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Try
                builSQL.Length = 0
                builSQL.Append("INSERT INTO W_�x��(")
                builSQL.Append(" ���q�{")
                builSQL.Append(" ,�����{")
                builSQL.Append(" ,�J�[�h�{")
                builSQL.Append(" ,���̑��{")
                builSQL.Append(" ,�|�C���g�����{")
                builSQL.Append(" ,����Ŗ{")
                builSQL.Append(" ,������")
                builSQL.Append(" ,�J�[�h��")
                builSQL.Append(" ,���̑���")
                builSQL.Append(" ,�|�C���g������")
                builSQL.Append(" ,����ŗ�)")
                builSQL.Append(" VALUES(@���q�{,@�����{,@�J�[�h�{,@���̑��{,@�|�C���g�����{,@����Ŗ{,@������,@�J�[�h��,@���̑���,@�|�C���g������,@����ŗ�)")

                dt = DBA.ExecuteNonQuery(builSQL.ToString, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "����W�v"
        ''' <summary>����W�v</summary>
        ''' <returns>�ڕW���</returns>
        ''' <remarks></remarks>
        Protected Friend Function W_�ڕW�W�v() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT SUM(����{) AS �����{,SUM(����l�{) AS ���{�l,SUM(�����) AS ������,SUM(����l��) AS ���ݐl FROM W_�ڕW"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���ԓ������㍇�v�擾"
        ''' <summary>���ԓ������㍇�v�擾</summary>
        ''' <returns>��������z,��������z</returns>
        ''' <remarks></remarks>
        Protected Friend Function getPeriodSales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ISNULL(SUM(MEISAI.���� - E_����.�T�[�r�X���z - E_����.�����),0) AS ����")
                builSQL.Append(", ISNULL(SUM(MEISAI.���� - E_����.�T�[�r�X���z),0) AS �ō�")
                builSQL.Append(" FROM E_���� INNER JOIN")
                builSQL.Append(" (SELECT ���X��, ���X�Ҕԍ�, ISNULL(SUM([����] * [���z] - �T�[�r�X),0) AS ����")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" WHERE ���X��>=@�J�n�� AND ���X��<= @�I���� AND ��v��='1'")
                builSQL.Append(" GROUP BY ���X��,���X�Ҕԍ�) MEISAI")
                builSQL.Append(" ON E_����.���X��=MEISAI.���X��")
                builSQL.Append(" AND E_����.���X�Ҕԍ�=MEISAI.���X�Ҕԍ�")
                builSQL.Append(" WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")

                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�c�Ɠ����擾"
        ''' <summary>�c�Ɠ����擾</summary>
        ''' <returns>�c�Ɠ��f�[�^</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_business_day(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT E_�c�Ɠ�.���W���z AS ���W���z")
                builSQL.Append(" FROM E_�c�Ɠ�")
                builSQL.Append(" WHERE E_�c�Ɠ�.�c�Ɠ�=@�c�Ɠ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���o�����擾"
        ''' <summary>���o�����擾</summary>
        ''' <returns>���o���f�[�^</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_receive_and_invest_money(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT E_���o��.���o���敪�ԍ� AS ���o���敪�ԍ�,")
                builSQL.Append(" SUM(E_���o��.���z) AS ���z")
                builSQL.Append(" FROM E_���o��")
                builSQL.Append(" WHERE E_���o��.���o����=@���o����")
                builSQL.Append(" GROUP BY E_���o��.���o���敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�^�b�t�W�v�f�[�^�擾"
        ''' <summary>�X�^�b�t�W�v�f�[�^�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>�X�^�b�t�W�v�ꗗ</returns>
        ''' <remarks>���ԓ��X�^�b�t�ʔ���A�|�C���g�����擾
        ''' 
        ''' </remarks>
        Protected Friend Function getStaffSalesList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT [D_�S����].[�S���Ҕԍ�]")
                builSQL.Append(" ,[D_�S����].[�S���Җ�]")
                builSQL.Append(" ,ISNULL(�ė�,0) AS �ė�")
                builSQL.Append(" ,ISNULL(�V�K,0) AS �V�K")
                builSQL.Append(" ,ISNULL(�S����,0) AS �S����")
                builSQL.Append(" ,ISNULL(�w��,0) AS �w��")
                builSQL.Append(" ,ISNULL(�|�C���g,0) AS �|�C���g")
                builSQL.Append(" ,ISNULL(�Z�p���z.������z,0) AS �Z�p����")
                builSQL.Append(" ,ISNULL(�X�̋��z.������z,0) AS �X�̔���")
                builSQL.Append(" ,ISNULL(�S�̻��޽,0) AS �S�̻��޽")
                'builSQL.Append(" ,ISNULL(������,0) AS ������")
                builSQL.Append(" ,ISNULL(�Z�p���z.������z,0) + ISNULL(�X�̋��z.������z,0) - ISNULL(�S�̻��޽,0) AS ������")
                builSQL.Append(" FROM D_�S����")

                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append(" (SELECT [��S���Ҕԍ�]")
                builSQL.Append(" ,SUM(CASE WHEN ���X�敪�ԍ�='1' THEN 1 ELSE 0 END) AS �ė�")
                builSQL.Append(" ,SUM(CASE WHEN ���X�敪�ԍ�='2' THEN 1 ELSE 0 END) AS �V�K")
                builSQL.Append(" ,SUM(CASE WHEN �w��='1' THEN 1 ELSE 0 END) AS �w��")
                builSQL.Append(" ,COUNT([��S���Ҕԍ�]) AS �S����")
                builSQL.Append(" ,SUM(�T�[�r�X���z) AS �S�̻��޽ ")
                builSQL.Append(" ,SUM(�����x�� + �J�[�h�x�� + ���̑��x�� + �|�C���g�����x��) AS ������ ")
                builSQL.Append(" FROM [E_����]")
                builSQL.Append(" WHERE [E_����].���X��>=@�J�n��")
                builSQL.Append(" AND [E_����].���X��<= @�I����")
                builSQL.Append(" GROUP BY [��S���Ҕԍ�]) E_����")
                builSQL.Append(" ON [E_����].[��S���Ҕԍ�]=[D_�S����].[�S���Ҕԍ�]")

                builSQL.Append(" LEFT OUTER JOIN (SELECT [�S���҃R�[�h],ISNULL(SUM(�|�C���g),0) AS �|�C���g FROM [E_�|�C���g]")
                builSQL.Append(" WHERE [E_�|�C���g].���X��>=@�J�n�� AND [E_�|�C���g].���X��<= @�I���� GROUP BY [�S���҃R�[�h]) E_�|�C���g")
                builSQL.Append(" ON [E_�|�C���g].[�S���҃R�[�h]=[D_�S����].[�S���Ҕԍ�]")

                'builSQL.Append(" LEFT OUTER JOIN (SELECT [��S���Ҕԍ�] ,ISNULL(SUM(���� * ���z - �T�[�r�X),0) AS ������z FROM [E_���㖾��]")
                'builSQL.Append(" LEFT OUTER JOIN [E_����] ON E_����.���X��=E_���㖾��.���X��")
                'builSQL.Append(" AND E_����.���X�Ҕԍ�=E_���㖾��.���X�Ҕԍ�")
                'builSQL.Append(" WHERE [E_���㖾��].���X��>=@�J�n�� AND [E_���㖾��].���X��<= @�I���� AND ��v��='1' AND ����敪�ԍ�='1'")
                'builSQL.Append(" GROUP BY [��S���Ҕԍ�]) �Z�p���z ON �Z�p���z.[��S���Ҕԍ�]=[D_�S����].[�S���Ҕԍ�]")
                builSQL.Append(" LEFT OUTER JOIN (SELECT [����S���Ҕԍ�] ,ISNULL(SUM(���� * ���z - �T�[�r�X),0) AS ������z FROM [E_���㖾��]")
                builSQL.Append(" WHERE [E_���㖾��].���X��>=@�J�n�� AND [E_���㖾��].���X��<= @�I���� AND ��v��='1' AND ����敪�ԍ�='1'")
                builSQL.Append(" GROUP BY [����S���Ҕԍ�]) �Z�p���z ON �Z�p���z.[����S���Ҕԍ�]=[D_�S����].[�S���Ҕԍ�]")

                builSQL.Append(" LEFT OUTER JOIN (SELECT [����S���Ҕԍ�] ,ISNULL(SUM(���� * ���z - �T�[�r�X),0) AS ������z FROM [E_���㖾��]")
                builSQL.Append(" WHERE [E_���㖾��].���X��>=@�J�n�� AND [E_���㖾��].���X��<= @�I���� AND ��v��='1' AND ����敪�ԍ�='2'")
                'builSQL.Append(" GROUP BY [����敪�ԍ�],[����S���Ҕԍ�]) �X�̋��z ON �X�̋��z.[����S���Ҕԍ�]=[D_�S����].[�S���Ҕԍ�]")
                builSQL.Append(" GROUP BY [����S���Ҕԍ�]) �X�̋��z ON �X�̋��z.[����S���Ҕԍ�]=[D_�S����].[�S���Ҕԍ�]")

                builSQL.Append(" WHERE [�폜�t���O]='0'")
                builSQL.Append(" GROUP BY [D_�S����].[�S���Ҕԍ�],[D_�S����].[�S���Җ�],[D_�S����].[�\����],[�ė�],[�V�K],[�S����]")
                builSQL.Append(" ,[�w��],[�|�C���g],�Z�p���z.������z,�X�̋��z.������z,�S�̻��޽,������")
                builSQL.Append(" ORDER BY [D_�S����].[�\����]")

                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
                Dim newRow As DataRow = dt.NewRow()
                newRow("�S���Ҕԍ�") = DBNull.Value
                newRow("�S���Җ�") = "���v"

                newRow("�ė�") = Str(dt.Compute("Sum(�ė�)", Nothing))
                newRow("�V�K") = Str(dt.Compute("Sum(�V�K)", Nothing))
                newRow("�S����") = Str(dt.Compute("Sum(�S����)", Nothing))
                newRow("�w��") = Str(dt.Compute("Sum(�w��)", Nothing))
                newRow("�|�C���g") = Str(dt.Compute("Sum(�|�C���g)", Nothing))
                newRow("�Z�p����") = Str(dt.Compute("Sum(�Z�p����)", Nothing))
                newRow("�X�̔���") = Str(dt.Compute("Sum(�X�̔���)", Nothing))
                newRow("�S�̻��޽") = Str(dt.Compute("Sum(�S�̻��޽)", Nothing))
                newRow("������") = Str(dt.Compute("Sum(������)", Nothing))

                dt.Rows.Add(newRow)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�W�v�f�[�^�擾�i����j"
        ''' <summary>�X�W�v�f�[�^�擾�i����j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>������</returns>
        ''' <remarks>���ԓ��̔�������擾
        ''' ����敪�ʔ��� �FE_���㖾�ׂ��u���� * ���z - �T�[�r�X�v�̏W�v
        ''' �S�̃T�[�r�X�@ �FE_������u�T�[�r�X���z * -1�v�̏W�v
        ''' ������@�@�@�@ �FE_������u�����x�� + �J�[�h�x�� + ���̑��x�� + �|�C���g�����x���v�̏W�v
        ''' ����Ł@�@�@�@ �FE_������u����Łv�̏W�v
        ''' ������@�@�@�@ �FE_������u�����x�� + �J�[�h�x�� + ���̑��x�� + �|�C���g�����x�� - ����Łv�̏W�v
        ''' ����敪�ʻ��޽�FE_���㖾�ׂ��u�T�[�r�X�v�̏W�v
        ''' </remarks>
        Protected Friend Function getShopSalesList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name ,num ,amount ,delflag")
                builSQL.Append(" FROM (")

                builSQL.Append("SELECT ����敪 + '����' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(MEISAI.����敪�ԍ�),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(amount),0) AS amount")
                builSQL.Append(" ,B_����敪.����敪�ԍ� AS dispOrder")
                builSQL.Append(" ,B_����敪.�폜�t���O AS delflag")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT ���X��,���X�Ҕԍ�,����敪�ԍ�,SUM(���� * ���z - �T�[�r�X) AS amount")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1'")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�,����敪�ԍ�) AS MEISAI")
                builSQL.Append(" RIGHT OUTER JOIN")
                builSQL.Append("  B_����敪")
                builSQL.Append(" ON MEISAI.����敪�ԍ� =B_����敪.����敪�ԍ�")
                builSQL.Append(" GROUP BY B_����敪.����敪�ԍ�,����敪 + '����',B_����敪.�폜�t���O")

                builSQL.Append(" UNION SELECT '�S�̻��޽' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(���X�Ҕԍ�),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(�T�[�r�X���z * -1),0) AS amount")
                builSQL.Append(" ,'1001' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND �T�[�r�X���z>0")

                builSQL.Append(" UNION SELECT  '������' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(�����),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(�����x��+�J�[�h�x��+���̑��x��+�|�C���g�����x��),0) AS amount")
                builSQL.Append(" ,'1002' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I����")

                builSQL.Append(" UNION SELECT '�����' AS name")
                builSQL.Append(" ,'' AS num")
                builSQL.Append(" ,ISNULL(SUM(�����),0) AS amount")
                builSQL.Append(" ,'1003' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I����")

                builSQL.Append(" UNION SELECT  '������' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(�����),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(�����x��+�J�[�h�x��+���̑��x��+�|�C���g�����x��-�����),0) AS amount")
                builSQL.Append(" ,'1004' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I����")

                builSQL.Append(" UNION SELECT '('+����敪 + '���޽)' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(MEISAI.����敪�ԍ�),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(amount),0) AS amount")
                builSQL.Append("  ,B_����敪.����敪�ԍ�+1050 AS dispOrder")
                builSQL.Append(" ,B_����敪.�폜�t���O AS delflag")
                builSQL.Append("  FROM ( ")
                builSQL.Append("   SELECT ����敪�ԍ�,SUM(�T�[�r�X) AS amount")
                builSQL.Append("   FROM E_���㖾��")
                builSQL.Append("   WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1' AND �T�[�r�X>0")
                builSQL.Append("   GROUP BY ���X��,���X�Ҕԍ�,����敪�ԍ�) AS MEISAI")
                builSQL.Append("  RIGHT OUTER JOIN")
                builSQL.Append("  B_����敪")
                builSQL.Append("  ON MEISAI.����敪�ԍ� =B_����敪.����敪�ԍ�")
                builSQL.Append("  GROUP BY B_����敪.����敪�ԍ�,'('+����敪 + '���޽)',B_����敪.�폜�t���O")

                builSQL.Append(" ) AS A")
                builSQL.Append(" ORDER BY A.dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�W�v�f�[�^�擾�i���X�敪�j"
        ''' <summary>�X�W�v�f�[�^�擾�i���X�敪�j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>���X���</returns>
        ''' <remarks>���ԓ��̗��X�����擾</remarks>
        Protected Friend Function getShopVisitList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ���X�敪 AS name")
                builSQL.Append(" ,ISNULL(COUNT(MEISAI.amount),0) AS num")
                builSQL.Append(" ,ISNULL(SUM(MEISAI.amount - E_����.�T�[�r�X���z),0) AS amount")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT ���X��,���X�Ҕԍ�,SUM(���� * ���z - �T�[�r�X) AS amount")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1'")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append("  E_����")
                builSQL.Append(" ON   MEISAI.���X��=E_����.���X��")
                builSQL.Append("  AND MEISAI.���X�Ҕԍ�=E_����.���X�Ҕԍ�")
                builSQL.Append(" RIGHT OUTER JOIN")
                builSQL.Append("  B_���X�敪")
                builSQL.Append(" ON E_����.���X�敪�ԍ� =B_���X�敪.���X�敪�ԍ� ")
                builSQL.Append(" GROUP BY B_���X�敪.���X�敪�ԍ�,���X�敪")
                builSQL.Append(" ORDER BY B_���X�敪.���X�敪�ԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�W�v�f�[�^�擾�i�w���j"
        ''' <summary>�X�W�v�f�[�^�擾�i�w���j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>�w�����</returns>
        ''' <remarks>���ԓ��̎w�������擾</remarks>
        Protected Friend Function getShopDesignatedList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT '�w��' AS name")
                builSQL.Append(" ,ISNULL(COUNT(E_����.�w��),0) AS num")
                builSQL.Append(" ,ISNULL(SUM(MEISAI.amount - E_����.�T�[�r�X���z),0) AS amount")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT ���X��,���X�Ҕԍ�,SUM(���� * ���z - �T�[�r�X) AS amount")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1'")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append("  E_����")
                builSQL.Append(" ON   MEISAI.���X��=E_����.���X��")
                builSQL.Append("  AND MEISAI.���X�Ҕԍ�=E_����.���X�Ҕԍ�")
                builSQL.Append(" WHERE E_����.�w��='1'")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�W�v�f�[�^�擾�i�x���j"
        ''' <summary>�X�W�v�f�[�^�擾�i�x���j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>�x�����</returns>
        ''' <remarks>���ԓ��̎x�������擾</remarks>
        Protected Friend Function getShopPaymentList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name,num,amount")
                builSQL.Append(" FROM (")
                builSQL.Append("  SELECT '����' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN �����x��>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(�����x��),0) AS amount")
                builSQL.Append("  ,'1' AS dispOrder")
                builSQL.Append("  FROM  E_����")
                builSQL.Append("  WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '�J�[�h' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN �J�[�h�x��>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(�J�[�h�x��),0) AS amount")
                builSQL.Append("  ,'2' AS dispOrder")
                builSQL.Append("  FROM  E_����")
                builSQL.Append("  WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '���̑�' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN ���̑��x��>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(���̑��x��),0) AS amount")
                builSQL.Append("  ,'3' AS dispOrder")
                builSQL.Append("  FROM  E_����")
                builSQL.Append("  WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '�|�C���g����' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN �|�C���g�����x��>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(�|�C���g�����x��),0) AS amount")
                builSQL.Append("  ,'3' AS dispOrder")
                builSQL.Append("  FROM  E_����")
                builSQL.Append("  WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '���v' AS name")
                builSQL.Append("  ,ISNULL(COUNT(���X��),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(�����x��+�J�[�h�x��+���̑��x��+�|�C���g�����x��),0) AS amount")
                builSQL.Append("  ,'99' AS dispOrder")
                builSQL.Append("  FROM  E_����")
                builSQL.Append("  WHERE E_����.���X��>=@�J�n�� AND E_����.���X��<= @�I����")
                builSQL.Append("  ) AS E_����")
                builSQL.Append("  ORDER BY dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�W�v�f�[�^�擾�i���o���j"
        ''' <summary>�X�W�v�f�[�^�擾�i���o���j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>���o�����</returns>
        ''' <remarks>���ԓ��̓��o�������擾</remarks>
        Protected Friend Function getShopCashList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name,num,amount")
                builSQL.Append(" FROM (")
                builSQL.Append("  SELECT '����' AS name")
                builSQL.Append("  ,ISNULL(COUNT(E_���o��.���o���敪�ԍ�),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(���z),0) AS amount")
                builSQL.Append("  ,'1' AS dispOrder")
                builSQL.Append("  FROM  E_���o��")
                builSQL.Append("  WHERE E_���o��.���o����>=@�J�n�� AND E_���o��.���o����<= @�I����")
                builSQL.Append("  AND E_���o��.���o���敪�ԍ�='1'")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '�o��' AS name")
                builSQL.Append("  ,ISNULL(COUNT(E_���o��.���o���敪�ԍ�),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(���z),0) AS amount")
                builSQL.Append("  ,'2' AS dispOrder")
                builSQL.Append("  FROM  E_���o��")
                builSQL.Append("  WHERE E_���o��.���o����>=@�J�n�� AND E_���o��.���o����<= @�I����")
                builSQL.Append("  AND E_���o��.���o���敪�ԍ�='2'")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '���v' AS name")
                builSQL.Append("  ,ISNULL(COUNT(E_���o��.���o���敪�ԍ�),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(CASE E_���o��.���o���敪�ԍ� WHEN '1' THEN ���z ")
                builSQL.Append("  WHEN '2' THEN ���z*-1 END),0) AS amount")
                builSQL.Append("  ,'99' AS dispOrder")
                builSQL.Append("  FROM  E_���o��")
                builSQL.Append("  WHERE E_���o��.���o����>=@�J�n�� AND E_���o��.���o����<= @�I����")
                builSQL.Append(" ) AS E_���o��")
                builSQL.Append(" ORDER BY dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "�X�W�v�f�[�^�擾�i�P���j"
        ''' <summary>�X�W�v�f�[�^�擾�i�P���j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�J�n��/@�I����</param>
        ''' <returns>����P�����</returns>
        ''' <remarks>���ԓ��̔���P�������擾</remarks>
        Protected Friend Function getShopCostList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name ,amount")
                builSQL.Append(" FROM (")
                builSQL.Append(" SELECT '����P��' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(MEISAI1.cnt),0) >0 THEN")
                builSQL.Append(" ISNULL(SUM(MEISAI1.amount- E_����.�T�[�r�X���z),0) / ISNULL(COUNT(MEISAI1.cnt),0)")
                builSQL.Append(" ELSE 0 END AS amount")
                builSQL.Append(" ,'0' AS dispOrder")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT MEISAI0.���X��,MEISAI0.���X�Ҕԍ�,SUM(MEISAI0.amount) AS amount")
                builSQL.Append(" ,COUNT(MEISAI0.����敪�ԍ�) AS cnt")
                builSQL.Append("  FROM (")
                builSQL.Append("  SELECT ���X��,���X�Ҕԍ�,����敪�ԍ�,SUM(���� * ���z - �T�[�r�X) AS amount")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1'")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�,����敪�ԍ�) AS MEISAI0")
                builSQL.Append(" GROUP BY ���X��,���X�Ҕԍ�) AS MEISAI1")
                builSQL.Append(" LEFT OUTER JOIN E_����")
                builSQL.Append(" ON E_����.���X�� = MEISAI1.���X��")
                builSQL.Append(" AND E_����.���X�Ҕԍ� = MEISAI1.���X�Ҕԍ�")

                builSQL.Append(" UNION SELECT ����敪 + '�P��' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(MEISAI.����敪�ԍ�),0) >0 THEN")
                builSQL.Append(" ISNULL(SUM(MEISAI.amount),0) / ISNULL(COUNT(MEISAI.����敪�ԍ�),0) ")
                builSQL.Append(" ELSE 0 END AS amount")
                builSQL.Append(" ,B_����敪.����敪�ԍ� AS dispOrder")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT ���X��,���X�Ҕԍ�,����敪�ԍ�,SUM(���� * ���z - �T�[�r�X) AS amount")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1'")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�,����敪�ԍ�) AS MEISAI")
                builSQL.Append(" RIGHT OUTER JOIN")
                builSQL.Append("  B_����敪")
                builSQL.Append(" ON MEISAI.����敪�ԍ� = B_����敪.����敪�ԍ�")
                builSQL.Append(" GROUP BY B_����敪.����敪�ԍ�,����敪 + '�P��'")

                builSQL.Append(" UNION SELECT '�ڋq�P��' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(MEISAI2.amount),0)>0 THEN ")
                builSQL.Append("  ISNULL(SUM(MEISAI2.amount - E_����.�T�[�r�X���z),0) / ISNULL(COUNT(MEISAI2.amount),0)")
                builSQL.Append("  ELSE 0 END AS amount")
                builSQL.Append(" ,'30' AS dispOrder")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT ���X��,���X�Ҕԍ�,SUM(���� * ���z - �T�[�r�X) AS amount")
                builSQL.Append("  FROM E_���㖾��")
                builSQL.Append("  WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I���� AND ��v�� ='1'")
                builSQL.Append("  GROUP BY ���X��,���X�Ҕԍ�) AS MEISAI2")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append("  E_����")
                builSQL.Append(" ON   MEISAI2.���X��=E_����.���X��")
                builSQL.Append("  AND MEISAI2.���X�Ҕԍ�=E_����.���X�Ҕԍ�")

                builSQL.Append(" UNION SELECT '�X�^�b�t1�l����' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(SUM(�X�^�b�t��),0)>0 THEN")
                builSQL.Append(" SUM(amount) / ISNULL(SUM(�X�^�b�t��),0) ")
                builSQL.Append(" ELSE ISNULL(SUM(amount),0) END AS amount")
                builSQL.Append(" ,'40' AS dispOrder")
                builSQL.Append(" FROM  E_�c�Ɠ�")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append(" (SELECT ���X��,")
                builSQL.Append(" ISNULL(SUM(�����x��+�J�[�h�x��+���̑��x��+�|�C���g�����x��-�T�[�r�X���z),0) AS amount")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I����")
                builSQL.Append(" GROUP BY ���X��)AS meisai")
                builSQL.Append(" ON meisai.���X�� =  E_�c�Ɠ�.�c�Ɠ�")
                builSQL.Append(" WHERE �c�Ɠ� >= @�J�n�� AND �c�Ɠ� <= @�I����")

                builSQL.Append(" UNION SELECT '1������' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(�c�Ɠ�),0)>0 THEN")
                builSQL.Append(" SUM(amount) / ISNULL(COUNT(�c�Ɠ�),0) ")
                builSQL.Append(" ELSE ISNULL(SUM(amount),0) END AS amount")
                builSQL.Append(" ,'50' AS dispOrder")
                builSQL.Append(" FROM  E_�c�Ɠ�")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append(" (SELECT ���X��,")
                builSQL.Append(" ISNULL(SUM(�����x��+�J�[�h�x��+���̑��x��+�|�C���g�����x��-�T�[�r�X���z),0) AS amount")
                builSQL.Append(" FROM E_����")
                builSQL.Append(" WHERE ���X�� >= @�J�n�� AND ���X�� <= @�I����")
                builSQL.Append(" GROUP BY ���X��)AS meisai")
                builSQL.Append(" ON meisai.���X�� =  E_�c�Ɠ�.�c�Ɠ�")
                builSQL.Append(" WHERE �c�Ɠ� >= @�J�n�� AND �c�Ɠ� <= @�I����")
                builSQL.Append("  ) AS A")
                builSQL.Append(" ORDER BY A.dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

    End Class
End Namespace
