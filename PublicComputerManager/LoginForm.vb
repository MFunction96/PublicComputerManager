'**********************************************************
'名称：登录窗体
'功能：作为管理员登录界面
'**********************************************************

Imports PublicComputerManager.RegOpt

Public Class LoginForm

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim rk As RegKey
        Try
            rk = RegAPI.RegGetValue(New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\PublicComputerManager", "Passwd"))
            If rk.Regvalue.ToString() = vbNullString Then
                Throw New Exception("程序错误！")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
            Exit Sub
        End Try
        If rk.Regvalue.ToString() = DESCrypt.Encrypt(PwdT.Text) Then
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
            Enabled = False
            Close()
        Else
            MsgBox("密码错误！", CType(vbCritical + vbOKOnly, MsgBoxStyle), "错误")
            PwdT.Text = vbNullString
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        MainForm.Enabled = True
        Close()
    End Sub

    Private Shared Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class