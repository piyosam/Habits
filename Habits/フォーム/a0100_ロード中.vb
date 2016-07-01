'�V�X�e���� �F HABITS
'�@�\���@�@ �F a0100_���[�h��
'�T�v�@�@�@ �F �������[�h����
'�����@�@�@ �F 2010/04/26�@�r�v�i�@�쐬
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports System.Text

Public Class a0100_���[�h��

#Region "�ϐ��E�萔��`"

    Private bChecked As Boolean = False         ' �}�X�^�f�[�^�`�F�b�N�σt���O
    Private logic As Habits.Logic.a0100_Logic

    Private logic_base As Habits.Logic.LogicBase
#End Region

#Region "�C�x���g"

#Region "�y�[�W���[�h����"
    ''' <summary>���[�h������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0100_���[�h��_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '��ʃC���[�W��\�������邽�߁ATimer�ɂď������s���B

        ' �V�X�e��Ver���擾���T�[�o�ɓo�^����B
        logic_base = New Habits.Logic.LogicBase
        logic_base.SystemVerForSever(My.Application.Info.Version.ToString())

    End Sub
#End Region

#Region "�t�H�[���N���[�Y�㏈��"
    ''' <summary>�t�H�[��������ꂽ�㏈��</summary>
    ''' <remarks></remarks>
    Private Sub a0100_���[�h��_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "�^�C�}�[����"
    ''' <summary>�^�C�}�[����</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadTimer.Tick
        If (bChecked = False) Then
            ' �}�X�^�_�E�����[�h�`�F�b�N
            checkMasterDownload()
            Me.Close()
        End If
    End Sub
#End Region

#End Region

#Region "���\�b�h"

#Region "�}�X�^�_�E�����[�h�`�F�b�N"
    ''' <summary>�}�X�^�_�E�����[�h�`�F�b�N</summary>
    ''' <remarks></remarks>
    Protected Sub checkMasterDownload()
        logic = New Habits.Logic.a0100_Logic
        Me.Activate()

        '�`�F�b�N�ςɕύX
        bChecked = True
        Try
            '�iWeb�V�X�e���j�}�X�^�X�V�f�[�^�L���`�F�b�N
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MasterUpdateCheck.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollection�̍쐬
            Dim ps As New System.Collections.Specialized.NameValueCollection
            Dim sUdDate As String
            Dim dt As New DataTable

            ' �ŏI�_�E�����[�h���Ԏ擾
            dt = logic.selectDownloadDate()
            sUdDate = dt.Rows(0)("�ŏI�_�E�����[�h").ToString()

            '���M����f�[�^�i�t�B�[���h���ƒl�̑g�ݍ��킹�j��ǉ�
            ps.Add("q1", My.Settings.LoginName)
            ps.Add("q2", My.Settings.LoginPassword)
            ps.Add("q3", sShopcode)
            ps.Add("q4", sUdDate)
            wc.QueryString = ps

            '�f�[�^�𑗐M���A�܂���M����
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then
                '���펞
                rtn = MsgBox("�}�X�^�f�[�^���X�V����Ă��܂��B�@" & Chr(13) & Chr(13) & _
                "�f�[�^��M���s���Ă��������B�@", Clng_Okinb1, TTL)

            ElseIf result.ToString.StartsWith("-2") = True Then
                '�X�V�K�v�������ꍇ���b�Z�[�W�Ȃ�
            Else
                'Web���ŔF�؂Ɏ��s�����ꍇ
                rtn = MsgBox("�F�؃G���[���������܂����B�@" & Chr(13) & Chr(13) & _
                "�V�X�e���Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
            End If

        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�ڑ��G���[���������܂����B�@" & Chr(13) & Chr(13) & _
                    "�C���^�[�l�b�g�ւ̐ڑ����m�F���Ă��������B�@", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#End Region

End Class
