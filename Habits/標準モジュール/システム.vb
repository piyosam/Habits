'�V�X�e���� �F HABITS
'�T�v�@�@�@ �F
'�����@�@�@ �F �V�X�e��
'�����@�@�@ �F 2010/04/01�@�r�v�i�@�쐬
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module �V�X�e��

    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    '�T�v �F Sys_Init
    '���� �F �Ȃ�
    '���� �F �V�X�e���J�n���̏�������
    Public Function Sys_Init() As Long

        '' �f�[�^�x�[�X�A�N�Z�X�N���X�����^�ڑ��I�[�v��
        Try
            DBA = New Habits.DB.DBAccess(True)
            DBA2 = New Habits.DB.DBAccess(True)
        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)

            MsgBox("���[�h�����Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
            "PC���ċN�����Ă������G���[����������ꍇ�́@" & Chr(13) & Chr(13) & _
            "�V�X�e���Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
            Return 1
            Exit Function
        End Try

        Try
            '�N����ʂ�\������
            a0100_���[�h��.ShowDialog()

            '' �V�X�e�����t�擾
            USER_DATE = System.DateTime.Today()

            '�ʐM���t���O�A�����ȊO�C���s�t���O�A�ŋ敪�ݒ�
            Dim logicBase As Habits.Logic.LogicBase = New Habits.Logic.LogicBase
            logicBase.setA_SystemVariable()

            ''�t���O������
            ACTIVE_NETWORK_FLAG = False
            FORCED_CLOSE_FLAG = False
            MESSAGE_CHECK_FLAG = False
            MANAGER_MODE = False        '�Ǘ��Ҍ����폜

        Catch ex As Exception
            '���O�o��
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)

            MsgBox("���[�h�����Ɏ��s���܂����B�@" & Chr(13) & Chr(13) & _
                        "PC���ċN�����Ă������G���[����������ꍇ�́@" & Chr(13) & Chr(13) & _
                        "�V�X�e���Ǘ��҂ɘA�����Ă��������B�@", Clng_Okexb1, TTL)
            rtn = 2
            Sys_Exit()
        End Try
    End Function

    '�T�v �F Sys_Exit
    '���� �F �Ȃ�
    '���� �F �V�X�e���I�����̏I������
    Public Function Sys_Exit() As Long
        Try
            If (ACTIVE_NETWORK_FLAG) Then
                FORCED_CLOSE_FLAG = True
                MsgBox("�f�[�^���M���̂��߁A���΂炭���҂����������B�@", Clng_Okexb1, TTL)
                While (ACTIVE_NETWORK_FLAG)
                    Sleep(10000)
                End While
            End If

            MANAGER_MODE = False        '�Ǘ��Ҍ�������

            '' �f�[�^�x�[�X�ڑ��N���[�Y
            DBA.Close()
            '' �f�[�^�x�[�X�A�N�Z�X�N���X�j��
            DBA.Dispose()
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    '�T�v �F Sys_Error
    '���� �F str_ErrMsg ,In ,string  ,�G���[���b�Z�[�W
    '�@�@ �F con_Target ,In ,control ,��ѐ�
    '���� �F �G���[���b�Z�[�W���o�͂��A�Y���R���g���[���ֈʒu�t����
    Public Sub Sys_Error(ByVal str_ErrMsg As String, ByVal con_Target As Object)

        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep())
        rtn = MsgBox(str_ErrMsg, Clng_Okinb1, TTL)
        con_Target.Focus()
    End Sub

    '�T�v �F Sys_Trap
    '���� �F str_Fname  ,In ,string ,�t�H�[����
    '�@�@ �F str_Mname  ,In ,string ,���W���[����
    '�@�@ �F str_Reason ,In ,string ,���R
    '���� �F �_���G���[�������̏���
    Public Sub Sys_Trap(ByVal str_Fname As String, ByVal str_Mname As String, ByVal str_Reason As String)

        rtn = MsgBox("�_���G���[���������܂����B�@" & Chr(13) & _
                     "�ȉ��̏���S���҂ɘA�����Ă��������B�@" & Chr(13) & Chr(13) & _
                     "�@�t�H�[�����@�F�@" & str_Fname & Chr(13) & _
                     "���W���[�����@�F�@" & str_Mname & Chr(13) & _
                     "�@�@�@�@���R�@�F�@" & str_Reason, Clng_Okcrb1, TTL)
    End Sub

    '�T�v �F Sys_InputCheck
    '���� �F var_Check     ,In ,Variant ,�Ώە�����
    '�@�@ �F int_Length    ,In ,Integer ,�ő咷
    '�@�@ �F str_Type      ,In ,string  ,�^�C�v�iA�F���p�p���J�i, N�F����, N+�F����(0�ȏ�), K�F�S�p����, M�F�S�p�E���p����, D�F���t,
    '�@�@ �F �@�@�@�@�@       Fn�F�����_���l(n�͏����_�ȉ��̌����A�ő咷�͏����_�y�я����_�ȉ��܂�)�j
    '�@�@ �F int_Operation ,In ,Integer ,�K�{�i0�FNOP, 1�FCHECK�j
    '���� �F
    Public Function Sys_InputCheck(ByVal var_Check As Object, ByVal int_Length As Integer, ByVal str_Type As String, ByVal int_Operation As Integer) As Boolean

        Dim intDec As Integer

        If (int_Operation = 1) Then    'Operation����
            Sys_InputCheck = True
        Else
            Sys_InputCheck = False
        End If

        If (var_Check.ToString = "") Then Exit Function

        If (Sys_Len(var_Check) = 0) Then Exit Function

        If (int_Operation = 0) Then    'Operation����
            Sys_InputCheck = True
        End If

        If (int_Length = 0) Then Exit Function

        Select Case Left(str_Type, 1)

            Case "A"    '���p�p���J�i

                If (Sys_Len(var_Check) > int_Length) Then Exit Function
                If (Sys_Zenkaku(var_Check)) Then Exit Function

            Case "N"    '����

                If (Sys_Len(var_Check) > int_Length) Then Exit Function
                If Not (IsNumeric(var_Check)) Then Exit Function

                If (InStr(1, var_Check, ".", vbTextCompare) > 0) Then Exit Function '�����_�`�F�b�N

                If String.Equals(str_Type, "N+") Then
                    If (CDec(var_Check) < CDec(0)) Then Exit Function '�����`�F�b�N
                End If

            Case "K"    '�S�p����

                If (Sys_Len(var_Check) > int_Length * 2) Then Exit Function

            Case "M"    '�S�p�E���p����

                If (Len(var_Check) > int_Length) Then Exit Function

            Case "D"    '���t

                If Not (IsDate(var_Check)) Then Exit Function

            Case "F"    '�����_���l

                If (Sys_Len(var_Check) > int_Length) Then Exit Function
                If Not (IsNumeric(var_Check)) Then Exit Function

                intDec = InStr(1, var_Check, ".", vbTextCompare)    '�����_�ʒu
                ' �����_�Ȃ�����
                If (intDec > 0 AndAlso (Len(var_Check) - intDec) > CInt(Right(str_Type, 1))) Then Exit Function

            Case Else    '�p�����[�^�G���[

                Exit Function
        End Select

        Sys_InputCheck = False

    End Function

    '�T�v �F Sys_InputCheck_Date
    '���� �F var_Check     ,In ,Variant ,�Ώە�����
    '�@�@ �F err_Msg      ,Out ,String  ,�G���[���b�Z�[�W���e
    '���� �F
    Public Function Sys_InputCheck_Date(ByVal var_Check As Object, ByRef err_Msg As String) As Boolean
        Sys_InputCheck_Date = False

        If String.IsNullOrEmpty(var_Check) Then
            err_Msg = "�͕K�{���͂ł��B�@"
            Exit Function
        End If
        If Sys_Zenkaku(var_Check) Then
            err_Msg = "�͔��p�œ��͂��Ă��������B�@"
            Exit Function
        End If
        If Sys_InputCheck(var_Check, 10, "D", 1) Then
            err_Msg = "��YYYY/MM/DD�`���œ��͂��Ă��������B�@"
            Exit Function
        End If
        If Date.Parse(var_Check) < Date.Parse(Min_Date) Then
            err_Msg = "��" & Min_Date & "�ȍ~�œ��͂��Ă��������B�@"
            Exit Function
        End If
        Sys_InputCheck_Date = True

    End Function

    '�T�v �F Sys_InputCheck_Month
    '���� �F var_Check     ,In ,Variant ,�Ώە�����
    '�@�@ �F err_Msg      ,Out ,String  ,�G���[���b�Z�[�W���e
    '���� �F
    Public Function Sys_InputCheck_Month(ByVal var_Check As Object, ByRef err_Msg As String) As Boolean
        Sys_InputCheck_Month = False

        If String.IsNullOrEmpty(var_Check) Then
            err_Msg = "�͕K�{���͂ł��B�@"
            Exit Function
        End If
        If Sys_Zenkaku(var_Check) Then
            err_Msg = "�͔��p�œ��͂��Ă��������B�@"
            Exit Function
        End If
        If Sys_InputCheck(var_Check, 10, "D", 1) Then
            err_Msg = "��YYYY/MM�`���œ��͂��Ă��������B�@"
            Exit Function
        End If
        Sys_InputCheck_Month = True

    End Function

    '�T�v �F Sys_Len
    '���� �F str_Check ,In ,Variant ,�Ώە�����
    '���� �F ��������Ԃ�
    Public Function Sys_Len(ByVal str_Check As Object) As Long

        Sys_Len = 0
        If str_Check.ToString = "" Then Exit Function
        Sys_Len = str_Check.ToString.Length

    End Function

    '�T�v �F Sys_Zenkaku
    '���� �F str_Check    ,In  ,Variant ,�Ώە�����
    '�@�@ �F Sys_Zenkaku ,In  ,Boolean ,�iFalse�F��, True�F�L�j
    '���� �F �S�p�����̗L�����`�F�b�N����
    Public Function Sys_Zenkaku(ByVal str_Check As Object) As Boolean

        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Sys_Zenkaku = False

        If SJIS.GetByteCount(str_Check.ToString()) <> str_Check.ToString().Length Then
            Sys_Zenkaku = True
        End If
    End Function

    ''' <summary>�w�肳�ꂽ�R���g���[���z���̃e�L�X�g�{�b�N�X�̒l���N���A����B�i�ċA�j</summary>
    ''' <param name="v_control"></param>
    ''' <remarks></remarks>
    Public Sub Sys_ClearTextBox(ByVal v_control As System.Windows.Forms.Control)
        Dim o As System.Windows.Forms.Control
        For Each o In v_control.Controls
            If o.GetType Is GetType(System.Windows.Forms.TextBox) Then
                o.Text = ""
            End If
            If o.Controls.Count > 0 Then
                Call Sys_ClearTextBox(o)
            End If
        Next
    End Sub

    '�T�v �F Sys_Lock
    '���� �F con_Target ,In ,Control ,���b�N����R���g���[��
    '���� �F �w�肳�ꂽ�R���g���[�������b�N����
    Public Sub Sys_Lock(ByVal con_Target As Object)

        con_Target.Enabled = False
        con_Target.Locked = True

    End Sub

#Region "����ŎZ�o"
    '�T�v �F Sys_Tax
    '���� �F var_Charge   ,In ,variant ,���z
    '�@�@ �F var_BaseDate ,In ,variant ,���
    '�@�@ �F var_Total ,In ,variant ,�ō����i����Z�o�̏ꍇ�F1�A����ȊO�F0
    '���� �F �{�̉��i�܂��͐ō����i������Ŋz���v�Z����
    Public Function Sys_Tax(ByVal var_Charge As Object, ByVal var_BaseDate As Object, ByVal var_Total As Object) As Decimal

        Dim i As Integer
        Dim total As Integer = 100

        Sys_Tax = 0

        If IsDBNull(var_Charge) OrElse IsDBNull(var_BaseDate) OrElse var_Charge = 0 Then Exit Function

        Dim BSZ As New DataTable ' B_�����
        Dim str_sql As String

        Try
            str_sql = "SELECT * FROM B_����� ORDER BY �{�s�� DESC"
            BSZ = DBA.ExecuteDataTable(str_sql)
        Catch ex As Exception
            Throw ex
        End Try
        For i = 0 To (BSZ.Rows.Count - 1) Step +1
            If (var_BaseDate >= (BSZ.Rows(i)("�{�s��").ToString)) Then
                '�ō����i����̎Z�o�̏ꍇ
                If var_Total = 1 Then
                    total = total + BSZ.Rows(i)("�ŗ�").ToString
                End If

                Select Case iTaxtype
                    Case 1 ' �؂�̂�
                        Sys_Tax = Math.Floor(var_Charge * BSZ.Rows(i)("�ŗ�").ToString / total)

                    Case 2 ' �l�̌ܓ�
                        Sys_Tax = Int((var_Charge * BSZ.Rows(i)("�ŗ�").ToString / total) + 0.5)

                    Case 3 ' �؂�グ
                        Sys_Tax = Math.Ceiling(var_Charge * BSZ.Rows(i)("�ŗ�").ToString / total)

                    Case Else
                        '�G���[
                        Sys_Tax = Math.Ceiling(var_Charge * BSZ.Rows(i)("�ŗ�").ToString / total)
                End Select
                Exit For
            End If
        Next i
    End Function
#End Region

#Region "�T�[�r�X���z�Z�o"
    '�T�v �F Sys_Service
    '���� �F var_Charge   ,In ,variant ,���z
    '���� �F �T�[�r�X���z���v�Z����
    Public Function Sys_Service(ByVal var_Charge As Object) As Decimal
        Sys_Service = 0

        If IsDBNull(var_Charge) OrElse var_Charge = 0 Then Exit Function
        Select Case iServicetype
            Case 1 ' �؂�̂�
                Sys_Service = Math.Floor(var_Charge)

            Case 2 ' �l�̌ܓ�
                Sys_Service = Math.Round(var_Charge, MidpointRounding.AwayFromZero)

            Case 3 ' �؂�グ
                Sys_Service = Math.Ceiling(var_Charge)

            Case Else
                ' �G���[
                Sys_Service = Math.Ceiling(var_Charge)
        End Select
    End Function
#End Region

#Region "�����J�n���擾"
    '�T�v �F getMonthlyStartDate
    '���� �F var_BaseDate ,In ,variant ,���
    '���� �F ����������錎���J�n�����v�Z����
    Public Function getMonthlyStartDate(ByVal var_BaseDate As Object) As Date
        Dim baseLogic As Habits.Logic.LogicBase
        baseLogic = New Habits.Logic.LogicBase

        Dim dt As DataTable
        Dim start As Integer = 1
        Dim base As Integer = DatePart("d", var_BaseDate)

        Try
            '' �����J�n���擾
            dt = baseLogic.A_System()
            If dt.Rows.Count > 0 Then
                start = dt.Rows(0)("�����J�n��").ToString()
            End If

            If start > base Then
                getMonthlyStartDate = DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate) - 1, start)
            Else
                getMonthlyStartDate = DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate), start)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "�������擾"
    '�T�v �F Sys_Startdate
    '���� �F var_BaseDate ,In ,variant ,���
    '���� �F ����������錎��1�����v�Z����
    Public Function Sys_StartDate(ByVal var_BaseDate As Object) As Date

        Sys_StartDate = DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate), 1)

    End Function
#End Region

#Region "�������擾"
    '�T�v �F Sys_Enddate
    '���� �F var_BaseDate ,In ,variant ,���
    '���� �F ����������錎�̖������v�Z����
    Public Function Sys_EndDate(ByVal var_BaseDate As Object) As Date

        Sys_EndDate = DateAdd("m", 1, DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate), 1))
        Sys_EndDate = DateAdd("d", -1, Sys_EndDate)

    End Function
#End Region

#Region "���l�L�[�̂ݓ��͉ݒ�"
    ''' <summary>
    ''' ���l�L�[�̂ݓ��͉ݒ�
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Sys_KeyPressNumeric(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "COM�I�u�W�F�N�g���J��"
    ''' <summary>
    ''' COM�I�u�W�F�N�g���J��
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub MRComObject(ByRef obj As Object)
        If Not obj Is Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        obj = Nothing
        GC.Collect()
    End Sub
#End Region

End Module
