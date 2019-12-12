Public Class UserFilterForm누적

    Private Sub ButtonInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInput.Click
        Dim convm As New ConvMatrix
        convm.grid(0) = CInt(Grid0.Text)
        convm.grid(1) = CInt(Grid1.Text)
        convm.grid(2) = CInt(Grid2.Text)
        convm.grid(3) = CInt(Grid3.Text)
        convm.grid(4) = CInt(Grid4.Text)
        convm.grid(5) = CInt(Grid5.Text)
        convm.grid(6) = CInt(Grid6.Text)
        convm.grid(7) = CInt(Grid7.Text)
        convm.grid(8) = CInt(Grid8.Text)
        convm.Factor = CInt(Factor.Text)
        convm.Offset = CInt(Offset.Text)

        Dim bm As New Bitmap(Form1.after.Image)
        Form1.after.Image = ConvolutionFilters.convolution3by3(bm, convm)
        Me.Hide()
    End Sub
End Class