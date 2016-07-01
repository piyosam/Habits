Imports System.IO
Imports System.Text

''' <summary>
''' �t�@�C���p�N���X
''' </summary>
''' <remarks></remarks>
Public Class FileUtil

#Region "�ϐ��E�萔"

    Public Enum OutPutType
        Normal = 0
        Daily = 1
        Weekly = 2
    End Enum

#End Region

#Region "���\�b�h"

#Region "�t�@�C���o��"
    ''' <summary>
    ''' �t�@�C���o��
    ''' </summary>
    ''' <param name="vContents">�o�͓��e</param>
    ''' <param name="vPath">�o�͐�p�X</param>
    ''' <param name="vType">�C�x���g</param>
    ''' <param name="vOutput">�o�̓��[�h</param>
    ''' <param name="vFileName">�o�̓t�@�C����</param>
    ''' <param name="vOverType">�㏑������(True: �㏑������/False:�㏑�����Ȃ�/Default�F�㏑�����Ȃ�)</param>
    ''' <returns>�o�͌���(True: ����/False: ���s)</returns>
    ''' <remarks></remarks>
    Public Shared Function WriteLogFile(ByVal vContents As String, ByVal vPath As String, _
        Optional ByVal vType As TraceEventType = TraceEventType.Warning, _
        Optional ByVal vOutput As OutPutType = OutPutType.Normal, _
        Optional ByVal vFileName As String = Nothing, _
        Optional ByVal vOverType As Boolean = False) As Boolean

        Dim filePath As String
        Dim filename As String

        Try
            '�o�͐�p�X�̍Ō��\ + log\ ������
            If vPath.Substring(vPath.Length - 1) <> "\" Then vPath = vPath & "\"
            vPath = vPath & "log\"

            '�f�B���N�g�������݂��Ȃ��ꍇ�쐬����
            chkDir(vPath)

            '�o�͐�p�X�̗L��
            If Directory.Exists(vPath) = True Then

                Dim logdate As DateTime = DateTime.Now      '���ݎ���
                Dim sb As New StringBuilder                 '�o�͓��e
                Dim typestring As String

                Select Case vType
                    Case TraceEventType.Critical : typestring = "Critical"
                    Case TraceEventType.Error : typestring = "Error"
                    Case TraceEventType.Information : typestring = "Information"
                    Case Else : typestring = "Warning"
                End Select
                '�������ݓ��e
                sb.Append(logdate.ToString("yyyy/MM/dd HH:mm:ss") & ": ")   '���ݓ���:
                sb.Append(typestring & ",")                                 '���e�w�b�_
                sb.Append(vContents)                                        '���e
                sb.Append(ControlChars.NewLine)                             '���s

                If vOutput = OutPutType.Normal Then
                    '�V�K�쐬���[�h
                    If String.IsNullOrEmpty(vFileName) = True Then Return False
                    filePath = vPath & vFileName
                    '�㏑��
                    If vOverType = False Then
                        If File.Exists(filePath) = True Then Return False
                    End If
                    '�t�@�C����������
                    File.WriteAllText(filePath, sb.ToString)
                Else
                    '�ǉ����[�h
                    Select Case vOutput
                        Case OutPutType.Daily
                            filename = logdate.ToString("yyyyMMdd") & ".log"
                        Case OutPutType.Weekly
                            Dim diff As Double
                            Dim diffE As Double
                            Select Case logdate.DayOfWeek
                                Case DayOfWeek.Sunday : diff = 0 : diffE = 6
                                Case DayOfWeek.Monday : diff = -1 : diffE = 5
                                Case DayOfWeek.Tuesday : diff = -2 : diffE = 4
                                Case DayOfWeek.Wednesday : diff = -3 : diffE = 3
                                Case DayOfWeek.Thursday : diff = -4 : diffE = 2
                                Case DayOfWeek.Friday : diff = -5 : diffE = 1
                                Case DayOfWeek.Saturday : diff = -6 : diffE = 0
                            End Select
                            Dim weekly As Date = logdate.AddDays(diff)
                            Dim weeklyE As Date = logdate.AddDays(diffE)
                            filename = weekly.ToString("yyyyMMdd") & "-" & weeklyE.ToString("MMdd") & ".log"
                        Case Else
                            If String.IsNullOrEmpty(vFileName) = True Then Return False
                            filename = vFileName
                    End Select
                    filePath = vPath & filename

                    '�ǉ����[�h�t�@�C����������
                    File.AppendAllText(filePath, sb.ToString, System.Text.Encoding.GetEncoding("Shift_Jis"))
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region

#Region "�t�@�C���o�́i����f�[�^�X�V���O�j"
    ''' <summary>
    ''' �t�@�C���o�́i����f�[�^�X�V���O�j
    ''' </summary>
    ''' <param name="vContents1">�o�͓��e1</param>
    ''' <param name="vContents2">�o�͓��e2</param>
    ''' <param name="vTableName">�e�[�u����</param>
    ''' <param name="vType">�C�x���g</param>
    ''' <returns>�o�͌���(True: ����/False: ���s)</returns>
    ''' <remarks></remarks>
    Public Shared Function WriteDataHistoryLogFile(ByVal vContents1 As DataTable, ByVal vContents2 As DataTable, _
        Optional ByVal vTableName As String = Nothing, _
        Optional ByVal vType As String = Nothing) As Boolean

        Dim logdate As DateTime = DateTime.Now                      '���ݎ���
        Dim vPath As String = My.Settings.LogPath
        Dim startDate As DateTime = getMonthlyStartDate(logdate)
        Dim filePath As String = vPath & "HabitsHistory" & startDate.AddMonths(1).AddDays(-1).ToString("yyyyMM") & ".csv"

        Try
            '�o�͐�p�X�̗L��
            If Directory.Exists(vPath) = True Then

                Dim sb As New System.Text.StringBuilder                     '�o�͓��e
                Dim typestring As String = ""
                Dim contents As String = ""
                '�������ݓ��e
                contents = logdate.ToString("yyyy/MM/dd HH:mm:ss") & ",���X��,���X�Ҕԍ�,�ڋq�ԍ�,�ڋq��,��S���Җ�,���㍇�v�i�Ŕ��j"

                sb.Append(contents)                                         '�w�b�_
                sb.Append(ControlChars.NewLine)                             '���s

                contents = edtContents(vContents1)
                sb.Append("�ύX�O," & contents)                             '�X�V�O���R�[�h
                sb.Append(ControlChars.NewLine)                             '���s
                contents = edtContents(vContents2)
                sb.Append("�@�@��," & contents)                             '�X�V�ヌ�R�[�h
                sb.Append(ControlChars.NewLine)                             '���s

                '�t�@�C����������
                Dim Writer As New IO.StreamWriter(filePath, True, System.Text.Encoding.UTF8)
                Writer.WriteLine(sb.ToString)

                Writer.Close()

            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region

#Region "�f�[�^�x�[�X���e���J���}��؂蕶���ɕҏW"
    Private Shared Function edtContents(ByVal dt As DataTable) As String
        Dim rtn As String = ""
        Dim i As Integer = 0
        If Not dt Is Nothing _
            AndAlso dt.Rows.Count > 0 _
            AndAlso dt.Columns.Count > 0 Then
            For i = 0 To dt.Columns.Count - 1
                If i > 0 Then
                    rtn &= ","
                End If
                rtn &= dt.Rows(0).Item(i).ToString()
            Next
        End If
        Return rtn
    End Function
#End Region

#Region "�t�@�C�����擾"
    ''' <summary>
    ''' �t�@�C�����擾
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFilename(ByVal path As Object) As String
        Dim i As Integer
        Dim fnm As String

        '** �t�@�C�����؂�o��
        fnm = LCase(Trim(path))
        If Strings.Right(fnm, 1) = "\" Then
            GetFilename = ""
        Else
            For i = Len(fnm) To 1 Step -1
                If Mid(fnm, i, 1) = "\" Then Exit For
            Next
            If i > 0 Then
                GetFilename = Strings.Right(fnm, Len(fnm) - i)
            Else
                For i = 1 To Len(fnm)
                    If Mid(fnm, i, 1) = ":" Then Exit For
                Next
                If i < Len(fnm) Then
                    GetFilename = Strings.Right(fnm, Len(fnm) - i)
                Else
                    GetFilename = ""
                End If
            End If
        End If
    End Function
#End Region

#Region "�f�B���N�g���쐬"

    ''' <summary>
    ''' �f�B���N�g���쐬
    ''' </summary>
    ''' <param name="strDir"></param>
    ''' <remarks>�f�B���N�g�������݂��Ȃ��ꍇ�A�f�B���N�g�����쐬</remarks>
    Public Shared Sub chkDir(ByVal strDir As String)
        If Not System.IO.Directory.Exists(strDir) Then
            MkDir(strDir)
        End If
    End Sub

#End Region

#End Region

End Class

