Imports System
Imports System.Threading
Imports System.Text

Public Class MultiThreadMsg

#Region "���`�F�b�N���b�Z�[�W�̃`�F�b�N"
    ' �߂�l�ƃp�����[�^�̂���f���Q�[�g
    Delegate Function ThreadMethodDelegate(ByVal c As String) As Integer ' 
    Shared threadMethodDelegateInstance As ThreadMethodDelegate ' 

    Public Shared Sub UpdateToServer()
        threadMethodDelegateInstance _
          = New ThreadMethodDelegate(AddressOf ThreadMethod) ' 

        ' �f���Q�[�g�ɂ��X���b�h�����Ăяo��
        threadMethodDelegateInstance.BeginInvoke(".", _
          New AsyncCallback(AddressOf MyCallback), DateTime.Now) ' 
    End Sub
#End Region

#Region "���b�Z�[�W�����擾"
    ''' <summary>
    ''' ���b�Z�[�W�����擾
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function ThreadMethod(ByVal c As String) As Integer
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '�iWeb�V�X�e���j���`�F�b�N���b�Z�[�W�����擾
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MessageDataCheck.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollection�̍쐬
            Dim ps As New System.Collections.Specialized.NameValueCollection
            Dim dt As New DataTable

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
                Dim startIndex As Integer = InStr(result.ToString, ":") + 1
                Dim endIndex As Integer = InStr(startIndex, result.ToString, ":")
                MESSAGE_CNT = Mid(result.ToString(), startIndex, endIndex - startIndex)

            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("���O�C���G���[�F" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                MsgBox("�A�b�v���[�h�t�H���_�����G���[�F" & result, Clng_Okexb1, TTL)
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
            '���b�Z�[�W�@�\�͖{�̋@�\�ɉe����^���Ȃ����߁A�^�C�}�[�N���̃G���[���b�Z�[�W�͕\�����Ȃ�
            'MsgBox("�ڑ��G���[���������܂����B�@" & Chr(13) & Chr(13) & _
            '        "�C���^�[�l�b�g�ւ̐ڑ��󋵂��m�F���Ă��������B�@", Clng_Okexb1, TTL)
        End Try
        Return 1
    End Function
#End Region

    ' �X���b�h�����I����ɌĂяo�����R�[���o�b�N�E���\�b�h
    Public Shared Sub MyCallback(ByVal ar As IAsyncResult) ' 
        'MESSAGE_CHECK_FLAG = False

    End Sub

End Class
