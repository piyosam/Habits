Imports System
Imports System.Threading
Imports System.Text

Public Class MultiThread

#Region "�f�[�^����M-Auto"
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

    Public Shared Function ThreadMethod(ByVal c As String) As Integer
        Dim logic As Habits.Logic.MultiThread_Logic = New Habits.Logic.MultiThread_Logic
        Dim dt As DataTable = logic.select_ASY
        Dim str_path As String = Nothing
        Dim param As New Habits.DB.DBParameter

        ' �f�[�^�i�[�p�X���擾
        If dt.Rows.Count <> 0 Then
            str_path = dt.Rows(0)("�f�[�^�i�[�p�X��")
        Else
            MsgBox("�f�[�^�i�[�p�X���ݒ肳��Ă��܂���B�@", Clng_Okexb1, TTL)
            a0200_���C��.TimerDataSync.Enabled = True
            Return -1
        End If

        Do
            Try
                ' Z_SQL���s�����f�[�^�擾
                dt = logic.get_SQLHistory

                If dt.Rows.Count = 0 Then
                    ' ���R�[�h�����݂��Ȃ��ꍇ�A�I��
                    Exit Do
                End If

                �A�b�v���[�h�t�@�C���폜()
                '----------------------------
                ' CSV�f�[�^�쐬
                '----------------------------
                My.Computer.FileSystem.WriteAllText((str_path & "\upload_" & sShopcode & ".csv"), dt.Rows(0)(1), True, System.Text.Encoding.GetEncoding("Shift-JIS"))

                '----------------------------
                ' ZIP�t�@�C���쐬
                '----------------------------
                '�쐬����ZIP�t�@�C���̐ݒ�
                Dim zipPath As String = str_path & "\upload_" & sShopcode & ".zip"
                '���k����t�@�C���̐ݒ�
                Dim filePaths As String() = {str_path & "\upload_" & sShopcode & ".csv"}
                'ZipOutputStream�̍쐬
                Dim fos As New java.io.FileOutputStream(zipPath)
                Dim zos As New java.util.zip.ZipOutputStream(fos)
                Dim file As String

                For Each file In filePaths
                    'ZIP�ɒǉ�����Ƃ��̃t�@�C���������肷��
                    Dim f As String = System.IO.Path.GetFileName(file)
                    '�f�B���N�g����ێ����鎞�͎��̂悤�ɂ���
                    'Dim f As String = file.Remove( _
                    '    0, System.IO.Path.GetPathRoot(file).Length)
                    'f = f.Replace("\", "/")
                    Dim ze As New java.util.zip.ZipEntry(f)
                    ze.setMethod(java.util.zip.ZipEntry.DEFLATED)
                    zos.putNextEntry(ze)
                    'FileInputStream�̍쐬
                    Dim fis As New java.io.FileInputStream(file)
                    '������
                    Dim buffer(8191) As System.SByte
                    While True
                        Dim len As Integer = fis.read(buffer, 0, buffer.Length)
                        If len <= 0 Then
                            Exit While
                        End If
                        zos.write(buffer, 0, len)
                    End While
                    '����
                    fis.close()
                    zos.closeEntry()
                Next file

                zos.close()
                fos.close()

                '----------------------------
                ' �t�@�C�����M
                '----------------------------
                Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "DataUpLoad.aspx"

                '���M����f�[�^�i�t�B�[���h���ƒl�̑g�ݍ��킹�j��ǉ�
                Dim filePath As String = str_path & "\upload_" & sShopcode & ".zip"
                Dim fileName As String = System.IO.Path.GetFileName(filePath)
                Dim wc As WebClientEx = New WebClientEx()
                wc.Timeout = 600000

                Dim nvc As System.Collections.Specialized.NameValueCollection = New System.Collections.Specialized.NameValueCollection()

                ''------------------------------------------------
                ''�t�@�C���X�V����
                ''------------------------------------------------
                '���M����f�[�^�i�t�B�[���h���ƒl�̑g�ݍ��킹�j��ǉ�
                nvc.Add("q1", My.Settings.LoginName)        ' ID
                nvc.Add("q2", My.Settings.LoginPassword)    ' Password
                wc.QueryString = nvc

                '�f�[�^�𑗐M���A�܂���M����
                Dim ret As Byte() = wc.UploadFile(url, filePath)
                Dim result As String = Encoding.UTF8.GetString(ret)
                wc.Dispose()

                If result.ToString.StartsWith("1") OrElse result.ToString.StartsWith("3") Then
                    ' ����
                    param.Clear()
                    param.Add("@�����ԍ�", dt.Rows(0)(0))
                    Dim rtn As Integer = logic.delete_SQLHistory(param)
                    UpdateConnectErrorTimes(False)
                Else
                    UpdateConnectErrorTimes(True)
                    Return -1
                End If

            Catch ex As Exception
                '���O�o��
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)
                UpdateConnectErrorTimes(True)
                Return -1
            End Try
            ''�����I�����A�r���I��
            If (FORCED_CLOSE_FLAG) Then
                Exit Do
            End If
        Loop

        Return 1
    End Function
#End Region

#Region "�A�b�v���[�h�t�@�C���̍폜"
    ''' <summary>
    ''' CSV,ZIP�t�@�C���̍폜���s��
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub �A�b�v���[�h�t�@�C���폜()
        Dim str_path As String = Nothing
        Dim dt As DataTable
        Dim logic As Habits.Logic.MultiThread_Logic

        logic = New Habits.Logic.MultiThread_Logic

        dt = logic.select_ASY
        If dt.Rows.Count <> 0 Then
            str_path = dt.Rows(0)("�f�[�^�i�[�p�X��")
        End If

        Try
            Dim fileName1 As String = str_path & "\upload_" & sShopcode & ".zip"
            Dim fileName2 As String = str_path & "\upload_" & sShopcode & ".csv"

            ' FileSystemObject (FSO) �̐V�����C���X�^���X�𐶐�����
            ' �t�@�C�����폜����
            System.IO.File.Delete(fileName1)
            System.IO.File.Delete(fileName2)

        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("�A�b�v���[�h�t�@�C���̍폜�Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                    "�J��Ԃ���������ꍇ�́A�Ǘ��҂ɘA�����Ă������B�@", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

    ' �X���b�h�����I����ɌĂяo�����R�[���o�b�N�E���\�b�h
    Public Shared Sub MyCallback(ByVal ar As IAsyncResult) ' 
        Dim dt As DataTable
        Dim iError As Integer = 0
        Dim logic As Habits.Logic.MultiThread_Logic = New Habits.Logic.MultiThread_Logic
        ACTIVE_NETWORK_FLAG = False

        dt = logic.GetConnectError()
        If dt.Rows.Count > 0 Then
            iError = dt.Rows(0)("�ʐM���G���[��")
            If iError >= CONNECT_ERROR Then
                a0200_���C��.lbl_Connect.Visible = True
            End If
        End If
    End Sub

    ' �ʐM���G���[�񐔍X�V����
    Public Shared Sub UpdateConnectErrorTimes(ByVal bError As Boolean) '
        Dim logic As Habits.Logic.MultiThread_Logic = New Habits.Logic.MultiThread_Logic
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim iError As Integer = 0

        If bError = False Then
            param.Add("@�ʐM���G���[��", 0)
        Else
            dt = logic.GetConnectError()
            If dt.Rows.Count > 0 Then
                iError = dt.Rows(0)("�ʐM���G���[��")
                If iError >= CONNECT_ERROR Then
                    param.Add("@�ʐM���G���[��", (iError))
                Else
                    param.Add("@�ʐM���G���[��", (iError + 1))
                End If
            Else
                param.Add("@�ʐM���G���[��", 1)
            End If
        End If

        logic.UpdateConnectError(param)
    End Sub

End Class
