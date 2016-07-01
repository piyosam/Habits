'�V�X�e���� �F HABITS
'�T�v�@�@�@ �F
'�����@�@�@ �F �e�[�u��
'�����@�@�@ �F 2010/04/01�@�r�v�i�@�쐬
'�o�[�W���� �F Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module �e�[�u��

    '�T�v �F DataTable��Select���ʂ̗L����Ԃ�
    '���� �F dataTable ,In ,DataTable  ,�f�[�^
    '�@�@�@�@filterExpression ,In ,String   ,������
    '���� �F DataTable��Select���A���ʂ�1���ȏ�Ȃ�True��Ԃ�
    Public Function DataTableSelect(ByRef dataTable As DataTable, ByVal filterExpression As String) As Boolean

        Dim dr() As DataRow

        dr = dataTable.Select(filterExpression)

        If dr.Length > 0 Then
            DataTableSelect = True
        Else
            DataTableSelect = False
        End If
    End Function

    '�T�v �F GetNextSequence
    '���� �F dataTable ,In ,DataTable  ,�f�[�^
    '        columnName ,In ,String  ,�񖼁i���l�^�j
    '        columnName ,In ,String  ,�񖼁i���l�^�j
    '���� �F �w�肵�����l�^�̗�̍ő�l+1��Ԃ�
    Public Function GetNextSequence(ByRef dataTable As DataTable, ByVal columnName As String, _
        Optional ByVal defaultSauence As Integer = 1) As Integer

        Dim nums As Integer() = New Integer() {}
        Dim tmp As Object
        Dim index As Integer
        Dim NextSeqence As Integer

        '���l��̍쐬
        index = 0
        For i As Integer = 0 To dataTable.Rows.Count - 1
            Do
                tmp = dataTable.Rows(i).Item(columnName)
                If IsDBNull(tmp) Then Exit Do
                If Not IsNumeric(tmp) Then Exit Do

                ReDim Preserve nums(index)
                nums(index) = tmp
                index = index + 1
            Loop Until True
        Next

        If nums.Length <= 0 Then
            GetNextSequence = defaultSauence
            Exit Function
        End If

        '���l����\�[�g
        Array.Sort(nums)

        '���̘A��(�ő�l+1)���擾
        NextSeqence = nums(nums.Length - 1) + 1
        GetNextSequence = NextSeqence
    End Function
End Module
