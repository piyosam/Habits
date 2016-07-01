Namespace My

    ''' <summary>
    ''' ���̃C�x���g�� MyApplication �ɑ΂��ė��p�ł��܂�:
    ''' 
    ''' Startup: �A�v���P�[�V�������J�n���ꂽ�Ƃ��A�X�^�[�g�A�b�v �t�H�[�����쐬�����O�ɔ������܂��B
    ''' Shutdown: �A�v���P�[�V���� �t�H�[�������ׂĕ���ꂽ��ɔ������܂��B���̃C�x���g�́A�ʏ�̏I���ȊO�̕��@�ŃA�v���P�[�V�������I�����ꂽ�Ƃ��ɂ͔������܂���B
    ''' UnhandledException: �n���h������Ă��Ȃ���O���A�v���P�[�V�����Ŕ��������Ƃ��ɔ�������C�x���g�ł��B
    ''' StartupNextInstance: �P��C���X�^���X �A�v���P�[�V�������N������A���ꂪ���ɃA�N�e�B�u�ł���Ƃ��ɔ������܂��B 
    ''' NetworkAvailabilityChanged: �l�b�g���[�N�ڑ����ڑ����ꂽ�Ƃ��A�܂��͐ؒf���ꂽ�Ƃ��ɔ������܂��B
    ''' </summary>
    ''' <remarks></remarks>
    Partial Friend Class MyApplication

        ''' <summary>
        ''' ����������
        ''' </summary>
        ''' <param name="commandLineArgs"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            Return MyBase.OnInitialize(commandLineArgs)
        End Function

        ''' <summary>
        ''' �Q�ڈȍ~�̃C���X�^���X�̏�������
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

            Me.MainForm.Activate()
            Windows.Forms.MessageBox.Show("���ɋN�����Ă��܂��B���̃A�v���P�[�V�����͑��d�N���ł��܂���B", TTL, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)

        End Sub

        ''' <summary> 
        ''' ��������O���L���b�`����
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            '���b�Z�[�W�_�C�A���O��\��
            Call ShowErrorMessage(e.Exception, "�yMyApplication_UnhandledException�ɂ���O�ʒm�ł��B�z")

            ''���O�o�͂���(app.config�ɐݒ���L�q)
            'With My.Application.Log
            '    .DefaultFileLogWriter.Delimiter = ","
            '    .WriteException(e.Exception, _
            '        TraceEventType.Critical, _
            '        "datetime: " & _
            '        My.Computer.Clock.GmtTime.ToString)
            'End With

            FileUtil.WriteLogFile(e.Exception.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            e.ExitApplication = False

        End Sub

        ''' <summary>
        '''  �G���[�_�C�A���O��\������
        ''' </summary>
        ''' <param name="ex">��O</param>
        ''' <param name="extraMessage">��O���b�Z�[�W</param>
        ''' <remarks></remarks>
        Private Shared Sub ShowErrorMessage(ByVal ex As Exception, ByVal extraMessage As String)

            Dim errorMsg As IO.StringWriter = New IO.StringWriter()

            With errorMsg
                .WriteLine(extraMessage & Environment.NewLine)
                .WriteLine("�\�\�\�\�\�\�\�\" & Environment.NewLine)
                .WriteLine("�G���[���������܂����B�Ǘ��҂ɂ��m�点��������" & Environment.NewLine)
                .WriteLine("�y�G���[���e�z" & Environment.NewLine & ex.Message & Environment.NewLine)
                .WriteLine("�y�X�^�b�N�g���[�X�z" & Environment.NewLine & ex.StackTrace)
            End With
            Windows.Forms.MessageBox.Show(errorMsg.ToString, TTL)
        End Sub
    End Class

End Namespace

