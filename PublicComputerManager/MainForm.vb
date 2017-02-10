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
        Dim onreg(), offreg() As RegStatus
        Dim regp As RegPath
        Dim n As Integer
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_LOCAL_MACHINE, "Software\Policies\Microsoft\Windows\safer\codeidentifiers", "DefaultLevel", True)
        onreg(0) = New RegStatus(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H40000)
        offreg(0) = New RegStatus(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        limproc = New Status(LimProcS, LimProcB, n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoDrives", True)
        onreg(0) = New RegStatus(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H4)
        offreg(0) = New RegStatus(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        limitdisk = New Status(LimitDiskS, LimitDiskB, n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", True)
        onreg(0) = New RegStatus(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H2)
        offreg(0) = New RegStatus(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        registry = New Status(RegistryS, RegistryB, n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Policies\Microsoft\Windows\System", "DisableCMD", True)
        onreg(0) = New RegStatus(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H1)
        offreg(0) = New RegStatus(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        cmd = New Status(CmdS, CmdB, n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", True)
        onreg(0) = New RegStatus(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H1)
        offreg(0) = New RegStatus(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        taskmgr = New Status(TaskmgrS, TaskmgrB, n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRun", True)
        onreg(0) = New RegStatus(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H1)
        offreg(0) = New RegStatus(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        launcher = New Status(LauncherS, LauncherB, n, onreg, offreg)

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