'�V�X�e���� �F HABITS
'�T�v�@�@�@ �F
'�����@�@�@ �F ���j���[
'�����@�@�@ �F 2010/04/01�@�r�v�i�@�쐬
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module ���j���[

    '�T�v �F Men_�V�X�e���̏I��
    '���� �F �Ȃ�
    '���� �F �V�X�e���̏I��

    Public Function Men_�V�X�e���̏I��() As Long

        If (MsgBox("����ꂳ�܂ł����B�@" & Chr(13) & Chr(13) & _
                   "�V�X�e�����I�����Ă���낵���ł����H�@", Clng_Ynqub2, TTL) = vbNo) Then
            a0200_���C��.btn���X.Focus()
            Exit Function
        End If
        M01.DialogResult = System.Windows.Forms.DialogResult.Cancel
        M01.Close()
    End Function
End Module
