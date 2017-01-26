'**********************************************************
'名称：主窗体
'功能：本程序的核心窗口，功能的控制面板
'修改时间：2017-01-24
'**********************************************************
Public Class MainForm

    Private limproc As Status
    Private limitdisk As Status
    Private mmc As Status
    Private registry As Status
    Private task As Status
    Private conpal As Status
    Private launcher As Status
    Private cmd As Status
    Private taskmgr As Status
    Private pwrshell As Status

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim onreg(), offreg() As REGVALUESET
        Dim n As Integer
        n = 1
        ReDim onreg(n), offreg(n)
        onreg(0) = New REGVALUESET(False, RegAPI.REG_TYPE.REG_DWORD, &H40000, True)
        offreg(0) = New REGVALUESET(True, RegAPI.REG_TYPE.REG_DWORD, &H0, True)
        limproc = New Status(LimProcS, LimProcB, n, RegAPI.REG_ROOT_KEY.HKEY_LOCAL_MACHINE, "Software\Policies\Microsoft\Windows\safer\codeidentifiers", "DefaultLevel", onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        onreg(0) = New REGVALUESET(False, RegAPI.REG_TYPE.REG_DWORD, &H4, True)
        offreg(0) = New REGVALUESET(True, RegAPI.REG_TYPE.REG_DWORD, &H0, True)
        limitdisk = New Status(LimitDiskS, LimitDiskB, n, RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoDrives", onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        onreg(0) = New REGVALUESET(False, RegAPI.REG_TYPE.REG_DWORD, &H2, True)
        offreg(0) = New REGVALUESET(True, RegAPI.REG_TYPE.REG_DWORD, &H0, True)
        registry = New Status(RegistryS, RegistryB, n, RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        onreg(0) = New REGVALUESET(False, RegAPI.REG_TYPE.REG_DWORD, &H1, True)
        offreg(0) = New REGVALUESET(True, RegAPI.REG_TYPE.REG_DWORD, &H0, True)
        cmd = New Status(CmdS, CmdB, n, RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Policies\Microsoft\Windows\System", "DisableCMD", onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        onreg(0) = New REGVALUESET(False, RegAPI.REG_TYPE.REG_DWORD, &H1, True)
        offreg(0) = New REGVALUESET(True, RegAPI.REG_TYPE.REG_DWORD, &H0, True)
        taskmgr = New Status(TaskmgrS, TaskmgrB, n, RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        onreg(0) = New REGVALUESET(False, RegAPI.REG_TYPE.REG_DWORD, &H1, True)
        offreg(0) = New REGVALUESET(True, RegAPI.REG_TYPE.REG_DWORD, &H0, True)
        launcher = New Status(LauncherS, LauncherB, n, RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRun", onreg, offreg)

    End Sub

    Private Sub AccAdmin_Click(sender As Object, e As EventArgs) Handles AccAdmin.Click
        Visible = False
    End Sub

    Private Sub MdfPwd_Click(sender As Object, e As EventArgs) Handles MdfPwd.Click

    End Sub

    Private Sub CancelDown_Click(sender As Object, e As EventArgs) Handles CancelDown.Click

    End Sub

    Private Sub ReExp_Click(sender As Object, e As EventArgs) Handles ReExp.Click

    End Sub

    Private Sub PCHunter_Click(sender As Object, e As EventArgs) Handles PCHunter.Click

    End Sub

    Private Sub DiskGenius_Click(sender As Object, e As EventArgs) Handles DiskGenius.Click

    End Sub

    Private Sub LimProcB_Click(sender As Object, e As EventArgs) Handles LimProcB.Click
        limproc.ChangeState()
    End Sub

    Private Sub LimitDiskB_Click(sender As Object, e As EventArgs) Handles LimitDiskB.Click

    End Sub

    Private Sub MmcB_Click(sender As Object, e As EventArgs) Handles MmcB.Click

    End Sub

    Private Sub RegistryB_Click(sender As Object, e As EventArgs) Handles RegistryB.Click

    End Sub

    Private Sub TaskSchB_Click(sender As Object, e As EventArgs) Handles TaskSchB.Click

    End Sub

    Private Sub ConPalB_Click(sender As Object, e As EventArgs) Handles ConPalB.Click

    End Sub

    Private Sub LauncherB_Click(sender As Object, e As EventArgs) Handles LauncherB.Click

    End Sub

    Private Sub CmdB_Click(sender As Object, e As EventArgs) Handles CmdB.Click

    End Sub

    Private Sub TaskmgrB_Click(sender As Object, e As EventArgs) Handles TaskmgrB.Click

    End Sub

    Private Sub PwrShellB_Click(sender As Object, e As EventArgs) Handles PwrShellB.Click

    End Sub
End Class