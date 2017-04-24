<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.PwdL = New System.Windows.Forms.Label()
        Me.PwdT = New System.Windows.Forms.TextBox()
        Me.Login = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PwdL
        '
        Me.PwdL.AutoSize = True
        Me.PwdL.Location = New System.Drawing.Point(82, 55)
        Me.PwdL.Name = "PwdL"
        Me.PwdL.Size = New System.Drawing.Size(97, 15)
        Me.PwdL.TabIndex = 0
        Me.PwdL.Text = "请输入密码："
        '
        'PwdT
        '
        Me.PwdT.Location = New System.Drawing.Point(107, 83)
        Me.PwdT.Name = "PwdT"
        Me.PwdT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PwdT.Size = New System.Drawing.Size(265, 25)
        Me.PwdT.TabIndex = 1
        '
        'Login
        '
        Me.Login.Location = New System.Drawing.Point(66, 144)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(145, 29)
        Me.Login.TabIndex = 2
        Me.Login.Text = "登录"
        Me.Login.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(246, 144)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(145, 29)
        Me.Cancel.TabIndex = 3
        Me.Cancel.Text = "取消"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'LoginForm
        '
        Me.AcceptButton = Me.Login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(453, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.PwdT)
        Me.Controls.Add(Me.PwdL)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "管理员登录"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PwdL As Label
    Friend WithEvents PwdT As TextBox
    Friend WithEvents Login As Button
    Friend WithEvents Cancel As Button
End Class
