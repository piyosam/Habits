'�V�X�e���� �F HABITS
'�T�v�@�@�@ �F
'�����@�@�@ �F �錾
'�����@�@�@ �F 2010/04/01�@�r�v�i�@�쐬
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module �錾

    Public DBA As Habits.DB.DBAccess
    Public DBA2 As Habits.DB.DBAccess

    '--------------------------------------------------
    ' �t�H�[��
    '--------------------------------------------------
    Public M01 As Object                        ' ���j���[�E�t�H�[��
    Public rtn As Long                          ' �߂�l
    Public CST_CODE As Long                     ' �ڋq�ԍ�
    Public SER_NO As Integer                    ' ���X�Ҕԍ�
    Public MESSAGE_CNT As Integer               ' ���`�F�b�N���b�Z�[�W����

    Public USER_DATE As Date                    ' ���[�U�[���t

    Public NETWORK_FLAG As Boolean              ' �ʐM���t���O�iTrue�F�ʐM���Ă悢�AFalse�F�ʐM�����Ȃ��j
    Public ACTIVE_NETWORK_FLAG As Boolean       ' �ʐM���t���O�iTrue:�ʐM���̂��ߍĒʐM�����Ȃ��AFalse�F�ʐM�Ȃ��j
    Public FORCED_CLOSE_FLAG As Boolean         ' �����I���t���O�iTrue�F�����I��������AFalse�F�ʏ폈�����j
    Public MESSAGE_CHECK_FLAG As Boolean        ' ���b�Z�[�W�����`�F�b�N���t���O�iTrue:���b�Z�[�WCK�s�v�AFalse�F���b�Z�[�WCK�v�j
    Public MANAGER_MODE As Boolean              ' �Ǘ��҃��[�h�iTrue�F�Ǘ��҃��[�h�AFalse�F���̑��j

    Public sShopcode As String                  ' �X�܃R�[�h


    Public TAX_MANAGEMENT_TYPE As Integer       ' �ŋ敪�i1�F�ƐŎ��Ǝ�or2�F�ېŎ��Ǝҁj
    Public iTaxtype As Integer                  ' ��v������Ōv�Z�^�C�v
    Public iServicetype As Integer              ' ��v���T�[�r�X�v�Z�^�C�v
    Public ReCheckFlag As Boolean               ' �ĉ�v���`�F�b�N�t���O

    Public ReCheckDenpyoFlag As Boolean         ' �ĉ�v���`�[�{�^�������`�F�b�N�t���O

    '--------------------------------------------------
    ' �萔
    '--------------------------------------------------
    Public Const APP_NAME As String = "HabitsProject"
    Public Const TTL As String = "HABITS"                   ' �^�C�g��
    Public Const URL_HABITS_MAIN As String = "https://Habits.swj.co.jp/"        ' Web�T�[�o��HabitsURL��
    Public Const URL_HABITS_NETWORK As String = ".DataSync/"                    ' Web�T�[�o��Habits�f�[�^�ʐM�f�B���N�g��
    Public Const URL_HABITS_NDATAFOLDER As String = ".DataSync/DownloadData/"   ' Web�T�[�o��Habits�f�[�^�ʐM�f�[�^�ۊǃf�B���N�g��

    '�f�[�^�ۑ��t�H���_
    Public Const MESSAGE_PATH As String = "MessageData"     ' ���b�Z�[�W�ʐM�p�t�H���_
    Public Const MASTER_PATH As String = "MasterTable"      ' �}�X�^�X�V�p�t�H���_
    Public Const RESERVE_PATH As String = "ReserveTable"    ' �\��f�[�^�p�t�H���_

    Public Const Clng_MAXCstNo As Long = 1000000            ' �ő�ڋq�ԍ�
    Public Const Clng_STFreeNo As Long = 500000             ' �t���[�ڋq�̊J�n�ڋq�ԍ�
    Public Const Max_MasterNo As Integer = 9999             ' �ő�R�[�h�ԍ�
    Public Const Min_Date As String = "1900/1/1"

    '���X�����\�t���O
    'True : �ݒ���������Ŗ����ꍇ�ł��A���X�������\�Ƃ���B
    Public Visit_Mode As Boolean = False

    '��v�����\�t���O
    'True : �ݒ���������Ŗ����ꍇ�ł��A��v�������\�Ƃ���B
    Public Cashiers_Mode As Boolean = False

    '���X�敪
    Public Const VISIT_RETURN As Integer = 1            ' �ė�
    Public Const VISIT_NEW As Integer = 2               ' �V�K
    Public Const VISIT_FREE As Integer = 3              ' �t���[
    Public Const VISIT_FREE_CHAR As String = "�t���["   ' �t���[����

    '�o�^�敪
    Public Const BTN_REGIST As String = "�o�^"     ' �o�^
    Public Const BTN_UPDATE As String = "�ύX"     ' �ύX
    Public Const BTN_DELETE As String = "�폜"     ' �폜

    '�o�^�敪
    Public Const REGISTER_COMPLETION As Integer = 1     ' �o�^��

    '�ʐM���G���[��
    Public Const CONNECT_ERROR As Integer = 5

    '��v���X�̑Ώۃt���O
    'False:�X�̑Ώۂ̉�v���A�݌ɐ���0��-�ł����Ă��A�i�E���X���Ȃ�
    Public Const item_mode As Boolean = False

    '��񃁃b�Z�[�W
    Public Const Clng_Okcrb1 As Long = vbOKOnly + vbCritical + vbDefaultButton1       '�x��
    Public Const Clng_Okexb1 As Long = vbOKOnly + vbExclamation + vbDefaultButton1    '����
    Public Const Clng_Okinb1 As Long = vbOKOnly + vbInformation + vbDefaultButton1    '���

    '�m�F���b�Z�[�W
    Public Const Clng_Ynqub1 As Long = vbYesNo + vbQuestion + vbDefaultButton1        '�₢���킹
    Public Const Clng_Ynqub2 As Long = vbYesNo + vbQuestion + vbDefaultButton2        '��2�{�^����W��

    '���b�Z�[�W����Ɏg�p������s�R�[�h
    Public Const NEW_LINE_CODE As String = "<br/>"

End Module
