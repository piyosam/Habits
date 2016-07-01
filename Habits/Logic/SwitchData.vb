#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�f�[�^�ڍs���W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class SwitchData
        Inherits Habits.Logic.LogicBase

        Const tax As Double = 0.05
        Public managementTax As Int16
        Public taxType As Int16
        Public ServiceType As Int16
        Const TITLE As String = "�f�[�^�C��"

#Region "[OK]�ߋ��f�[�^�o�^�\�֐ؑ�"
        ''' <summary>�ߋ��f�[�^�o�^�\�֐ؑ�</summary>
        ''' <remarks></remarks>
        Sub switchOKPast()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                dt = A_System()

                If dt Is Nothing OrElse dt.Rows(0).Item("�\��1").Equals("True") Then
                    '�Ή��ς̂��ߏI��
                    Exit Sub
                End If

                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '���[�J���f�[�^�X�V�p
                str_sql = "UPDATE A_�V�X�e�� SET �\��1 = 'True'"
                rtn = DBA.ExecuteNonQuery(str_sql)

                '�T�[�o�f�[�^�X�V�p
                UpDateForSever_System()

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "[NG]�ߋ��f�[�^�o�^�s�֐ؑ�"
        ''' <summary>�ߋ��f�[�^�o�^�s�֐ؑ�</summary>
        ''' <remarks></remarks>
        Sub switchNGPast()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                dt = A_System()

                'If dt Is Nothing OrElse Not dt.Rows(0).Item("�\��1").Equals("True") Then
                '    '�Ή��ς̂��ߏI��
                '    Exit Sub
                'End If

                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '���[�J���f�[�^�X�V�p
                str_sql = "UPDATE A_�V�X�e�� SET �\��1 = ''"
                rtn = DBA.ExecuteNonQuery(str_sql)

                '�T�[�o�f�[�^�X�V�p
                UpDateForSever_System()

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "�ō��Ή��f�[�^�ڍs����"
        ''' <summary>�f�[�^�ڍs����</summary>
        ''' <remarks></remarks>
        Sub upPoint()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                '�ō��Ή��󋵃`�F�b�N
                str_sql = "SELECT �\��2 FROM A_�V�X�e��"
                dt = DBA.ExecuteDataTable(str_sql)
                If dt Is Nothing OrElse dt.Rows(0).Item("�\��2").Equals("�|�C���g����") Then
                    '�Ή��ς̂��ߏI��
                    Exit Sub
                End If

                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '�f�[�^�ύX
                upServerPoint()

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "�ō��Ή��f�[�^�ڍs����"
        ''' <summary>�f�[�^�ڍs����</summary>
        ''' <remarks></remarks>
        Sub switchDataTable()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                '�ō��Ή��󋵃`�F�b�N
                str_sql = "SELECT �\��2 FROM A_�V�X�e��"
                dt = DBA.ExecuteDataTable(str_sql)
                If dt Is Nothing OrElse dt.Rows(0).Item("�\��2").Equals("�ō��Ή�") Then
                    '�Ή��ς̂��ߏI��
                    Exit Sub
                End If

                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                '�e�[�u�����ڒǉ�
                makeTable()

                '����Ń`�F�b�N
                managementTax = judgeTaxType()
                taxType = My.MySettings.Default.TaxType
                ServiceType = My.MySettings.Default.ServiceType
                '�f�[�^�ϊ�
                changeData()

                ' �R�~�b�g
                DBA.TransactionCommit()
                'A�V�X�e���̒l�ݒ�
                setA_SystemVariable()

            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "�e�[�u�����ڒǉ�"
        ''' <summary>�_�E�����[�h�f�[�^����e�[�u���X�V</summary>
        ''' <remarks></remarks>
        Sub makeTable()
            Dim builSQL As New StringBuilder()


            '��SQL�i�m�F�Ɏg�p�j
            'CREATE TABLE [dbo].[B_�|�C���g����](
            '[�|�C���g�����ԍ�] [smallint] NOT NULL,
            '[�|�C���g������] [nvarchar](32) NOT NULL,
            '[�\����] [smallint] NOT NULL,
            '[�폜�t���O] [bit] NOT NULL,
            '[�o�^��] [datetime] NOT NULL CONSTRAINT [DF_B_�|�C���g����_�o�^��]  DEFAULT (getdate()),
            '[�X�V��] [datetime] NOT NULL CONSTRAINT [DF_B_�|�C���g����_�X�V��]  DEFAULT (getdate()),
            'CONSTRAINT [PK_B_�|�C���g����] PRIMARY KEY NONCLUSTERED
            '(
            '            [�|�C���g�����ԍ�](Asc)
            ') ON [PRIMARY]
            ') ON [PRIMARY]
            '--��A_�V�X�e��
            'ALTER TABLE [A_�V�X�e��] ADD �ŋ敪 smallint NOT NULL CONSTRAINT [DF_A_�V�X�e��_�ŋ敪]  DEFAULT ((2));
            '--��C_���i
            'ALTER TABLE [C_���i] ADD ���z�Ǘ��敪 smallint NOT NULL CONSTRAINT [DF_C_���i_���z�Ǘ��敪]  DEFAULT ((1));
            '--��E_����
            'ALTER TABLE [E_����] ADD �|�C���g�����ԍ� smallint NOT NULL CONSTRAINT [DF_E_����_�|�C���g�����ԍ�]  DEFAULT ((0));
            'ALTER TABLE [E_����] ADD �|�C���g�����x�� int NOT NULL CONSTRAINT [DF_E_����_�|�C���g�����x��]  DEFAULT ((0));
            'ALTER TABLE [E_����] ADD �T�[�r�X�ԍ� smallint NOT NULL CONSTRAINT [DF_E_����_�T�[�r�X�ԍ�]  DEFAULT ((0));
            'ALTER TABLE [E_����] ADD �T�[�r�X���z int NOT NULL CONSTRAINT [DF_E_����_�T�[�r�X���z]  DEFAULT ((0));
            '--��E_���㖾��
            'ALTER TABLE [E_���㖾��] ADD ����� int NOT NULL CONSTRAINT [DF_E_���㖾��_�����]  DEFAULT ((0));
            '--��E_���X��
            'ALTER TABLE [E_���X��] ADD �|�C���g�����ԍ� smallint NOT NULL CONSTRAINT [DF_E_���X��_�|�C���g�����ԍ�]  DEFAULT ((0));
            'ALTER TABLE [E_���X��] ADD �|�C���g�����x�� int NOT NULL CONSTRAINT [DF_E_���X��_�|�C���g�����x��]  DEFAULT ((0));
            'ALTER TABLE [E_���X��] ADD �T�[�r�X�ԍ� smallint NOT NULL CONSTRAINT [DF_E_���X��_�T�[�r�X�ԍ�]  DEFAULT ((0));
            'ALTER TABLE [E_���X��] ADD �T�[�r�X�敪 smallint NOT NULL CONSTRAINT [DF_E_���X��_�T�[�r�X�敪]  DEFAULT ((1));
            'ALTER TABLE [E_���X��] ADD �T�[�r�X���z int NOT NULL CONSTRAINT [DF_E_���X��_�T�[�r�X���z]  DEFAULT ((0));
            '--��W_���V�[�g
            'DROP TABLE W_���V�[�g
            'CREATE TABLE [dbo].[W_���V�[�g](
            '[�ԍ�] [smallint] NOT NULL,
            '[�f�[�^�^�C�v] [int] NULL,
            '[����] [nvarchar](33) NULL,
            '[��S���Җ�] [nvarchar](32) NULL,
            '[�i��] [nvarchar](32) NULL,
            '[����] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_����]  DEFAULT ((0)),
            '[���z] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_���z]  DEFAULT ((0)),
            '[���v] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_���v]  DEFAULT ((0)),
            '[�����] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_�����]  DEFAULT ((0)),
            '[���v] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_���v]  DEFAULT ((0)),
            '[���ނ�] [int] NULL CONSTRAINT [DF_W_���V�[�g_���ނ�]  DEFAULT ((0)),
            'CONSTRAINT [PK_W_���V�[�g] PRIMARY KEY NONCLUSTERED 
            '(
            '            [�ԍ�](Asc)
            ') ON [PRIMARY]
            ') ON [PRIMARY]
            '--��W_�ڋq���o
            'DROP TABLE W_�ڋq���o
            'CREATE TABLE [dbo].[W_�ڋq���o](
            '[�I��] [bit] NOT NULL CONSTRAINT [DF_W_�ڋq���o_�I��]  DEFAULT ((0)),
            '[�ڋq�ԍ�] [int] NULL,
            '[��] [nvarchar](32) NULL,
            '[��] [nvarchar](32) NULL,
            '[���J�i] [nvarchar](32) NULL,
            '[���J�i] [nvarchar](32) NULL,
            '[���ʔԍ�] [smallint] NULL,
            '[���N����] [datetime] NULL,
            '[�X�֔ԍ�] [nvarchar](8) NULL,
            '[�s���{��] [nvarchar](16) NULL,
            '[�Z��1] [nvarchar](128) NULL,
            '[�Z��2] [nvarchar](128) NULL,
            '[�Z��3] [nvarchar](128) NULL,
            '[�d�b�ԍ�] [nvarchar](19) NULL,
            '[Email�A�h���X] [nvarchar](256) NULL,
            '[�Ƒ���] [nvarchar](32) NULL,
            '[�] [nvarchar](32) NULL,
            '[�D���Șb��] [nvarchar](32) NULL,
            '[�����Șb��] [nvarchar](32) NULL,
            '[�`���t���O] [bit] NULL,
            '[����] [nvarchar](64) NULL,
            '[�Љ��] [nvarchar](32) NULL,
            '[�O�񗈓X��] [datetime] NULL,
            '[���X��N_1] [datetime] NULL,
            '[���X��N_2] [datetime] NULL,
            '[���X��] [int] NULL,
            '[����敪�ԍ�] [int] NULL,
            '[�敪���v���z] [int] NULL,
            '[��S���Ҕԍ�] [smallint] NULL,
            '[�o�^�敪�ԍ�] [smallint] NULL,
            '[DM��]�t���O] [bit] NULL,
            '[�o�^��] [datetime] NULL,
            '[�X�V��] [datetime] NULL
            ') ON [PRIMARY]
            '--��W_�x��
            'DROP TABLE W_�x��
            'CREATE TABLE [dbo].[W_�x��](
            '[���q�{] [int] NOT NULL CONSTRAINT [DF_W_�x��_���q�{]  DEFAULT ((0)),
            '[�����{] [int] NOT NULL CONSTRAINT [DF_W_�x��_�����{]  DEFAULT ((0)),
            '[�J�[�h�{] [int] NOT NULL CONSTRAINT [DF_W_�x��_�J�[�h�{]  DEFAULT ((0)),
            '[���̑��{] [int] NOT NULL CONSTRAINT [DF_W_�x��_���̑��{]  DEFAULT ((0)),
            '[�|�C���g�����{] [int] NOT NULL CONSTRAINT [DF_W_�x��_�|�C���g�����{]  DEFAULT ((0)),
            '[����Ŗ{] [int] NOT NULL CONSTRAINT [DF_W_�x��_����Ŗ{]  DEFAULT ((0)),
            '[������] [int] NOT NULL CONSTRAINT [DF_W_�x��_������]  DEFAULT ((0)),
            '[�J�[�h��] [int] NOT NULL CONSTRAINT [DF_W_�x��_�J�[�h��]  DEFAULT ((0)),
            '[���̑���] [int] NOT NULL CONSTRAINT [DF_W_�x��_���̑���]  DEFAULT ((0)),
            '[�|�C���g������] [int] NOT NULL CONSTRAINT [DF_W_�x��_�|�C���g������]  DEFAULT ((0)),
            '[����ŗ�] [int] NOT NULL CONSTRAINT [DF_W_�x��_����ŗ�]  DEFAULT ((0)),
            ') ON [PRIMARY]
            '--��W_�o�͑Ώ�
            'DROP TABLE W_�o�͑Ώ�

            '--��B_�|�C���g����
            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[B_�|�C���g����](")
            builSQL.Append("[�|�C���g�����ԍ�] [smallint] NOT NULL,")
            builSQL.Append("[�|�C���g������] [nvarchar](32) NOT NULL,")
            builSQL.Append("[�\����] [smallint] NOT NULL,")
            builSQL.Append("[�폜�t���O] [bit] NOT NULL,")
            builSQL.Append("[�o�^��] [datetime] NOT NULL CONSTRAINT [DF_B_�|�C���g����_�o�^��]  DEFAULT (getdate()),")
            builSQL.Append("[�X�V��] [datetime] NOT NULL CONSTRAINT [DF_B_�|�C���g����_�X�V��]  DEFAULT (getdate()),")
            builSQL.Append("CONSTRAINT [PK_B_�|�C���g����] PRIMARY KEY NONCLUSTERED")
            builSQL.Append("(")
            builSQL.Append("[�|�C���g�����ԍ�] Asc")
            builSQL.Append(") ON [PRIMARY]")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��A_�V�X�e��
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [A_�V�X�e��] ADD �ŋ敪 smallint NOT NULL CONSTRAINT [DF_A_�V�X�e��_�ŋ敪]  DEFAULT ((2));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��C_���i
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [C_���i] ADD ���z�Ǘ��敪 smallint NOT NULL CONSTRAINT [DF_C_���i_���z�Ǘ��敪]  DEFAULT ((1));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��E_����
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_����] ADD �|�C���g�����ԍ� smallint NOT NULL CONSTRAINT [DF_E_����_�|�C���g�����ԍ�]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_����] ADD �|�C���g�����x�� int NOT NULL CONSTRAINT [DF_E_����_�|�C���g�����x��]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_����] ADD �T�[�r�X�ԍ� smallint NOT NULL CONSTRAINT [DF_E_����_�T�[�r�X�ԍ�]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_����] ADD �T�[�r�X���z int NOT NULL CONSTRAINT [DF_E_����_�T�[�r�X���z]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��E_���㖾��
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_���㖾��] ADD ����� int NOT NULL CONSTRAINT [DF_E_���㖾��_�����]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��E_���X��
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_���X��] ADD �|�C���g�����ԍ� smallint NOT NULL CONSTRAINT [DF_E_���X��_�|�C���g�����ԍ�]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_���X��] ADD �|�C���g�����x�� int NOT NULL CONSTRAINT [DF_E_���X��_�|�C���g�����x��]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_���X��] ADD �T�[�r�X�ԍ� smallint NOT NULL CONSTRAINT [DF_E_���X��_�T�[�r�X�ԍ�]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_���X��] ADD �T�[�r�X�敪 smallint NOT NULL CONSTRAINT [DF_E_���X��_�T�[�r�X�敪]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_���X��] ADD �T�[�r�X���z int NOT NULL CONSTRAINT [DF_E_���X��_�T�[�r�X���z]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��W_���V�[�g
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_���V�[�g")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[W_���V�[�g](")
            builSQL.Append("[�ԍ�] [smallint] NOT NULL,")
            builSQL.Append("[�f�[�^�^�C�v] [int] NULL,")
            builSQL.Append("[����] [nvarchar](33) NULL,")
            builSQL.Append("[��S���Җ�] [nvarchar](32) NULL,")
            builSQL.Append("[�i��] [nvarchar](32) NULL,")
            builSQL.Append("[����] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_����]  DEFAULT ((0)),")
            builSQL.Append("[���z] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_���z]  DEFAULT ((0)),")
            builSQL.Append("[���v] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_���v]  DEFAULT ((0)),")
            builSQL.Append("[�����] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_�����]  DEFAULT ((0)),")
            builSQL.Append("[���v] [int] NOT NULL CONSTRAINT [DF_W_���V�[�g_���v]  DEFAULT ((0)),")
            builSQL.Append("[���ނ�] [int] NULL CONSTRAINT [DF_W_���V�[�g_���ނ�]  DEFAULT ((0)),")
            builSQL.Append("CONSTRAINT [PK_W_���V�[�g] PRIMARY KEY NONCLUSTERED ")
            builSQL.Append("(")
            builSQL.Append("[�ԍ�] Asc")
            builSQL.Append(") ON [PRIMARY]")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��W_�ڋq���o
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_�ڋq���o")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[W_�ڋq���o](")
            builSQL.Append("[�I��] [bit] NOT NULL CONSTRAINT [DF_W_�ڋq���o_�I��]  DEFAULT ((0)),")
            builSQL.Append("[�ڋq�ԍ�] [int] NULL,")
            builSQL.Append("[��] [nvarchar](32) NULL,")
            builSQL.Append("[��] [nvarchar](32) NULL,")
            builSQL.Append("[���J�i] [nvarchar](32) NULL,")
            builSQL.Append("[���J�i] [nvarchar](32) NULL,")
            builSQL.Append("[���ʔԍ�] [smallint] NULL,")
            builSQL.Append("[���N����] [datetime] NULL,")
            builSQL.Append("[�X�֔ԍ�] [nvarchar](8) NULL,")
            builSQL.Append("[�s���{��] [nvarchar](16) NULL,")
            builSQL.Append("[�Z��1] [nvarchar](128) NULL,")
            builSQL.Append("[�Z��2] [nvarchar](128) NULL,")
            builSQL.Append("[�Z��3] [nvarchar](128) NULL,")
            builSQL.Append("[�d�b�ԍ�] [nvarchar](19) NULL,")
            builSQL.Append("[Email�A�h���X] [nvarchar](256) NULL,")
            builSQL.Append("[�Ƒ���] [nvarchar](32) NULL,")
            builSQL.Append("[�] [nvarchar](32) NULL,")
            builSQL.Append("[�D���Șb��] [nvarchar](32) NULL,")
            builSQL.Append("[�����Șb��] [nvarchar](32) NULL,")
            builSQL.Append("[�`���t���O] [bit] NULL,")
            builSQL.Append("[����] [nvarchar](64) NULL,")
            builSQL.Append("[�Љ��] [nvarchar](32) NULL,")
            builSQL.Append("[�O�񗈓X��] [datetime] NULL,")
            builSQL.Append("[���X��N_1] [datetime] NULL,")
            builSQL.Append("[���X��N_2] [datetime] NULL,")
            builSQL.Append("[���X��] [int] NULL,")
            builSQL.Append("[����敪�ԍ�] [int] NULL,")
            builSQL.Append("[�敪���v���z] [int] NULL,")
            builSQL.Append("[��S���Ҕԍ�] [smallint] NULL,")
            builSQL.Append("[�o�^�敪�ԍ�] [smallint] NULL,")
            builSQL.Append("[DM��]�t���O] [bit] NULL,")
            builSQL.Append("[�o�^��] [datetime] NULL,")
            builSQL.Append("[�X�V��] [datetime] NULL")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��W_�x��
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_�x��")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[W_�x��](")
            builSQL.Append("[���q�{] [int] NOT NULL CONSTRAINT [DF_W_�x��_���q�{]  DEFAULT ((0)),")
            builSQL.Append("[�����{] [int] NOT NULL CONSTRAINT [DF_W_�x��_�����{]  DEFAULT ((0)),")
            builSQL.Append("[�J�[�h�{] [int] NOT NULL CONSTRAINT [DF_W_�x��_�J�[�h�{]  DEFAULT ((0)),")
            builSQL.Append("[���̑��{] [int] NOT NULL CONSTRAINT [DF_W_�x��_���̑��{]  DEFAULT ((0)),")
            builSQL.Append("[�|�C���g�����{] [int] NOT NULL CONSTRAINT [DF_W_�x��_�|�C���g�����{]  DEFAULT ((0)),")
            builSQL.Append("[����Ŗ{] [int] NOT NULL CONSTRAINT [DF_W_�x��_����Ŗ{]  DEFAULT ((0)),")
            builSQL.Append("[������] [int] NOT NULL CONSTRAINT [DF_W_�x��_������]  DEFAULT ((0)),")
            builSQL.Append("[�J�[�h��] [int] NOT NULL CONSTRAINT [DF_W_�x��_�J�[�h��]  DEFAULT ((0)),")
            builSQL.Append("[���̑���] [int] NOT NULL CONSTRAINT [DF_W_�x��_���̑���]  DEFAULT ((0)),")
            builSQL.Append("[�|�C���g������] [int] NOT NULL CONSTRAINT [DF_W_�x��_�|�C���g������]  DEFAULT ((0)),")
            builSQL.Append("[����ŗ�] [int] NOT NULL CONSTRAINT [DF_W_�x��_����ŗ�]  DEFAULT ((0)),")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--��W_�o�͑Ώ�
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_�o�͑Ώ�")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

        End Sub
#End Region

#Region "�ō���������"
        ''' <summary>judgeTaxType</summary>
        ''' <returns>1�F�Ŕ��i�{�̉��i�j�Ǘ��A2:�ō����i�Ǘ�</returns>
        ''' <remarks></remarks>
        Function judgeTaxType() As Int16
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim rtn As Int16 = 1

            Try
                str_sql = "SELECT COUNT(*) FROM B_����� WHERE �ŗ�=0"
                dt = DBA.ExecuteDataTable(str_sql)

                If (dt.Rows(0)(0).ToString() > 0) Then
                    rtn = 2
                End If
                Return rtn

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "�e�[�u���̒l�ϊ�"
        ''' <summary>�e�[�u���̒l�ϊ�</summary>
        ''' <remarks></remarks>
        Sub upServerPoint()
            Dim builSQL As New StringBuilder()
            Dim dt As New DataTable

            '���|�C���g����
            builSQL.Length = 0
            builSQL.Append("SELECT * FROM [B_�|�C���g����]")
            dt = DBA.ExecuteDataTable(builSQL.ToString())

            For Each dr As DataRow In dt.Rows
                '��Z_SQL���s���� DELETE
                builSQL.Length = 0
                builSQL.Append("DELETE FROM point_purchases WHERE")
                builSQL.Append(" shop_code=" & VbSQLNStr(sShopcode))
                builSQL.Append(" AND code=" & VbSQLStr(dr.Item("�|�C���g�����ԍ�").ToString()))
                InsertZSqlExecHis(TITLE, builSQL.ToString)

                '��Z_SQL���s���� INSERT
                builSQL.Length = 0
                builSQL.Append("INSERT INTO point_purchases (shop_code,code,name,display_order,delete_flag,insert_date,update_date) VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(dr.Item("�|�C���g�����ԍ�").ToString()))
                builSQL.Append("," & VbSQLNStr(dr.Item("�|�C���g������").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("�\����").ToString()))
                If dr.Item("�폜�t���O") = True Then
                    builSQL.Append(",''1''")
                Else
                    builSQL.Append(",''0''")
                End If

                builSQL.Append("," & VbSQLStr(dr.Item("�o�^��").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("�X�V��").ToString()))
                builSQL.Append(")")
                InsertZSqlExecHis(TITLE, builSQL.ToString)
            Next

            '���T�[�r�X
            builSQL.Length = 0
            builSQL.Append("SELECT * FROM [B_�T�[�r�X]")
            dt = DBA.ExecuteDataTable(builSQL.ToString())

            For Each dr As DataRow In dt.Rows
                '��Z_SQL���s���� DELETE
                builSQL.Length = 0
                builSQL.Append("DELETE FROM service WHERE")
                builSQL.Append(" shop_code=" & VbSQLNStr(sShopcode))
                builSQL.Append(" AND code=" & VbSQLStr(dr.Item("�T�[�r�X�ԍ�").ToString()))
                InsertZSqlExecHis(TITLE, builSQL.ToString)

                '��Z_SQL���s���� INSERT
                builSQL.Length = 0
                builSQL.Append("INSERT INTO service (shop_code,code,name,display_order,delete_flag,insert_date,update_date) VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(dr.Item("�T�[�r�X�ԍ�").ToString()))
                builSQL.Append("," & VbSQLNStr(dr.Item("�T�[�r�X��").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("�\����").ToString()))
                If dr.Item("�폜�t���O") = True Then
                    builSQL.Append(",''1''")
                Else
                    builSQL.Append(",''0''")
                End If

                builSQL.Append("," & VbSQLStr(dr.Item("�o�^��").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("�X�V��").ToString()))
                builSQL.Append(")")
                InsertZSqlExecHis(TITLE, builSQL.ToString)
            Next
            '��A_�V�X�e���ύX
            builSQL.Length = 0
            builSQL.Append("UPDATE A_�V�X�e�� SET �\��2='�|�C���g����'")
            dt = DBA.ExecuteDataTable(builSQL.ToString())

            '��Z_SQL���s���� INSERT
            UpDateForSever_System()

        End Sub
#End Region

#Region "�e�[�u���̒l�ϊ�"
        ''' <summary>�e�[�u���̒l�ϊ�</summary>
        ''' <remarks></remarks>
        Sub changeData()
            Dim builSQL As New StringBuilder()
            Dim dt As New DataTable

            '--��B_�|�C���g����
            '--�ϊ��Ȃ�

            '--��A_�V�X�e���i1�F�ƐŎ��ƎҁA2�F�ېŎ��Ǝҁj
            builSQL.Length = 0
            builSQL.Append("UPDATE [A_�V�X�e��] SET �ŋ敪='2',�\��2='�ō��Ή�',�ύX����=getdate()")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())
            '��Z_SQL���s���� INSERT
            UpDateForSever_System()

            '--��C_���i�i1�F�Ŕ��i�{�̉��i�j�Ǘ��A2:�ō����i�Ǘ��j
            builSQL.Length = 0
            builSQL.Append("UPDATE [C_���i] SET ���z�Ǘ��敪='" & managementTax & "';")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())
            '��Z_SQL���s���� INSERT
            builSQL.Length = 0
            builSQL.Append("UPDATE goods SET")
            builSQL.Append(" management_tax=" & VbSQLStr(managementTax))
            builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
            InsertZSqlExecHis(TITLE, builSQL.ToString)

            '--��E_����
            '--�ϊ��Ȃ�

            '--��E_���㖾��
            If managementTax = 1 Then
                builSQL.Length = 0
                Select Case taxType
                    Case 1 ' �؂�̂�
                        builSQL.Append("UPDATE E_���㖾�� SET ����� = FLOOR((���z * ���� - �T�[�r�X) * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= FLOOR((amount * count - service_amount) * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case 2 ' �l�̌ܓ�
                        builSQL.Append("UPDATE E_���㖾�� SET ����� = ROUND((���z * ���� - �T�[�r�X) * " & tax & ",0)")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= ROUND((amount * count - service_amount) * " & tax & ",0)")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case Else ' �؂�グ
                        builSQL.Append("UPDATE E_���㖾�� SET ����� = CEILING((���z * ���� - �T�[�r�X) * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= CEILING((amount * count - service_amount) * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                End Select

                builSQL.Length = 0
                builSQL.Append("UPDATE E_���㖾�� SET ���z = CEILING(���z * " & 1 + tax & ")")
                rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                '��Z_SQL���s���� INSERT
                builSQL.Length = 0
                builSQL.Append("UPDATE sales_details SET")
                builSQL.Append(" amount= CEILING(amount * " & 1 + tax & ")")
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(TITLE, builSQL.ToString)

                builSQL.Length = 0
                Select Case ServiceType
                    Case 1 ' �؂�̂�
                        builSQL.Append("UPDATE E_���㖾�� SET �T�[�r�X = FLOOR(�T�[�r�X * " & 1 + tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" service_amount= FLOOR(service_amount * " & 1 + tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case 2 ' �l�̌ܓ�
                        builSQL.Append("UPDATE E_���㖾�� SET �T�[�r�X = ROUND(�T�[�r�X * " & 1 + tax & ",0)")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" service_amount= ROUND(service_amount * " & 1 + tax & ",0)")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case Else ' �؂�グ
                        builSQL.Append("UPDATE E_���㖾�� SET �T�[�r�X = CEILING(�T�[�r�X * " & 1 + tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" service_amount= CEILING(service_amount * " & 1 + tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                End Select

                builSQL.Length = 0
                builSQL.Append("SELECT c.���X��,c.���X�Ҕԍ�,c.����ԍ�,c.���z+���z AS �C�����z")
                builSQL.Append(" FROM ( SELECT")
                builSQL.Append(" E_����.���X�� AS ���X��")
                builSQL.Append(" ,E_����.���X�Ҕԍ� AS ���X�Ҕԍ�")
                builSQL.Append(" ,�����x��+�J�[�h�x��+���̑��x��-�x�� AS ���z")
                builSQL.Append(" ,�x��")
                builSQL.Append(" ,�����x��+�J�[�h�x��+���̑��x�� AS ���z")
                builSQL.Append(" FROM (")
                builSQL.Append(" SELECT ���X��,���X�Ҕԍ�,SUM(���z*���� -�T�[�r�X) AS �x�� FROM E_���㖾��")
                builSQL.Append(" GROUP BY ���X��,���X�Ҕԍ�) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN E_����")
                builSQL.Append(" ON E_����.���X��=MEISAI.���X��")
                builSQL.Append(" AND E_����.���X�Ҕԍ�=MEISAI.���X�Ҕԍ�")
                builSQL.Append(" WHERE �����x��+�J�[�h�x�� + ���̑��x��  > MEISAI.�x��")
                builSQL.Append(" ) AS a")
                builSQL.Append(" INNER JOIN")
                builSQL.Append(" (SELECT E_���㖾��.*")
                builSQL.Append(" FROM E_���㖾��,")
                builSQL.Append(" (SELECT ���X��,���X�Ҕԍ�,MIN(����ԍ�) AS ����ԍ�")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" GROUP BY ���X��,���X�Ҕԍ�) AS b")
                builSQL.Append(" WHERE(E_���㖾��.���X�� = b.���X��)")
                builSQL.Append(" AND E_���㖾��.���X�Ҕԍ� =b.���X�Ҕԍ�")
                builSQL.Append(" AND E_���㖾��.����ԍ� =b.����ԍ�")
                builSQL.Append(" ) AS c")
                builSQL.Append(" ON c.���X��=a.���X��")
                builSQL.Append(" AND c.���X�Ҕԍ�=a.���X�Ҕԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString())

                For Each dr As DataRow In dt.Rows
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_���㖾�� SET ���z='" & dr.Item("�C�����z").ToString() & "'")
                    builSQL.Append(" WHERE ���X��='" & dr.Item("���X��").ToString() & "'")
                    builSQL.Append(" AND ���X�Ҕԍ�='" & dr.Item("���X�Ҕԍ�").ToString() & "'")
                    builSQL.Append(" AND ����ԍ�='" & dr.Item("����ԍ�").ToString() & "'")
                    rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                    '��Z_SQL���s���� INSERT
                    builSQL.Length = 0
                    builSQL.Append("UPDATE sales_details SET")
                    builSQL.Append(" amount=" & VbSQLStr(dr.Item("�C�����z").ToString()))
                    builSQL.Append(" WHERE visit_date=" & VbSQLStr(dr.Item("���X��").ToString()))
                    builSQL.Append(" AND visit_number=" & VbSQLStr(dr.Item("���X�Ҕԍ�").ToString()))
                    builSQL.Append(" AND code=" & VbSQLStr(dr.Item("����ԍ�").ToString()))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(TITLE, builSQL.ToString)
                Next

                builSQL.Length = 0
                builSQL.Append("SELECT c.���X��,c.���X�Ҕԍ�,c.����ԍ�,c.�T�[�r�X-���z AS �C�����z")
                builSQL.Append(" FROM ( SELECT")
                builSQL.Append(" E_����.���X�� AS ���X��")
                builSQL.Append(" ,E_����.���X�Ҕԍ� AS ���X�Ҕԍ�")
                builSQL.Append(" ,�����x��+�J�[�h�x��+���̑��x��-�x�� AS ���z")
                builSQL.Append(" ,�x��")
                builSQL.Append(" ,�����x��+�J�[�h�x��+���̑��x�� AS ���z")
                builSQL.Append(" FROM (")
                builSQL.Append(" SELECT ���X��,���X�Ҕԍ�,SUM(���z*���� -�T�[�r�X) AS �x�� FROM E_���㖾��")
                builSQL.Append(" GROUP BY ���X��,���X�Ҕԍ�) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN E_����")
                builSQL.Append(" ON E_����.���X��=MEISAI.���X��")
                builSQL.Append(" AND E_����.���X�Ҕԍ�=MEISAI.���X�Ҕԍ�")
                builSQL.Append(" WHERE �����x��+�J�[�h�x�� + ���̑��x�� <> MEISAI.�x��")
                builSQL.Append(" ) AS a")
                builSQL.Append(" INNER JOIN")
                builSQL.Append(" (SELECT E_���㖾��.*")
                builSQL.Append(" FROM E_���㖾��,")
                builSQL.Append(" (SELECT ���X��,���X�Ҕԍ�,MIN(����ԍ�) AS ����ԍ�")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" GROUP BY ���X��,���X�Ҕԍ�) AS b")
                builSQL.Append(" WHERE(E_���㖾��.���X�� = b.���X��)")
                builSQL.Append(" AND E_���㖾��.���X�Ҕԍ� =b.���X�Ҕԍ�")
                builSQL.Append(" AND E_���㖾��.����ԍ� =b.����ԍ�")
                builSQL.Append(" ) AS c")
                builSQL.Append(" ON c.���X��=a.���X��")
                builSQL.Append(" AND c.���X�Ҕԍ�=a.���X�Ҕԍ�")
                dt = DBA.ExecuteDataTable(builSQL.ToString())

                For Each dr As DataRow In dt.Rows
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_���㖾�� SET �T�[�r�X='" + dr.Item("�C�����z").ToString() + "'")
                    builSQL.Append(" WHERE ���X��='" + dr.Item("���X��").ToString() + "'")
                    builSQL.Append(" AND ���X�Ҕԍ�='" + dr.Item("���X�Ҕԍ�").ToString() + "'")
                    builSQL.Append(" AND ����ԍ�='" + dr.Item("����ԍ�").ToString() + "'")
                    rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                    '��Z_SQL���s���� INSERT
                    builSQL.Length = 0
                    builSQL.Append("UPDATE sales_details SET")
                    builSQL.Append(" service_amount=" & VbSQLStr(dr.Item("�C�����z").ToString()))
                    builSQL.Append(" WHERE visit_date=" & VbSQLStr(dr.Item("���X��").ToString()))
                    builSQL.Append(" AND visit_number=" & VbSQLStr(dr.Item("���X�Ҕԍ�").ToString()))
                    builSQL.Append(" AND code=" & VbSQLStr(dr.Item("����ԍ�").ToString()))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(TITLE, builSQL.ToString)
                Next
            Else
                builSQL.Length = 0
                Select Case taxType
                    Case 1 ' �؂�̂�
                        builSQL.Append("UPDATE E_���㖾�� SET ����� = FLOOR((���z * ���� - �T�[�r�X) /" & 1 + tax & " * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= FLOOR((amount * count - service_amount) / " & 1 + tax & " * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case 2 ' �l�̌ܓ�
                        builSQL.Append("UPDATE E_���㖾�� SET ����� = ROUND((���z * ���� - �T�[�r�X) /" & 1 + tax & " * " & tax & ",0)")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= ROUND((amount * count - service_amount) / " & 1 + tax & " * " & tax & ",0)")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case Else ' �؂�グ
                        builSQL.Append("UPDATE E_���㖾�� SET ����� = CEILING((���z * ���� - �T�[�r�X) /" & 1 + tax & " * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '��Z_SQL���s���� INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= CEILING((amount * count - service_amount) / " & 1 + tax & " * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                End Select

                builSQL.Length = 0
                builSQL.Append("UPDATE E_���� SET ")
                builSQL.Append(" �����=(")
                builSQL.Append(" SELECT SUM(�����)")
                builSQL.Append(" FROM E_���㖾��")
                builSQL.Append(" WHERE E_����.���X�� = E_���㖾��.���X��")
                builSQL.Append(" AND E_����.���X�Ҕԍ�=E_���㖾��.���X�Ҕԍ�")
                builSQL.Append(" GROUP BY E_���㖾��.���X��,E_���㖾��.���X�Ҕԍ�")
                builSQL.Append(")")
                rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                '��Z_SQL���s���� INSERT
                builSQL.Length = 0
                builSQL.Append("UPDATE sales SET")
                builSQL.Append(" tax= ( SELECT SUM(tax) FROM sales_details")
                builSQL.Append(" WHERE sales.visit_date = sales_details.visit_date")
                builSQL.Append(" AND sales.visit_number = sales_details.visit_number")
                builSQL.Append(" GROUP BY sales_details.visit_date,sales_details.visit_number")
                builSQL.Append(" )")
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(TITLE, builSQL.ToString)
            End If

            '--��E_���X��
            '--�ϊ��Ȃ�

            '--��W_���V�[�g
            '--�ϊ��Ȃ�

            '--��W_�ڋq���o
            '--�ϊ��Ȃ�

            '--��W_�x��
            '--�ϊ��Ȃ�

            '--��W_�o�͑Ώ�
            '--�ϊ��Ȃ�

        End Sub
#End Region
    End Class
End Namespace
