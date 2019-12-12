Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Rotation

    Public angle As Integer

    Public Function Img_Rotation(ByVal img As Bitmap, ByVal angle As Integer) As Bitmap

        Dim rad As Double = angle * Math.PI / 180.0
        Dim cos_value As Double = Math.Cos(rad)
        Dim sin_value As Double = Math.Sin(rad)

        Dim minx As Integer = 0
        Dim miny As Integer = 0
        Dim maxx As Integer = 0
        Dim maxy As Integer = 0

        Dim nx, ny As Integer
        nx = CInt(cos_value * img.Width)
        ny = CInt(sin_value * img.Width)
        If maxx < nx Then maxx = nx
        If minx > nx Then minx = nx
        If maxy < ny Then maxy = ny
        If miny > ny Then miny = ny

        nx = CInt(-sin_value * img.Height)
        ny = CInt(cos_value * img.Height)
        If maxx < nx Then maxx = nx
        If minx > nx Then minx = nx
        If maxy < ny Then maxy = ny
        If miny > ny Then miny = ny

        nx = CInt(cos_value * img.Width - sin_value * img.Height)
        ny = CInt(sin_value * img.Width + cos_value * img.Height)
        If maxx < nx Then maxx = nx
        If minx > nx Then minx = nx
        If maxy < ny Then maxy = ny
        If miny > ny Then miny = ny

        Dim rot_w, rot_h As Integer
        rot_w = maxx - minx
        rot_h = maxy - miny

        Dim img_rot As Bitmap = New Bitmap(rot_w, rot_h)

        Dim pixels(img.Height * img.Width - 1) As Integer
        Dim pixels_rot(rot_h * rot_w - 1) As Integer
        Dim pixels_2d(img.Height - 1, img.Width - 1) As Integer
        Dim pixels_rot_2d(rot_h - 1, rot_w - 1) As Integer

        Dim bmd As BitmapData = img.LockBits(New Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
        Dim scan0 As IntPtr = bmd.Scan0

        Dim rot_bmd As BitmapData = img_rot.LockBits(New Rectangle(0, 0, rot_w, rot_h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
        Dim rot_scan0 As IntPtr = rot_bmd.Scan0

        Marshal.Copy(scan0, pixels, 0, pixels.Length)
        Marshal.Copy(rot_scan0, pixels_rot, 0, pixels_rot.Length)

        For j As Integer = 0 To img.Height - 1
            For i As Integer = 0 To img.Width - 1
                pixels_2d(j, i) = pixels(j * img.Width + i)
            Next
        Next

        Dim real_x, real_y, p, q, temp_red, temp_green, temp_blue As Single
        Dim x1, x2, y1, y2 As Integer

        For j As Integer = 0 To rot_h - 1
            For i As Integer = 0 To rot_w - 1

                real_x = (i + minx) * cos_value + (j + miny) * sin_value
                real_y = -(i + minx) * sin_value + (j + miny) * cos_value

                If (real_x < 0 Or real_x > img.Width - 1 Or real_y < 0 Or real_y > img.Height - 1) Then
                    Continue For
                End If

                x1 = Int(real_x)
                y1 = Int(real_y)

                If x1 = img.Width - 1 Then
                    x2 = img.Width - 1
                Else
                    x2 = x1 + 1
                End If

                If y1 = img.Height - 1 Then
                    y2 = img.Height - 1
                Else
                    y2 = y1 + 1
                End If

                p = real_x - x1
                q = real_y - y1

                temp_red = (1.0 - p) * (1.0 - q) * Sub_Red(pixels_2d(y1, x1)) _
                            + p * (1.0 - q) * Sub_Red(pixels_2d(y1, x2)) _
                            + (1.0 - p) * q * Sub_Red(pixels_2d(y2, x1)) _
                            + p * q * Sub_Red(pixels_2d(y2, x2))

                temp_green = (1.0 - p) * (1.0 - q) * Sub_Green(pixels_2d(y1, x1)) _
                              + p * (1.0 - q) * Sub_Green(pixels_2d(y1, x2)) _
                              + (1.0 - p) * q * Sub_Green(pixels_2d(y2, x1)) _
                              + p * q * Sub_Green(pixels_2d(y2, x2))

                temp_blue = (1.0 - p) * (1.0 - q) * Sub_Blue(pixels_2d(y1, x1)) _
                             + p * (1.0 - q) * Sub_Blue(pixels_2d(y1, x2)) _
                             + (1.0 - p) * q * Sub_Blue(pixels_2d(y2, x1)) _
                             + p * q * Sub_Blue(pixels_2d(y2, x2))

                pixels_rot_2d(j, i) = CInt((255 << 24) Or (temp_red << 16) Or _
                                                      (temp_green << 8) Or temp_blue)
            Next
        Next

        Marshal.Copy(pixels, 0, scan0, pixels.Length)
        img.UnlockBits(bmd)


        For j As Integer = 0 To rot_h - 1
            For i As Integer = 0 To rot_w - 1
                pixels_rot(j * rot_w + i) = pixels_rot_2d(j, i)
            Next
        Next

        Marshal.Copy(pixels_rot, 0, rot_scan0, pixels_rot.Length)
        img_rot.UnlockBits(rot_bmd)

        Return img_rot

    End Function

    Private Function Sub_Red(ByVal pixel As Integer) As Byte
        Dim red As Byte
        red = (pixel >> 16) And &HFF
        Return red
    End Function
    Private Function Sub_Green(ByVal pixel As Integer) As Byte
        Dim green As Byte
        green = (pixel >> 8) And &HFF
        Return green
    End Function
    Private Function Sub_Blue(ByVal pixel As Integer) As Byte
        Dim blue As Byte
        blue = pixel And &HFF
        Return blue
    End Function

End Class
