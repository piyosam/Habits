''' <summary>f0600_�X�^�b�t��ʏ���</summary>
''' <remarks></remarks>
Public Class f0600_�X�^�b�t
    Private logic As New Habits.Logic.f0600_Logic

#Region "�C�x���g"

#Region "�y�[�W���[�h����"
    ''' <summary>���[�h������</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0600_�X�^�b�t_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.f0600_Logic
        Me.�S���\��.Checked = False
        Me.�V�K.Enabled = True
        Me.�o�^.Enabled = False
        '�X�^�b�t�ꗗ�\��
        ReDisp()

        Me.�V�K.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "�t�H�[���N���[�Y�㏈��"
    ''' <summary>�t�H�[��������ꂽ�㏈��</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0600_�X�^�b�t_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim dt As DataTable
        dt = logic.select_d_stuff
        If dt.Rows.Count = 0 Then
            Call Sys_Error("�X�^�b�t��1�����o�^����Ă��܂���B�@", Me.�V�K)
            Exit Sub
        End If
        Me.Dispose()
    End Sub
#End Region

#Region "�V�K�{�^������"
    ''' <summary>
    ''' �V�K�{�^���N���b�N����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub �V�K_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �V�K.Click
        Dim dt As New DataTable
        Dim max_staffno As Integer

        dt = logic.�S����_�ő�ԍ��擾()
        max_staffno = Integer.Parse(dt.Rows(0)("�ő�ԍ�").ToString)
        If (max_staffno >= Max_MasterNo) Then
            Call Sys_Error("�o�^�ő吔�ɒB�������ߓo�^�ł��܂���B�@", Me.����)
            Exit Sub
        End If

        Me.�S���҈ꗗ.ClearSelection()
        Clear_���͍���()
        SetEnable_���͍���(True)

        Me.�S���Җ�.Focus()
        Me.�o�^.Enabled = True
        Me.�o�^.Text = BTN_REGIST

        Me.lbl�S���Ҕԍ�.Text = (max_staffno + 1).ToString
        Me.Activate()
    End Sub
#End Region

#Region "����{�^������"
    ''' <summary>
    ''' ����{�^���N���b�N����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ����_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ����.Click
        Dim dt As DataTable
        dt = logic.select_d_stuff
        If dt.Rows.Count = 0 Then
            Call Sys_Error("�X�^�b�t��1�����o�^����Ă��܂���B�@", Me.�V�K)
            Exit Sub
        End If
        Me.Close()
    End Sub
#End Region

#Region "���ڃN���A�{�^������"
    ''' <summary>
    ''' ���ڃN���A�{�^���N���b�N����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ���ڃN���A_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ���ڃN���A.Click
        Me.�S���҈ꗗ.ClearSelection()
        Clear_���͍���()
        lbl�S���Ҕԍ�.Text = Nothing
        Me.�o�^.Text = "�ύX"
        SetEnable_���͍���(False)
    End Sub
#End Region

#Region "�o�^�{�^������"
    ''' <summary>
    ''' �o�^�{�^���N���b�N����
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub �o�^_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �o�^.Click
        Dim dt As New Integer
        Dim param As New Habits.DB.DBParameter
        Dim deleteDt As DataTable
        Dim deleteCnt As Integer

        If Me.�o�^.Text = "�o�^" Then

            If Not input_check(True) Then Exit Sub
            param.Add("@�S���Ҕԍ�", Me.lbl�S���Ҕԍ�.Text)
            param.Add("@�S���Җ�", Me.�S���Җ�.Text)
            param.Add("@�\����", Me.�\����.Text)
            If Me.�폜�t���O.Checked = True Then
                param.Add("@�폜�t���O", 1)
            ElseIf Me.�폜�t���O.Checked = False Then
                param.Add("@�폜�t���O", 0)
            End If
            param.Add("@�o�^��", Now())
            param.Add("@�X�V��", Now())
            dt = logic.�S���Ғǉ�(param)
            rtn = MsgBox("�o�^���܂����B�@�@�@�@" & Chr(13), Clng_Okinb1, TTL)

        ElseIf Me.�o�^.Text = "�ύX" Then
            If Not input_check(False) Then Exit Sub
            param.Add("@�S���Ҕԍ�", Me.lbl�S���Ҕԍ�.Text)
            param.Add("@�S���Җ�", Me.�S���Җ�.Text)
            param.Add("@�\����", Me.�\����.Text)
            If Me.�폜�t���O.Checked = True Then
                deleteDt = logic.�S���ҍ폜�t���O�`�F�b�N()
                deleteCnt = Integer.Parse(deleteDt.Rows(0)("�\������").ToString)
                If deleteCnt <= 1 Then
                    Call Sys_Error("�X�^�b�t��S�Ĕ�\���ɂ��邱�Ƃ͂ł��܂���B�@", Me.�폜�t���O)
                    ReDisp()
                    Exit Sub
                End If
                param.Add("@�폜�t���O", 1)
            ElseIf Me.�폜�t���O.Checked = False Then
                param.Add("@�폜�t���O", 0)
            End If
            param.Add("@�X�V��", Now())
            dt = logic.�S���ҍX�V(param)
            rtn = MsgBox("�ύX���܂����B�@�@�@�@" & Chr(13), Clng_Okinb1, TTL)
        End If
        ReDisp()
        Me.�V�K.Focus()
    End Sub
#End Region

    Private Sub �S���\��_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles �S���\��.CheckedChanged
        ReDisp()
    End Sub

    Private Sub �S���҈ꗗ_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles �S���҈ꗗ.SelectionChanged
        ReDisplay_���͍���()
    End Sub

#End Region

#Region "�L�[����������"
    Private Sub �S���Җ�_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles �S���Җ�.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.�\����.Focus()
        End If
    End Sub

    Private Sub �\����_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles �\����.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.�폜�t���O.Focus()
        End If
    End Sub

    Private Sub �폜�t���O_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles �폜�t���O.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.�o�^.Focus()
        End If
    End Sub
#End Region

#Region "�L�[�v���X�ݒ�"
    Private Sub �\����_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles �\����.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "���\�b�h"
    ''' <summary>���̓`�F�b�N</summary>
    ''' <remarks></remarks>
    Private Function input_check(ByVal mode As Boolean) As Boolean
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        input_check = False
        Me.lbl�S���Ҕԍ�.Text = Trim(Me.lbl�S���Ҕԍ�.Text)

        If Sys_InputCheck(Me.lbl�S���Ҕԍ�.Text, 4, "N+", 1) Then
            Call Sys_Error("�X�^�b�t�ԍ� ���s���ł��B�@", Me.lbl�S���Ҕԍ�)
            Exit Function
        End If

        Me.�S���Җ�.Text = Trim(Me.�S���Җ�.Text)
        If String.IsNullOrEmpty(Me.�S���Җ�.Text) Then
            Call Sys_Error("�X�^�b�t�� �͕K�{���͂ł��B�@", Me.�S���Җ�)
            Exit Function
        End If
        If (Sys_InputCheck(Me.�S���Җ�.Text, 32, "M", 1)) Then
            Call Sys_Error("�X�^�b�t�� ��32�����ȓ��œ��͂��Ă��������B", Me.�S���Җ�)
            Exit Function
        End If

        Me.�\����.Text = Trim(Me.�\����.Text)
        If String.IsNullOrEmpty(Me.�\����.Text) Then
            Call Sys_Error("�\���� �͕K�{���͂ł��B�@", Me.�\����)
            Exit Function
        End If
        If Sys_Zenkaku(Me.�\����.Text) Then
            Call Sys_Error("�\���� �͔��p�����œ��͂��Ă��������B�@", Me.�\����)
            Exit Function
        End If
        If (Sys_InputCheck(Me.�\����.Text, 4, "N+", 1)) Then
            Call Sys_Error("�\���� �͔��p����4�����ȓ��œ��͂��Ă��������B�@", Me.�\����)
            Exit Function
        End If

        Select Case mode
            Case True ''�o�^�̏ꍇ
                param.Add("@�S���Ҕԍ�", Me.lbl�S���Ҕԍ�.Text)
                dt = logic.select_number(param)
                param.Clear()
                If dt.Rows.Count > 0 Then
                    Call Sys_Error("�w�肳�ꂽ�X�^�b�t�ԍ��͊��ɓo�^����Ă��܂��B�@", Me.lbl�S���Ҕԍ�)
                    Exit Function
                End If
                param.Add("@�S���Җ�", Me.�S���Җ�.Text)
                dt = logic.select_name(param)
                param.Clear()
                If dt.Rows.Count > 0 Then
                    Call Sys_Error("���͂����X�^�b�t���͓o�^�ςł��B�@" & Chr(13) & Chr(13) & "�X�^�b�t����ύX���ēo�^���Ă��������B�@", Me.�S���Җ�)
                    Exit Function
                End If
            Case False ''�ύX�̏ꍇ
                param.Add("@�S���Җ�", Me.�S���Җ�.Text)
                param.Add("@�S���Ҕԍ�", Me.lbl�S���Ҕԍ�.Text)
                dt = logic.select_name(param)
                param.Clear()
                If dt.Rows.Count > 0 Then
                    If Me.�S���҈ꗗ.SelectedRows(0).Cells(1).Value.ToString = Me.�S���Җ�.Text Then
                        Exit Select
                    End If
                    Call Sys_Error("���͂����X�^�b�t���͓o�^�ςł��B�@" & Chr(13) & Chr(13) & "�X�^�b�t����ύX���ēo�^���Ă��������B�@", Me.�S���Җ�)
                    Exit Function
                End If
        End Select

        input_check = True
    End Function

    ''' <summary>�ĕ\��</summary>
    ''' <remarks></remarks>
    Private Sub ReDisp()
        Dim dt As New System.Data.DataTable
        If Me.�S���\��.Checked = True Then
            dt = logic.�S���ґS���擾
        ElseIf Me.�S���\��.Checked = False Then
            dt = logic.�S���҈ꗗ�擾
        End If

        If dt.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.�S���҈ꗗ.DataSource = dt
        Me.�S���҈ꗗ.ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.�S���҈ꗗ.Columns(0).Width = 60
        Me.�S���҈ꗗ.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.�S���҈ꗗ.Columns(1).Width = 172
        Me.�S���҈ꗗ.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.�S���҈ꗗ.Columns(2).Width = 71
        Me.�S���҈ꗗ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.�S���҈ꗗ.Columns(3).Width = 60
        Me.�S���҈ꗗ.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.�S���҈ꗗ.ClearSelection()

        Me.lbl�S���Ҕԍ�.Text = Nothing
        Clear_���͍���()
        Me.�S���҈ꗗ.ClearSelection()
        ReDisplay_���͍���()
    End Sub

    ''' <summary>���͍��ڍĕ\������</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_���͍���()
        If Me.�S���҈ꗗ.SelectedRows.Count > 0 Then
            Me.�o�^.Text = "�ύX"
            Me.lbl�S���Ҕԍ�.Text = Me.�S���҈ꗗ.SelectedRows(0).Cells("�ԍ�").Value.ToString
            Me.�S���Җ�.Text = Me.�S���҈ꗗ.SelectedRows(0).Cells("�X�^�b�t��").Value.ToString
            Me.�\����.Text = Me.�S���҈ꗗ.SelectedRows(0).Cells("�\����").Value.ToString
            Me.�폜�t���O.Checked = False
            If Me.�S���҈ꗗ.SelectedRows(0).Cells("�\��").Value.ToString = "�~" Then
                Me.�폜�t���O.Checked = True
            Else
                Me.�폜�t���O.Checked = False
            End If

            SetEnable_���͍���(True)

            Me.�V�K.Enabled = True
            Me.�o�^.Enabled = True

            Me.�S���Җ�.Focus()
        Else
            Me.�o�^.Text = "�o�^"
            Clear_���͍���()
            If (String.IsNullOrEmpty(Me.lbl�S���Ҕԍ�.Text)) Then
                SetEnable_���͍���(False)
            Else
                SetEnable_���͍���(True)
            End If
        End If
    End Sub

    ''' <summary>���͍��ڃN���A����</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_���͍���()
        Me.�S���Җ�.Text = Nothing
        Me.�\����.Text = Nothing
        Me.�폜�t���O.Checked = False
        Me.�V�K.Enabled = True
    End Sub

    ''' <summary>���͍���Enable�ݒ�</summary>
    ''' <param name="v_bool">True�F�o�^�AFalse�F�o�^�s��</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetEnable_���͍���(ByVal v_bool As Boolean)
        If v_bool Then
            Me.lbl�S���Ҕԍ�.BackColor = Color.White
            Me.�S���Җ�.Enabled = True
            Me.�S���Җ�.BackColor = Color.White
            Me.�\����.Enabled = True
            Me.�\����.BackColor = Color.White
            Me.�폜�t���O.Enabled = True

            Me.���ڃN���A.Enabled = True
            Me.�o�^.Enabled = True
        Else
            Me.lbl�S���Ҕԍ�.BackColor = SystemColors.Control
            Me.�S���Җ�.Enabled = False
            Me.�S���Җ�.BackColor = SystemColors.Control
            Me.�\����.Enabled = False
            Me.�\����.BackColor = SystemColors.Control
            Me.�폜�t���O.Enabled = False

            Me.���ڃN���A.Enabled = False
            Me.�o�^.Enabled = False
        End If
    End Sub
#End Region

End Class