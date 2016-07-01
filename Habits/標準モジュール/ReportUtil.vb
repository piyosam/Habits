Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

'' �y��{�\�[�X�Q�l���z http://msdn.microsoft.com/ja-jp/library/ms251691(VS.80).aspx
'' �y�p���̐ݒ�z       http://www.atmarkit.co.jp/bbs/phpBB/viewtopic.php?topic=47345&forum=7   ��������

''' <summary>���|�[�g�p���[�e�B���e�B�[</summary>
''' <remarks></remarks>
Public Class ReportUtil
    Implements IDisposable

#Region "�ϐ��E�萔"
    Private Const SFWER_SUCCESS As Integer = 0
    Private Const MSG_NOMONITOR As Integer = 0

    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)

    Dim m_RepName As String      '' ���|�[�g��`�t�@�C����
    Dim m_DSName As String       '' �f�[�^�Z�b�g��
    Dim m_RepData As DataTable   '' �f�[�^�e�[�u��
    Dim m_DefaultPrinter As Boolean
    Dim m_Params As List(Of Microsoft.Reporting.WinForms.ReportParameter)    '' �p�����[�^
    Dim m_Landscape As Boolean
    Dim m_RawKind As Integer

    Private m_PrinterName As String = My.Settings.PrinterName        '' �R�}���h�^�C���A�E�g(s)

#End Region

#Region "�R���X�g���N�^"

    ''' <summary>�R���X�g���N�^</summary>
    ''' <param name="vRepName">���|�[�g��`�t�@�C����</param>
    ''' <param name="vDSName">�f�[�^�Z�b�g��</param>
    ''' <param name="vRepData">�f�[�^�e�[�u��</param>
    ''' <param name="vDefaultPrinter">True�F�f�t�H���g�v�����^�ɏo�́AFalse�F�w��̃v�����^�ɏo��</param>
    ''' <param name="vParams">�p�����[�^ ���ȗ����͐ݒ�Ȃ�</param>
    ''' <param name="vLandscape">�p������ ���ȗ����͉�����</param>
    ''' <param name="vRawKind">�p���T�C�Y ���ȗ�����A4</param>
    ''' <remarks></remarks>
    Sub New( _
        ByVal vRepName As String, _
        ByVal vDSName As String, _
        ByVal vRepData As DataTable, _
        ByVal vDefaultPrinter As Boolean, _
        Optional ByVal vParams As List(Of Microsoft.Reporting.WinForms.ReportParameter) = Nothing, _
        Optional ByVal vLandscape As Boolean = True, _
        Optional ByVal vRawKind As Integer = PaperKind.A4 _
    )
        m_RepName = vRepName
        m_DSName = vDSName
        m_RepData = vRepData
        m_DefaultPrinter = vDefaultPrinter
        m_Params = vParams
        m_Landscape = vLandscape
        m_RawKind = vRawKind

    End Sub

#End Region

#Region "Protected Friend SetLandscape���\�b�h / SetRawKind���\�b�h"

    ''' <summary>
    ''' �p���̌�����ݒ肷��
    ''' </summary>
    ''' <param name="vLandscape">True:������ / False:����ȊO(�K��l)</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetLandscape(ByVal vLandscape As Boolean)
        m_Landscape = vLandscape
    End Sub

    ''' <summary>
    ''' �p���̃T�C�Y��ݒ肷��
    ''' </summary>
    ''' <param name="vRawKind">PaperKind�Őݒ肳���l</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetRawKind(ByVal vRawKind As Integer)
        m_RawKind = vRawKind
    End Sub
#End Region

#Region "Public Send���\�b�h"

    ''' <summary>�v�����^�[�ɏo�͂���</summary>
    ''' <param name="printName">�v�����^���@���ȗ����͋K��̃v�����^�ɏo��</param>
    ''' <returns>����������������ۂ��FTrue=������� / False=������s</returns>
    ''' <remarks></remarks>
    Public Function SendPrinter(Optional ByVal printName As String = Nothing) As Boolean
        '' �o�̓f�[�^�����̏ꍇ�A�����𔲂���
        If Not ChkData() Then
            'MessageUtil.ShowMsg(MSGLST.PRINT_NODATE)
            'Exit Function
        End If
        Return PrintMain(m_RepName, m_DSName, m_RepData, m_Params, printName, m_DefaultPrinter)
    End Function

    ''' <summary>ImageWriter(Microsoft Office Document Image Writer)�ɏo�͂���</summary>
    ''' <returns>����������������ۂ��FTrue=������� / False=������s</returns>
    ''' <remarks></remarks>
    Public Function SendImage() As Boolean
        '' �o�̓f�[�^�����̏ꍇ�A�����𔲂���
        If Not ChkData() Then
            'MessageUtil.ShowMsg(MSGLST.PRINT_NODATE)
            'Exit Function
        End If

        Return PrintMain(m_RepName, m_DSName, m_RepData, m_Params, "Microsoft Office Document Image Writer", m_DefaultPrinter)

    End Function

#End Region

#Region "Private ChkData"

    ''' <summary>
    ''' �o�̓f�[�^�`�F�b�N
    ''' </summary>
    ''' <returns>True:�o�̓f�[�^�L�� / False:�o�̓f�[�^����</returns>
    ''' <remarks></remarks>
    Private Function ChkData() As Boolean
        '' �o�̓f�[�^����
        If m_RepData Is Nothing OrElse m_RepData.Rows.Count = 0 Then
            'Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Private ���\�b�h"

#Region "PrintMain / ������C��"

    ''' <summary>������C��</summary>
    ''' <param name="vRepName">���|�[�g��`�t�@�C����</param>
    ''' <param name="vDSName">�f�[�^�Z�b�g��</param>
    ''' <param name="vRepData">�f�[�^�e�[�u��</param>
    ''' <param name="vParams">�p�����[�^ ���ȗ����̓f�[�^�e�[�u�����琶��</param>
    ''' <param name="vPrintSetthings">�v�����^�Z�b�e�B���O�@���ȗ����͋K��̃v�����^�ɏo��</param>
    ''' <returns>����������������ۂ��FTrue=������� / False=������s</returns>
    ''' <remarks></remarks>
    Private Function PrintMain( _
        ByVal vRepName As String, _
        ByVal vDSName As String, _
        ByVal vRepData As DataTable, _
        ByVal vParams As List(Of Microsoft.Reporting.WinForms.ReportParameter), _
        ByVal vPrintSetthings As PrinterSettings _
    ) As Boolean
        Dim report As Microsoft.Reporting.WinForms.LocalReport
        Try
            report = getReport(vRepName, vDSName, vRepData, vParams)

            '' �p���̌����ƃT�C�Y��ݒ肷��
            vPrintSetthings.DefaultPageSettings.Landscape = m_Landscape
            For i As Integer = 0 To vPrintSetthings.PaperSizes.Count - 1
                vPrintSetthings.PaperSizes.Item(i).RawKind = m_RawKind
            Next

            '' EMF�t�@�C������
            Call Export(report)

            m_currentPageIndex = 0

            '' �ʏ�g���v�����^�擾
            If vPrintSetthings Is Nothing Or vPrintSetthings.PrinterName Is String.Empty Then
                Dim pd As New System.Drawing.Printing.PrintDocument
                '�v�����^���̎擾
                vPrintSetthings = CType(pd.PrinterSettings.Clone, PrinterSettings)
                pd = Nothing
            End If

            '' ������s
            Return PrintExec(vPrintSetthings)

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        Finally
            report = Nothing
        End Try

    End Function

    ''' <summary>������C��</summary>
    ''' <param name="vRepName">���|�[�g��`�t�@�C����</param>
    ''' <param name="vDSName">�f�[�^�Z�b�g��</param>
    ''' <param name="vRepData">�f�[�^�e�[�u��</param>
    ''' <param name="vParams">�p�����[�^ ���ȗ����͐ݒ�Ȃ�</param>
    ''' <param name="vPrintName">�v�����^���@���ȗ����͋K��̃v�����^�ɏo��</param>
    ''' <param name="vDefaultPrinter">True�F�f�t�H���g�v�����^�ɏo�́AFalse�F�K��̃v�����^�ɏo��</param>
    ''' <returns>����������������ۂ��FTrue=������� / False=������s</returns>
    ''' <remarks></remarks>
    Private Function PrintMain( _
        ByVal vRepName As String, _
        ByVal vDSName As String, _
        ByVal vRepData As DataTable, _
        ByVal vParams As List(Of Microsoft.Reporting.WinForms.ReportParameter), _
        ByVal vPrintName As String, _
        ByVal vDefaultPrinter As Boolean _
    ) As Boolean
        Dim rds As Microsoft.Reporting.WinForms.ReportDataSource
        Dim report As Microsoft.Reporting.WinForms.LocalReport
        Try
            '' ���|�[�g�f�[�^�\�[�X����
            rds = New Microsoft.Reporting.WinForms.ReportDataSource
            rds.Name = vDSName
            rds.Value = vRepData

            '' ���[�J���ŏ�������ĕ\������郌�|�[�g�𐶐�
            report = New Microsoft.Reporting.WinForms.LocalReport
            report.DataSources.Add(rds)
            report.ReportEmbeddedResource = APP_NAME & "." & vRepName '' APP_NAME = "HabitsProject"
            If Not vParams Is Nothing Then report.SetParameters(vParams)

            report.Refresh()

            '' EMF�t�@�C������
            Call Export(report)

            m_currentPageIndex = 0

            '' �ʏ�g���v�����^�擾
            If vPrintName Is Nothing Or vPrintName Is String.Empty Then


                Dim pd As New System.Drawing.Printing.PrintDocument
                If vDefaultPrinter = True Then
                    '�v�����^���̎擾
                    vPrintName = pd.PrinterSettings.PrinterName

                Else
                    vPrintName = m_PrinterName
                End If

                pd = Nothing
            End If

                '' ������s
                Return PrintExec(vPrintName)

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        Finally
            rds = Nothing
            report = Nothing
        End Try

    End Function
#End Region

#Region "Export / EMF�t�@�C���ϊ�"

    ''' <summary>EMF�t�@�C���ϊ�</summary>
    ''' <param name="report"></param>
    ''' <remarks></remarks>
    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = _
        "<DeviceInfo>" + _
        " <OutputFormat>EMF</OutputFormat>" + _
        "</DeviceInfo>"
        '"  <PageWidth>8.5in</PageWidth>" + _
        '"  <PageHeight>11in</PageHeight>" + _
        '"  <MarginTop>0.25in</MarginTop>" + _
        '"  <MarginLeft>0.25in</MarginLeft>" + _
        '"  <MarginRight>0.25in</MarginRight>" + _
        '"  <MarginBottom>0.25in</MarginBottom>" + _

        Dim warnings() As Warning = Nothing
        m_streams = New List(Of Stream)()

        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub
#End Region

#Region "CreateStream / EMF�t�@�C������"

    ''' <summary>EMF�t�@�C������</summary>
    ''' <param name="name"></param>
    ''' <param name="fileNameExtension"></param>
    ''' <param name="encoding"></param>
    ''' <param name="mimeType"></param>
    ''' <param name="willSeek"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        '' Exe�Ɠ����t�H���_�Ɋg���qemf�̃t�@�C���𐶐�����B��F�u./Sample1_1.emf�v
        Dim sFolder As String = "./emf/"
        If Not Directory.Exists(sFolder) Then Directory.CreateDirectory(sFolder)
        Dim stream As Stream = New FileStream(sFolder + name + "." + fileNameExtension, FileMode.Create)
        m_streams.Add(stream)
        Return stream
    End Function
#End Region

#Region "PrintPage / �y�[�W����"

    ''' <summary>�y�[�W����H</summary>
    ''' <param name="sender"></param>
    ''' <param name="ev"></param>
    ''' <remarks></remarks>
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub
#End Region

#Region "PrintExec / ������s"

    ''' <summary>
    ''' ������s
    ''' </summary>
    ''' <param name="printerSet">�v�����^�[�ݒ�</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PrintExec(ByVal printerSet As PrinterSettings) As Boolean
        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return False
        End If

        '' �v�����^�[�`�F�b�N
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings = printerSet
        If Not printDoc.PrinterSettings.IsValid Then
            'MessageUtil.ShowMsg( _
            '    MessageBoxIcon.Error, _
            '    MessageBoxButtons.OK, _
            '    MessageBoxDefaultButton.Button1, _
            '    printerSet.PrinterName & "�v�����^�[��������܂���ł����B" _
            ')
            Return False
        End If

        '' �v�����^�[�o��
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
        Return True

    End Function

    ''' <summary>������s</summary>
    ''' <param name="printerName">�v�����^�[��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PrintExec(ByVal printerName As String) As Boolean
        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return False
        End If

        '' �v�����^�[�`�F�b�N
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            'MessageUtil.ShowMsg( _
            '    MessageBoxIcon.Error, _
            '    MessageBoxButtons.OK, _
            '    MessageBoxDefaultButton.Button1, _
            '    printerName & "�v�����^�[��������܂���ł����B" _
            ')
            Return False
        End If

        '' �v�����^�[�o��
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
        Return True

    End Function
#End Region


#End Region


#Region "Private GetReport���\�b�h"

    ''' <summary>
    ''' ���|�[�g�𐶐����ĕԂ�
    ''' </summary>
    ''' <param name="vRepName">���|�[�g��</param>
    ''' <param name="vDSName">���|�[�g�f�[�^�\�[�X��</param>
    ''' <param name="vRepData">���|�[�g�f�[�^�\�[�X</param>
    ''' <param name="vParams">�p�����[�^</param>
    ''' <returns>�������|�[�g</returns>
    ''' <remarks></remarks>
    Private Function getReport(ByVal vRepName As String, _
                                 ByVal vDSName As String, _
                                 ByVal vRepData As DataTable, _
                                 ByVal vParams As List(Of ReportParameter) _
                                 ) As LocalReport
        Dim rds As ReportDataSource
        Dim report As LocalReport
        Try
            '' ���|�[�g�f�[�^�\�[�X����
            rds = New ReportDataSource
            rds.Name = vDSName
            rds.Value = vRepData

            '' ���[�J���ŏ�������ĕ\������郌�|�[�g�𐶐�
            report = New LocalReport
            report.DataSources.Add(rds)
            report.ReportEmbeddedResource = APP_NAME & "." & vRepName

            '' �p�����[�^�Z�b�g
            If Not vParams Is Nothing Then
                report.SetParameters(vParams)
            Else
                Dim prm As List(Of ReportParameter) = GetParameters(report, vRepData)
                If Not prm Is Nothing Then report.SetParameters(prm)
            End If

            Return report
        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        End Try
    End Function
#End Region

#Region "Private GetParameters���\�b�h"

    ''' <summary>
    ''' �p�����[�^���f�[�^�\�[�X���琶������
    ''' </summary>
    ''' <param name="vReport">�Ώۃ��|�[�g</param>
    ''' <param name="vRepData">�f�[�^�e�[�u��</param>
    ''' <returns>�p�����[�^ �������ꍇ��Nothing</returns>
    ''' <remarks></remarks>
    Private Function GetParameters(ByVal vReport As Microsoft.Reporting.WinForms.LocalReport, ByVal vRepData As DataTable) _
                                            As List(Of Microsoft.Reporting.WinForms.ReportParameter)

        Try
            Dim Parameters As New List(Of ReportParameter)
            '' �f�[�^�\�[�X���Ȃ��ꍇ
            If vRepData.Rows.Count = 0 Then
                For Each rp As ReportParameterInfo In vReport.GetParameters()
                    Parameters.Add(getParameter(rp.Name, StringUtil.BLANK))
                Next
            Else
                '' ���|�[�g�̃p�����[�^���쐬
                For Each rp As ReportParameterInfo In vReport.GetParameters()
                    If IsDataItemExist(rp.Name, vRepData) Then
                        Parameters.Add(getParameter(rp.Name, vRepData))
                    End If
                Next
            End If

            If Parameters.Count = 0 Then
                Return Nothing
            Else
                Return Parameters
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        End Try
    End Function

    ''' <summary>
    ''' �p�����[�^�쐬
    ''' </summary>
    ''' <param name="vPrmName">�p�����[�^��</param>
    ''' <param name="vRepData">�f�[�^�e�[�u��</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getParameter(ByVal vPrmName As String, ByVal vRepData As DataTable) As ReportParameter
        Return New ReportParameter(vPrmName, CnvUtil.VbStr(vRepData.Rows(0).Item(vPrmName)))
    End Function

    ''' <summary>
    ''' �p�����[�^�쐬
    ''' </summary>
    ''' <param name="vPrmName">�p�����[�^��</param>
    ''' <param name="vDataValue">�p�����[�^���e</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getParameter(ByVal vPrmName As String, ByVal vDataValue As String) As ReportParameter
        Return New ReportParameter(vPrmName, vDataValue)
    End Function

    ''' <summary>
    ''' �f�[�^�\�[�X�J�������݃`�F�b�N
    ''' </summary>
    ''' <param name="vPrmName">�J������</param>
    ''' <param name="vRepData">�f�[�^�e�[�u��</param>
    ''' <returns>True:���݂��� / False:���݂��Ȃ�</returns>
    ''' <remarks></remarks>
    Private Function IsDataItemExist(ByVal vPrmName As String, ByVal vRepData As DataTable) As Boolean
        Try
            Dim obj As Object = vRepData.Rows(0).Item(vPrmName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "�I������"
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        If Not (m_streams Is Nothing) Then
            Dim stream As Stream
            For Each stream In m_streams
                stream.Close()
                '' �t�@�C���폜
                Dim sFileName As String = CType(stream, System.IO.FileStream).Name
                If Not (sFileName Is Nothing OrElse sFileName = String.Empty) Then
                    If File.Exists(sFileName) Then File.Delete(sFileName)
                End If
            Next
            m_streams = Nothing
        End If

    End Sub

    Protected Overrides Sub Finalize()
        Me.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

End Class

Public Class CnvUtil
    ''' <summary>
    ''' Object��String�ɕϊ�
    ''' </summary>
    ''' <param name="obj">�ϊ��Ώ�</param>
    ''' <param name="nullDef">Nothing��Null�̎��ɕԂ��l</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function VbStr(ByVal obj As Object, Optional ByVal nullDef As String = "") As String
        If obj Is Nothing OrElse obj Is DBNull.Value Then Return nullDef
        Return CStr(obj)
    End Function
End Class

Public Class StringUtil
    Public Shared BLANK As String = ""

End Class