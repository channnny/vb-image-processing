Public Class UserRGBForm누적

    Private Sub ButtonInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInput.Click
        Dim red, green, blue As Integer
        Dim cCurrColor As Color
        Dim bm As New Bitmap(Form1.after.Image)

        red = CInt(Grid0.Text)
        green = CInt(TextBox1.Text)
        blue = CInt(TextBox2.Text)

        For iY As Integer = 0 To bm.Height - 1
            For iX As Integer = 0 To bm.Width - 1
                cCurrColor = bm.GetPixel(iX, iY)
                Dim intAlpha As Integer = cCurrColor.A
                Dim intRed As Integer = cCurrColor.R
                Dim intGreen As Integer = cCurrColor.G
                Dim intBlue As Integer = cCurrColor.B

                Dim intSRed As Integer = CInt((red * intRed + intGreen + intBlue))
                Dim intSGreen As Integer = CInt((intRed + green * intGreen + intBlue))
                Dim intSBlue As Integer = CInt((intRed + intGreen + blue * intBlue))

                If intSRed > 255 Then
                    intRed = 255
                Else
                    intRed = intSRed
                End If

                If intSGreen > 255 Then
                    intGreen = 255
                Else
                    intGreen = intSGreen
                End If

                If intSBlue > 255 Then
                    intBlue = 255
                Else
                    intBlue = intSBlue
                End If

                bm.SetPixel(iX, iY, Color.FromArgb(intAlpha, intRed, intGreen, intBlue))
            Next
        Next

        Form1.after.Image = bm
        Me.Hide()
    End Sub
End Class