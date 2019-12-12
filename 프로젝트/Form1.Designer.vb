<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.before = New System.Windows.Forms.PictureBox()
        Me.loadBtn = New System.Windows.Forms.Button()
        Me.changeBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.after = New System.Windows.Forms.PictureBox()
        CType(Me.before, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.after, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "(*.jpg)|*.jpg"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(580, 41)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(96, 34)
        Me.saveBtn.TabIndex = 8
        Me.saveBtn.Text = "저장하기"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(540, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "After"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(161, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Before"
        '
        'before
        '
        Me.before.Location = New System.Drawing.Point(26, 118)
        Me.before.Name = "before"
        Me.before.Size = New System.Drawing.Size(321, 354)
        Me.before.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.before.TabIndex = 4
        Me.before.TabStop = False
        '
        'loadBtn
        '
        Me.loadBtn.Location = New System.Drawing.Point(52, 41)
        Me.loadBtn.Name = "loadBtn"
        Me.loadBtn.Size = New System.Drawing.Size(96, 34)
        Me.loadBtn.TabIndex = 3
        Me.loadBtn.Text = "불러오기"
        Me.loadBtn.UseVisualStyleBackColor = True
        '
        'changeBtn
        '
        Me.changeBtn.Location = New System.Drawing.Point(450, 41)
        Me.changeBtn.Name = "changeBtn"
        Me.changeBtn.Size = New System.Drawing.Size(97, 34)
        Me.changeBtn.TabIndex = 2
        Me.changeBtn.Text = "전환"
        Me.changeBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(178, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "필터"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(221, 46)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(205, 23)
        Me.ComboBox1.TabIndex = 0
        '
        'after
        '
        Me.after.Location = New System.Drawing.Point(392, 115)
        Me.after.Name = "after"
        Me.after.Size = New System.Drawing.Size(336, 356)
        Me.after.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.after.TabIndex = 5
        Me.after.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 513)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.after)
        Me.Controls.Add(Me.before)
        Me.Controls.Add(Me.loadBtn)
        Me.Controls.Add(Me.changeBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.before, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.after, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents saveBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents after As PictureBox
    Friend WithEvents before As PictureBox
    Friend WithEvents loadBtn As Button
    Friend WithEvents changeBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
