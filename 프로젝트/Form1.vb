Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Form1

    Dim 필터() As String = {"GrayScale filter", "Invert Filter", "Brightness Filter",
        "Sepia Tone Filter", "X-ray Filter",
        "Smooth Filter", "Sharpen Filter", "Gaussian Blur Filter", "Embossing Filter",
        "Edge Detection Filter", "Customize Filter", "Customize RGB Filter", "Rotation Filter"}

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

    Public Function 부드럽게처리(ByVal bm As Bitmap) As Bitmap
        Dim level As Integer
        level = CInt(InputBox("0부터 20중에서 값을 입력하세요. 값이 클수록 변화가 적습니다.",
                              "Smooth level 입력", "1"))

        Dim convm As New ConvMatrix
        convm.SetAll(1)
        convm.grid(4) = CInt(level)
        convm.Factor = CInt(level + 8)
        convm.Offset = 0

        Return ConvolutionFilters.convolution3by3(bm, convm)
    End Function

    Private Function 쉐어펜(ByVal bm As Bitmap) As Bitmap
        Dim level As Integer
        level = CInt(InputBox("0부터 20중에서 값을 입력하세요. 11이 가장 적당합니다.",
                              "Sharpening값 입력", "11"))
        Dim convm As New ConvMatrix
        convm.SetAll(0)
        convm.grid(1) = -2
        convm.grid(3) = -2
        convm.grid(5) = -2
        convm.grid(7) = -2
        convm.grid(4) = CInt(level)
        convm.Factor = CInt(level - 8)

        Return ConvolutionFilters.convolution3by3(bm, convm)
    End Function

    Private Function 가우시안블러(ByVal bm As Bitmap) As Bitmap
        Dim level As Integer
        level = CInt(InputBox("0부터 40중에서 값을 입력하세요. 값이 클수록 변화가 적습니다.",
                              "Gaussian Blur 입력", "0"))

        Dim convm As New ConvMatrix
        convm.SetAll(1)
        convm.grid(1) = 2
        convm.grid(3) = 2
        convm.grid(5) = 2
        convm.grid(7) = 2
        convm.grid(4) = CInt(level)
        convm.Factor = CInt(level + 12)
        convm.Offset = 0

        Return ConvolutionFilters.convolution3by3(bm, convm)
    End Function

    Private Function 엠보싱(ByVal bm As Bitmap) As Bitmap
        Dim level As Integer
        level = CInt(InputBox("0부터 20중에서 값을 입력하세요. 4가 가장 적당합니다.",
                              "Sharpening값 입력", "4"))
        Dim convm As New ConvMatrix
        convm.SetAll(-1)
        convm.grid(1) = 0
        convm.grid(3) = 0
        convm.grid(5) = 0
        convm.grid(7) = 0
        convm.grid(4) = CInt(level)
        convm.Factor = CInt(level - 3)
        convm.Offset = 127

        Return ConvolutionFilters.convolution3by3(bm, convm)
    End Function

    Private Function 엣지검출(ByVal bm As Bitmap) As Bitmap
      
        Dim direction As Integer
        direction = InputBox("경계검출방향을 선택해주세요." & Chr(13) & Chr(10) & "수평을 원하시면 1을 수직을 원하시면 2를 입력하세요.",
                              "경계선 방향 입력", "1")
        Dim convm As New ConvMatrix
        '1이면 수평,,,2면 수직 검출
        Select Case direction
            Case 1
                convm.SetAll(1)
                convm.grid(3) = 0
                convm.grid(4) = 0
                convm.grid(5) = 0
                convm.grid(6) = -1
                convm.grid(7) = -1
                convm.grid(8) = -1
                convm.Factor = 1
                convm.Offset = 127
            Case 2
                convm.SetAll(1)
                convm.grid(1) = 0
                convm.grid(4) = 0
                convm.grid(7) = 0
                convm.grid(2) = -1
                convm.grid(5) = -1
                convm.grid(8) = -1
                convm.Factor = 1
                convm.Offset = 127
        End Select

        Return ConvolutionFilters.convolution3by3(bm, convm)
    End Function

    Public Function 세피아(ByVal bm As Bitmap) As Bitmap
        Dim bmpImage As Bitmap = bm
        Dim cCurrColor As Color

        For iY As Integer = 0 To bmpImage.Height - 1
            For iX As Integer = 0 To bmpImage.Width - 1
                cCurrColor = bmpImage.GetPixel(iX, iY)
                Dim intAlpha As Integer = cCurrColor.A
                Dim intRed As Integer = cCurrColor.R
                Dim intGreen As Integer = cCurrColor.G
                Dim intBlue As Integer = cCurrColor.B

                Dim intSRed As Integer = CInt((0.393 * intRed + 0.769 * intGreen + 0.189 * intBlue))
                Dim intSGreen As Integer = CInt((0.349 * intRed + 0.686 * intGreen + 0.168 * intBlue))
                Dim intSBlue As Integer = CInt((0.272 * intRed + 0.534 * intGreen + 0.131 * intBlue))

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

                bmpImage.SetPixel(iX, iY, Color.FromArgb(intAlpha, intRed, intGreen, intBlue))
            Next
        Next

        Return bmpImage
    End Function

    Public Function X선(ByVal bm As Bitmap) As Bitmap
        Dim iX As Integer
        Dim iY As Integer
        Dim bmpImage As Bitmap = bm
        Dim intPrevColor As Integer

        For iX = 0 To bmpImage.Width - 1
            For iY = 0 To bmpImage.Height - 1
                intPrevColor = (CInt(bmpImage.GetPixel(iX, iY).R) + bmpImage.GetPixel(iX, iY).G + bmpImage.GetPixel(iX, iY).B) \ 3
                bmpImage.SetPixel(iX, iY, Color.FromArgb(intPrevColor, intPrevColor, intPrevColor))
            Next iY
        Next iX

        Dim iaAttributes As New ImageAttributes
        Dim cmMatrix As New ColorMatrix

        cmMatrix.Matrix00 = -1 : cmMatrix.Matrix11 = -1 : cmMatrix.Matrix22 = -1
        cmMatrix.Matrix40 = 1 : cmMatrix.Matrix41 = 1 : cmMatrix.Matrix42 = 1
        iaAttributes.SetColorMatrix(cmMatrix)

        Dim rect As New Rectangle(0, 0, bmpImage.Width, bmpImage.Height)
        Dim graph As Graphics = Graphics.FromImage(bmpImage)

        graph.DrawImage(bmpImage, rect, rect.X, rect.Y, rect.Width, rect.Height, GraphicsUnit.Pixel, iaAttributes)

        Return bmpImage
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(필터)
        filename = ""
        ComboBox1.SelectedIndex = 0
    End Sub

    ' 파일선택으로 이미지 불러오기
    Private Sub loadBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadBtn.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            before.ImageLocation = OpenFileDialog1.FileName
            filename = OpenFileDialog1.FileName
        End If
    End Sub

    ' 필터를 선택하면 사진에 필터 입히기
    Private Sub changeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeBtn.Click
        Dim num, filterNum As Double
        Dim myrotation As New Rotation

        If filename.Equals("") Then '파일이 열리지 않으면
            MsgBox("로드된 이미지가 없습니다.", vbCritical, "안내창")
        Else
            If after.Image IsNot Nothing Then  'after 이미지가 있는데 다른 필터를 누르면 저장안한거 안내창 띄우기
                num = MsgBox("저장하지 않은 이미지가 있습니다," & Chr(13) & Chr(10) & "필터를 바꾸시겠습니까?", vbYesNo, "안내창")

                If num = 6 Then '저장원하지 않을 경우 필터 누적 물어보기
                    filterNum = MsgBox("필터를 누적하시겠습니까?", vbYesNo, "안내창")

                    If filterNum = 6 Then   ' 필터 누적의 경우
                        Dim colorbmp As New Bitmap(after.Image)
                        before.Image = after.Image
                        Select Case ComboBox1.SelectedItem
                            Case "GrayScale filter"
                                after.Image = 흑백처리(colorbmp)
                            Case "Invert Filter"
                                after.Image = 색반전처리(colorbmp)
                            Case "Brightness Filter"
                                Dim bright As Integer
                                bright = CInt(InputBox("밝기 정도를 입력하세요(범위 : -255 ~ 255)", "밝기 입력", "0"))
                                after.Image = 밝게처리(colorbmp, bright)
                            Case "Smooth Filter"
                                after.Image = 부드럽게처리(colorbmp)
                            Case "Gaussian Blur Filter"
                                after.Image = 가우시안블러(colorbmp)
                            Case "Sharpen Filter"
                                after.Image = 쉐어펜(colorbmp)
                            Case "Embossing Filter"
                                after.Image = 엠보싱(colorbmp)
                            Case "Edge Detection Filter"
                                after.Image = 엣지검출(colorbmp)
                            Case "Customize Filter"
                                UserFilterForm누적.Show()
                            Case "Sepia Tone Filter"
                                after.Image = 세피아(colorbmp)
                            Case "X-ray Filter"
                                after.Image = X선(colorbmp)
                            Case "Customize RGB Filter"
                                UserRGBForm누적.Show()
                            Case "Rotation Filter"
                                Dim angle As Integer
                                angle = CInt(InputBox("회전 각도를 입력하세요.", "각도 입력", "0"))
                                after.Image = myrotation.Img_Rotation(colorbmp, angle)
                        End Select

                    ElseIf filterNum = 7 Then   '필터 누적 안할 경우
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
                            Case "Smooth Filter"
                                after.Image = 부드럽게처리(colorbmp)
                            Case "Gaussian Blur Filter"
                                after.Image = 가우시안블러(colorbmp)
                            Case "Sharpen Filter"
                                after.Image = 쉐어펜(colorbmp)
                            Case "Embossing Filter"
                                after.Image = 엠보싱(colorbmp)
                            Case "Edge Detection Filter"
                                after.Image = 엣지검출(colorbmp)
                            Case "Customize Filter"
                                UserFilterForm.Show()
                            Case "Sepia Tone Filter"
                                after.Image = 세피아(colorbmp)
                            Case "X-ray Filter"
                                after.Image = X선(colorbmp)
                            Case "Customize RGB Filter"
                                UserRGBForm.Show()
                            Case "Rotation Filter"
                                Dim angle As Integer
                                angle = CInt(InputBox("회전 각도를 입력하세요.", "각도 입력", "0"))
                                after.Image = myrotation.Img_Rotation(colorbmp, angle)
                        End Select
                    End If
                End If

            Else    'after 이미지 없으면 필터 적용
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
                    Case "Smooth Filter"
                        after.Image = 부드럽게처리(colorbmp)
                    Case "Gaussian Blur Filter"
                        after.Image = 가우시안블러(colorbmp)
                    Case "Sharpen Filter"
                        after.Image = 쉐어펜(colorbmp)
                    Case "Embossing Filter"
                        after.Image = 엠보싱(colorbmp)
                    Case "Edge Detection Filter"
                        after.Image = 엣지검출(colorbmp)
                    Case "Customize Filter"
                        UserFilterForm.Show()
                    Case "Sepia Tone Filter"
                        after.Image = 세피아(colorbmp)
                    Case "X-ray Filter"
                        after.Image = X선(colorbmp)
                    Case "Customize RGB Filter"
                        UserRGBForm.Show()
                    Case "Rotation Filter"
                        Dim angle As Integer
                        angle = CInt(InputBox("회전 각도를 입력하세요.", "각도 입력", "0"))
                        after.Image = myrotation.Img_Rotation(colorbmp, angle)
                End Select
            End If
        End If

    End Sub

    ' 이미지 저장
    Private Sub saveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveBtn.Click
        If filename.Equals("") Then '파일이 열리지 않으면
            MsgBox("로드된 이미지가 없습니다.", vbCritical, "안내창")
        Else
            If after.Image Is Nothing Then   'after 이미지가 없으면
                MsgBox("저장할 이미지가 없습니다.", vbCritical, "안내창")
            Else
                If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                    after.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            End If

        End If
    End Sub
End Class
