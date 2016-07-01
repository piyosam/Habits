'�V�X�e���� �F HABITS
'�@�\���@�@ �F z0100_progressForm
'�T�v�@�@�@ �F �v���O���X�o�[�i�i�s�󋵁j�\���@�\
'           �F �Q�ƁFhttp://www.atmarkit.co.jp/fdotnet/dotnettips/181waitdlg/waitdlg.vb
'�����@�@�@ �F 2011/04/20�@�r�v�i�@�쐬
'           �F 2011/09/28�@�r�v�i�@���ݖ��g�p�ł��邪�A�Q�l�ɂȂ邽�ߍ폜�����c���Ă݂�
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z0100_progressForm

    '----------------------------------------------------------------------
    '   �i����Max���������m�ȏꍇ
    '       Show���\�b�h��Init���\�b�h��Bar��Max��ݒ肵��
    '       Set���\�b�h��Bar�̌��݈ʒu���w�肵�܂��B
    '       ���e�v���p�e�B(Msg1�`3�ABarMin�ABarMax�ABarVal)��ݒ肵�Ă�OK
    '----------------------------------------------------------------------
    '   �i����Max�������s���ȏꍇ
    '       AutoOn���\�b�h�Ŏ����i�����J�n��
    '       AutoOff���\�b�h�Ŏ����i�����I�����܂��B
    '----------------------------------------------------------------------

#Region "�ϐ��E�萔"
    ''' <summary>�_�C�A���O�\�����t���O</summary>
    Private bShowing As Boolean = False

    ''' <summary>�Ăяo���t�H�[��</summary>
    Dim fmParent As System.Windows.Forms.Form

    ''' <summary>�o�b�N�O���E���h����</summary>
    Private WithEvents m_Background As New ComponentModel.BackgroundWorker

    ''' <summary>�i���p���b�Z�[�W</summary>
    Enum enmMsg2
        ''' <summary>�f�[�^�擾���c</summary>
        GetData
        ''' <summary>�f�[�^�擾�I��</summary>
        GotData
    End Enum

#End Region

#Region "�C���X�^���X����"
    Sub New(Optional ByVal fmParent As System.Windows.Forms.Form = Nothing)
        ' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        Me.Text = "�������c"

        '' �Ăяo���t�H�[���擾
        If fmParent Is Nothing Then
            Me.fmParent = CType(System.Windows.Forms.Form.ActiveForm, a0200_���C��)
        Else
            Me.fmParent = fmParent
        End If

        '' �o�b�O�O���E���h�ϐ��ݒ�
        m_Background.WorkerReportsProgress = True       '' �i�s�󋵂̍X�V��񍐂ł��邩�ǂ�����ݒ�B
        m_Background.WorkerSupportsCancellation = True  '' �񓯊��̃L�����Z�����T�|�[�g���邩�ǂ�����ݒ�B

    End Sub
    Sub New(ByVal fmParentName As String)
        Me.New(DirectCast(My.Application.OpenForms.Item(fmParentName), System.Windows.Forms.Form))
        '' ���̌Ăяo���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        'InitializeComponent()

        'Dim fm As BaseForm = DirectCast(My.Application.OpenForms.Item(fmParentName), BaseForm)
    End Sub
#End Region

#Region "Show���\�b�h�̃V���h�E"
    ''' <summary>Show���\�b�h�̃V���h�E</summary>
    ''' <param name="vMsg1">�P�Ԗڂ̃��b�Z�[�W ���ȗ����͋󕶎����Z�b�g</param>
    ''' <param name="vMsg2">�Q�Ԗڂ̃��b�Z�[�W ���ȗ����͋󕶎����Z�b�g</param>
    ''' <param name="vMsg3">�R�Ԗڂ̃��b�Z�[�W ���ȗ����͋󕶎����Z�b�g</param>
    ''' <param name="vBarMax">�i���o�[�ő�l</param>
    ''' <remarks></remarks>
    Public Shadows Sub Show( _
        Optional ByVal vMsg1 As String = Nothing, _
        Optional ByVal vMsg2 As String = Nothing, _
        Optional ByVal vMsg3 As String = Nothing, _
        Optional ByVal vBarMax As Integer = 100 _
    )
        ' �ϐ��̏�����
        Me.DialogResult = DialogResult.OK

        Me.Init(vMsg1, vMsg2, vMsg3, vBarMax)

        MyBase.Show() : Me.bShowing = True

        Me.fmParent.Enabled = False

        '' �����v�\��
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Application.DoEvents()

    End Sub
#End Region

#Region "ShowDialog���\�b�h�̃V���h�E / �g�p�s��"
    ''' <summary>ShowDialog���\�b�h�̃V���h�E�iWaitDialog�N���X�ł́AShowDialog���\�b�h�͎g�p�s�j</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function ShowDialog() As System.Windows.Forms.DialogResult
        Debug.Assert(False, _
         "WaitDialog�N���X��ShowDialog���\�b�h�𗘗p�ł��܂���B" + vbCrLf + _
         "Show���\�b�h���g���ă��[�h���X�E�_�C�A���O���\�z���Ă��������B")
        Return DialogResult.Abort
    End Function
#End Region

#Region "Close���\�b�h�̃V���h�E"
    ''' <summary>Close���\�b�h�̃V���h�E</summary>
    ''' <remarks></remarks>
    Public Shadows Sub Close()

        '' �o�b�N�O���E���h���s���Ȃ�A�o�b�N�O���E���h�������~
        If m_Background.IsBusy Then m_Background.CancelAsync()

        If Me.bShowing Then Me.bShowing = False : MyBase.Close()

        Me.fmParent.Enabled = True
        Me.fmParent.Activate()

        '' �����v����
        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub
#End Region

#Region "X �L�����Z������ / �g�p�s��"
    'Private bCancel As Boolean = False   ' ���~�t���O

    '''' <summary>�L�����Z���E�{�^���������ꂽ�Ƃ��̏���</summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks>������r���ŃL�����Z���i���f�j����B</remarks>
    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ' ���~����
    '    Cancel()
    'End Sub

    '''' <summary>���~�i�L�����Z���j����</summary>
    '''' <remarks></remarks>
    'Private Sub Cancel()
    '    Me.bCancel = True
    '    Me.DialogResult = DialogResult.Abort
    'End Sub

    '''' <summary>�������L�����Z���i���~�j����Ă��邩�ǂ����������l���擾����B</summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks>�L�����Z�����ꂽ�ꍇ��true�B����ȊO��false�B</remarks>
    'Public ReadOnly Property IsCancel() As Boolean
    '    Get
    '        Return Me.bCancel
    '    End Get
    'End Property
#End Region

#Region "�C�x���g�FMyBase_Closing / �_�C�A���O��������Ƃ��̏���"
    ''' <summary>�_�C�A���O��������Ƃ��̏���</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>�E��́m����n�{�^���������ꂽ�ꍇ�ɂ́A����C�x���g�𖳌��ɂ���B</remarks>
    Private Sub MyBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bShowing = True Then
            ' �܂��_�C�A���O�͕��Ȃ�
            e.Cancel = True
        Else
            ' �t�H�[���͕�����Ƃ���̂őf���ɕ���
            e.Cancel = False
        End If
    End Sub
#End Region

#Region "�v���p�e�B�FMsg1 / �P�Ԗڂ̃��b�Z�[�W"
    ''' <summary>���C���E���b�Z�[�W�̃e�L�X�g��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>�����̊T�v��\������B</item>
    ''' <item>�Ⴆ�΁A�t�@�C���̓]�����s���Ă���Ȃ�A�u�t�@�C����]�����Ă��܂��c�c�v�̂悤�ɕ\������B</item>
    ''' </remarks>
    Public Property Msg1() As String
        Get
            Return Me.lblMsg1.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMsg1.Text = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FMsg2 / �Q�Ԗڂ̃��b�Z�[�W"
    ''' <summary>�T�u�E���b�Z�[�W�̃e�L�X�g��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>�ڍׂȏ������e��\������B</item>
    ''' <item>�Ⴆ�΁A�t�@�C���]���Ȃ�A�]�����̌ʂ̃t�@�C�����i�ureadme.htm�v�ucontents.htm�v�Ȃǁj��\������B</item>
    ''' </remarks>
    Public Property Msg2() As String
        Get
            Return Me.lblMsg2.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMsg2.Text = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FMsg3 / �R�Ԗڂ̃��b�Z�[�W"
    ' �����̐i�s�󋵂Ƃ��āA�u�������̉������I������̂��v�u�S�̂̉������I������̂��v�Ȃǂ�\������B
    ''' <summary>�i�s�󋵃��b�Z�[�W�̃e�L�X�g��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>�����̐i�s�󋵂Ƃ��āA�u�������̉������I������̂��v�u�S�̂̉������I������̂��v�Ȃǂ�\������B</item>
    ''' </remarks>
    Public Property Msg3() As String
        Get
            Return Me.lblMsg3.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMsg3.Text = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FBarVal / �i�s�o�[�̌��݈ʒu��ݒ肷��B"
    ''' <summary>�i�s�o�[�̌��݈ʒu��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>�Ⴆ�΁A������200�̍H�����������ꍇ�A���݂���200�̍H���̒��̂ǂ̈ʒu�ɂ��邩�������l�B</item>
    ''' <item> ����l�́u0�v�B</item>
    ''' </remarks>
    Public Property BarVal() As Integer
        Get
            Return Me.prgBar.Value
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Value = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FBarMax / �i�s�o�[�͈̔͂̍ő�l��ݒ肷��B"
    ''' <summary>�i�s�o�[�͈̔͂̍ő�l��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>������200�̍H��������Ȃ�u200�v�ɂȂ�B</item>
    ''' <item>����l�́u100�v�B</item>
    ''' </remarks>
    Public Property BarMax() As Integer
        Get
            Return Me.prgBar.Maximum
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Maximum = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FBarMin / �i�s�o�[�͈̔͂̍ŏ��l��ݒ肷��B"
    ''' <summary>�i�s�o�[�͈̔͂̍ŏ��l��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>����l�́u0�v�B</item>
    ''' </remarks>
    Public Property BarMin() As Integer
        Get
            Return Me.prgBar.Minimum
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Minimum = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FBarStep / �i�s�o�[�̌��݈ʒu�iBarVal�j��i�߂�ʂ�ݒ肷��B"
    ''' <summary>PerformStep���\�b�h���Ăяo�����Ƃ��ɁA�i�s�o�[�̌��݈ʒu��i�߂�ʁiBarVal�̑����l�j��ݒ肷��B</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>�����H����200�ŁA5�̍H�����I������i�K�Ői�s�o�[���X�V�������ꍇ�́u5�v�ɂ���B</item>
    ''' <item>����l�́u10�v�B</item>
    ''' </remarks>
    Public Property BarStep() As Integer
        Get
            Return Me.prgBar.Step
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Step = Value
        End Set
    End Property
#End Region

#Region "�v���p�e�B�FPerformStep / �i�s�o�[�̌��݈ʒu�iBarVal�j��BarStep�v���p�e�B�̗ʂ����i�߂�B"
    ''' <summary>�i�s�o�[�̌��݈ʒu�iBarVal�j��BarStep�v���p�e�B�̗ʂ����i�߂�B</summary>
    ''' <remarks></remarks>
    Public Sub PerformStep()
        Me.prgBar.PerformStep()
    End Sub
#End Region

#Region "�v���p�e�B�FInit / �i�s�󋵂�����������B"
    ''' <summary>�i�s�󋵂�����������B</summary>
    ''' <param name="vMsg1">�P�Ԗڂ̃��b�Z�[�W ���ȗ����͋󕶎����Z�b�g</param>
    ''' <param name="vMsg2">�Q�Ԗڂ̃��b�Z�[�W ���ȗ����͋󕶎����Z�b�g</param>
    ''' <param name="vMsg3">�R�Ԗڂ̃��b�Z�[�W ���ȗ����͋󕶎����Z�b�g</param>
    ''' <param name="vBarMax">�i���o�[�ő�l</param>
    ''' <remarks>�����i�����s���Ȃ玩���i���I�����s���܂��B</remarks>
    Public Sub Init( _
        Optional ByVal vMsg1 As String = Nothing, _
        Optional ByVal vMsg2 As String = Nothing, _
        Optional ByVal vMsg3 As String = Nothing, _
        Optional ByVal vBarMax As Integer = 100 _
    )
        Call AutoOff()  '' �����i���I��
        If vMsg1 Is Nothing Then vMsg1 = ""
        If vMsg2 Is Nothing Then vMsg2 = ""
        If vMsg3 Is Nothing Then vMsg3 = ""
        Me.Msg1 = vMsg1
        Me.Msg2 = vMsg2
        Me.Msg3 = vMsg3
        Me.BarMax = vBarMax
        Me.BarStep = 1
        Me.BarVal = 0
        Me.Activate()
        System.Windows.Forms.Application.DoEvents()
    End Sub
#End Region

#Region "�v���p�e�B�FSet / �i�s�󋵂�ݒ肷��B"
    ''' <summary>�i�s�󋵂�ݒ肷��B</summary>
    ''' <param name="vBarVal">�i���o�[���݈ʒu</param>
    ''' <param name="vMsg1">�P�Ԗڂ̃��b�Z�[�W ���ȗ����͂��̂܂�</param>
    ''' <param name="vMsg2">�Q�Ԗڂ̃��b�Z�[�W ���ȗ����͂��̂܂�</param>
    ''' <param name="vMsg3">�R�Ԗڂ̃��b�Z�[�W ���ȗ����͂��̂܂�</param>
    ''' <remarks></remarks>
    Public Sub [Set]( _
        ByVal vBarVal As Integer, _
        Optional ByVal vMsg1 As String = Nothing, _
        Optional ByVal vMsg2 As String = Nothing, _
        Optional ByVal vMsg3 As String = Nothing _
    )
        If Not vMsg1 Is Nothing Then Me.Msg1 = vMsg1
        If Not vMsg2 Is Nothing Then Me.Msg2 = vMsg2
        If Not vMsg3 Is Nothing Then Me.Msg3 = vMsg3
        Me.BarVal = vBarVal
        Me.Activate()
        System.Windows.Forms.Application.DoEvents()
    End Sub
#End Region

#Region "Private �v���p�e�B�FgetMsg / �i�s���b�Z�[�W��Ԃ��B"
    Private Function getMsg(ByVal vMsg As enmMsg2) As String
        Dim sMsg As String = "�������c"
        Select Case vMsg
            Case enmMsg2.GetData : sMsg = "�f�[�^�擾���c"
            Case enmMsg2.GotData : sMsg = "�f�[�^�擾�I��"
        End Select
        Return sMsg
    End Function
#End Region

#Region "�v���p�e�B�FAutoOn / �����i���i�o�b�N�O���E���h�j�J�n"
    Public Sub AutoOn(ByVal vMsg2 As String)
        Me.Msg2 = vMsg2
        Me.BarVal = Me.BarMin
        Me.Activate()
        If Not m_Background.IsBusy Then m_Background.RunWorkerAsync(100) '' �o�b�N�O���E���h�������J�n����B
    End Sub
    Public Sub AutoOn(ByVal vMsg2 As enmMsg2)
        Dim sMsg As String = getMsg(vMsg2)
        Call AutoOn(sMsg)
    End Sub
#End Region

#Region "�v���p�e�B�FAutoOff / �����i���i�o�b�N�O���E���h�j�I��"
    Public Sub AutoOff(Optional ByVal vMsg2 As String = Nothing)
        If m_Background.IsBusy Then m_Background.CancelAsync() '' �o�b�N�O���E���h�������I������B
        If vMsg2 Is Nothing Then vMsg2 = ""
        Me.Msg2 = vMsg2
        Me.Activate()
    End Sub
    Public Sub AutoOff(ByVal vMsg2 As enmMsg2)
        Dim sMsg As String = getMsg(vMsg2)
        Call AutoOff(sMsg)
    End Sub
#End Region

#Region "�C�x���g�Fm_Background_DoWork / �o�b�N�O���E���h�̃��[�N�����B"
    Private Sub m_Background_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_Background.DoWork
        ' ���̃��\�b�h�ւ̃p�����[�^
        Dim iArg As Integer = CType(e.Argument, Integer)

        ' ���Ԃ̂����鏈��
        For i As Integer = 1 To iArg

            ' �L�����Z������ĂȂ�������I�Ƀ`�F�b�N
            If m_Background.CancellationPending Then
                e.Cancel = True
                Return
            End If

            System.Threading.Thread.Sleep(100)

            Dim percentage As Integer = CInt(i * 100 / iArg) ' �i���傭��
            If percentage < Me.BarMin Then percentage = Me.BarMin
            If Me.BarMax < percentage Then percentage = Me.BarMax
            m_Background.ReportProgress(percentage)
            ' ProgressChanged�C�x���g����
        Next

        ' ���̃��\�b�h����̖߂�l
        e.Result = "���ׂĊ���"

        ' ���̌�Am_Background_RunWorkerCompleted�C�x���g������
    End Sub
#End Region

#Region "�C�x���g�Fm_Background_ProgressChanged / �i�s�󋵂����|�[�g���邽�߁A�����Z�b�V�������ɒ���I�ɔ������܂��B"
    Private Sub m_Background_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles m_Background.ProgressChanged
        Try
            Me.prgBar.Value = e.ProgressPercentage
        Catch ex As Exception
            '' �������Ȃ�
        End Try
    End Sub
#End Region

#Region "�C�x���g�Fm_Background_RunWorkerCompleted / �o�b�N�O���E���h����̊������A�L�����Z�����A�܂��̓o�b�N�O���E���h����ɂ���ė�O�����������Ƃ��ɔ������܂��B"
    Private Sub m_Background_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles m_Background.RunWorkerCompleted
        Me.Activate()
    End Sub
#End Region

End Class