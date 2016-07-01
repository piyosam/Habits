Namespace Habits.DB

    'システム名 ： HABITS
    '概要　　　 ：DBPrameter
    '説明　　　 ： 
    '履歴　　　 ： 2010/04/01　ＳＷＪ　作成
    'バージョン ： Ver1.00
    'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

    Public Class DBParameter

        Private Const PARAMETER_KEY As String = "PARAMETER"
        Private Const VALUE_KEY As String = "VALUE"
        Private m_list As New ArrayList

        ''' <summary>
        ''' パラメーターの件数を返す
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function GetList() As ArrayList

            Return m_list

        End Function

        ''' <summary>
        ''' パラメーターを追加する
        ''' </summary>
        ''' <param name="v_parameterName"></param>
        ''' <param name="v_value"></param>
        ''' <remarks></remarks>
        Protected Friend Sub Add(ByVal v_parameterName As String, ByVal v_value As Object)
            Dim data As New Hashtable

            data.Add(PARAMETER_KEY, v_parameterName)
            data.Add(VALUE_KEY, v_value)
            m_list.Add(data)

        End Sub

        ''' <summary>
        ''' パラメーターの件数を返す
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function Count() As Integer

            Return m_list.Count

        End Function

        ''' <summary>
        ''' パラメーター名を取得する
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function GetParameterName(ByVal index As Integer) As String
            Dim data As New Hashtable
            Dim parameterName As String

            data = m_list.Item(index)
            parameterName = data.Item(PARAMETER_KEY)

            Return parameterName

        End Function

        ''' <summary>
        ''' 値を取得する
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function GetValue(ByVal index As Integer) As Object
            Dim data As New Hashtable
            Dim value As Object

            data = m_list.Item(index)
            value = data.Item(VALUE_KEY)

            Return value

        End Function

        ''' <summary>
        ''' 値を取得する
        ''' </summary>
        ''' <param name="parameterName">パラメータキー</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function GetValue(ByVal parameterName As Object) As Object
            Dim data As New Hashtable
            Dim value As Object = DBNull.Value

            For Each data In m_list
                If data.Item(PARAMETER_KEY).Equals(parameterName) Then
                    value = data.Item(VALUE_KEY)
                    Exit For
                End If
            Next
            Return value

        End Function

        ''' <summary>
        ''' パラメータをクリアする
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub Clear()
            m_list.Clear()
        End Sub
    End Class

End Namespace
