Public Class ConvMatrix

    Public Factor As Integer = 1
    Public Offset As Integer = 0
    Public grid(8) As Integer

    Sub New()
        For i As Integer = 0 To 8
            grid(i) = 0
            grid(4) = 1
        Next
    End Sub

    Public Sub SetAll(ByVal value As Integer)
        For i As Integer = 0 To 8
            grid(i) = value
        Next
    End Sub

End Class
