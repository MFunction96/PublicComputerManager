'**********************************************************
'名称：主窗体
'功能：本程序的核心窗口，功能的控制面板
'**********************************************************

Imports PublicComputerManager.RegOpt
Imports PublicComputerManager.StatusOpt

Public Class MainForm

    Private limproc As Status
    Private limitdisk As Status
    Private mmc As Status
    Private registry As Status
    Private task As Status
    Private ctrlpal As Status
    Private launcher As Status
    Private cmd As Status
    Private taskmgr As Status
    Private pwrshell As Status
    Private login As New LoginForm

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim onreg, offreg As RegStore()
        Dim regp As RegPath
        Dim n As Integer
        n = 1
        ReDim onreg(n - 1), offreg(n - 1)
        regp = New RegPath(REG_ROOT_KEY.HKEY_LOCAL_MACHINE, "Software\Policies\Microsoft\Windows\safer\codeidentifiers", "DefaultLevel")
        onreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H0)
        offreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H40000)
        limproc = New Status(LimProcS, LimProcB, New RegStatus(n, onreg, offreg))
        n = 1
        ReDim onreg(n - 1), offreg(n - 1)
        regp = New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoDrives")
        onreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H4)
        offreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H0)
        limitdisk = New Status(LimitDiskS, LimitDiskB, New RegStatus(n, onreg, offreg))
        n = 1
        ReDim onreg(n - 1), offreg(n - 1)
        regp = New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools")
        offreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H2)
        onreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H0)
        registry = New Status(RegistryS, RegistryB, New RegStatus(n, onreg, offreg))
        n = 1
        ReDim onreg(n - 1), offreg(n - 1)
        regp = New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Policies\Microsoft\Windows\System", "DisableCMD")
        offreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H1)
        onreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H0)
        cmd = New Status(CmdS, CmdB, New RegStatus(n, onreg, offreg))
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr")
        onreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H0)
        offreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H1)
        taskmgr = New Status(TaskmgrS, TaskmgrB, New RegStatus(n, onreg, offreg))
        n = 1
        ReDim onreg(n - 1), offreg(n - 1)
        regp = New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRun")
        onreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H0)
        offreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H1)
        launcher = New Status(LauncherS, LauncherB, New RegStatus(n, onreg, offreg))

        n = 1
        ReDim onreg(n - 1), offreg(n - 1)
        regp = New RegPath(REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoControlPanel")
        onreg(0) = New RegStore(True, regp, REG_TYPE.REG_DWORD, &H0)
        offreg(0) = New RegStore(False, regp, REG_TYPE.REG_DWORD, &H1)
        ctrlpal = New Status(CtrlPalS, CtrlPalB, New RegStatus(n, onreg, offreg))

        limproc.CheckState()
        limitdisk.CheckState()
        registry.CheckState()
        cmd.CheckState()
        taskmgr.CheckState()
        launcher.CheckState()
        ctrlpal.CheckState()

    End Sub

    Private Sub AccAdmin_Click(sender As Object, e As EventArgs) Handles AccAdmin.Click
        Enabled = False
        login.Show()
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
        limitdisk.ChangeState()
    End Sub

    Private Sub MmcB_Click(sender As Object, e As EventArgs) Handles MmcB.Click

    End Sub

    Private Sub RegistryB_Click(sender As Object, e As EventArgs) Handles RegistryB.Click
        registry.ChangeState()
    End Sub

    Private Sub TaskSchB_Click(sender As Object, e As EventArgs) Handles TaskSchB.Click

    End Sub

    Private Sub CtrlPalB_Click(sender As Object, e As EventArgs) Handles CtrlPalB.Click
        ctrlpal.ChangeState()
    End Sub

    Private Sub LauncherB_Click(sender As Object, e As EventArgs) Handles LauncherB.Click
        launcher.ChangeState()
    End Sub

    Private Sub CmdB_Click(sender As Object, e As EventArgs) Handles CmdB.Click
        cmd.ChangeState()
    End Sub

    Private Sub TaskmgrB_Click(sender As Object, e As EventArgs) Handles TaskmgrB.Click
        taskmgr.ChangeState()
    End Sub

    Private Sub PwrShellB_Click(sender As Object, e As EventArgs) Handles PwrShellB.Click

    End Sub

End Class