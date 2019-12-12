Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class ConvolutionFilters

    Public Shared Function convolution3by3(ByVal b As Bitmap, ByVal m As ConvMatrix) As Bitmap
        If m.Factor = 0 Then Return b
        Dim bScr As Bitmap = b.Clone
        Dim bmd As BitmapData = b.LockBits(New Rectangle(0, 0, b.Width, b.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format32bppArgb)
        Dim bmdSrc As BitmapData = bScr.LockBits(New Rectangle(0, 0, bScr.Width, bScr.Height),
                                                 ImageLockMode.ReadWrite,
                                                 PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmd.Scan0
        Dim scan0Src As IntPtr = bmdSrc.Scan0
        Dim pixels(b.Width * b.Height - 1) As Integer
        Dim pixelsSrc(bScr.Width * bScr.Height - 1) As Integer
        Marshal.Copy(scan0, pixels, 0, pixels.Length)
        Marshal.Copy(scan0Src, pixelsSrc, 0, pixelsSrc.Length)
        Dim total(3) As Single


        Dim index As Integer
        Dim gridValue As Single


        For y As Integer = 1 To b.Height - 2
            For x As Integer = 1 To b.Width - 2
                For j As Integer = -1 To 1
                    For i As Integer = -1 To 1
                        index = (y + j) * b.Width + x + i
                        gridValue = m.grid((j + 1) * 3 + i + 1)
                        total(0) = 255
                        total(1) += ((pixelsSrc(index) >> 16) And &HFF) * gridValue / m.Factor + m.Offset / 9
                        total(2) += ((pixelsSrc(index) >> 8) And &HFF) * gridValue / m.Factor + m.Offset / 9
                        total(3) += (pixelsSrc(index) And &HFF) * gridValue / m.Factor + m.Offset / 9
                    Next
                Next

                '계산된 값이 255초과하거나 음수면 안되므로
                For i As Integer = 0 To 3
                    If total(i) > 255 Then total(i) = 255
                    If total(i) < 0 Then total(i) = 0
                Next

                pixels(y * b.Width + x) =
                    (255 << 24) Or (Convert.ToInt32(total(1)) << 16
                                    ) Or (Convert.ToInt32(total(2) << 8)) Or Convert.ToInt32(total(3))

                Array.Clear(total, 0, 4)

            Next
        Next

        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        b.UnlockBits(bmd)
        bScr.UnlockBits(bmdSrc)
        Return b

    End Function
End Class
