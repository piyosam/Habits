#Region "�C���|�[�g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>���X�҉�ʃ��W�b�N�N���X</summary>
    ''' <remarks></remarks>
    Public Class d0400_logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>���X�҈ꗗ�擾</summary>
        ''' <param name="v_param">SQL�p�����[�^</param>
        ''' <returns>���X�ҏ�񃊃X�g</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT E_����.�ڋq�ԍ�")
                builSQL.Append(" ,(E_���X��.�� + '  ' + ISNULL(E_���X��.��,'')) AS ����")
                builSQL.Append(" ,B_����.����")
                builSQL.Append(" ,B_���X�敪.���X�敪")
                builSQL.Append(" ,CASE WHEN E_����.�w�� = 'True' THEN '�w��' ELSE '  ' END �w��")
                builSQL.Append(" ,D_�S����.�S���Җ�")
                builSQL.Append(" ,CASE WHEN (E_����.�J�[�h�x��>0 OR E_����.���̑��x��>0) AND E_����.�|�C���g�����x��>0 THEN '������ �߲��'")
                builSQL.Append(" WHEN (E_����.�J�[�h�x��>0 OR E_����.���̑��x��>0) THEN '������'")
                builSQL.Append(" WHEN E_����.�|�C���g�����x��>0 THEN '�߲��' END AS �x��")
                builSQL.Append(" ,���㖾��.���� - E_����.�T�[�r�X���z AS ������z")
                builSQL.Append(" ,���㖾��.�T�[�r�X + E_����.�T�[�r�X���z AS �T�[�r�X")
                builSQL.Append(" ,E_����.����� AS �����")
                'builSQL.Append(" ,(���㖾��.����+E_����.�����) AS �ō�")
                builSQL.Append(" ,E_����.���X�Ҕԍ�")

                builSQL.Append(" FROM E_����")

                builSQL.Append(" INNER JOIN E_���X��")
                builSQL.Append(" ON E_����.���X�� = E_���X��.���X�� AND E_����.���X�Ҕԍ� = E_���X��.���X�Ҕԍ�")
                builSQL.Append(" AND E_����.�ڋq�ԍ� = E_���X��.�ڋq�ԍ�")

                builSQL.Append(" INNER JOIN (SELECT ���X��,���X�Ҕԍ�,�ڋq�ԍ�,SUM(���� * ���z - �T�[�r�X) AS ����,SUM(�T�[�r�X) AS �T�[�r�X")
                builSQL.Append(" FROM E_���㖾�� WHERE ���X�� = @�I���� AND ��v�� = 'True' GROUP BY ���X��,���X�Ҕԍ�,�ڋq�ԍ�) AS ���㖾��")
                builSQL.Append(" ON E_����.���X�� = ���㖾��.���X�� AND E_����.���X�Ҕԍ� = ���㖾��.���X�Ҕԍ� AND E_����.�ڋq�ԍ� = ���㖾��.�ڋq�ԍ�")

                builSQL.Append(" INNER JOIN B_���� ON E_����.���ʔԍ� = B_����.���ʔԍ�")
                builSQL.Append(" INNER JOIN B_���X�敪 ON E_����.���X�敪�ԍ� = B_���X�敪.���X�敪�ԍ�")
                builSQL.Append(" INNER JOIN D_�S���� ON E_����.��S���Ҕԍ� = D_�S����.�S���Ҕԍ�")
                builSQL.Append(" INNER JOIN D_�ڋq ON E_����.�ڋq�ԍ� = D_�ڋq.�ڋq�ԍ�")

                builSQL.Append(" WHERE E_����.���X�� = @�I����")
                builSQL.Append(" ORDER BY E_����.���X�Ҕԍ� ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace