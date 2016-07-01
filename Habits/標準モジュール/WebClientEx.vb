Class WebClientEx
    Inherits System.Net.WebClient
    Private _timeout As Integer = 1000

    Public Property Timeout() As Integer
        Get
            Return _timeout
        End Get

        Set(ByVal value As Integer)
            _timeout = value
        End Set
    End Property

    Protected Overrides Function GetWebRequest(ByVal address As Uri) As Net.WebRequest
        Dim request As Net.WebRequest
        request = MyBase.GetWebRequest(address)
        request.Timeout = Timeout
        Return request
    End Function
End Class