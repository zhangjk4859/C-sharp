<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Nums = New System.Windows.Forms.Panel()
        Me.NumCE = New System.Windows.Forms.Button()
        Me.NumDot = New System.Windows.Forms.Button()
        Me.Num0 = New System.Windows.Forms.Button()
        Me.Num6 = New System.Windows.Forms.Button()
        Me.Num5 = New System.Windows.Forms.Button()
        Me.Num4 = New System.Windows.Forms.Button()
        Me.Num9 = New System.Windows.Forms.Button()
        Me.Num8 = New System.Windows.Forms.Button()
        Me.Num7 = New System.Windows.Forms.Button()
        Me.Num3 = New System.Windows.Forms.Button()
        Me.Num2 = New System.Windows.Forms.Button()
        Me.Num1 = New System.Windows.Forms.Button()
        Me.Operators = New System.Windows.Forms.Panel()
        Me.Equation = New System.Windows.Forms.Button()
        Me.OP4 = New System.Windows.Forms.Button()
        Me.OP3 = New System.Windows.Forms.Button()
        Me.OP2 = New System.Windows.Forms.Button()
        Me.OP1 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Nums.SuspendLayout()
        Me.Operators.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FloralWhite
        Me.Label1.Location = New System.Drawing.Point(32, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 35)
        Me.Label1.TabIndex = 0
        '
        'Nums
        '
        Me.Nums.Controls.Add(Me.NumCE)
        Me.Nums.Controls.Add(Me.NumDot)
        Me.Nums.Controls.Add(Me.Num0)
        Me.Nums.Controls.Add(Me.Num6)
        Me.Nums.Controls.Add(Me.Num5)
        Me.Nums.Controls.Add(Me.Num4)
        Me.Nums.Controls.Add(Me.Num9)
        Me.Nums.Controls.Add(Me.Num8)
        Me.Nums.Controls.Add(Me.Num7)
        Me.Nums.Controls.Add(Me.Num3)
        Me.Nums.Controls.Add(Me.Num2)
        Me.Nums.Controls.Add(Me.Num1)
        Me.Nums.Location = New System.Drawing.Point(34, 132)
        Me.Nums.Name = "Nums"
        Me.Nums.Size = New System.Drawing.Size(182, 248)
        Me.Nums.TabIndex = 1
        '
        'NumCE
        '
        Me.NumCE.Location = New System.Drawing.Point(129, 188)
        Me.NumCE.Name = "NumCE"
        Me.NumCE.Size = New System.Drawing.Size(36, 33)
        Me.NumCE.TabIndex = 11
        Me.NumCE.Text = "CE"
        Me.NumCE.UseVisualStyleBackColor = True
        '
        'NumDot
        '
        Me.NumDot.Location = New System.Drawing.Point(73, 188)
        Me.NumDot.Name = "NumDot"
        Me.NumDot.Size = New System.Drawing.Size(36, 33)
        Me.NumDot.TabIndex = 10
        Me.NumDot.Text = "."
        Me.NumDot.UseVisualStyleBackColor = True
        '
        'Num0
        '
        Me.Num0.Location = New System.Drawing.Point(19, 188)
        Me.Num0.Name = "Num0"
        Me.Num0.Size = New System.Drawing.Size(36, 33)
        Me.Num0.TabIndex = 9
        Me.Num0.Text = "0"
        Me.Num0.UseVisualStyleBackColor = True
        '
        'Num6
        '
        Me.Num6.Location = New System.Drawing.Point(129, 75)
        Me.Num6.Name = "Num6"
        Me.Num6.Size = New System.Drawing.Size(36, 33)
        Me.Num6.TabIndex = 8
        Me.Num6.Text = "6"
        Me.Num6.UseVisualStyleBackColor = True
        '
        'Num5
        '
        Me.Num5.Location = New System.Drawing.Point(73, 75)
        Me.Num5.Name = "Num5"
        Me.Num5.Size = New System.Drawing.Size(36, 33)
        Me.Num5.TabIndex = 7
        Me.Num5.Text = "5"
        Me.Num5.UseVisualStyleBackColor = True
        '
        'Num4
        '
        Me.Num4.Location = New System.Drawing.Point(19, 75)
        Me.Num4.Name = "Num4"
        Me.Num4.Size = New System.Drawing.Size(36, 33)
        Me.Num4.TabIndex = 6
        Me.Num4.Text = "4"
        Me.Num4.UseVisualStyleBackColor = True
        '
        'Num9
        '
        Me.Num9.Location = New System.Drawing.Point(129, 132)
        Me.Num9.Name = "Num9"
        Me.Num9.Size = New System.Drawing.Size(36, 33)
        Me.Num9.TabIndex = 5
        Me.Num9.Text = "9"
        Me.Num9.UseVisualStyleBackColor = True
        '
        'Num8
        '
        Me.Num8.Location = New System.Drawing.Point(73, 132)
        Me.Num8.Name = "Num8"
        Me.Num8.Size = New System.Drawing.Size(36, 33)
        Me.Num8.TabIndex = 4
        Me.Num8.Text = "8"
        Me.Num8.UseVisualStyleBackColor = True
        '
        'Num7
        '
        Me.Num7.Location = New System.Drawing.Point(19, 132)
        Me.Num7.Name = "Num7"
        Me.Num7.Size = New System.Drawing.Size(36, 33)
        Me.Num7.TabIndex = 3
        Me.Num7.Text = "7"
        Me.Num7.UseVisualStyleBackColor = True
        '
        'Num3
        '
        Me.Num3.Location = New System.Drawing.Point(129, 15)
        Me.Num3.Name = "Num3"
        Me.Num3.Size = New System.Drawing.Size(36, 33)
        Me.Num3.TabIndex = 2
        Me.Num3.Text = "3"
        Me.Num3.UseVisualStyleBackColor = True
        '
        'Num2
        '
        Me.Num2.Location = New System.Drawing.Point(73, 15)
        Me.Num2.Name = "Num2"
        Me.Num2.Size = New System.Drawing.Size(36, 33)
        Me.Num2.TabIndex = 1
        Me.Num2.Text = "2"
        Me.Num2.UseVisualStyleBackColor = True
        '
        'Num1
        '
        Me.Num1.Location = New System.Drawing.Point(19, 15)
        Me.Num1.Name = "Num1"
        Me.Num1.Size = New System.Drawing.Size(36, 33)
        Me.Num1.TabIndex = 0
        Me.Num1.Text = "1"
        Me.Num1.UseVisualStyleBackColor = True
        '
        'Operators
        '
        Me.Operators.Controls.Add(Me.Equation)
        Me.Operators.Controls.Add(Me.OP4)
        Me.Operators.Controls.Add(Me.OP3)
        Me.Operators.Controls.Add(Me.OP2)
        Me.Operators.Controls.Add(Me.OP1)
        Me.Operators.Location = New System.Drawing.Point(222, 132)
        Me.Operators.Name = "Operators"
        Me.Operators.Size = New System.Drawing.Size(107, 248)
        Me.Operators.TabIndex = 2
        '
        'Equation
        '
        Me.Equation.Location = New System.Drawing.Point(34, 174)
        Me.Equation.Name = "Equation"
        Me.Equation.Size = New System.Drawing.Size(45, 42)
        Me.Equation.TabIndex = 4
        Me.Equation.Text = "="
        Me.Equation.UseVisualStyleBackColor = True
        '
        'OP4
        '
        Me.OP4.Location = New System.Drawing.Point(34, 134)
        Me.OP4.Name = "OP4"
        Me.OP4.Size = New System.Drawing.Size(45, 42)
        Me.OP4.TabIndex = 3
        Me.OP4.Text = "/"
        Me.OP4.UseVisualStyleBackColor = True
        '
        'OP3
        '
        Me.OP3.Location = New System.Drawing.Point(34, 94)
        Me.OP3.Name = "OP3"
        Me.OP3.Size = New System.Drawing.Size(45, 42)
        Me.OP3.TabIndex = 2
        Me.OP3.Text = "*"
        Me.OP3.UseVisualStyleBackColor = True
        '
        'OP2
        '
        Me.OP2.Location = New System.Drawing.Point(34, 53)
        Me.OP2.Name = "OP2"
        Me.OP2.Size = New System.Drawing.Size(45, 42)
        Me.OP2.TabIndex = 1
        Me.OP2.Text = "-"
        Me.OP2.UseVisualStyleBackColor = True
        '
        'OP1
        '
        Me.OP1.Location = New System.Drawing.Point(34, 13)
        Me.OP1.Name = "OP1"
        Me.OP1.Size = New System.Drawing.Size(45, 42)
        Me.OP1.TabIndex = 0
        Me.OP1.Text = "+"
        Me.OP1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(163, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(253, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(374, 408)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Operators)
        Me.Controls.Add(Me.Nums)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "计算器"
        Me.Nums.ResumeLayout(False)
        Me.Operators.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Nums As System.Windows.Forms.Panel
    Friend WithEvents NumCE As System.Windows.Forms.Button
    Friend WithEvents NumDot As System.Windows.Forms.Button
    Friend WithEvents Num0 As System.Windows.Forms.Button
    Friend WithEvents Num6 As System.Windows.Forms.Button
    Friend WithEvents Num5 As System.Windows.Forms.Button
    Friend WithEvents Num4 As System.Windows.Forms.Button
    Friend WithEvents Num9 As System.Windows.Forms.Button
    Friend WithEvents Num8 As System.Windows.Forms.Button
    Friend WithEvents Num7 As System.Windows.Forms.Button
    Friend WithEvents Num3 As System.Windows.Forms.Button
    Friend WithEvents Num2 As System.Windows.Forms.Button
    Friend WithEvents Num1 As System.Windows.Forms.Button
    Friend WithEvents Operators As System.Windows.Forms.Panel
    Friend WithEvents Equation As System.Windows.Forms.Button
    Friend WithEvents OP4 As System.Windows.Forms.Button
    Friend WithEvents OP3 As System.Windows.Forms.Button
    Friend WithEvents OP2 As System.Windows.Forms.Button
    Friend WithEvents OP1 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
