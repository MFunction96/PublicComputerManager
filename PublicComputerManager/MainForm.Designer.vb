<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.AdminGroup = New System.Windows.Forms.GroupBox()
        Me.ReExp = New System.Windows.Forms.Button()
        Me.CancelDown = New System.Windows.Forms.Button()
        Me.MdfPwd = New System.Windows.Forms.Button()
        Me.AccAdmin = New System.Windows.Forms.Button()
        Me.Tools = New System.Windows.Forms.GroupBox()
        Me.DiskGenius = New System.Windows.Forms.Button()
        Me.PCHunter = New System.Windows.Forms.Button()
        Me.AccessLimit = New System.Windows.Forms.GroupBox()
        Me.LimitDiskB = New System.Windows.Forms.Button()
        Me.LimitDiskS = New System.Windows.Forms.Label()
        Me.LimitDiskT = New System.Windows.Forms.Label()
        Me.LimProcB = New System.Windows.Forms.Button()
        Me.LimProcS = New System.Windows.Forms.Label()
        Me.LimProcT = New System.Windows.Forms.Label()
        Me.ManageLimit = New System.Windows.Forms.GroupBox()
        Me.PwrShellB = New System.Windows.Forms.Button()
        Me.PwrShellS = New System.Windows.Forms.Label()
        Me.PwrShellT = New System.Windows.Forms.Label()
        Me.TaskSchB = New System.Windows.Forms.Button()
        Me.CmdB = New System.Windows.Forms.Button()
        Me.TaskmgrT = New System.Windows.Forms.Label()
        Me.TaskSchS = New System.Windows.Forms.Label()
        Me.TaskmgrS = New System.Windows.Forms.Label()
        Me.TaskSchT = New System.Windows.Forms.Label()
        Me.TaskmgrB = New System.Windows.Forms.Button()
        Me.LauncherB = New System.Windows.Forms.Button()
        Me.CmdT = New System.Windows.Forms.Label()
        Me.LauncherS = New System.Windows.Forms.Label()
        Me.CmdS = New System.Windows.Forms.Label()
        Me.LauncherT = New System.Windows.Forms.Label()
        Me.CtrlPalB = New System.Windows.Forms.Button()
        Me.CtrlPalS = New System.Windows.Forms.Label()
        Me.CtrlPalT = New System.Windows.Forms.Label()
        Me.MmcB = New System.Windows.Forms.Button()
        Me.MmcS = New System.Windows.Forms.Label()
        Me.MmcT = New System.Windows.Forms.Label()
        Me.RegistryB = New System.Windows.Forms.Button()
        Me.RegistryS = New System.Windows.Forms.Label()
        Me.RegistryT = New System.Windows.Forms.Label()
        Me.AdminGroup.SuspendLayout()
        Me.Tools.SuspendLayout()
        Me.AccessLimit.SuspendLayout()
        Me.ManageLimit.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdminGroup
        '
        Me.AdminGroup.Controls.Add(Me.ReExp)
        Me.AdminGroup.Controls.Add(Me.CancelDown)
        Me.AdminGroup.Controls.Add(Me.MdfPwd)
        Me.AdminGroup.Controls.Add(Me.AccAdmin)
        Me.AdminGroup.Location = New System.Drawing.Point(54, 50)
        Me.AdminGroup.Name = "AdminGroup"
        Me.AdminGroup.Size = New System.Drawing.Size(210, 261)
        Me.AdminGroup.TabIndex = 0
        Me.AdminGroup.TabStop = False
        Me.AdminGroup.Text = "管理控制"
        '
        'ReExp
        '
        Me.ReExp.Enabled = False
        Me.ReExp.Location = New System.Drawing.Point(33, 196)
        Me.ReExp.Name = "ReExp"
        Me.ReExp.Size = New System.Drawing.Size(137, 28)
        Me.ReExp.TabIndex = 3
        Me.ReExp.Text = "重启Explorer"
        Me.ReExp.UseVisualStyleBackColor = True
        '
        'CancelDown
        '
        Me.CancelDown.Enabled = False
        Me.CancelDown.Location = New System.Drawing.Point(33, 145)
        Me.CancelDown.Name = "CancelDown"
        Me.CancelDown.Size = New System.Drawing.Size(137, 28)
        Me.CancelDown.TabIndex = 2
        Me.CancelDown.Text = "取消关机"
        Me.CancelDown.UseVisualStyleBackColor = True
        '
        'MdfPwd
        '
        Me.MdfPwd.Enabled = False
        Me.MdfPwd.Location = New System.Drawing.Point(33, 94)
        Me.MdfPwd.Name = "MdfPwd"
        Me.MdfPwd.Size = New System.Drawing.Size(137, 28)
        Me.MdfPwd.TabIndex = 1
        Me.MdfPwd.Text = "修改密码"
        Me.MdfPwd.UseVisualStyleBackColor = True
        '
        'AccAdmin
        '
        Me.AccAdmin.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AccAdmin.Location = New System.Drawing.Point(33, 42)
        Me.AccAdmin.Name = "AccAdmin"
        Me.AccAdmin.Size = New System.Drawing.Size(137, 28)
        Me.AccAdmin.TabIndex = 0
        Me.AccAdmin.Text = "切换为管理员模式"
        Me.AccAdmin.UseVisualStyleBackColor = True
        '
        'Tools
        '
        Me.Tools.Controls.Add(Me.DiskGenius)
        Me.Tools.Controls.Add(Me.PCHunter)
        Me.Tools.Enabled = False
        Me.Tools.Location = New System.Drawing.Point(54, 343)
        Me.Tools.Name = "Tools"
        Me.Tools.Size = New System.Drawing.Size(210, 157)
        Me.Tools.TabIndex = 1
        Me.Tools.TabStop = False
        Me.Tools.Text = "辅助工具"
        '
        'DiskGenius
        '
        Me.DiskGenius.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DiskGenius.Location = New System.Drawing.Point(33, 94)
        Me.DiskGenius.Name = "DiskGenius"
        Me.DiskGenius.Size = New System.Drawing.Size(137, 28)
        Me.DiskGenius.TabIndex = 5
        Me.DiskGenius.Text = "DiskGenius"
        Me.DiskGenius.UseVisualStyleBackColor = True
        '
        'PCHunter
        '
        Me.PCHunter.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.PCHunter.Location = New System.Drawing.Point(33, 45)
        Me.PCHunter.Name = "PCHunter"
        Me.PCHunter.Size = New System.Drawing.Size(137, 28)
        Me.PCHunter.TabIndex = 4
        Me.PCHunter.Text = "PCHunter"
        Me.PCHunter.UseVisualStyleBackColor = True
        '
        'AccessLimit
        '
        Me.AccessLimit.Controls.Add(Me.LimitDiskB)
        Me.AccessLimit.Controls.Add(Me.LimitDiskS)
        Me.AccessLimit.Controls.Add(Me.LimitDiskT)
        Me.AccessLimit.Controls.Add(Me.LimProcB)
        Me.AccessLimit.Controls.Add(Me.LimProcS)
        Me.AccessLimit.Controls.Add(Me.LimProcT)
        Me.AccessLimit.Location = New System.Drawing.Point(305, 31)
        Me.AccessLimit.Name = "AccessLimit"
        Me.AccessLimit.Size = New System.Drawing.Size(347, 137)
        Me.AccessLimit.TabIndex = 2
        Me.AccessLimit.TabStop = False
        Me.AccessLimit.Text = "访问限制"
        '
        'LimitDiskB
        '
        Me.LimitDiskB.Enabled = False
        Me.LimitDiskB.Location = New System.Drawing.Point(246, 82)
        Me.LimitDiskB.Name = "LimitDiskB"
        Me.LimitDiskB.Size = New System.Drawing.Size(84, 31)
        Me.LimitDiskB.TabIndex = 7
        Me.LimitDiskB.Text = "检测中..."
        Me.LimitDiskB.UseVisualStyleBackColor = True
        '
        'LimitDiskS
        '
        Me.LimitDiskS.AutoSize = True
        Me.LimitDiskS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LimitDiskS.ForeColor = System.Drawing.Color.DarkGray
        Me.LimitDiskS.Location = New System.Drawing.Point(158, 92)
        Me.LimitDiskS.Name = "LimitDiskS"
        Me.LimitDiskS.Size = New System.Drawing.Size(82, 15)
        Me.LimitDiskS.TabIndex = 4
        Me.LimitDiskS.Text = "检测中..."
        '
        'LimitDiskT
        '
        Me.LimitDiskT.AutoSize = True
        Me.LimitDiskT.Location = New System.Drawing.Point(25, 92)
        Me.LimitDiskT.Name = "LimitDiskT"
        Me.LimitDiskT.Size = New System.Drawing.Size(127, 15)
        Me.LimitDiskT.TabIndex = 3
        Me.LimitDiskT.Text = "限制访问系统分区"
        '
        'LimProcB
        '
        Me.LimProcB.Enabled = False
        Me.LimProcB.Location = New System.Drawing.Point(246, 34)
        Me.LimProcB.Name = "LimProcB"
        Me.LimProcB.Size = New System.Drawing.Size(84, 31)
        Me.LimProcB.TabIndex = 6
        Me.LimProcB.Text = "检测中..."
        Me.LimProcB.UseVisualStyleBackColor = True
        '
        'LimProcS
        '
        Me.LimProcS.AutoSize = True
        Me.LimProcS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LimProcS.ForeColor = System.Drawing.Color.DarkGray
        Me.LimProcS.Location = New System.Drawing.Point(158, 44)
        Me.LimProcS.Name = "LimProcS"
        Me.LimProcS.Size = New System.Drawing.Size(82, 15)
        Me.LimProcS.TabIndex = 1
        Me.LimProcS.Text = "检测中..."
        '
        'LimProcT
        '
        Me.LimProcT.AutoSize = True
        Me.LimProcT.Location = New System.Drawing.Point(25, 44)
        Me.LimProcT.Name = "LimProcT"
        Me.LimProcT.Size = New System.Drawing.Size(127, 15)
        Me.LimProcT.TabIndex = 0
        Me.LimProcT.Text = "全面限制进程运行"
        '
        'ManageLimit
        '
        Me.ManageLimit.Controls.Add(Me.PwrShellB)
        Me.ManageLimit.Controls.Add(Me.PwrShellS)
        Me.ManageLimit.Controls.Add(Me.PwrShellT)
        Me.ManageLimit.Controls.Add(Me.TaskSchB)
        Me.ManageLimit.Controls.Add(Me.CmdB)
        Me.ManageLimit.Controls.Add(Me.TaskmgrT)
        Me.ManageLimit.Controls.Add(Me.TaskSchS)
        Me.ManageLimit.Controls.Add(Me.TaskmgrS)
        Me.ManageLimit.Controls.Add(Me.TaskSchT)
        Me.ManageLimit.Controls.Add(Me.TaskmgrB)
        Me.ManageLimit.Controls.Add(Me.LauncherB)
        Me.ManageLimit.Controls.Add(Me.CmdT)
        Me.ManageLimit.Controls.Add(Me.LauncherS)
        Me.ManageLimit.Controls.Add(Me.CmdS)
        Me.ManageLimit.Controls.Add(Me.LauncherT)
        Me.ManageLimit.Controls.Add(Me.CtrlPalB)
        Me.ManageLimit.Controls.Add(Me.CtrlPalS)
        Me.ManageLimit.Controls.Add(Me.CtrlPalT)
        Me.ManageLimit.Controls.Add(Me.MmcB)
        Me.ManageLimit.Controls.Add(Me.MmcS)
        Me.ManageLimit.Controls.Add(Me.MmcT)
        Me.ManageLimit.Controls.Add(Me.RegistryB)
        Me.ManageLimit.Controls.Add(Me.RegistryS)
        Me.ManageLimit.Controls.Add(Me.RegistryT)
        Me.ManageLimit.Location = New System.Drawing.Point(305, 189)
        Me.ManageLimit.Name = "ManageLimit"
        Me.ManageLimit.Size = New System.Drawing.Size(347, 348)
        Me.ManageLimit.TabIndex = 3
        Me.ManageLimit.TabStop = False
        Me.ManageLimit.Text = "管理限制"
        '
        'PwrShellB
        '
        Me.PwrShellB.Enabled = False
        Me.PwrShellB.Location = New System.Drawing.Point(246, 293)
        Me.PwrShellB.Name = "PwrShellB"
        Me.PwrShellB.Size = New System.Drawing.Size(84, 31)
        Me.PwrShellB.TabIndex = 15
        Me.PwrShellB.Text = "暂不可用"
        Me.PwrShellB.UseVisualStyleBackColor = True
        '
        'PwrShellS
        '
        Me.PwrShellS.AutoSize = True
        Me.PwrShellS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PwrShellS.ForeColor = System.Drawing.Color.DarkGray
        Me.PwrShellS.Location = New System.Drawing.Point(158, 303)
        Me.PwrShellS.Name = "PwrShellS"
        Me.PwrShellS.Size = New System.Drawing.Size(71, 15)
        Me.PwrShellS.TabIndex = 28
        Me.PwrShellS.Text = "暂不可用"
        '
        'PwrShellT
        '
        Me.PwrShellT.AutoSize = True
        Me.PwrShellT.Location = New System.Drawing.Point(20, 301)
        Me.PwrShellT.Name = "PwrShellT"
        Me.PwrShellT.Size = New System.Drawing.Size(117, 15)
        Me.PwrShellT.TabIndex = 27
        Me.PwrShellT.Text = "PowerShell状态"
        '
        'TaskSchB
        '
        Me.TaskSchB.Enabled = False
        Me.TaskSchB.Location = New System.Drawing.Point(246, 108)
        Me.TaskSchB.Name = "TaskSchB"
        Me.TaskSchB.Size = New System.Drawing.Size(84, 31)
        Me.TaskSchB.TabIndex = 10
        Me.TaskSchB.Text = "暂不可用"
        Me.TaskSchB.UseVisualStyleBackColor = True
        '
        'CmdB
        '
        Me.CmdB.Enabled = False
        Me.CmdB.Location = New System.Drawing.Point(246, 219)
        Me.CmdB.Name = "CmdB"
        Me.CmdB.Size = New System.Drawing.Size(84, 31)
        Me.CmdB.TabIndex = 13
        Me.CmdB.Text = "检测中..."
        Me.CmdB.UseVisualStyleBackColor = True
        '
        'TaskmgrT
        '
        Me.TaskmgrT.AutoSize = True
        Me.TaskmgrT.Location = New System.Drawing.Point(25, 266)
        Me.TaskmgrT.Name = "TaskmgrT"
        Me.TaskmgrT.Size = New System.Drawing.Size(112, 15)
        Me.TaskmgrT.TabIndex = 6
        Me.TaskmgrT.Text = "任务管理器状态"
        '
        'TaskSchS
        '
        Me.TaskSchS.AutoSize = True
        Me.TaskSchS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TaskSchS.ForeColor = System.Drawing.Color.DarkGray
        Me.TaskSchS.Location = New System.Drawing.Point(158, 118)
        Me.TaskSchS.Name = "TaskSchS"
        Me.TaskSchS.Size = New System.Drawing.Size(71, 15)
        Me.TaskSchS.TabIndex = 25
        Me.TaskSchS.Text = "暂不可用"
        '
        'TaskmgrS
        '
        Me.TaskmgrS.AutoSize = True
        Me.TaskmgrS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TaskmgrS.ForeColor = System.Drawing.Color.DarkGray
        Me.TaskmgrS.Location = New System.Drawing.Point(158, 266)
        Me.TaskmgrS.Name = "TaskmgrS"
        Me.TaskmgrS.Size = New System.Drawing.Size(82, 15)
        Me.TaskmgrS.TabIndex = 7
        Me.TaskmgrS.Text = "检测中..."
        '
        'TaskSchT
        '
        Me.TaskSchT.AutoSize = True
        Me.TaskSchT.Location = New System.Drawing.Point(40, 116)
        Me.TaskSchT.Name = "TaskSchT"
        Me.TaskSchT.Size = New System.Drawing.Size(97, 15)
        Me.TaskSchT.TabIndex = 24
        Me.TaskSchT.Text = "计划任务状态"
        '
        'TaskmgrB
        '
        Me.TaskmgrB.Enabled = False
        Me.TaskmgrB.Location = New System.Drawing.Point(246, 256)
        Me.TaskmgrB.Name = "TaskmgrB"
        Me.TaskmgrB.Size = New System.Drawing.Size(84, 31)
        Me.TaskmgrB.TabIndex = 14
        Me.TaskmgrB.Text = "检测中..."
        Me.TaskmgrB.UseVisualStyleBackColor = True
        '
        'LauncherB
        '
        Me.LauncherB.Enabled = False
        Me.LauncherB.Location = New System.Drawing.Point(246, 182)
        Me.LauncherB.Name = "LauncherB"
        Me.LauncherB.Size = New System.Drawing.Size(84, 31)
        Me.LauncherB.TabIndex = 12
        Me.LauncherB.Text = "检测中..."
        Me.LauncherB.UseVisualStyleBackColor = True
        '
        'CmdT
        '
        Me.CmdT.AutoSize = True
        Me.CmdT.Location = New System.Drawing.Point(25, 229)
        Me.CmdT.Name = "CmdT"
        Me.CmdT.Size = New System.Drawing.Size(112, 15)
        Me.CmdT.TabIndex = 12
        Me.CmdT.Text = "命令提示符状态"
        '
        'LauncherS
        '
        Me.LauncherS.AutoSize = True
        Me.LauncherS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LauncherS.ForeColor = System.Drawing.Color.DarkGray
        Me.LauncherS.Location = New System.Drawing.Point(158, 192)
        Me.LauncherS.Name = "LauncherS"
        Me.LauncherS.Size = New System.Drawing.Size(82, 15)
        Me.LauncherS.TabIndex = 22
        Me.LauncherS.Text = "检测中..."
        '
        'CmdS
        '
        Me.CmdS.AutoSize = True
        Me.CmdS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CmdS.ForeColor = System.Drawing.Color.DarkGray
        Me.CmdS.Location = New System.Drawing.Point(158, 229)
        Me.CmdS.Name = "CmdS"
        Me.CmdS.Size = New System.Drawing.Size(82, 15)
        Me.CmdS.TabIndex = 13
        Me.CmdS.Text = "检测中..."
        '
        'LauncherT
        '
        Me.LauncherT.AutoSize = True
        Me.LauncherT.Location = New System.Drawing.Point(40, 190)
        Me.LauncherT.Name = "LauncherT"
        Me.LauncherT.Size = New System.Drawing.Size(97, 15)
        Me.LauncherT.TabIndex = 21
        Me.LauncherT.Text = "运行工具状态"
        '
        'CtrlPalB
        '
        Me.CtrlPalB.Enabled = False
        Me.CtrlPalB.Location = New System.Drawing.Point(246, 145)
        Me.CtrlPalB.Name = "CtrlPalB"
        Me.CtrlPalB.Size = New System.Drawing.Size(84, 31)
        Me.CtrlPalB.TabIndex = 11
        Me.CtrlPalB.Text = "检测中..."
        Me.CtrlPalB.UseVisualStyleBackColor = True
        '
        'CtrlPalS
        '
        Me.CtrlPalS.AutoSize = True
        Me.CtrlPalS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CtrlPalS.ForeColor = System.Drawing.Color.DarkGray
        Me.CtrlPalS.Location = New System.Drawing.Point(158, 155)
        Me.CtrlPalS.Name = "CtrlPalS"
        Me.CtrlPalS.Size = New System.Drawing.Size(82, 15)
        Me.CtrlPalS.TabIndex = 19
        Me.CtrlPalS.Text = "检测中..."
        '
        'CtrlPalT
        '
        Me.CtrlPalT.AutoSize = True
        Me.CtrlPalT.Location = New System.Drawing.Point(40, 153)
        Me.CtrlPalT.Name = "CtrlPalT"
        Me.CtrlPalT.Size = New System.Drawing.Size(97, 15)
        Me.CtrlPalT.TabIndex = 18
        Me.CtrlPalT.Text = "控制面板状态"
        '
        'MmcB
        '
        Me.MmcB.Enabled = False
        Me.MmcB.Location = New System.Drawing.Point(246, 34)
        Me.MmcB.Name = "MmcB"
        Me.MmcB.Size = New System.Drawing.Size(84, 31)
        Me.MmcB.TabIndex = 8
        Me.MmcB.Text = "暂不可用"
        Me.MmcB.UseVisualStyleBackColor = True
        '
        'MmcS
        '
        Me.MmcS.AutoSize = True
        Me.MmcS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.MmcS.ForeColor = System.Drawing.Color.DarkGray
        Me.MmcS.Location = New System.Drawing.Point(158, 44)
        Me.MmcS.Name = "MmcS"
        Me.MmcS.Size = New System.Drawing.Size(71, 15)
        Me.MmcS.TabIndex = 16
        Me.MmcS.Text = "暂不可用"
        '
        'MmcT
        '
        Me.MmcT.AutoSize = True
        Me.MmcT.Location = New System.Drawing.Point(55, 42)
        Me.MmcT.Name = "MmcT"
        Me.MmcT.Size = New System.Drawing.Size(82, 15)
        Me.MmcT.TabIndex = 15
        Me.MmcT.Text = "控制台状态"
        '
        'RegistryB
        '
        Me.RegistryB.Enabled = False
        Me.RegistryB.Location = New System.Drawing.Point(246, 71)
        Me.RegistryB.Name = "RegistryB"
        Me.RegistryB.Size = New System.Drawing.Size(84, 31)
        Me.RegistryB.TabIndex = 9
        Me.RegistryB.Text = "检测中..."
        Me.RegistryB.UseVisualStyleBackColor = True
        '
        'RegistryS
        '
        Me.RegistryS.AutoSize = True
        Me.RegistryS.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RegistryS.ForeColor = System.Drawing.Color.DarkGray
        Me.RegistryS.Location = New System.Drawing.Point(158, 81)
        Me.RegistryS.Name = "RegistryS"
        Me.RegistryS.Size = New System.Drawing.Size(82, 15)
        Me.RegistryS.TabIndex = 10
        Me.RegistryS.Text = "检测中..."
        '
        'RegistryT
        '
        Me.RegistryT.AutoSize = True
        Me.RegistryT.Location = New System.Drawing.Point(55, 79)
        Me.RegistryT.Name = "RegistryT"
        Me.RegistryT.Size = New System.Drawing.Size(82, 15)
        Me.RegistryT.TabIndex = 9
        Me.RegistryT.Text = "注册表状态"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(699, 596)
        Me.Controls.Add(Me.ManageLimit)
        Me.Controls.Add(Me.AccessLimit)
        Me.Controls.Add(Me.Tools)
        Me.Controls.Add(Me.AdminGroup)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PublicComputerManager"
        Me.AdminGroup.ResumeLayout(False)
        Me.Tools.ResumeLayout(False)
        Me.AccessLimit.ResumeLayout(False)
        Me.AccessLimit.PerformLayout()
        Me.ManageLimit.ResumeLayout(False)
        Me.ManageLimit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AdminGroup As GroupBox
    Friend WithEvents MdfPwd As Button
    Friend WithEvents AccAdmin As Button
    Friend WithEvents CancelDown As Button
    Friend WithEvents ReExp As Button
    Friend WithEvents Tools As GroupBox
    Friend WithEvents DiskGenius As Button
    Friend WithEvents PCHunter As Button
    Friend WithEvents AccessLimit As GroupBox
    Friend WithEvents LimProcB As Button
    Friend WithEvents LimProcS As Label
    Friend WithEvents LimProcT As Label
    Friend WithEvents LimitDiskB As Button
    Friend WithEvents LimitDiskS As Label
    Friend WithEvents LimitDiskT As Label
    Friend WithEvents ManageLimit As GroupBox
    Friend WithEvents RegistryB As Button
    Friend WithEvents RegistryS As Label
    Friend WithEvents RegistryT As Label
    Friend WithEvents TaskmgrB As Button
    Friend WithEvents TaskmgrS As Label
    Friend WithEvents TaskmgrT As Label
    Friend WithEvents MmcB As Button
    Friend WithEvents MmcS As Label
    Friend WithEvents MmcT As Label
    Friend WithEvents CmdB As Button
    Friend WithEvents CmdS As Label
    Friend WithEvents CmdT As Label
    Friend WithEvents CtrlPalB As Button
    Friend WithEvents CtrlPalS As Label
    Friend WithEvents CtrlPalT As Label
    Friend WithEvents LauncherB As Button
    Friend WithEvents LauncherS As Label
    Friend WithEvents LauncherT As Label
    Friend WithEvents PwrShellB As Button
    Friend WithEvents PwrShellS As Label
    Friend WithEvents PwrShellT As Label
    Friend WithEvents TaskSchB As Button
    Friend WithEvents TaskSchS As Label
    Friend WithEvents TaskSchT As Label
End Class
