#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>�Ǘ��җp�p�X���[�h�o�^��ʃ��W�b�N</summary>
    ''' <remarks></remarks>
    Public Class z0700_Logic
        Inherits Habits.Logic.LogicBase

#Region "�Ǘ��җp�p�X���[�h�o�^"
        ''' <summary>�Ǘ��җp�p�X���[�h�o�^</summary>
        ''' <remarks></remarks>
        Sub updateA_Pwd(ByVal pwd As String)
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()
                param.Add("@pwd", pwd)
                str_sql = "UPDATE A_�V�X�e�� SET �\��3=@pwd"
                rtn = DBA.ExecuteNonQuery(str_sql, param)

                UpDateForSever_System()

                ' �R�~�b�g
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region
    End Class
End Namespace