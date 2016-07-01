'�V�X�e���� �F HABITS
'�@�\���@�@ �F a0200_���C��
'�T�v�@�@�@ �F ���C����ʕ\���@�\
'�����@�@�@ �F 2010/04/26�@�r�v�i�@�쐬
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports System.Text

Public Class a0200_���C��

#Region "�ϐ��E�萔��`"

    Dim downloadClient As System.Net.WebClient = Nothing
    Private logic As Habits.Logic.a0200_Logic
    Private a0100_logic As Habits.Logic.a0100_Logic     '�f�[�^�C�������ǉ����Ɏg�p
    Private SwitchData_logic As Habits.Logic.SwitchData '�f�[�^�C�������ǉ����Ɏg�p
    Private bReserve As Boolean = False
    Private bMaster As Boolean = False
    Private str_path As String = Nothing
    Private upTime As String = Nothing
    Private Const PAGE_TITLE As String = "a0200_���C��"

#End Region

#Region "�C�x���g"

#Region "�y�[�W���[�h����"
    ''' <summary>���[�h������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0200_���C��_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As DataTable
        logic = New Habits.Logic.a0200_Logic
        a0100_logic = New Habits.Logic.a0100_Logic
        SwitchData_logic = New Habits.Logic.SwitchData
        Me.Activate()

        Try
            TimerDataSync.Enabled = False
            M01 = Me

            '' �V�X�e���J�n����
            rtn = Sys_Init()

            '' �v�Z�^�C�v�擾
            setTaxType()
            setServiceType()

            ' �_�E�����[�h�i�[�p�X�ݒ�
            Me.str_path = logic.getStockPath()

            '----------------�f�[�^�C�����Ɏg�p------------------
            ''20131113
            'a0100_logic.updateKurihama()

            '�����ύX�s��
            'If sShopcode = "kawasaki" Then
            '    SwitchData_logic.switchNGPast()
            'End If

            '�����ύX��
            'If sShopcode = "ebina" Then
            'SwitchData_logic.switchNGPast()
            'End If

            '�|�C���g�C��
            'SwitchData_logic.upPoint()
            ''A_�V�X�e���ϐ��ݒ�
            'SwitchData_logic.setA_SystemVariable()
            '----------------�f�[�^�C�����Ɏg�p------------------

            '' �\��f�[�^��M
            receiveReserve(0)

            '' �@�\�̎g�p�����ݒ�
            setAdminMenu()                  ' �Ǘ��ҋ@�\
            setReserveMenu()                ' �\��@�\
            setReceiptMenu()                ' ���V�[�g����@�\

            '' �^�C�g���o�[�̕����ݒ�
            setTitleBar()

            Me.lbl_Connect.Visible = False
            If (setTransmitMenu()) Then
                TimerDataSync.Enabled = True

                If NETWORK_FLAG = True Then
                    dt = logic.GetConnectError()
                    If (dt.Rows.Count > 0 AndAlso Integer.Parse(dt.Rows(0)("�ʐM���G���[��").ToString) >= CONNECT_ERROR) Then
                        Me.lbl_Connect.Visible = True
                    End If
                End If
            End If

            '' ��ʍĕ\��
            ReDisplay()
            FreeCursor()
            Me.ActiveControl = Me.btn���X   ' �u���X�v�{�^���Ƀt�H�[�J�X            
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            Me.Close()
        End Try
    End Sub
#End Region

#Region "�t�H�[���N���[�Y�㏈��"
    ''' <summary>�t�H�[��������ꂽ�㏈��</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0200_���C��_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Sys_Exit()
    End Sub
#End Region

#Region "���X�҃^�u�N���b�N����"
    ''' <summary>
    ''' ���X�҃^�u�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tp���X��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp���X��.Click
        setFocus()
    End Sub
#End Region

#Region "��v�σ^�u�N���b�N����"
    ''' <summary>
    ''' ��v�σ^�u�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tp��v��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp��v��.Click
        setFocus()
    End Sub
#End Region

#Region "�\��^�u�N���b�N����"
    ''' <summary>
    ''' �\��^�u�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tp�\��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp�\��.Click
        setFocus()
    End Sub
#End Region

#Region "�ڋq���^�u�N���b�N����"
    ''' <summary>
    ''' �ڋq���^�u�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc�ڍ׏��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc�ڍ׏��.Click
        setFocus()
    End Sub
#End Region

#Region "���X���̃^�u�I������"
    ''' <summary>
    ''' ���X���^�u��ύX�����ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc���X���_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc���X���.SelectedIndexChanged
        ' �R���g���[��������
        FreeCursor()
    End Sub
#End Region

#Region "�ڍ׏��̃^�u�I������"
    ''' <summary>
    ''' �ڍ׏��^�u��ύX�����ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc�ڍ׏��_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc�ڍ׏��.SelectedIndexChanged
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "�ڋq���̃^�u�I������"
    ''' <summary>
    ''' �ڋq���^�u��ύX�����ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc�ڋq�ڍ�_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc�ڋq�ڍ�.SelectedIndexChanged
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "���X�҈ꗗ�N���b�N����"
    ''' <summary>
    ''' ���X�҈ꗗ�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv���X�҈ꗗ_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv���X�҈ꗗ.CellClick
        Me.btn�J���e.Enabled = True
        Me.btn�ύX.Enabled = True
        Me.btn�҂�.Enabled = True
        If (dgv���X�҈ꗗ.SelectedRows(0).Cells(9).Value.ToString().Equals("�҂�")) Then
            btn�҂�.Text = "�{�p�J�n"
        Else
            btn�҂�.Text = "�{�p�҂�"
        End If

        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "��v�ψꗗ�N���b�N����"
    ''' <summary>
    ''' ��v�ψꗗ�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv��v�ς݈ꗗ_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv��v�ς݈ꗗ.CellClick
        Me.btn�J���e.Enabled = True
        Me.btn�ύX.Enabled = True
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "�\��ꗗ�N���b�N����"
    ''' <summary>
    ''' �\��ꗗ�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv�\��ꗗ_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv�\��ꗗ.CellClick
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "�ߋ����X���ꗗ�N���b�N����"
    ''' <summary>
    ''' �ߋ����X���ꗗ�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv�ߋ����X���ꗗ_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv�ߋ����X���ꗗ.CellClick
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "����ꗗ�N���b�N����"
    ''' <summary>
    ''' ����ꗗ�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv����ꗗ_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv����ꗗ.CellClick
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "�J���e�ꗗ�N���b�N����"
    ''' <summary>
    ''' �J���e�ꗗ�̂ǂ�����Click���ꂽ�ꍇ�̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv�J���e�ꗗ_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv�J���e�ꗗ.CellClick
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#End Region

#Region "�{�^�������C�x���g"

#Region "���b�Z�[�W�o�^�{�^������"
    ''' <summary>���b�Z�[�W�o�^�{�^���N���b�N������</summary>
    ''' <remarks></remarks>
    Private Sub BtnMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMessage.Click
        i0100_���b�Z�[�W�o�^.ShowDialog()
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "�ݒ���{�^������"
    ''' <summary>�ݒ���{�^���N���b�N������</summary>
    ''' <remarks></remarks>
    Private Sub Btn�ݒ��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn�ݒ��.Click
        a0700_���t�ݒ�.ShowDialog()
        ReDisplay()
        FreeCursor()
    End Sub
#End Region

#Region "�X�^�b�t�I���{�^������"
    ''' <summary>
    ''' �X�^�b�t�I���{�^���N���b�N���̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn�X�^�b�t�I��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn�X�^�b�t�I��.Click
        a0800_�X�^�b�t�I��.int_mode = 1
        a0800_�X�^�b�t�I��.ShowDialog()
        Me.ActiveControl = Me.btn���X   ' �u���X�v�{�^���Ƀt�H�[�J�X
        Me.Activate()
    End Sub
#End Region

#Region "�ڋq�����{�^������"
    ''' <summary>
    ''' �ڋq�����{�^���N���b�N���̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn�ڋq����.Click
        z_0300_�ڋq����.����loaded = False
        z_0300_�ڋq����.ShowDialog()
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "���X�ҁE���X�{�^������"
    ''' <summary>���X�{�^���N���b�N������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn���X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn���X.Click
        a0300_���X.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "���X�ҁE��v�{�^������"
    ''' <summary>���X�ҁE��v�{�^���N���b�N���̏���</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn����.Click
        If Not isVisitorSelection() Then Exit Sub

        ReCheckFlag = False         '�ĉ�v�`�F�b�N�t���O�F�ʏ��v
        c0100_����.ShowDialog()
        ReDisplay()
        FreeCursor()
        Me.Activate()
    End Sub
#End Region

#Region "���X�ҁE����{�^������"
    ''' <summary>���X�ҁE����{�^���N���b�N���̏���</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn���_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn���.Click
        Dim i As Integer = 0
        Dim int_number As Integer = 0   ' ���X��
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        If Not isVisitorSelection() Then Exit Sub

        If (MsgBox(Me.lbl��.Text & " �l�̗��X���������܂����H�@", Clng_Ynqub1, TTL) = vbNo) Then
            Me.btn���X.Focus()
            Exit Sub
        End If

        Try
            ' �g�����U�N�V�����J�n
            DBA.TransactionStart()

            Dim EUM As New DataTable     ' E_���㖾��
            Dim EKA As New DataTable     ' E_�J���e

            'E_���㖾�׍폜
            param.Clear()
            param.Add("@���X��", USER_DATE)
            param.Add("@���X�Ҕԍ�", SER_NO)
            param.Add("@�ڋq�ԍ�", CST_CODE)
            logic.E_���㖾�׍폜(param)

            'E_�J���e�폜
            logic.delete_carte(param, PAGE_TITLE)

            'E_���X�ҍX�V
            logic.DeleteVisitor(param)

            'D_�ڋq�e�[�u���X�V
            dt = logic.select_number(param)
            If dt.Rows.Count <> 0 Then
                int_number = Integer.Parse(dt.Rows(0)("���X��").ToString) - 1
            End If

            param.Clear()
            param.Add("@���X��", int_number)
            param.Add("@�X�V��", Now)
            param.Add("@�ڋq�ԍ�", CST_CODE)
            logic.DeleteCustomer(param)

            ' �R�~�b�g
            DBA.TransactionCommit()
        Catch ex As Exception
            ' ���[���o�b�N
            DBA.TransactionRollBack()
            Throw ex
        End Try
        '' ��ʍĕ\��
        ReDisplay()
        FreeCursor()
    End Sub
#End Region

#Region "��v�ρE���ԁA�H���{�^������"
    ''' <summary>��v�ρE���ԁA�H���{�^���N���b�N��</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn��Ǝ���_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn��Ǝ���.Click

        If Me.dgv��v�ς݈ꗗ.SelectedRows.Count <> 0 Then
            a1500_��Ǝ��Ԑݒ�.�ڋq�ԍ�.Text = Me.dgv��v�ς݈ꗗ.CurrentRow.Cells(2).Value.ToString
            a1500_��Ǝ��Ԑݒ�.���t.Text = USER_DATE.ToString("yyyy/MM/dd(ddd\)")
            a1500_��Ǝ��Ԑݒ�.���X�Ҕԍ�.Text = Me.dgv��v�ς݈ꗗ.CurrentRow.Cells(1).Value.ToString
            a1500_��Ǝ��Ԑݒ�.�ڋq��.Text = Me.dgv��v�ς݈ꗗ.CurrentRow.Cells(3).Value.ToString
            a1500_��Ǝ��Ԑݒ�.���X��.Text = Me.dgv��v�ς݈ꗗ.CurrentRow.Cells(0).Value.ToString
            a1500_��Ǝ��Ԑݒ�.��S���Җ�.Text = Me.dgv��v�ς݈ꗗ.CurrentRow.Cells(8).Value.ToString

            a1500_��Ǝ��Ԑݒ�.ShowDialog()
            Me.btn��v�ҏW.Focus()
        Else
            MsgBox("��v�ςݗ��X�҂�I�����Ă��������B�@", Clng_Okexb1, TTL)
            Me.btn��Ǝ���.Focus()
        End If
        Me.Activate()
    End Sub
#End Region

#Region "��v�ρE��v�{�^������"
    ''' <summary>��v�ρE��v�{�^���N���b�N���̏���</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn��v�ҏW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn��v�ҏW.Click
        '---------------�����܂ɃZ���N���b�N�C�x���g���������Ă��ڋq�ԍ��A���X�Ҕԍ����擾�ł��Ȃ��Ƃ�������̂ŕی��Œǉ����܂���--------------
        If CST_CODE = 0 Or SER_NO = 0 Then
            rtn = MsgBox("������x���X�҂�I�����Ă��������B�@", Clng_Okexb1, TTL)
            Exit Sub
        End If
        '---------------������------------------------------------------------------------------------------------------------------------------
        If Not isBilledSelection() Then Exit Sub
        ReCheckFlag = True         '�ĉ�v�`�F�b�N�t���O�F�ĉ�v
        c0100_����.ShowDialog()
        ReDisplay()
        FreeCursor()
        Me.Activate()
    End Sub
#End Region

#Region "�\��ҁE���X�{�^������"
    ''' <summary>
    ''' �\��ҁE���X�{�^����������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn�\��җ��X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�\��җ��X.Click
        If Me.dgv�\��ꗗ.SelectedRows.Count <> 0 Then
            a0300_���X.reserve_number = Me.dgv�\��ꗗ.CurrentRow.Cells(4).Value.ToString

            a0300_���X.reserve_mode = True
            a0300_���X.ShowDialog()
            Me.Activate()
        Else
            MsgBox("�\��ꗗ����\��҂�I�����Ă��������B�@", Clng_Okexb1, TTL)
        End If
    End Sub
#End Region

#Region "�\��ҁE�f�[�^��M�{�^������"
    ''' <summary>
    ''' �\��ҁE�f�[�^��M�{�^���N���b�N���̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub �\���M_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �\���M.Click
        receiveReserve(0)
        '' ��ʍĕ\��
        ReDisplay()
        FreeCursor()
    End Sub
#End Region

#Region "�J���e�E�J���e���̓{�^������"
    ''' <summary>�J���e�E�J���e���̓{�^���N���b�N���̏���</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn�J���e_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�J���e.Click
        If Me.dgv���X�҈ꗗ.SelectedRows.Count = 0 Then
            If Me.dgv��v�ς݈ꗗ.SelectedRows.Count = 0 Then
                Exit Sub
            Else
                a1300_�J���e.�S���Җ�.Text = Me.dgv��v�ς݈ꗗ.CurrentRow.Cells("�S��").Value.ToString
            End If
        Else
            a1300_�J���e.�S���Җ�.Text = Me.dgv���X�҈ꗗ.CurrentRow.Cells("�S��").Value.ToString
        End If
        a1300_�J���e.ShowDialog()

        SetDetailInfo()
        setFocus()
    End Sub
#End Region

#Region "�ڋq���E�ύX�{�^������"
    ''' <summary>
    ''' �ڋq���E�ύX�{�^���N���b�N���̏���
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCustomerInfoChenge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�ύX.Click
        Dim type As Integer = 0
        Dim count As Integer = 0

        z_0500_�ڋq�ύX.button_mode = False ''�ڋq���ύX�{�^���������͌ڋq�ύX��ʂ̌����{�^���͕\�������Ȃ�
        If Me.dgv���X�҈ꗗ.SelectedRows.Count = 0 Then
            If Me.dgv��v�ς݈ꗗ.SelectedRows.Count = 0 Then
                Exit Sub
            Else
                type = 2
                count = Me.dgv��v�ς݈ꗗ.SelectedRows(0).Index
            End If
        Else
            type = 1
            count = Me.dgv���X�҈ꗗ.SelectedRows(0).Index
        End If

        z_0500_�ڋq�ύX.���X��.Text = ""    ' men_���X�ғo�^�ȊO�͐ݒ�s�v
        z_0500_�ڋq�ύX.���X�Ҕԍ�.Text = ""

        Dim dt As New DataTable

        '�ڋq�ԍ��ɊY������ڋq�������ꍇ�ɏ���
        If Not Me.lbl�ڋq�ԍ�.Text.Equals("") Then
            z_0500_�ڋq�ύX.lbl�ڋq�ԍ�.Text = Me.lbl�ڋq�ԍ�.Text
            z_0500_�ڋq�ύX.�ύX.Enabled = True
            z_0500_�ڋq�ύX.�폜.Enabled = True

            z_0500_�ڋq�ύX.��.Focus()
            z_0500_�ڋq�ύX.ShowDialog()

            If type = 1 Then
                Me.dgv���X�҈ꗗ.Rows(count).Selected = True
            ElseIf type = 2 Then
                Me.dgv��v�ς݈ꗗ.Rows(count).Selected = True
            End If

            SetDetailInfo()
        End If
        dt.Dispose()
        Me.ActiveControl = Me.btn���X   ' �u���X�v�{�^���Ƀt�H�[�J�X
        Me.Activate()
    End Sub

#Region "���X�҈ꗗ�I������"
    ''' <summary>
    ''' ���X�҈ꗗ�I������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv���X�҈ꗗ_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv���X�҈ꗗ.SelectionChanged
        Dim dt As New DataTable

        If Me.dgv���X�҈ꗗ.SelectedRows.Count <> 0 Then
            '' ���X�Ҕԍ����擾
            SER_NO = Integer.Parse(Me.dgv���X�҈ꗗ.SelectedRows(0).Cells(1).Value.ToString)

            '' �ڋq�ԍ���ݒ�
            CST_CODE = Integer.Parse(Me.dgv���X�҈ꗗ.SelectedRows(0).Cells(2).Value.ToString)

            '' �ڍ׏��ݒ�
            SetDetailInfo()

            '' ��v�ς݈ꗗ�I������
            Me.dgv��v�ς݈ꗗ.ClearSelection()

            If Me.dgv���X�҈ꗗ.SelectedRows(0).Cells(12).Value.ToString = "��" Then
                Me.tc�ڍ׏��.SelectedIndex = 1
                Me.tc�ڋq�ڍ�.SelectedIndex = 2
            End If
        End If
        ' �t�H�[�J�X�ݒ�
        setFocus()
    End Sub
#End Region

#Region "��v�ψꗗ�I������"
    ''' <summary>
    ''' ��v�ψꗗ�I������
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv��v�ς݈ꗗ_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv��v�ς݈ꗗ.SelectionChanged
        Dim dt As New DataTable

        If Me.dgv��v�ς݈ꗗ.SelectedRows.Count <> 0 Then
            '' ���X�Ҕԍ����擾
            SER_NO = Integer.Parse(Me.dgv��v�ς݈ꗗ.SelectedRows(0).Cells(1).Value.ToString)

            '' �ڋq�ԍ���ݒ�
            CST_CODE = Long.Parse(Me.dgv��v�ς݈ꗗ.SelectedRows(0).Cells(2).Value.ToString)

            '' �ڍ׏��ݒ�
            SetDetailInfo()

            '' ���X�҈ꗗ�I������
            Me.dgv���X�҈ꗗ.ClearSelection()
        End If
    End Sub
#End Region

#Region "�J���e�E�ߋ����X���ꗗ�I��"
    ''' <summary>�J���e���-�ߋ����X���ꗗ �I��ύX</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv�ߋ����X���ꗗ_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv�ߋ����X���ꗗ.SelectionChanged
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        If Me.dgv�ߋ����X���ꗗ.SelectedRows.Count <> 0 Then
            '' �p�����[�^�ݒ�i@���X��/@���X�Ҕԍ�/@�ڋq�ԍ��j
            param.Add("@���X��", Me.dgv�ߋ����X���ꗗ.SelectedRows(0).Cells(0).Value)
            param.Add("@���X�Ҕԍ�", Me.dgv�ߋ����X���ꗗ.SelectedRows(0).Cells(1).Value)
            param.Add("@�ڋq�ԍ�", Me.dgv�ߋ����X���ꗗ.SelectedRows(0).Cells(2).Value)
            '' �f�[�^�擾
            dt = logic.ClinicalRecordSales(param)
            Me.dgv����ꗗ.DataSource = dt
            Me.dgv����ꗗ.Columns(0).Width = 52     ' ����敪 
            Me.dgv����ꗗ.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.dgv����ꗗ.Columns(1).Width = 150    ' ���i
            Me.dgv����ꗗ.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.dgv����ꗗ.Columns(2).Width = 30     ' ����
            Me.dgv����ꗗ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv����ꗗ.Columns(3).Width = 55     ' ���z
            Me.dgv����ꗗ.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv����ꗗ.Columns(4).Width = 55     ' �T�[�r�X
            Me.dgv����ꗗ.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv����ꗗ.Columns(5).Visible = False ' ����敪�ԍ�
            Me.dgv����ꗗ.ClearSelection()
        Else
            '' �I���s���Ȃ��ꍇ�̓f�[�^�N���A
            Me.dgv����ꗗ.DataSource = Nothing
        End If
    End Sub
#End Region

#End Region

#Region "���X�ҁE�҂��{�^������"
    ''' <summary>�҂��{�^���N���b�N������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn�҂�_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn�҂�.Click

    End Sub
#End Region

#End Region

#Region "���j���[�o�[�C�x���g"


#Region "���[�U"
    ''' <summary>[���j���[�o�[]-[�V�X�e��]-[�Ǘ�]-[���[�U]</summary>
    ''' <remarks></remarks>
    Private Sub ���[�UToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���[�UToolStripMenuItem.Click
        a1000_���[�U�[���.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�ڕW�z"
    ''' <summary>[���j���[�o�[]-[�V�X�e��]-[�Ǘ�]-[�ڕW�z]</summary>
    ''' <remarks></remarks>
    Private Sub �ڕW�zToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles �ڕW�zToolStripMenuItem.Click
        a1100_�ڕW�z.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�݌ɊǗ�"
    ''' <summary>[���j���[�o�[]-[�V�X�e��]-[�Ǘ�]-[�݌ɊǗ�]</summary>
    ''' <remarks></remarks>
    Private Sub �݌ɊǗ�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �݌ɊǗ�ToolStripMenuItem.Click
        a1400_���o�ɓo�^.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "����"
    ''' <summary>[���j���[�o�[]-[�V�X�e��]-[�Ǘ�]-[����]</summary>
    ''' <remarks></remarks>
    Private Sub ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ToolStripMenuItem.Click
        a1600_�������.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "���[�h�ύX"
    ''' <summary>���[�h�ύX�I��������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ���[�h�ύX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���[�h�ύXToolStripMenuItem.Click
        a2000_���[�h�ύX.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�p�X���[�h�ύX"
    ''' <summary>���[�h�ύX�I��������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub �p�X���[�h_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �p�X���[�h�ύXToolStripMenuItem.Click
        z0700_�p�X���[�h�ύX.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�V�X�e���I��"
    ''' <summary>�V�X�e���I���I��������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub �V�X�e���I��_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �V�X�e���I��ToolStripMenuItem.Click
        rtn = Men_�V�X�e���̏I��()
    End Sub
#End Region

#Region "�c�Ɠ�"
    ''' <summary>[���j���[�o�[]-[����Ɩ�]-[�c�Ɠ�]</summary>
    ''' <remarks></remarks>
    Private Sub �c�Ɠ�ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles �c�Ɠ�ToolStripMenuItem.Click
        d0200_�c�Ɠ�.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�����W�v"
    ''' <summary>[���j���[�o�[]-[����Ɩ�]-[�����W�v]</summary>
    ''' <remarks></remarks>
    Private Sub �����W�vToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles �����W�vToolStripMenuItem.Click
        d0300_�X�W�v.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�ύX�����o��"
    ''' <summary>[���j���[�o�[]-[����Ɩ�]-[�ύX�����o��]</summary>
    ''' <remarks></remarks>
    Private Sub �ύX�����o��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ύX�����o��ToolStripMenuItem.Click
        d0600_�������O�o��.ShowDialog()
        Me.Activate()
    End Sub
#End Region


#Region "�V�K�o�^"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[�ڋq]-[�V�K�o�^]</summary>
    ''' <remarks></remarks>
    Private Sub �V�K�o�^ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �V�K�o�^ToolStripMenuItem.Click
        f0100_�ڋq�o�^.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�ύX�E�폜"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[�ڋq]-[�ύX�E�폜]</summary>
    ''' <remarks></remarks>
    Private Sub �ύX�폜ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ύX�폜ToolStripMenuItem.Click
        z_0500_�ڋq�ύX.button_mode = True
        z_0500_�ڋq�ύX.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "����敪"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[���j���[]-[����敪]</summary>
    ''' <remarks></remarks>
    Private Sub ����敪ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����敪ToolStripMenuItem.Click
        f0500_����敪.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "����"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[���j���[]-[����]</summary>
    ''' <remarks></remarks>
    Private Sub ����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����ToolStripMenuItem.Click
        f0500_����.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "���i"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[���j���[]-[���i]</summary>
    ''' <remarks></remarks>
    Private Sub ���iToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���iToolStripMenuItem.Click
        f0500_���i.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�H��"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[���j���[]-[�H��]</summary>
    ''' <remarks></remarks>
    Private Sub �H��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �H��ToolStripMenuItem.Click
        f1100_�H���}�X�^.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�X�^�b�t"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[�X�^�b�t]</summary>
    ''' <remarks></remarks>
    Private Sub �X�^�b�tToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �X�^�b�tToolStripMenuItem.Click
        f0600_�X�^�b�t.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "���[�J�["
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[���[�J�[]</summary>
    ''' <remarks></remarks>
    Private Sub ���[�J�[ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���[�J�[ToolStripMenuItem.Click
        f0700_���[�J�[.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�J�[�h���"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[�J�[�h���]</summary>
    ''' <remarks></remarks>
    Private Sub �J�[�h���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �J�[�h���ToolStripMenuItem.Click
        f0800_�J�[�h���.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�T�[�r�X"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[�T�[�r�X]</summary>
    ''' <remarks></remarks>
    Private Sub �T�[�r�XToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles �T�[�r�XToolStripMenuItem.Click
        f0900_�T�[�r�X.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�|�C���g����"
    ''' <summary>[���j���[�o�[]-[�}�X�^]-[�|�C���g����]</summary>
    ''' <remarks></remarks>
    Private Sub �|�C���g����ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �|�C���g����ToolStripMenuItem.Click
        f1200_�|�C���g����.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�f�[�^��M"
    ''' <summary>[���j���[�o�[]-[�f�[�^����M]-[�f�[�^��M]</summary>
    ''' <remarks></remarks>
    Private Sub �f�[�^��MToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �f�[�^��MToolStripMenuItem.Click

        If NETWORK_FLAG = False Then
            rtn = MsgBox("�ʐM��������Ă��܂���B�@" & Chr(13) & Chr(13) & _
              "�ʐM�ݒ��ύX���Ă��������B�@", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If ACTIVE_NETWORK_FLAG = True Then
            rtn = MsgBox("���݃T�[�o�[�ƒʐM���ł��B�@" & Chr(13) & Chr(13) & _
                        "���΂炭���Ԃ������Ă���A�ēx���s���ĉ������B�@", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If (MsgBox("�f�[�^��M���J�n���܂��B�@" & Chr(13) & Chr(13) & "��낵���ł����H�@", Clng_Ynqub1, TTL) = vbYes) Then
            receiveData(0)
        End If

    End Sub
#End Region

#Region "�ʐM�ݒ�"
    ''' <summary>[���j���[�o�[]-[�f�[�^����M]-[�ʐM�ݒ�]</summary>
    ''' <remarks></remarks>
    Private Sub �ʐM�ݒ�ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ʐM�ݒ�ToolStripMenuItem.Click
        a1800_�ʐM�ݒ�.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�u�����N���V�[�g���"
    ''' <summary>[���j���[�o�[]-[�֗��c�[��]-[�u�����N���V�[�g���]</summary>
    ''' <remarks></remarks>
    Private Sub �u�����N���V�[�g���ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �u�����N���V�[�g���ToolStripMenuItem.Click
        '�u�����N���V�[�g���
        logic.printBlankReceipt(0, 0)

    End Sub
#End Region

#Region "�f�[�^���o"
    ''' <summary>[���j���[�o�[]-[�֗��c�[��]-[�f�[�^���o]</summary>
    ''' <remarks></remarks>
    Private Sub �f�[�^���oToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �f�[�^���oToolStripMenuItem.Click
        h0100_�f�[�^���o.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "�ڋq�ꗗ"
    ''' <summary>[���j���[�o�[]-[�֗��c�[��]-[�ڋq�ꗗ]</summary>
    ''' <remarks></remarks>
    Private Sub �ڋq�ꗗToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �ڋq�ꗗToolStripMenuItem.Click
        h0300_�ڋq.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "���o�^�҈ꗗ"
    ''' <summary>[���j���[�o�[]-[�֗��c�[��]-[���o�^�҈ꗗ]</summary>
    ''' <remarks></remarks>
    Private Sub ���o�^�҈ꗗToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���o�^�҈ꗗToolStripMenuItem.Click
        h0400_���o�^��.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "���b�Z�[�W�ꗗ"
    ''' <summary>[���j���[�o�[]-[�֗��c�[��]-[���b�Z�[�W�ꗗ]</summary>
    ''' <remarks></remarks>
    Private Sub ���b�Z�[�W�ꗗToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���b�Z�[�W�ꗗToolStripMenuItem.Click
        a1900_���b�Z�[�W�ꗗ.ShowDialog()
        Me.Activate()
    End Sub
#End Region


#Region "�o�[�W�������"
    ''' <summary>[���j���[�o�[]-[�w���v]-[�o�[�W�������]</summary>
    ''' <remarks></remarks>
    Private Sub �o�[�W�������ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �o�[�W�������ToolStripMenuItem.Click
        a1700_�o�[�W�������.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#End Region

#Region "���\�b�h"

#Region "�c�Ɠ��ݒ�`�F�b�N"
    ''' <summary>�c�Ɠ��ݒ�`�F�b�N</summary>
    ''' <remarks></remarks>
    Private Function GetBusinessDay() As DataTable
        Dim dt As New DataTable
        Do
            If IsDate(USER_DATE) = True Then
                dt = logic.BusinessDay(USER_DATE)
                If dt.Rows.Count() > 0 Then
                    Return dt
                Else
                    a0600_�c�Ɠ�.ShowDialog()
                End If
                dt = logic.BusinessDay(USER_DATE)
                If dt.Rows.Count() > 0 Then
                    Return dt
                Else
                    MsgBox("�c�Ɠ���񂪐ݒ肳��Ă��܂���B�@" & Chr(13) & Chr(13) & "���t�̕ύX�A�܂��͉c�Ɠ�����ݒ肵�Ă��������B�@", Clng_Okexb1, TTL)
                    a0700_���t�ݒ�.ShowDialog()
                End If
            Else
                MsgBox("���t���s���ł��B���t�ݒ肵�����Ă��������B�@", Clng_Okexb1, TTL)
                a0700_���t�ݒ�.ShowDialog()
            End If
        Loop
    End Function
#End Region

#Region "��ʍĕ\������"
    ''' <summary>��ʍĕ\������</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        Dim dtBusinessDay As DataTable = GetBusinessDay()

        '' ���X�҈ꗗ
        Me.dgv���X�҈ꗗ.DataSource = logic.VisitorList()

        Me.dgv���X�҈ꗗ.Columns(0).Visible = False
        Me.dgv���X�҈ꗗ.Columns(1).Visible = False
        Me.dgv���X�҈ꗗ.Columns(2).Width = 60
        Me.dgv���X�҈ꗗ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv���X�҈ꗗ.Columns(3).Width = 122
        Me.dgv���X�҈ꗗ.Columns(4).Visible = False
        Me.dgv���X�҈ꗗ.Columns(5).Visible = False
        Me.dgv���X�҈ꗗ.Columns(6).Width = 80
        Me.dgv���X�҈ꗗ.Columns(7).Width = 37
        Me.dgv���X�҈ꗗ.Columns(7).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv���X�҈ꗗ.Columns(8).Width = 78
        Me.dgv���X�҈ꗗ.Columns(9).Width = 25
        Me.dgv���X�҈ꗗ.Columns(9).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv���X�҈ꗗ.Columns(10).Width = 40
        Me.dgv���X�҈ꗗ.Columns(11).Visible = False
        Me.dgv���X�҈ꗗ.Columns(12).Visible = False
        Me.dgv���X�҈ꗗ.Columns(13).Width = 40
        Me.dgv���X�҈ꗗ.Columns(13).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        '' ��v�ς݈ꗗ
        Me.dgv��v�ς݈ꗗ.DataSource = logic.AccountingEndList()

        Me.dgv��v�ς݈ꗗ.Columns(0).Visible = False
        Me.dgv��v�ς݈ꗗ.Columns(1).Visible = False
        Me.dgv��v�ς݈ꗗ.Columns(2).Width = 60
        Me.dgv��v�ς݈ꗗ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv��v�ς݈ꗗ.Columns(3).Width = 122
        Me.dgv��v�ς݈ꗗ.Columns(4).Visible = False
        Me.dgv��v�ς݈ꗗ.Columns(5).Visible = False
        Me.dgv��v�ς݈ꗗ.Columns(6).Width = 80
        Me.dgv��v�ς݈ꗗ.Columns(7).Width = 37
        Me.dgv��v�ς݈ꗗ.Columns(7).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv��v�ς݈ꗗ.Columns(8).Width = 78
        Me.dgv��v�ς݈ꗗ.Columns(9).Width = 25
        Me.dgv��v�ς݈ꗗ.Columns(9).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv��v�ς݈ꗗ.Columns(10).Width = 40
        Me.dgv��v�ς݈ꗗ.Columns(11).Width = 40
        Me.dgv��v�ς݈ꗗ.Columns(12).Visible = False

        '' �\��ꗗ
        If Format(USER_DATE, "yyyy/MM/dd") <> Format(Now, "yyyy/MM/dd") Then
            Me.dgv�\��ꗗ.DataSource = Nothing
        Else
            Me.dgv�\��ꗗ.DataSource = logic.ReserveList()
            Me.dgv�\��ꗗ.Columns(0).Width = 87
            Me.dgv�\��ꗗ.Columns(1).Width = 86
            Me.dgv�\��ꗗ.Columns(2).Width = 190
            Me.dgv�\��ꗗ.Columns(3).Width = 120
            Me.dgv�\��ꗗ.Columns(4).Visible = False
        End If

        Me.dgv���X�҈ꗗ.ClearSelection()
        Me.dgv��v�ς݈ꗗ.ClearSelection()
        ClearDetailInfo()

        dtBusinessDay.Dispose()

        If (Visit_Mode <> True) Then
            If Format(USER_DATE, "yyyy/MM/dd").Equals(Format(Now, "yyyy/MM/dd")) Then
                Me.btn���X.Enabled = True
                Me.btn���.Enabled = True
                Me.btn�\��җ��X.Enabled = True
                Me.�\���M.Enabled = True
            Else
                Me.btn���X.Enabled = False
                Me.btn���.Enabled = True
                Me.btn�\��җ��X.Enabled = False
                Me.�\���M.Enabled = False
            End If
        End If

        If (Cashiers_Mode <> True) Then
            If Format(USER_DATE, "yyyy/MM/dd").Equals(Format(Now, "yyyy/MM/dd")) Then
                Me.btn����.Enabled = True
                Me.btn��v�ҏW.Enabled = True
            Else
                Me.btn����.Enabled = False
                Me.btn��v�ҏW.Enabled = False
            End If
        End If
        Me.btn�҂�.Enabled = False
        '' �^�C�g���o�[�̕����ݒ�
        setTitleBar()

    End Sub
#End Region

#Region "�t�H�[�J�X�ݒ菈��"
    ''' <summary>�t�H�[�J�X�ݒ菈��</summary>
    ''' <remarks></remarks>
    Protected Friend Sub setFocus()
        ' �^�u�ݒ�
        Select Case Me.tc���X���.SelectedIndex
            Case 0    ' �^�u(���X��)
                btn���X.Focus()
            Case 1    ' �^�u(��v��)
                btn��Ǝ���.Focus()
            Case 2    ' �^�u(�\��)
                btn�\��җ��X.Focus()
        End Select
        Me.Activate()
    End Sub
#End Region

#Region "�ڍ׏��̐ݒ�"
    ''' <summary>�ڍ׏��̐ݒ�</summary>
    ''' <remarks></remarks>
    Private Sub SetDetailInfo()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        Dim txt_�O�񗈓X�� As String
        Dim txt_���X���m1 As String
        Dim txt_���X���m2 As String

        ' �ڍ׏��̃N���A
        ClearDetailInfo()

        '' �ߋ����X���f�[�^�擾
        dt = logic.ClinicalRecordHistoryDay(CST_CODE)
        Me.dgv�ߋ����X���ꗗ.DataSource = dt
        Me.dgv�ߋ����X���ꗗ.Columns(0).Width = 100        ' ���X��
        Me.dgv�ߋ����X���ꗗ.Columns(0).DefaultCellStyle.Format() = "yyyy/MM/dd (ddd)"
        Me.dgv�ߋ����X���ꗗ.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv�ߋ����X���ꗗ.Columns(1).Visible = False    ' ���X�Ҕԍ�
        Me.dgv�ߋ����X���ꗗ.Columns(2).Visible = False    ' �ڋq�ԍ�
        Me.dgv�ߋ����X���ꗗ.Columns(3).Width = 122        ' �S����
        Me.dgv�ߋ����X���ꗗ.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgv�ߋ����X���ꗗ.Columns(4).Width = 20         ' �w��
        Me.dgv�ߋ����X���ꗗ.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv�ߋ����X���ꗗ.Columns(5).Width = 100        ' ���z����
        Me.dgv�ߋ����X���ꗗ.Columns(5).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

        '' �J���e�ꗗ�f�[�^�擾
        param.Clear()
        param.Add("@���X��", USER_DATE)
        param.Add("@���X�Ҕԍ�", SER_NO)

        dt = logic.ClinicalRecordInfo(CST_CODE)
        Me.dgv�J���e�ꗗ.DataSource = dt
        Me.dgv�J���e�ꗗ.Columns(0).Width = 70             ' ���X��
        Me.dgv�J���e�ꗗ.Columns(1).Visible = False        ' �S����
        Me.dgv�J���e�ꗗ.Columns(2).Width = 272            ' �J���e
        Me.dgv�J���e�ꗗ.ClearSelection()

        '' �ڋq���f�[�^�擾
        dt = logic.CustomerInfo()
        If dt.Rows.Count > 0 Then
            Me.lbl�ڋq�ԍ�.Text = dt.Rows(0)("�ڋq�ԍ�").ToString
            Me.lbl��.Text = dt.Rows(0)("��").ToString
            Me.lbl��.Text = dt.Rows(0)("��").ToString
            Me.lbl���J�i.Text = dt.Rows(0)("���J�i").ToString
            Me.lbl���J�i.Text = dt.Rows(0)("���J�i").ToString
            '' �Z��
            Me.lbl�X�֔ԍ�.Text = dt.Rows(0)("�X�֔ԍ�").ToString
            Me.lbl�s���{��.Text = dt.Rows(0)("�s���{��").ToString
            Me.lbl�s�撬��.Text = dt.Rows(0)("�Z��1").ToString
            Me.lbl����.Text = dt.Rows(0)("�Z��2").ToString
            Me.lbl�Ԓn����.Text = dt.Rows(0)("�Z��3").ToString
            Me.lbl�d�b�ԍ�.Text = dt.Rows(0)("�d�b�ԍ�").ToString
            Me.lblEmail.Text = dt.Rows(0)("Email�A�h���X").ToString
            Me.lbl�o�^�敪.Text = dt.Rows(0)("�o�^�敪").ToString
            '' �l���
            If Not IsDBNull(dt.Rows(0)("���N����")) Then
                Me.lbl����.Text = DateValue(dt.Rows(0)("���N����").ToString).ToString("yyyy/M/d")
                Dim ad As DateTime ''�����a��ɕύX���邽�߂̕ϐ�
                ad = DateTime.Parse(Me.lbl����.Text)
                Dim culture As Globalization.CultureInfo = New System.Globalization.CultureInfo("ja-JP", True)
                culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
                Me.lbl���N����.Text = ad.ToString("ggyy�NM��d��", culture) ''�����N�����\���ǉ����܂���
            End If
            Me.lbl����.Text = dt.Rows(0)("����").ToString
            Me.lbl�Ƒ���.Text = dt.Rows(0)("�Ƒ���").ToString
            Me.lbl�.Text = dt.Rows(0)("�").ToString
            '' �X�g�p
            Me.lbl�D���Șb��.Text = dt.Rows(0)("�D���Șb��").ToString
            Me.lbl�����Șb��.Text = dt.Rows(0)("�����Șb��").ToString
            Me.lbl����.Text = dt.Rows(0)("����").ToString
            Me.lbl�Љ��.Text = dt.Rows(0)("�Љ��").ToString

            txt_�O�񗈓X�� = ""
            If Not IsDBNull(dt.Rows(0)("�O�񗈓X��")) Then
                If Not (DateValue(dt.Rows(0)("�O�񗈓X��").ToString) = Date.Parse("1900/01/01")) Then
                    txt_�O�񗈓X�� = DateValue(dt.Rows(0)("�O�񗈓X��").ToString).ToString("yyyy/MM/dd (ddd)")

                End If
            End If
            Me.lbl���X����1.Text = txt_�O�񗈓X��

            txt_���X���m1 = ""
            If Not IsDBNull(dt.Rows(0)("���X��N_1")) Then
                If Not (DateValue(dt.Rows(0)("���X��N_1").ToString) = Date.Parse("1900/01/01")) Then
                    txt_���X���m1 = DateValue(dt.Rows(0)("���X��N_1").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl���X����2.Text = txt_���X���m1

            txt_���X���m2 = ""
            If Not IsDBNull(dt.Rows(0)("���X��N_2")) Then
                If Not (DateValue(dt.Rows(0)("���X��N_2").ToString) = Date.Parse("1900/01/01")) Then
                    txt_���X���m2 = DateValue(dt.Rows(0)("���X��N_2").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl���X����3.Text = txt_���X���m2

            Me.lbl��S����.Text = dt.Rows(0)("�S���Җ�").ToString
            If Not IsDBNull(dt.Rows(0)("�o�^��")) Then
                Me.lbl�o�^��.Text = DateValue(dt.Rows(0)("�o�^��").ToString).ToString("yyyy/MM/dd (ddd)")
            End If
        End If
        dt.Dispose()
    End Sub
#End Region

#Region "�ڍ׏��̃N���A"
    ''' <summary>
    ''' �ڍ׏��̃N���A
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearDetailInfo()
        '' �J���e�^�u
        Me.dgv�ߋ����X���ꗗ.DataSource = Nothing
        Me.dgv����ꗗ.DataSource = Nothing
        Me.dgv�J���e�ꗗ.DataSource = Nothing

        '' �ڋq���^�u
        lbl�ڋq�ԍ�.Text = Nothing
        lbl��.Text = Nothing
        lbl��.Text = Nothing
        lbl���J�i.Text = Nothing
        lbl���J�i.Text = Nothing

        ' �Z���^�u
        lbl�X�֔ԍ�.Text = Nothing
        lbl�s���{��.Text = Nothing
        lbl�s�撬��.Text = Nothing
        lbl����.Text = Nothing
        lbl�Ԓn����.Text = Nothing
        lbl�d�b�ԍ�.Text = Nothing
        lblEmail.Text = Nothing
        lbl�o�^�敪.Text = Nothing

        ' �l���^�u
        lbl���N����.Text = Nothing
        lbl����.Text = Nothing
        lbl����.Text = Nothing
        lbl�Ƒ���.Text = Nothing
        lbl�.Text = Nothing

        ' �X�g�p�^�u
        lbl�D���Șb��.Text = Nothing
        lbl�����Șb��.Text = Nothing
        lbl����.Text = Nothing
        lbl�Љ��.Text = Nothing
        lbl��S����.Text = Nothing
        lbl���X����1.Text = Nothing
        lbl���X����2.Text = Nothing
        lbl���X����3.Text = Nothing
        lbl�o�^��.Text = Nothing
    End Sub
#End Region

#Region "���X�҈ꗗ�I���`�F�b�N"
    ''' <summary>
    ''' ���X�҈ꗗ�I���`�F�b�N
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isVisitorSelection() As Boolean

        Dim vNumber As String
        Dim cNumber As String
        Dim dt As DataTable

        If Me.dgv���X�҈ꗗ.SelectedRows.Count <= 0 Then
            rtn = MsgBox("���X�҂�I�����Ă��������B�@", Clng_Okexb1, TTL)
            Me.btn���X.Focus()
            Return False
        End If

        vNumber = Me.dgv���X�҈ꗗ.SelectedRows(0).Cells(1).Value.ToString
        dt = logic.GetVisitorData(vNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("���W���[��", "Mod_���X�ґI��", "���X�҈ꗗ�̘A����l�̗��X�Ҕԍ����s��")
            Return False
        End If

        cNumber = dt.Rows(0)("�ڋq�ԍ�").ToString
        dt = logic.GetCustomerData(cNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("���W���[��", "Mod_���X�ґI��", "���X�҈ꗗ�̌ڋq�ԍ����s��")
            Return False
        End If
        '---------------�����܂ɃZ���N���b�N�C�x���g���������Ă��ڋq�ԍ��A���X�Ҕԍ����擾�ł��Ȃ��Ƃ�������̂ŕی��Œǉ����܂���--------------
        If CST_CODE = 0 Or SER_NO = 0 Then
            rtn = MsgBox("������x���X�҂�I�����Ă��������B�@", Clng_Okexb1, TTL)
            Exit Function
        End If
        '---------------������------------------------------------------------------------------------------------------------------------------
        Return True
    End Function
#End Region

#Region "��v�ψꗗ�I���`�F�b�N"
    ''' <summary>��v�ς݈ꗗ�I���`�F�b�N</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isBilledSelection() As Boolean
        Dim vNumber As String
        Dim cNumber As String
        Dim dt As DataTable

        If Me.dgv��v�ς݈ꗗ.SelectedRows.Count <= 0 Then
            rtn = MsgBox("��v�ςݗ��X�҂�I�����Ă��������B�@", Clng_Okexb1, TTL)
            Me.btn���X.Focus()
            Return False
        End If

        vNumber = Me.dgv��v�ς݈ꗗ.SelectedRows(0).Cells(1).Value.ToString
        dt = logic.GetVisitorData(vNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("���W���[��", "Mod_���X�ґI��", "��v�ς݈ꗗ�̘A����l�̗��X�Ҕԍ����s��")
            Return False
        End If

        cNumber = dt.Rows(0)("�ڋq�ԍ�").ToString
        dt = logic.GetCustomerData(cNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("���W���[��", "Mod_���X�ґI��", "��v�ς݈ꗗ�̌ڋq�ԍ����s��")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "�Ǘ��ҋ@�\�g�p�ېݒ�"
    ''' <summary>�Ǘ��ҋ@�\�g�p��or�s�ݒ�</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setAdminMenu() As Boolean
        '' �f�[�^���o�@�\��\��
        If My.MySettings.Default.AdminFlag = "1" Then
            �f�[�^���oToolStripMenuItem.Enabled = True
            �f�[�^���oToolStripMenuItem.Visible = True
        Else
            �f�[�^���oToolStripMenuItem.Enabled = False
            �f�[�^���oToolStripMenuItem.Visible = False
        End If
    End Function
#End Region

#Region "�\��@�\�g�p�ېݒ�"
    ''' <summary>�\��@�\�g�p��or�s�ݒ�</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setTransmitMenu() As Boolean
        '' �\��@�\��\��
        If My.MySettings.Default.ReserveFlag = "1" Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "�f�[�^����M�g�p�ېݒ�"
    ''' <summary>�f�[�^����M�@�\�g�p��or�s�ݒ�</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setReserveMenu() As Boolean
        '' �f�[�^����M�@�\��\��
        If My.MySettings.Default.UpdateFlag = "1" Then
            �f�[�^����MToolStripMenuItem.Visible = True
            �f�[�^��MToolStripMenuItem.Enabled = True
            �f�[�^��MToolStripMenuItem.Visible = True
            �ʐM�ݒ�ToolStripMenuItem.Enabled = True
            �ʐM�ݒ�ToolStripMenuItem.Visible = True
        Else
            �f�[�^����MToolStripMenuItem.Visible = False
            �f�[�^��MToolStripMenuItem.Enabled = False
            �f�[�^��MToolStripMenuItem.Visible = False
            �ʐM�ݒ�ToolStripMenuItem.Enabled = False
            �ʐM�ݒ�ToolStripMenuItem.Visible = False
        End If
    End Function
#End Region

#Region "���V�[�g����@�\�g�p�ېݒ�"
    ''' <summary>���V�[�g����@�\�g�p�ېݒ�</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setReceiptMenu() As Boolean
        '' ���V�[�g����@�\��\��
        If My.MySettings.Default.ReceiptFlag = "1" Then
            �u�����N���V�[�g���ToolStripMenuItem.Enabled = True
            �u�����N���V�[�g���ToolStripMenuItem.Visible = True
        Else
            �u�����N���V�[�g���ToolStripMenuItem.Enabled = False
            �u�����N���V�[�g���ToolStripMenuItem.Visible = False
        End If
    End Function
#End Region

#Region "����Ōv�Z���@�ݒ�"
    ''' <summary>����ŏ����_�ȉ��v�Z���@�ݒ�</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setTaxType() As Boolean
        iTaxtype = Integer.Parse(My.MySettings.Default.TaxType)
    End Function
#End Region

#Region "�T�[�r�X�v�Z���@�ݒ�"
    ''' <summary>�T�[�r�X�����_�ȉ��v�Z���@�ݒ�</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setServiceType() As Boolean
        iServicetype = Integer.Parse(My.MySettings.Default.ServiceType)
    End Function
#End Region

#Region "�J�[�\���������ݒ�"
    ''' <summary>
    ''' �J�[�\�����t���[�ɂȂ����ۂ̏���������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FreeCursor()
        Me.dgv�J���e�ꗗ.DataSource = Nothing
        Me.dgv�ߋ����X���ꗗ.DataSource = Nothing
        Me.dgv����ꗗ.DataSource = Nothing
        Me.lblEmail.Text = String.Empty
        Me.lbl����.Text = String.Empty
        Me.lbl�Ƒ���.Text = String.Empty
        Me.lbl�����Șb��.Text = String.Empty
        Me.lbl�ڋq�ԍ�.Text = String.Empty
        Me.lbl�ڋq�ԍ�.Text = String.Empty
        Me.lbl�D���Șb��.Text = String.Empty
        Me.lbl�s�撬��.Text = String.Empty
        Me.lbl��S����.Text = String.Empty
        Me.lbl�.Text = String.Empty
        Me.lbl�Љ��.Text = String.Empty
        Me.lbl��.Text = String.Empty
        Me.lbl���J�i.Text = String.Empty
        Me.lbl����.Text = String.Empty
        Me.lbl���N����.Text = String.Empty
        Me.lbl����.Text = String.Empty
        Me.lbl����.Text = String.Empty
        Me.lbl�d�b�ԍ�.Text = String.Empty
        Me.lbl�o�^�敪.Text = String.Empty
        Me.lbl�o�^��.Text = String.Empty
        Me.lbl�s���{��.Text = String.Empty
        Me.lbl�Ԓn����.Text = String.Empty
        Me.lbl��.Text = String.Empty
        Me.lbl���J�i.Text = String.Empty
        Me.lbl�X�֔ԍ�.Text = String.Empty
        Me.lbl���X����1.Text = String.Empty
        Me.lbl���X����2.Text = String.Empty
        Me.lbl���X����3.Text = String.Empty

        Me.dgv�\��ꗗ.ClearSelection()
        Me.dgv���X�҈ꗗ.ClearSelection()
        Me.dgv��v�ς݈ꗗ.ClearSelection()

        Me.btn�J���e.Enabled = False
        Me.btn�ύX.Enabled = False
        Me.btn�҂�.Enabled = False

        setFocus()
    End Sub
#End Region

#Region "�f�[�^��M�I��"
    ''' <summary>�f�[�^��M�I������</summary>
    ''' <remarks></remarks>
    Private Sub receiveData(ByVal iCount As Integer)

        Dim int_long As Integer
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer

        If System.IO.Directory.Exists(str_path) Then
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            �}�X�^�f�[�^�_�E�����[�h()
            Me.bMaster = True
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Else

            iStrCounter = InStr(str_path, "\")
            If iCount < 1 And iStrCounter > 0 Then
                While (bEnd = False)
                    iStrCounter = InStr(iStrCounter + 1, str_path, "\")
                    If iStrCounter = 0 Then
                        bEnd = True
                    Else
                        str_copypath = Mid(str_path, 1, iStrCounter - 1)
                        If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                            Try
                                MkDir(str_copypath)
                            Catch ex As Exception
                                '���O�o��
                                FileUtil.WriteLogFile(ex.ToString, _
                                                                My.Application.Info.DirectoryPath, _
                                                                TraceEventType.Error, _
                                                                FileUtil.OutPutType.Weekly)
                                MsgBox("�o�͐�t�@�C���̍쐬�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                                        "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
                            End Try
                        End If
                    End If
                End While
                receiveData(1)
                Exit Sub
            Else
                rtn = MsgBox("�_�E�����[�h��p�X������������܂���B�@" & Chr(13) & Chr(13) & _
                                         "�������p�X���w�肵�Ă��������B�@", Clng_Okexb1, TTL)
            End If
        End If
    End Sub
#End Region

#Region "�^�C�g���o�[�̕\�������ݒ�"
    ''' <summary>
    ''' �^�C�g���o�[�̕\�������ݒ�
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setTitleBar()
        Me.Text = "HABITS - ���C���@�@" & USER_DATE.ToString("yyyy�NM��d�� (ddd\)") & _
                "�@�@�@���X�ҁF" & dgv���X�҈ꗗ.Rows.Count & _
                "�l�@�@�@��v�ρF" & dgv��v�ς݈ꗗ.Rows.Count & _
                "�l�@�@�@�\��F" & dgv�\��ꗗ.Rows.Count & _
                "�l�@�@�@�����X�q���F" & (dgv���X�҈ꗗ.Rows.Count + dgv��v�ς݈ꗗ.Rows.Count) & "�l"
    End Sub
#End Region

#End Region

#Region "����M�E�\��"

    Private Sub downloadClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
    End Sub

    Private Sub downloadClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If bReserve = True Then
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            �\��f�[�^��������(0)
        End If

        If bMaster = True Then
            �}�X�^�f�[�^��������()
        End If

    End Sub

#Region "�\��f�[�^�_�E�����[�h"
    ''' <summary>
    ''' �\��f�[�^�_�E�����[�h
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �\��f�[�^�_�E�����[�h()
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            '�iWeb�V�X�e���j�\��f�[�^�_�E�����[�h����
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "ReserveDataSync.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollection�̍쐬
            Dim ps As New System.Collections.Specialized.NameValueCollection

            '���M����f�[�^�i�t�B�[���h���ƒl�̑g�ݍ��킹�j��ǉ�
            ps.Add("q1", My.Settings.LoginName)         ' ID
            ps.Add("q2", My.Settings.LoginPassword)     ' Password
            ps.Add("q3", sShopcode)                     ' ShopCode
            wc.QueryString = ps

            '�f�[�^�𑗐M���A�܂���M����
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then

                '�_�E�����[�h�����t�@�C���̕ۑ���
                Dim fileName As String = Me.str_path
                Dim filename2 As String = "ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
                Dim filename3 As String = "ReserveTable.txt"

                '�iWeb�T�C�h�j�_�E�����[�h����URL
                Dim u As New Uri(URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NDATAFOLDER & filename2)

                'WebClient�̍쐬
                If downloadClient Is Nothing Then
                    downloadClient = New System.Net.WebClient()
                End If
                '�����_�E�����[�h���J�n����
                downloadClient.DownloadFile(u, fileName + filename2)
                downloadClient.Dispose()
            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("���O�C���G���[�F" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                logic.delete_reserveDate()
            Else
                MsgBox("�s���F" & result, Clng_Okexb1, TTL)
            End If
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�ڑ��G���[�������������߁A�\����̎擾�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                    "�C���^�[�l�b�g�ւ̐ڑ��󋵂��m�F���Ă��������B�@", Clng_Okexb1, TTL)
        End Try

        Cursor.Current = Windows.Forms.Cursors.WaitCursor
    End Sub
#End Region

#Region "�\��f�[�^��������"
    ''' <summary>
    ''' �\��f�[�^��������
    ''' </summary>
    ''' <param name="iCount"></param>
    ''' <remarks></remarks>
    Private Sub �\��f�[�^��������(ByVal iCount As Integer)
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.bReserve = False

        Dim int_long As Integer
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer
        Dim str_makepath As String = Me.str_path + "ReserveTable\"

        int_long = str_makepath.Length - 1

        Try
            '�_�E�����[�h���ꂽ�t�@�C���̕ۑ���
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "ReserveTable"

            If System.IO.Directory.Exists(Mid(str_makepath, 1, int_long)) Then

                '�W�J����ZIP�t�@�C���̐ݒ�
                Dim zipPath As String = fileName1 + filename2
                '�W�J��̃t�H���_�̐ݒ�
                Dim extractDir As String = fileName1 + filename3

                '�ǂݍ���
                If System.IO.File.Exists(zipPath) Then

                    Dim fis As New java.io.FileInputStream(zipPath)
                    Dim zis As New java.util.zip.ZipInputStream(fis)
                    'ZIP���̃t�@�C�������擾
                    While True
                        Dim ze As java.util.zip.ZipEntry = zis.getNextEntry()
                        If ze Is Nothing Then
                            Exit While
                        End If
                        If Not ze.isDirectory() Then
                            '�t�@�C����
                            Dim fileName As String = _
                                System.IO.Path.GetFileName(ze.getName())
                            '�W�J��̃t�H���_
                            Dim destDir As String = System.IO.Path.Combine( _
                                extractDir, System.IO.Path.GetDirectoryName(ze.getName()))
                            System.IO.Directory.CreateDirectory(destDir)
                            '�W�J��̃p�X
                            Dim destPath As String = _
                                System.IO.Path.Combine(destDir, fileName)
                            'FileOutputStream�̍쐬
                            Dim fos As New java.io.FileOutputStream(destPath)
                            '������
                            Dim buffer(8191) As System.SByte
                            While True
                                Dim len As Integer = zis.read(buffer, 0, buffer.Length)
                                If len <= 0 Then
                                    Exit While
                                End If
                                fos.write(buffer, 0, len)
                            End While
                            '����
                            fos.close()
                        End If
                    End While

                    zis.close()
                    fis.close()

                    �\��ǂݍ���()
                    �\��t�@�C���폜()
                End If
            Else
                iStrCounter = InStr(str_makepath, "\")
                If iCount < 1 And iStrCounter > 0 Then
                    While (bEnd = False)
                        iStrCounter = InStr(iStrCounter + 1, str_makepath, "\")
                        If iStrCounter = 0 Then
                            bEnd = True
                        Else
                            str_copypath = Mid(str_makepath, 1, iStrCounter - 1)
                            If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                                Try
                                    MkDir(str_copypath)
                                Catch ex As Exception
                                    '���O�o��
                                    FileUtil.WriteLogFile(ex.ToString, _
                                                                    My.Application.Info.DirectoryPath, _
                                                                    TraceEventType.Error, _
                                                                    FileUtil.OutPutType.Weekly)
                                    MsgBox("�o�͐�t�@�C���̍쐬�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                                            "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
                                End Try
                            End If
                        End If
                    End While
                    �\��f�[�^��������(1)
                    Exit Sub
                Else
                    MsgBox("�t�@�C���̓W�J�Ɏ��s���܂����B�@" & Chr(13) & Chr(13), Clng_Okexb1, TTL)
                End If

            End If
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�t�@�C���̓W�J�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                   "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "�\��ǂݍ���"
    ''' <summary>
    ''' �\��ǂݍ���
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �\��ǂݍ���()
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        '�_�E�����[�h�t�@�C����Shift-JIS�R�[�h�Ƃ��ĊJ��
        Dim sr As New System.IO.StreamReader(Me.str_path & "ReserveTable\ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv", _
            System.Text.Encoding.GetEncoding("shift_jis"))
        Try
            Dim txt As String
            Dim bTableName As Boolean = False
            Dim sTablseName As String = ""

            '���e����s���ǂݍ���
            While sr.Peek() > -1
                txt = sr.ReadLine()
                If (txt = "-") Then
                    bTableName = True
                Else
                    If bTableName = True Then
                        sTablseName = txt
                        bTableName = False
                        logic.BedoreMakeSQL(sTablseName)
                    Else
                        logic.makeDownloadSQL(sTablseName, txt)
                    End If
                End If

            End While
            '����
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�t�@�C���̓Ǎ��Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                       "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
        Finally

            sr.Close()
        End Try
    End Sub
#End Region

#Region "�\��t�@�C���폜"
    ''' <summary>
    ''' �\��t�@�C���폜
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �\��t�@�C���폜()
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "ReserveTable\ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv"
            ' FileSystemObject (FSO) �̐V�����C���X�^���X�𐶐�����
            ' �t�@�C�����폜����
            System.IO.File.Delete(fileName1 + filename2)
            System.IO.File.Delete(fileName1 + filename3)

        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�t�@�C���̍폜�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                       "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "�}�X�^�f�[�^�_�E�����[�h"
    ''' <summary>
    ''' �}�X�^�f�[�^�_�E�����[�h
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �}�X�^�f�[�^�_�E�����[�h()
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '�iWeb�V�X�e���j�}�X�^�f�[�^�_�E�����[�h����
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MasterDataSync.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollection�̍쐬
            Dim ps As New System.Collections.Specialized.NameValueCollection
            Dim sUdDate As String
            Dim dt As New DataTable

            dt = logic.selectDownloadDate()
            sUdDate = dt.Rows(0)("�ŏI�_�E�����[�h").ToString()

            '���M����f�[�^�i�t�B�[���h���ƒl�̑g�ݍ��킹�j��ǉ�
            ps.Add("q1", My.Settings.LoginName)         ' ID
            ps.Add("q2", My.Settings.LoginPassword)     ' Password
            ps.Add("q3", sShopcode)                     ' ShopCode
            ps.Add("q4", sUdDate)                       ' Date
            wc.QueryString = ps

            '�f�[�^�𑗐M���A�܂���M����
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then
                '�_�E�����[�h�����t�@�C���̕ۑ���
                Dim fileName As String = Me.str_path
                Dim filename2 As String = "MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
                Dim filename3 As String = "MasterTable.txt"
                Dim startIndex As Integer = InStr(result.ToString, ";") + 1
                Dim endIndex As Integer = InStr(startIndex, result.ToString, ";")
                upTime = Mid(result.ToString(), startIndex, endIndex - startIndex)

                '�iWeb�T�C�h�j�_�E�����[�h����URL
                Dim u As New Uri(URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NDATAFOLDER & filename2)

                'WebClient�̍쐬
                If downloadClient Is Nothing Then
                    downloadClient = New System.Net.WebClient()
                End If
                '�C�x���g�n���h���̍쐬

                AddHandler downloadClient.DownloadProgressChanged, _
                    AddressOf downloadClient_DownloadProgressChanged
                AddHandler downloadClient.DownloadFileCompleted, _
                    AddressOf downloadClient_DownloadFileCompleted
                '�񓯊��_�E�����[�h���J�n����
                downloadClient.DownloadFileAsync(u, fileName + filename2)

            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("���O�C���G���[�F" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                MsgBox("�A�b�v���[�h�t�H���_�����G���[�F" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-3") = True Then
                MsgBox("�t�@�C���ۑ����s�G���[�F" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-4") = True Then
                MsgBox("Zip�t�@�C���ȊO���M�G���[�F" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-5") = True Then
                MsgBox("Zip�t�@�C���W�J���s�G���[�F" & result, Clng_Okexb1, TTL)
            Else
                MsgBox("�s���F" & result, Clng_Okexb1, TTL)
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�ڑ��G���[���������܂����B�@" & Chr(13) & Chr(13) & _
                    "�C���^�[�l�b�g�ւ̐ڑ��󋵂��m�F���Ă��������B�@", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "�}�X�^�f�[�^��������"
    ''' <summary>
    ''' �}�X�^�f�[�^��������
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �}�X�^�f�[�^��������()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.bMaster = False

        Try
            '�_�E�����[�h���ꂽ�t�@�C���̕ۑ���
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "MasterTable"

            '�W�J����ZIP�t�@�C���̐ݒ�
            Dim zipPath As String = fileName1 + filename2
            '�W�J��̃t�H���_�̐ݒ�
            Dim extractDir As String = fileName1 + filename3

            '�ǂݍ���
            Dim fis As New java.io.FileInputStream(zipPath)
            Dim zis As New java.util.zip.ZipInputStream(fis)
            'ZIP���̃t�@�C�������擾
            While True
                Dim ze As java.util.zip.ZipEntry = zis.getNextEntry()
                If ze Is Nothing Then
                    Exit While
                End If
                If Not ze.isDirectory() Then
                    '�t�@�C����
                    Dim fileName As String = _
                        System.IO.Path.GetFileName(ze.getName())
                    '�W�J��̃t�H���_
                    Dim destDir As String = System.IO.Path.Combine( _
                        extractDir, System.IO.Path.GetDirectoryName(ze.getName()))
                    System.IO.Directory.CreateDirectory(destDir)
                    '�W�J��̃p�X
                    Dim destPath As String = _
                        System.IO.Path.Combine(destDir, fileName)
                    'FileOutputStream�̍쐬
                    Dim fos As New java.io.FileOutputStream(destPath)
                    '������
                    Dim buffer(8191) As System.SByte
                    While True
                        Dim len As Integer = zis.read(buffer, 0, buffer.Length)
                        If len <= 0 Then
                            Exit While
                        End If
                        fos.write(buffer, 0, len)
                    End While
                    '����
                    fos.close()

                End If
            End While

            zis.close()
            fis.close()

            �}�X�^�ǂݍ���()
            �}�X�^�t�@�C���폜()
            logic.finishDownload(upTime)
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�t�@�C���̓W�J�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
            "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "�}�X�^�ǂݍ���"
    ''' <summary>
    ''' �}�X�^�ǂݍ���
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �}�X�^�ǂݍ���()
        '�_�E�����[�h��Shift-JIS�R�[�h�Ƃ��ĊJ��
        Dim sr As New System.IO.StreamReader(Me.str_path & "MasterTable\MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv", _
            System.Text.Encoding.GetEncoding("shift_jis"))
        Dim txt As String
        Dim bTableName As Boolean = False
        Dim sTablseName As String = ""

        '���e����s���ǂݍ���
        While sr.Peek() > -1
            txt = sr.ReadLine()
            If (txt = "-") Then
                bTableName = True
            Else
                If bTableName = True Then
                    sTablseName = txt
                    bTableName = False
                    logic.BedoreMakeSQL(sTablseName)
                Else
                    logic.makeDownloadSQL(sTablseName, txt)
                End If
            End If

        End While
        '����
        sr.Close()
    End Sub
#End Region

#Region "�}�X�^�t�@�C���폜"
    ''' <summary>
    ''' �}�X�^�t�@�C���폜
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub �}�X�^�t�@�C���폜()
        Try
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "MasterTable\MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv"
            ' FileSystemObject (FSO) �̐V�����C���X�^���X�𐶐�����
            ' �t�@�C�����폜����
            System.IO.File.Delete(fileName1 + filename2)
            System.IO.File.Delete(fileName1 + filename3)
            MsgBox("�f�[�^����M���܂����B�@�@�@�@" & Chr(13), Clng_Okinb1, TTL)
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�t�@�C���̍폜�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                      "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "�\��f�[�^��M����"
    ''' <summary>�\��f�[�^��M����</summary>
    ''' <remarks></remarks>
    Private Sub receiveReserve(ByVal iCount As Integer)

        Dim int_long As Integer
        Dim str_custompath As String
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer

        If setTransmitMenu() = False Then
            Exit Sub
        End If

        str_custompath = Me.str_path + "ReserveTable\"
        str_custompath = Replace(str_custompath, "/", "\")

        int_long = str_custompath.Length - 1

        If System.IO.Directory.Exists(Mid(str_custompath, 1, int_long)) Then
            Cursor.Current = Windows.Forms.Cursors.WaitCursor

            �\��f�[�^�_�E�����[�h()
            bReserve = True

            If bReserve = True Then
                Cursor.Current = Windows.Forms.Cursors.WaitCursor
                �\��f�[�^��������(0)
            End If

            Cursor.Current = Windows.Forms.Cursors.Default
        Else
            iStrCounter = InStr(str_custompath, "\")
            If iCount < 1 And iStrCounter > 0 Then
                While (bEnd = False)
                    iStrCounter = InStr(iStrCounter + 1, str_custompath, "\")
                    If iStrCounter = 0 Then
                        bEnd = True
                    Else
                        str_copypath = Mid(str_custompath, 1, iStrCounter - 1)
                        If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                            Try
                                MkDir(str_copypath)
                            Catch ex As Exception
                                '���O�o��
                                FileUtil.WriteLogFile(ex.ToString, _
                                                                My.Application.Info.DirectoryPath, _
                                                                TraceEventType.Error, _
                                                                FileUtil.OutPutType.Weekly)
                                MsgBox("�o�͐�t�@�C���̍쐬�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                                        "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
                            End Try
                        End If
                    End If
                End While
                receiveReserve(1)
                Exit Sub
            Else
                rtn = MsgBox("�t�@�C���o�͐�p�X������������܂���B�@" & Chr(13) & Chr(13) & _
                  "�������p�X���w�肵�Ă��������B�@", Clng_Okexb1, TTL)
            End If
        End If
    End Sub
#End Region

#End Region

#Region "�^�C�}�[����"
    ''' <summary>
    ''' �T�[�o�ւ̃f�[�^���M����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerDataSync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDataSync.Tick
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim iError As Integer = 0

        '�ʐM���t���O�`�F�b�N
        If NETWORK_FLAG = False Then
            Exit Sub
        End If

        If ACTIVE_NETWORK_FLAG = False Then
            Me.lbl_Connect.Visible = False
            '�ʐM�G���[�񐔃`�F�b�N
            dt = logic.GetConnectError()
            If dt.Rows.Count > 0 Then
                iError = Integer.Parse(dt.Rows(0)("�ʐM���G���[��").ToString)
                If iError >= CONNECT_ERROR Then
                    Me.lbl_Connect.Visible = True
                End If
            End If

            '�ʐM���t���Oon
            ACTIVE_NETWORK_FLAG = True

            '�ʐM�J�n
            MultiThread.UpdateToServer()
        Else
            Me.lbl_Connect.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' ���`�F�b�N�̃��b�Z�[�W�����擾����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerMessageChk_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMessageChk.Tick
        If MESSAGE_CHECK_FLAG = False Then
            '���b�Z�[�W�����`�F�b�N���t���O
            MESSAGE_CHECK_FLAG = True

            '�ʐM�J�n
            MultiThreadMsg.UpdateToServer()

            If MESSAGE_CNT > 0 Then
                If (MsgBox("���m�F�̃��b�Z�[�W��" & MESSAGE_CNT & "������܂��B�@�@", Clng_Okinb1, TTL) = vbOK) Then
                    MESSAGE_CHECK_FLAG = False
                End If
            Else
                MESSAGE_CHECK_FLAG = False
            End If
            MESSAGE_CNT = 0
        End If

    End Sub

#End Region

#Region "���o��"
    ''' <summary>[���j���[�o�[]-[����Ɩ�]-[���o��]</summary>
    ''' <remarks></remarks>
    Private Sub ���o��ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���o��ToolStripMenuItem.Click
        d0500_�������o���o�^.ShowDialog()
        Me.Activate()
    End Sub
#End Region

End Class




