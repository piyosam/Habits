#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�ڋq��ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class h0300_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>�ڋq���ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�ԍ�������/@�ԍ�������</param>
        ''' <param name="num">�\������</param>
        ''' <param name="regKbn">�o�^�敪</param>
        ''' <param name="prevFlag">True:�i�ރ{�^�������AFalse�F�߂�{�^������</param>
        ''' <returns>�ڋq��񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customerinfo(ByVal v_param As Habits.DB.DBParameter, ByVal num As Integer, ByVal regKbn As String, ByVal prevFlag As Boolean) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT TOP ")
                builSQL.Append(num)
                builSQL.Append(" D_�ڋq.�ڋq�ԍ� AS �ԍ�, D_�ڋq.�� + '  ' + ISNULL(D_�ڋq.��,'') AS ���� ,")
                builSQL.Append(" D_�ڋq.���J�i + '  ' + ISNULL(D_�ڋq.���J�i,'') AS �J�i,")
                builSQL.Append(" B_����.���� ,D_�ڋq.���N����, D_�ڋq.�X�֔ԍ� AS '��', D_�ڋq.�s���{��,")
                builSQL.Append(" ISNULL(D_�ڋq.�Z��1,'') + ISNULL(D_�ڋq.�Z��2,'') + ISNULL(D_�ڋq.�Z��3,'') AS �Z��,")
                builSQL.Append(" D_�ڋq.�d�b�ԍ�, D_�ڋq.Email�A�h���X")
                builSQL.Append(" FROM D_�ڋq")
                builSQL.Append(" LEFT JOIN B_���� ON D_�ڋq.���ʔԍ� = B_����.���ʔԍ�")
                builSQL.Append(" WHERE ")

                '�i�ރ{�^���A�߂��{�^����������
                If prevFlag = True Then
                    builSQL.Append(" D_�ڋq.�ڋq�ԍ� >= @�����J�n�ԍ� ")
                    builSQL.Append(" AND D_�ڋq.�ڋq�ԍ� <= @�����I���ԍ� ")
                Else
                    builSQL.Append(" D_�ڋq.�ڋq�ԍ� < @�����J�n�ԍ� ")
                End If

                '�o�^�敪�ݒ�
                If regKbn <> "" Then
                    builSQL.Append(" AND D_�ڋq.�o�^�敪�ԍ� = ")
                    builSQL.Append(regKbn)
                End If

                '�i�ރ{�^���A�߂��{�^����������
                If prevFlag = True Then
                    builSQL.Append(" ORDER BY D_�ڋq.�ڋq�ԍ�")
                Else
                    builSQL.Append(" ORDER BY D_�ڋq.�ڋq�ԍ� DESC ")
                End If

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�ŏ��A�ő�ڋq�ԍ��擾</summary>
        ''' <returns>�ŏ��A�ő�ڋq�ԍ�</returns>
        ''' <remarks></remarks>
        Protected Friend Function selectMinMaxCustomerId() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT")

                builSQL.Append(" ISNULL(�ŏ��ڋq�ԍ�,0) AS �ŏ��ڋq�ԍ�, ISNULL(�ő�ڋq�ԍ�,0) AS �ő�ڋq�ԍ�,")
                builSQL.Append(" ISNULL(�ŏ��ڋq�ԍ�_���o�^,0) AS �ŏ��ڋq�ԍ�_���o�^, ISNULL(�ő�ڋq�ԍ�_���o�^,0) AS �ő�ڋq�ԍ�_���o�^,")
                builSQL.Append(" ISNULL(�ŏ��ڋq�ԍ�_�o�^��,0) AS �ŏ��ڋq�ԍ�_�o�^��, ISNULL(�ő�ڋq�ԍ�_�o�^��,0) AS �ő�ڋq�ԍ�_�o�^��")
                builSQL.Append(" FROM")
                builSQL.Append(" (SELECT MIN(�ڋq�ԍ�) AS �ŏ��ڋq�ԍ�,MAX(�ڋq�ԍ�) AS �ő�ڋq�ԍ� FROM D_�ڋq WHERE �ڋq�ԍ� < @�t���[�ڋq�ԍ�) AS A")
                builSQL.Append(" ,(SELECT MIN(�ڋq�ԍ�) AS �ŏ��ڋq�ԍ�_���o�^,MAX(�ڋq�ԍ�) AS �ő�ڋq�ԍ�_���o�^ FROM D_�ڋq WHERE �o�^�敪�ԍ� = '0' AND �ڋq�ԍ� < @�t���[�ڋq�ԍ�) AS B")
                builSQL.Append(" ,(SELECT MIN(�ڋq�ԍ�) AS �ŏ��ڋq�ԍ�_�o�^��,MAX(�ڋq�ԍ�) AS �ő�ڋq�ԍ�_�o�^�� FROM D_�ڋq WHERE �o�^�敪�ԍ� = '1' AND �ڋq�ԍ� < @�t���[�ڋq�ԍ�) AS C")
                param.Add("@�t���[�ڋq�ԍ�", Clng_STFreeNo)

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>�o�^�敪�ꗗ�擾</summary>
        ''' <returns>�o�^�敪���X�g</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Dim dt As New DataTable
            Dim dt_rtn As New DataTable
            Dim i As Integer
            dt_rtn.Columns.Add("�o�^�敪�ԍ�")
            dt_rtn.Columns.Add("�o�^�敪")

            dt_rtn.Rows.Add("", "�S��")
            dt = MyBase.B_�o�^�敪()
            If dt.Rows.Count <> 0 Then
                i = 0
                While i < dt.Rows.Count
                    dt_rtn.Rows.Add(dt.Rows(i)("�o�^�敪�ԍ�"), dt.Rows(i)("�o�^�敪"))
                    i += 1
                End While
            End If


            Return dt_rtn
        End Function

    End Class
End Namespace
