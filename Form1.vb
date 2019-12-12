Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Form1
    Dim 필터() As String = {"GrayScale filter", "Invert Filter", "Brightness Filter"}
    Dim filename As String

    Public Function 흑백처리(ByVal bm As Bitmap) As Bitmap
        Dim bmb As New BitmapData
        bmb = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height),
                          System.Drawing.Imaging.ImageLockMode.ReadWrite,
                          Imaging.PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmb.Scan0
        Dim stride As Integer = bmb.Stride
        Dim pixels(bm.Width * bm.Height - 1) As Integer
        Marshal.Copy(scan0, pixels, 0, pixels.Length)
        Dim alpha, red, green, blue, gray As Integer

        For i As Integer = 0 To pixels.Length - 1
            alpha = (pixels(i) >> 24) And &HFF
            red = (pixels(i) >> 16) And &HFF
            green = (pixels(i) >> 8) And &HFF
            blue = pixels(i) And &HFF
            gray = CInt(0.299 * red + 0.587 * green + 0.114 * blue)

            pixels(i) = (255 << 24) Or (gray << 16) Or (gray << 8) Or gray
        Next

        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        bm.UnlockBits(bmb)
        Return bm
    End Function

    Public Function 색반전처리(ByVal bm As Bitmap) As Bitmap
        Dim bmb As New BitmapData
        bmb = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height),
                          System.Drawing.Imaging.ImageLockMode.ReadWrite,
                          Imaging.PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmb.Scan0
        Dim stride As Integer = bmb.Stride
        Dim pixels(bm.Width * bm.Height - 1) As Integer
        Marshal.Copy(scan0, pixels, 0, pixels.Length)

        For i As Integer = 0 To pixels.Length - 1
            pixels(i) = (Not pixels(i) And &HFFFFFFFF) Or (pixels(i) And &HFF000000)
        Next

        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        bm.UnlockBits(bmb)
        Return bm
    End Function

    Public Function 밝게처리(ByVal bm As Bitmap, ByVal bright As Integer) As Bitmap
        Dim bmb As New BitmapData
        bmb = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height),
                          System.Drawing.Imaging.ImageLockMode.ReadWrite,
                          Imaging.PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmb.Scan0
        Dim stride As Integer = bmb.Stride
        Dim pixels(bm.Width * bm.Height - 1) As Integer
        Marshal.Copy(scan0, pixels, 0, pixels.Length)
        Dim alpha, red, green, blue As Integer

        For i As Integer = 0 To pixels.Length - 1
            alpha = (pixels(i) >> 24) And &HFF
            red = (pixels(i) >> 16) And &HFF
            green = (pixels(i) >> 8) And &HFF
            blue = pixels(i) And &HFF

            red += bright
            green += bright
            blue += bright

            red = Math.Min(Math.Max(red, 0), 255)
            green = Math.Min(Math.Max(green, 0), 255)
            blue = Math.Min(Math.Max(blue, 0), 255)

            pixels(i) = (255 << 24) Or (red << 16) Or (green << 8) Or blue
        Next

        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        bm.UnlockBits(bmb)
        Return bm
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(필터)
        ComboBox1.SelectedIndex = 0
    End Sub
    ' 파일선택으로 이미지 불러오기
    Private Sub loadBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadBtn.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            before.ImageLocation = OpenFileDialog1.FileName
        End If
        OpenFileDialog1.FileName = ""
    End Sub
    ' 필터를 선택하면 사진에 필터 입히기
    Private Sub changeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeBtn.Click
        Dim colorbmp As New Bitmap(before.Image)
        Select Case ComboBox1.SelectedItem
            Case "GrayScale filter"
                after.Image = 흑백처리(colorbmp)
            Case "Invert Filter"
                after.Image = 색반전처리(colorbmp)
            Case "Brightness Filter"
                Dim bright As Integer
                bright = CInt(InputBox("밝기 정도를 입력하세요(범위 : -255 ~ 255)", "밝기 입력", "0"))
                after.Image = 밝게처리(colorbmp, bright)
        End Select
    End Sub
    ' 이미지 저장
    Private Sub saveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveBtn.Click
        If SaveFileDialog1.ShowDialog = DialogResult.OK Then
            after.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub
End Class
