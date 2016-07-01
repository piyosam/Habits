'�V�X�e���� �F HABITS
'�T�v�@�@�@ �F
'�����@�@�@ �F ���|�[�g
'�����@�@�@ �F 2010/04/01�@�r�v�i�@�쐬
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module ���|�[�g

    ''' <summary>���|�[�g�o��</summary>
    ''' <param name="vRepName">���|�[�g��</param>
    ''' <param name="vDSName">�f�[�^�\�[�X��</param>
    ''' <param name="vRepData">�f�[�^�\�[�X</param>
    ''' <param name="vDefaultPrinter">True�F�����g���v�����^�[ False: �ݒ肳�ꂽ�v�����^</param>
    ''' <param name="vPrintMode">0:��� / 1:�v���r���[</param>
    ''' <param name="vLandscape">����̌��� True�F�� / False:�c</param>
    ''' <param name="vRawKind">����T�C�Y</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Rep_Print(ByVal vRepName As String, _
                                        ByVal vDSName As String, _
                                        ByVal vRepData As DataTable, _
                                        ByVal vDefaultPrinter As Boolean, _
                                        Optional ByVal vPrintMode As Integer = 0, _
                                        Optional ByVal vLandscape As Boolean = False, _
                                        Optional ByVal vRawKind As Integer = Printing.PaperKind.A4) As Integer

        Dim strRep As String = APP_NAME & "." & vRepName

        ' '' ������[�h
        Dim repUtil As New ReportUtil(vRepName, vDSName, vRepData, vDefaultPrinter, , vLandscape, vRawKind)
        repUtil.SendPrinter()
        repUtil.Dispose()
        repUtil = Nothing

        Rep_Print = 0

    End Function
End Module
