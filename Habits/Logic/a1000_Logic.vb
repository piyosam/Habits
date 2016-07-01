#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>���[�U����ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class a1000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1000_���[�U�[���"

        ''' <summary>A_�V�X�e���擾</summary>
        ''' <returns>�V�X�e�����</returns>
        ''' <remarks></remarks>
        Protected Friend Function getA_System() As DataTable
            Return MyBase.A_System()
        End Function

        ''' <summary>A_�V�X�e���X�V</summary>
        ''' <param name="v_param">
        ''' �p�����[�^�F@�X��1/@�X��2/@��\�Җ�/@�X�X�֔ԍ�/@�X�Z��1/@�X�Z��2
        ''' @�X�d�b�ԍ�/@�XFAX�ԍ�/@�ݔ��䐔/@���W���z/@�s���{��/@�s�撬��/@�ύX����/@�����J�n��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function updateA_System(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE A_�V�X�e�� SET")
                builSQL.Append(" �X��1 = @�X��1")
                builSQL.Append(", �X��2 = @�X��2")
                builSQL.Append(", ��\�Җ� = @��\�Җ�")
                builSQL.Append(", �X�X�֔ԍ� = @�X�X�֔ԍ�")
                builSQL.Append(", �X�Z��1 = @�X�Z��1")
                builSQL.Append(", �X�Z��2 = @�X�Z��2")
                builSQL.Append(", �X�d�b�ԍ� = @�X�d�b�ԍ�")
                builSQL.Append(", �XFAX�ԍ� = @�XFAX�ԍ�")
                builSQL.Append(", �ݔ��䐔 = @�ݔ��䐔")
                builSQL.Append(", ���W���z = @���W���z")
                builSQL.Append(", �s���{�� = @�s���{��")
                builSQL.Append(", �s�撬�� = @�s�撬��")
                builSQL.Append(", �ύX���� = @�ύX����")
                builSQL.Append(", �����J�n�� = @�����J�n��")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE system SET")
                builSQL.Append(" shop_name1 =" & VbSQLNStr(v_param.GetValue("@�X��1")))
                builSQL.Append(", shop_name2 =" & VbSQLNStr(v_param.GetValue("@�X��2")))
                builSQL.Append(", manager =" & VbSQLNStr(v_param.GetValue("@��\�Җ�")))
                builSQL.Append(", post_code =" & VbSQLNStr(v_param.GetValue("@�X�X�֔ԍ�")))
                builSQL.Append(", address1 =" & VbSQLNStr(v_param.GetValue("@�X�Z��1")))
                builSQL.Append(", address2 =" & VbSQLNStr(v_param.GetValue("@�X�Z��2")))
                builSQL.Append(", phone =" & VbSQLNStr(v_param.GetValue("@�X�d�b�ԍ�")))
                builSQL.Append(", fax =" & VbSQLNStr(v_param.GetValue("@�XFAX�ԍ�")))
                builSQL.Append(", accommodated_count =" & VbSQLStr(v_param.GetValue("@�ݔ��䐔")))
                builSQL.Append(", register_amount =" & VbSQLStr(v_param.GetValue("@���W���z")))
                builSQL.Append(", prefectures_name =" & VbSQLNStr(v_param.GetValue("@�s���{��")))
                builSQL.Append(", cities_name =" & VbSQLNStr(v_param.GetValue("@�s�撬��")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@�ύX����")))
                builSQL.Append(", start_day =" & VbSQLStr(v_param.GetValue("@�����J�n��")))
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function

        ''' <summary>A_�V�X�e���X�V</summary>
        ''' <param name="v_param">
        ''' �p�����[�^�F@�X��1/@�X��2/@��\�Җ�/@�X�X�֔ԍ�/@�X�Z��1/@�X�Z��2
        ''' @�X�d�b�ԍ�/@�XFAX�ԍ�/@�ݔ��䐔/@���W���z/@�s���{��/@�s�撬��/@�ύX����/@�����J�n��</param>
        ''' <returns>�����t���O</returns>
        ''' <remarks></remarks>
        Protected Friend Function updatePartOfA_System(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' �g�����U�N�V�����J�n
                DBA.TransactionStart()

                builSQL.Append("UPDATE A_�V�X�e�� SET")
                builSQL.Append(" �X��1 = @�X��1")
                builSQL.Append(", �X��2 = @�X��2")
                builSQL.Append(", ��\�Җ� = @��\�Җ�")
                builSQL.Append(", �X�X�֔ԍ� = @�X�X�֔ԍ�")
                builSQL.Append(", �X�Z��1 = @�X�Z��1")
                builSQL.Append(", �X�Z��2 = @�X�Z��2")
                builSQL.Append(", �X�d�b�ԍ� = @�X�d�b�ԍ�")
                builSQL.Append(", �XFAX�ԍ� = @�XFAX�ԍ�")
                builSQL.Append(", �ݔ��䐔 = @�ݔ��䐔")
                builSQL.Append(", ���W���z = @���W���z")
                builSQL.Append(", �ύX���� = @�ύX����")
                builSQL.Append(", �����J�n�� = @�����J�n��")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL���s���� INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1�ݒ�
                builSQL.Append("UPDATE system SET")
                builSQL.Append(" shop_name1 =" & VbSQLNStr(v_param.GetValue("@�X��1")))
                builSQL.Append(", shop_name2 =" & VbSQLNStr(v_param.GetValue("@�X��2")))
                builSQL.Append(", manager =" & VbSQLNStr(v_param.GetValue("@��\�Җ�")))
                builSQL.Append(", post_code =" & VbSQLNStr(v_param.GetValue("@�X�X�֔ԍ�")))
                builSQL.Append(", address1 =" & VbSQLNStr(v_param.GetValue("@�X�Z��1")))
                builSQL.Append(", address2 =" & VbSQLNStr(v_param.GetValue("@�X�Z��2")))
                builSQL.Append(", phone =" & VbSQLNStr(v_param.GetValue("@�X�d�b�ԍ�")))
                builSQL.Append(", fax =" & VbSQLNStr(v_param.GetValue("@�XFAX�ԍ�")))
                builSQL.Append(", accommodated_count =" & VbSQLStr(v_param.GetValue("@�ݔ��䐔")))
                builSQL.Append(", register_amount =" & VbSQLStr(v_param.GetValue("@���W���z")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@�ύX����")))
                builSQL.Append(", start_day =" & VbSQLStr(v_param.GetValue("@�����J�n��")))
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' �R�~�b�g
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ���[���o�b�N
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function


        ''' <summary>�X�֔ԍ��ɂĎs�撬������</summary>
        ''' <param name="v_param">SQL�p�����[�^�F@�V�X�֔ԍ��\���p</param>
        ''' <returns>�s�撬����</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_address(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.SearchAddress(v_param)
        End Function
    End Class
End Namespace
