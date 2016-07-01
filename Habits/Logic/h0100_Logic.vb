#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�f�[�^���o��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class h0100_Logic
        Inherits Habits.Logic.LogicBase

#Region "���ʖ��̈ꗗ�擾"
        ''' <summary>���ʖ��̈ꗗ�擾</summary>
        ''' <returns>���ʃ��X�g</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_����()
        End Function
#End Region

#Region "�S���҈ꗗ�擾"
        ''' <summary>�S���҈ꗗ�擾</summary>
        ''' <returns>�S���҃��X�g</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function
#End Region

#Region "�T�[�r�X�ꗗ�擾"
        ''' <summary>�T�[�r�X�ꗗ�擾</summary>
        ''' <returns>�T�[�r�X���X�g</returns>
        ''' <remarks></remarks>
        Function ServiceName() As DataTable
            Return MyBase.getService_exclude()
        End Function
#End Region

#Region "����敪������"
        ''' <summary>����敪������</summary>
        ''' <returns>����敪���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_saleDivision() As DataTable
            Return MyBase.getSalesDiv_exclude()
        End Function
#End Region

#Region "����敪�ԍ��������ɕ��ނ�����"
        ''' <summary>����敪�ԍ��������ɕ��ނ�����</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�폜�t���O</param>
        ''' <returns>���ރ��X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_group(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return getClass_exclude(v_param)
        End Function
#End Region

#Region "����敪�ԍ�,���ޔԍ��������ɏ��i������"
        ''' <summary>����敪�ԍ�,���ޔԍ��������ɏ��i������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@�폜�t���O</param>
        ''' <returns>���i���X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_itemname(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ���i��,���i�ԍ�,����敪�ԍ�,���ޔԍ� FROM C_���i WHERE ����敪�ԍ� = @����敪�ԍ� AND ���ޔԍ� = @���ޔԍ� AND �폜�t���O = @�폜�t���O ORDER BY �\����,���i�ԍ�"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "���i���擾"
        ''' <summary>���i���擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@����敪�ԍ�/@���ޔԍ�/@�폜�t���O/@���i��</param>
        ''' <returns>���i���A���i�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_iteminfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ���i��,���i�ԍ� FROM C_���i WHERE ����敪�ԍ� = @����敪�ԍ� AND ���ޔԍ� = @���ޔԍ� AND �폜�t���O = @�폜�t���O AND ���i�� = @���i��"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "D_�ڋq���o�^�i�o�^�σf�[�^�̂݁j"
        ''' <summary>D_�ڋq���o�^�i�o�^�σf�[�^�̂݁j</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �ڋq�V�K�쐬�o�^��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("INSERT INTO W_�ڋq")
                builSQL.Append(" ( �ڋq�ԍ�, ��, ��, ���J�i, ���J�i, ���ʔԍ�, ���N����, �X�֔ԍ�, �s���{��, �Z��1,")
                builSQL.Append(" �Z��2, �Z��3, �d�b�ԍ�, Email�A�h���X, �Ƒ���, �, �D���Șb��, �����Șb��,")
                builSQL.Append(" �`���t���O, ����, �Љ��, �O�񗈓X��, ���X��N_1, ���X��N_2, ���X��,")
                builSQL.Append(" ��S���Ҕԍ�, �o�^�敪�ԍ�, DM��]�t���O,�o�^��, �X�V��)")

                builSQL.Append(" SELECT D_�ڋq.*")
                builSQL.Append(" FROM D_�ڋq")
                builSQL.Append(" WHERE (((D_�ڋq.�o�^�敪�ԍ�)=1) AND ((D_�ڋq.�ڋq�ԍ�)<@�ڋq�ԍ�));")

                str_sql = builSQL.ToString()
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_�ڋq���o�^"
        ''' <summary>D_�ڋq���o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ڋq�ԍ�</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �ڋq�V�K�쐬�S��(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("INSERT INTO W_�ڋq")
                builSQL.Append(" ( �ڋq�ԍ�, ��, ��, ���J�i, ���J�i, ���ʔԍ�, ���N����, �X�֔ԍ�, �s���{��, �Z��1,")
                builSQL.Append(" �Z��2, �Z��3, �d�b�ԍ�, Email�A�h���X, �Ƒ���, �, �D���Șb��, �����Șb��,")
                builSQL.Append(" �`���t���O, ����, �Љ��, �O�񗈓X��, ���X��N_1, ���X��N_2, ���X��,")
                builSQL.Append(" ��S���Ҕԍ�, �o�^�敪�ԍ�,DM��]�t���O, �o�^��, �X�V�� )")

                builSQL.Append(" SELECT D_�ڋq.*")
                builSQL.Append(" FROM D_�ڋq")
                builSQL.Append(" WHERE ((D_�ڋq.�ڋq�ԍ�)<@�ڋq�ԍ�);")

                str_sql = builSQL.ToString()
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "W_�ڋq���o���W_�ڋq�ɓo�^"
        ''' <summary>W_�ڋq���o���W_�ڋq�ɓo�^</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function �ڋq���o�쐬() As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim i As Integer = 0
            Dim param As New Habits.DB.DBParameter
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("INSERT INTO W_�ڋq")

                builSQL.Append(" SELECT ")
                builSQL.Append(" �ڋq�ԍ�, ��, ��, ���J�i, ���J�i, ���ʔԍ�, ���N����, �X�֔ԍ�, �s���{��, �Z��1,")
                builSQL.Append(" �Z��2, �Z��3, �d�b�ԍ�, Email�A�h���X, �Ƒ���, �, �D���Șb��, �����Șb��,")
                builSQL.Append(" �`���t���O, ����, �Љ��, �O�񗈓X��, ���X��N_1, ���X��N_2, ���X��,")
                builSQL.Append(" ��S���Ҕԍ�, �o�^�敪�ԍ�,DM��]�t���O ,�o�^��, �X�V�� ")
                builSQL.Append(" FROM W_�ڋq���o;")
                str_sql = builSQL.ToString()
                rtn = DBA.ExecuteNonQuery(str_sql)

            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "�ڋq�ԍ��ꗗ�擾"
        ''' <summary>�ڋq�ԍ��ꗗ�擾</summary>
        ''' <returns>�ڋq�ԍ��ꗗ</returns>
        ''' <remarks></remarks>
        Protected Friend Function �����J�E���g�p() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT DISTINCT �ڋq�ԍ� FROM W_�ڋq���o ORDER BY W_�ڋq���o.�ڋq�ԍ�;"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                '�f��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "W_�ڋq�폜"
        ''' <summary>W_�ڋq�폜</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_W_�ڋq�폜() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                str_sql = "DELETE W_�ڋq FROM W_�ڋq;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "W_���o�����폜"
        ''' <summary>W_���o�����폜</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_W_���o�����폜() As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                str_sql = "DELETE W_���o���� FROM W_���o����;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "W_�ڋq���o�폜"
        ''' <summary>W_�ڋq���o�폜</summary>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_W_�ڋq���o�폜() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                str_sql = "DELETE W_�ڋq���o FROM W_�ڋq���o;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "W_�ڋq���o��INSERT�����ʕ��擾"
        ''' <summary>W_�ڋq���o��INSERT�����ʕ��擾</summary>
        ''' <param name="type">���o�^�C�v
        ''' 0�F����
        ''' 1�F���N����
        ''' 2�F�a����
        ''' 3�F�N��
        ''' 4�F���j���[
        ''' 5�F���X��
        ''' 6�F�敪����
        ''' 7�F��S��
        ''' 8�F�ŏI���X��
        ''' 9�F�T�[�r�X
        ''' </param>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Function insert_W_�ڋq���o(ByVal type As Int32, ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO [W_�ڋq���o](")
                builSQL.Append(" �ڋq�ԍ�")
                builSQL.Append(",��")
                builSQL.Append(",��")
                builSQL.Append(",���J�i")
                builSQL.Append(",���J�i")
                builSQL.Append(",���ʔԍ�")
                builSQL.Append(",���N����")
                builSQL.Append(",�X�֔ԍ�")
                builSQL.Append(",�s���{��")
                builSQL.Append(",�Z��1")
                builSQL.Append(",�Z��2")
                builSQL.Append(",�Z��3")
                builSQL.Append(",�d�b�ԍ�")
                builSQL.Append(",Email�A�h���X")
                builSQL.Append(",�Ƒ���")
                builSQL.Append(",�")
                builSQL.Append(",�D���Șb��")
                builSQL.Append(",�����Șb��")
                builSQL.Append(",�`���t���O")
                builSQL.Append(",����")
                builSQL.Append(",�Љ��")
                builSQL.Append(",�O�񗈓X��")
                builSQL.Append(",���X��N_1")
                builSQL.Append(",���X��N_2")
                builSQL.Append(",���X��")
                If type = 6 Then
                    builSQL.Append(",����敪�ԍ�")
                    builSQL.Append(",�敪���v���z")
                End If
                builSQL.Append(",��S���Ҕԍ�")
                builSQL.Append(",�o�^�敪�ԍ�")
                builSQL.Append(",DM��]�t���O")
                builSQL.Append(",�o�^��")
                builSQL.Append(",�X�V��")
                builSQL.Append(")")

                builSQL.Append(" SELECT DISTINCT")
                builSQL.Append(" W_�ڋq.�ڋq�ԍ�")
                builSQL.Append(",W_�ڋq.��")
                builSQL.Append(",W_�ڋq.��")
                builSQL.Append(",W_�ڋq.���J�i")
                builSQL.Append(",W_�ڋq.���J�i")
                builSQL.Append(",W_�ڋq.���ʔԍ�")
                builSQL.Append(",W_�ڋq.���N����")
                builSQL.Append(",W_�ڋq.�X�֔ԍ�")
                builSQL.Append(",W_�ڋq.�s���{��")
                builSQL.Append(",W_�ڋq.�Z��1")
                builSQL.Append(",W_�ڋq.�Z��2")
                builSQL.Append(",W_�ڋq.�Z��3")
                builSQL.Append(",W_�ڋq.�d�b�ԍ�")
                builSQL.Append(",W_�ڋq.Email�A�h���X")
                builSQL.Append(",W_�ڋq.�Ƒ���")
                builSQL.Append(",W_�ڋq.�")
                builSQL.Append(",W_�ڋq.�D���Șb��")
                builSQL.Append(",W_�ڋq.�����Șb��")
                builSQL.Append(",W_�ڋq.�`���t���O")
                builSQL.Append(",W_�ڋq.����")
                builSQL.Append(",W_�ڋq.�Љ��")
                builSQL.Append(",W_�ڋq.�O�񗈓X��")
                builSQL.Append(",W_�ڋq.���X��N_1")
                builSQL.Append(",W_�ڋq.���X��N_2")
                builSQL.Append(",W_�ڋq.���X��")
                If type = 6 Then
                    builSQL.Append(",tmp2.����敪�ԍ�")
                    builSQL.Append(",tmp2.�敪���v���z")
                End If
                builSQL.Append(",W_�ڋq.��S���Ҕԍ�")
                builSQL.Append(",W_�ڋq.�o�^�敪�ԍ�")
                builSQL.Append(",W_�ڋq.DM��]�t���O")
                builSQL.Append(",W_�ڋq.�o�^��")
                builSQL.Append(",W_�ڋq.�X�V��")

                builSQL.Append(" FROM W_�ڋq")
                Select Case type
                    Case 0    ' �^�u(����)
                        builSQL.Append(" JOIN B_���� ON W_�ڋq.���ʔԍ� = B_����.���ʔԍ�")
                        builSQL.Append(" WHERE B_����.���� = @���ʔԍ�")

                    Case 1  ' �^�u(���N����)
                        builSQL.Append(" WHERE W_�ڋq.���N���� >= @���N�����J�n AND W_�ڋq.���N���� <= @���N�����I��")

                    Case 2  ' �^�u(�a����)
                        builSQL.Append(" WHERE DatePart(""m"",[���N����]) >= @�a�����J�n AND DatePart(""m"",[���N����]) <= @�a�����I��")

                    Case 3  ' �^�u(�N��)
                        builSQL.Append(" WHERE W_�ڋq.���N���� <= @�N��J�n AND W_�ڋq.���N���� > @�N��I��")

                    Case 4  ' �^�u(���j���[)
                        builSQL.Append(" WHERE �ڋq�ԍ� IN(SELECT �ڋq�ԍ� FROM E_���㖾�� WHERE ����敪�ԍ� = @����敪�ԍ� AND ��v�� = 'TRUE'")
                        builSQL.Append(" AND ���ޔԍ� = @���ޔԍ�")
                        builSQL.Append(" AND ���̔ԍ� = (SELECT ���i�ԍ� FROM C_���i WHERE ����敪�ԍ� = @����敪�ԍ� AND ���ޔԍ� = @���ޔԍ� AND ���i�ԍ� = @���i�ԍ�))")

                    Case 5  ' �^�u(���X��)
                        builSQL.Append(" WHERE W_�ڋq.���X�� >=@���X�񐔊J�n AND W_�ڋq.���X�� <= @���X�񐔏I��")

                    Case 6  ' �^�u(�敪����)
                        builSQL.Append(" INNER JOIN ")
                        builSQL.Append(" (SELECT �ڋq�ԍ�, ����敪�ԍ�,�敪���v���z")
                        builSQL.Append(" FROM (SELECT cus.�ڋq�ԍ�, sale.����敪�ԍ�,")
                        builSQL.Append(" SUM(sale.���z * sale.���� - sale.�T�[�r�X) AS �敪���v���z")
                        builSQL.Append(" FROM W_�ڋq AS cus INNER JOIN E_���㖾�� AS sale ON")
                        builSQL.Append(" cus.�ڋq�ԍ� = sale.�ڋq�ԍ�")
                        builSQL.Append(" where(sale.����敪�ԍ� = @����敪�ԍ�)  AND (sale.���X�� BETWEEN @�敪������ԊJ�n AND @�敪������ԏI��) AND sale.��v�� = 'TRUE'")
                        builSQL.Append(" GROUP BY cus.�ڋq�ԍ�, sale.����敪�ԍ�) AS tmp1")
                        builSQL.Append("  WHERE (�敪���v���z BETWEEN @�敪����J�n AND @�敪����I�� )")
                        builSQL.Append(" ) AS tmp2")
                        builSQL.Append(" ON W_�ڋq.�ڋq�ԍ� = tmp2.�ڋq�ԍ�")

                    Case 7  ' �^�u(��S��)
                        builSQL.Append(" WHERE �ڋq�ԍ� IN ( ")
                        builSQL.Append(" SELECT �ڋq�ԍ� FROM E_���� WHERE ��S���Ҕԍ� = @��S���Ҕԍ� AND �w�� = @�w�� GROUP BY �ڋq�ԍ� )")

                    Case 8  ' �^�u(�ŏI���X��)
                        builSQL.Append(" WHERE W_�ڋq.�O�񗈓X��>=@�ŏI���X���J�n AND W_�ڋq.�O�񗈓X��<= @�ŏI���X���I��")

                    Case 9  ' �^�u(�T�[�r�X)
                        builSQL.Append(" JOIN (E_���㖾�� JOIN B_�T�[�r�X ON E_���㖾��.�T�[�r�X�ԍ� = B_�T�[�r�X.�T�[�r�X�ԍ�) ON W_�ڋq.�ڋq�ԍ� = E_���㖾��.�ڋq�ԍ�")
                        builSQL.Append(" WHERE B_�T�[�r�X.�T�[�r�X�� = @�T�[�r�X�� AND E_���㖾��.��v�� = 'TRUE'")
                        builSQL.Append(" AND (E_���㖾��.���X�� BETWEEN @�T�[�r�X�J�n AND @�T�[�r�X�I��)")
                        builSQL.Append(" AND NOT EXISTS (SELECT * FROM W_�ڋq���o WHERE W_�ڋq���o.�ڋq�ԍ� = W_�ڋq.�ڋq�ԍ�)")

                        builSQL.Append(" UNION SELECT DISTINCT")
                        builSQL.Append(" W_�ڋq.�ڋq�ԍ�")
                        builSQL.Append(",W_�ڋq.��")
                        builSQL.Append(",W_�ڋq.��")
                        builSQL.Append(",W_�ڋq.���J�i")
                        builSQL.Append(",W_�ڋq.���J�i")
                        builSQL.Append(",W_�ڋq.���ʔԍ�")
                        builSQL.Append(",W_�ڋq.���N����")
                        builSQL.Append(",W_�ڋq.�X�֔ԍ�")
                        builSQL.Append(",W_�ڋq.�s���{��")
                        builSQL.Append(",W_�ڋq.�Z��1")
                        builSQL.Append(",W_�ڋq.�Z��2")
                        builSQL.Append(",W_�ڋq.�Z��3")
                        builSQL.Append(",W_�ڋq.�d�b�ԍ�")
                        builSQL.Append(",W_�ڋq.Email�A�h���X")
                        builSQL.Append(",W_�ڋq.�Ƒ���")
                        builSQL.Append(",W_�ڋq.�")
                        builSQL.Append(",W_�ڋq.�D���Șb��")
                        builSQL.Append(",W_�ڋq.�����Șb��")
                        builSQL.Append(",W_�ڋq.�`���t���O")
                        builSQL.Append(",W_�ڋq.����")
                        builSQL.Append(",W_�ڋq.�Љ��")
                        builSQL.Append(",W_�ڋq.�O�񗈓X��")
                        builSQL.Append(",W_�ڋq.���X��N_1")
                        builSQL.Append(",W_�ڋq.���X��N_2")
                        builSQL.Append(",W_�ڋq.���X��")
                        builSQL.Append(",W_�ڋq.��S���Ҕԍ�")
                        builSQL.Append(",W_�ڋq.�o�^�敪�ԍ�")
                        builSQL.Append(",W_�ڋq.DM��]�t���O")
                        builSQL.Append(",W_�ڋq.�o�^��")
                        builSQL.Append(",W_�ڋq.�X�V��")

                        builSQL.Append(" FROM W_�ڋq")
                        builSQL.Append(" JOIN (E_���� JOIN B_�T�[�r�X ON E_����.�T�[�r�X�ԍ� = B_�T�[�r�X.�T�[�r�X�ԍ�) ON W_�ڋq.�ڋq�ԍ� = E_����.�ڋq�ԍ�")
                        builSQL.Append(" WHERE B_�T�[�r�X.�T�[�r�X�� = @�T�[�r�X��")
                        builSQL.Append(" AND (E_����.���X�� BETWEEN @�T�[�r�X�J�n AND @�T�[�r�X�I��)")
                End Select
                builSQL.Append(" AND NOT EXISTS (SELECT * FROM W_�ڋq���o WHERE W_�ڋq���o.�ڋq�ԍ� = W_�ڋq.�ڋq�ԍ�);")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn

        End Function
#End Region

#Region "�����ꗗ�擾"
        ''' <summary>�����ꗗ�擾</summary>
        ''' <returns>�������X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_���o�����ꗗ() As DataTable
            Dim rtnCnt As DataTable
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("SELECT ����ԍ�, W_���o����.�敪, W_���o����.����, W_���o����.�l�P, W_���o����.�l�Q")
                builSQL.Append(" FROM W_���o����")
                builSQL.Append(" ORDER BY ����ԍ�;")

                str_sql = builSQL.ToString()
                rtnCnt = DBA.ExecuteDataTable(str_sql)
                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtnCnt
        End Function
#End Region

#Region "W_���o����o�^"
        ''' <summary>W_���o����o�^</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function W_���o����ǉ�(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO W_���o���� (����ԍ�,�敪,����,�l�P,�l�Q)")
                builSQL.Append(" VALUES(@����ԍ�,@�敪,@����,@�l�P,@�l�Q);")
                str_sql = builSQL.ToString()
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                '' ��O�������̓��[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtnCnt
        End Function
#End Region

    End Class
End Namespace