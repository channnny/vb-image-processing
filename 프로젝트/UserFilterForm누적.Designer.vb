<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserFilterForm누적
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonInput = New System.Windows.Forms.Button()
        Me.Offset = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Factor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Grid8 = New System.Windows.Forms.TextBox()
        Me.Grid7 = New System.Windows.Forms.TextBox()
        Me.Grid6 = New System.Windows.Forms.TextBox()
        Me.Grid5 = New System.Windows.Forms.TextBox()
        Me.Grid4 = New System.Windows.Forms.TextBox()
        Me.Grid3 = New System.Windows.Forms.TextBox()
        Me.Grid2 = New System.Windows.Forms.TextBox()
        Me.Grid1 = New System.Windows.Forms.TextBox()
        Me.Grid0 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(388, 192)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "offset"
        '
        'ButtonInput
        '
        Me.ButtonInput.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ButtonInput.Location = New System.Drawing.Point(296, 96)
        Me.ButtonInput.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonInput.Name = "ButtonInput"
        Me.ButtonInput.Size = New System.Drawing.Size(134, 59)
        Me.ButtonInput.TabIndex = 27
        Me.ButtonInput.Text = "영상 처리"
        Me.ButtonInput.UseVisualStyleBackColor = True
        '
        'Offset
        '
        Me.Offset.Location = New System.Drawing.Point(394, 214)
        Me.Offset.Margin = New System.Windows.Forms.Padding(4)
        Me.Offset.Name = "Offset"
        Me.Offset.Size = New System.Drawing.Size(35, 25)
        Me.Offset.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(353, 207)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 34)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "+"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(277, 207)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 34)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "/"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 192)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "factor"
        '
        'Factor
        '
        Me.Factor.Location = New System.Drawing.Point(311, 214)
        Me.Factor.Margin = New System.Windows.Forms.Padding(4)
        Me.Factor.Name = "Factor"
        Me.Factor.Size = New System.Drawing.Size(35, 25)
        Me.Factor.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Grid8)
        Me.GroupBox1.Controls.Add(Me.Grid7)
        Me.GroupBox1.Controls.Add(Me.Grid6)
        Me.GroupBox1.Controls.Add(Me.Grid5)
        Me.GroupBox1.Controls.Add(Me.Grid4)
        Me.GroupBox1.Controls.Add(Me.Grid3)
        Me.GroupBox1.Controls.Add(Me.Grid2)
        Me.GroupBox1.Controls.Add(Me.Grid1)
        Me.GroupBox1.Controls.Add(Me.Grid0)
        Me.GroupBox1.Location = New System.Drawing.Point(60, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(210, 212)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Grid"
        '
        'Grid8
        '
        Me.Grid8.Location = New System.Drawing.Point(137, 146)
        Me.Grid8.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid8.Name = "Grid8"
        Me.Grid8.Size = New System.Drawing.Size(48, 25)
        Me.Grid8.TabIndex = 8
        '
        'Grid7
        '
        Me.Grid7.Location = New System.Drawing.Point(81, 146)
        Me.Grid7.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid7.Name = "Grid7"
        Me.Grid7.Size = New System.Drawing.Size(48, 25)
        Me.Grid7.TabIndex = 7
        '
        'Grid6
        '
        Me.Grid6.Location = New System.Drawing.Point(25, 146)
        Me.Grid6.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid6.Name = "Grid6"
        Me.Grid6.Size = New System.Drawing.Size(48, 25)
        Me.Grid6.TabIndex = 6
        '
        'Grid5
        '
        Me.Grid5.Location = New System.Drawing.Point(137, 94)
        Me.Grid5.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid5.Name = "Grid5"
        Me.Grid5.Size = New System.Drawing.Size(48, 25)
        Me.Grid5.TabIndex = 5
        '
        'Grid4
        '
        Me.Grid4.Location = New System.Drawing.Point(81, 94)
        Me.Grid4.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid4.Name = "Grid4"
        Me.Grid4.Size = New System.Drawing.Size(48, 25)
        Me.Grid4.TabIndex = 4
        '
        'Grid3
        '
        Me.Grid3.Location = New System.Drawing.Point(25, 94)
        Me.Grid3.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid3.Name = "Grid3"
        Me.Grid3.Size = New System.Drawing.Size(48, 25)
        Me.Grid3.TabIndex = 3
        '
        'Grid2
        '
        Me.Grid2.Location = New System.Drawing.Point(137, 41)
        Me.Grid2.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(48, 25)
        Me.Grid2.TabIndex = 2
        '
        'Grid1
        '
        Me.Grid1.Location = New System.Drawing.Point(81, 41)
        Me.Grid1.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(48, 25)
        Me.Grid1.TabIndex = 1
        '
        'Grid0
        '
        Me.Grid0.Location = New System.Drawing.Point(25, 41)
        Me.Grid0.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid0.Name = "Grid0"
        Me.Grid0.Size = New System.Drawing.Size(48, 25)
        Me.Grid0.TabIndex = 0
        '
        'UserFilterForm누적
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 281)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonInput)
        Me.Controls.Add(Me.Offset)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Factor)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UserFilterForm누적"
        Me.Text = "UserFilterForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonInput As System.Windows.Forms.Button
    Friend WithEvents Offset As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Factor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Grid8 As System.Windows.Forms.TextBox
    Friend WithEvents Grid7 As System.Windows.Forms.TextBox
    Friend WithEvents Grid6 As System.Windows.Forms.TextBox
    Friend WithEvents Grid5 As System.Windows.Forms.TextBox
    Friend WithEvents Grid4 As System.Windows.Forms.TextBox
    Friend WithEvents Grid3 As System.Windows.Forms.TextBox
    Friend WithEvents Grid2 As System.Windows.Forms.TextBox
    Friend WithEvents Grid1 As System.Windows.Forms.TextBox
    Friend WithEvents Grid0 As System.Windows.Forms.TextBox
End Class
