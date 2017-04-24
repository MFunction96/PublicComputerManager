'**********************************************************
'名称：登录窗体
'功能：作为管理员登录界面
'**********************************************************

Imports PublicComputerManager.RegOpt

Public Class LoginForm

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        RegAPI.RegSetValue(New RegKey(RegPath.HKEY_CURRENT_USER, "Software\PublicComputerManager", "Passwd",, RegKey.REG_SZ, "123456"))
        Dim rk As RegKey = RegAPI.RegGetValue(New RegPath(RegPath.HKEY_CURRENT_USER, "Software\PublicComputerManager", "Passwd"))
        If rk.Regvalue.ToString() = PwdT.Text Then
            With MainForm
                .AccAdmin.Enabled = False
                '.MmcB.Enabled = True
                '.MdfPwd.Enabled = True
                '.CancelDown.Enabled = True
                '.ReExp.Enabled = True
                .CtrlPalB.Enabled = True
                .LauncherB.Enabled = True
                .CmdB.Enabled = True
                .TaskmgrB.Enabled = True
                .LimitDiskB.Enabled = True
                .LimProcB.Enabled = True
                '.Tools.Enabled = True
                .RegistryB.Enabled = True
                .Enabled = True
            End With
        Else
            MsgBox("密码错误！", CType(vbCritical + vbOKOnly, MsgBoxStyle), "错误")
            PwdT.Text = vbNullString
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        MainForm.Enabled = True
        Dispose()
    End Sub

End Class