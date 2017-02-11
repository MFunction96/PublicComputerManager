'**********************************************************
'名称：登录窗体
'功能：作为管理员登录界面
'**********************************************************
Public Class LoginForm
    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        With MainForm
            .AccAdmin.Enabled = False
            .MmcB.Enabled = True
            .MdfPwd.Enabled = True
            .CancelDown.Enabled = True
            .ReExp.Enabled = True
            .CtrlPalB.Enabled = True
            .LauncherB.Enabled = True
            .CmdB.Enabled = True
            .TaskmgrB.Enabled = True
            .LimitDiskB.Enabled = True
            .LimProcB.Enabled = True
            .Tools.Enabled = True
            .RegistryB.Enabled = True
            .Enabled = True
        End With
        Dispose()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        MainForm.Enabled = True
        Dispose()
    End Sub

End Class