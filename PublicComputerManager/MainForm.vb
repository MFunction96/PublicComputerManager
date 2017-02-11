'**********************************************************
'名称：主窗体
'功能：本程序的核心窗口，功能的控制面板
'**********************************************************
Public Class MainForm

    Private limproc As RegStatus
    Private limitdisk As RegStatus
    Private mmc As RegStatus
    Private registry As RegStatus
    Private task As RegStatus
    Private conpal As RegStatus
    Private launcher As RegStatus
    Private cmd As RegStatus
    Private taskmgr As RegStatus
    Private pwrshell As RegStatus
    Private login As New LoginForm

    Public admin As Boolean = False

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim onreg(), offreg() As RegStore
        Dim regp As RegPath
        Dim n As Integer
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_LOCAL_MACHINE, "Software\Policies\Microsoft\Windows\safer\codeidentifiers", "DefaultLevel", True)
        onreg(0) = New RegStore(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H40000)
        offreg(0) = New RegStore(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        limproc = New RegStatus(n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoDrives", True)
        onreg(0) = New RegStore(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H4)
        offreg(0) = New RegStore(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        limitdisk = New RegStatus(n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableRegistryTools", True)
        onreg(0) = New RegStore(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H2)
        offreg(0) = New RegStore(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        registry = New RegStatus(n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Policies\Microsoft\Windows\System", "DisableCMD", True)
        onreg(0) = New RegStore(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H1)
        offreg(0) = New RegStore(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        cmd = New RegStatus(n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", True)
        onreg(0) = New RegStore(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H1)
        offreg(0) = New RegStore(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        taskmgr = New RegStatus(n, onreg, offreg)
        n = 1
        ReDim onreg(n), offreg(n)
        regp = New RegPath(RegAPI.REG_ROOT_KEY.HKEY_CURRENT_USER, "Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRun", True)
        onreg(0) = New RegStore(False, regp, RegAPI.REG_TYPE.REG_DWORD, &H1)
        offreg(0) = New RegStore(True, regp, RegAPI.REG_TYPE.REG_DWORD, &H0)
        launcher = New RegStatus(n, onreg, offreg)

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

    End Sub

    Private Sub MmcB_Click(sender As Object, e As EventArgs) Handles MmcB.Click

    End Sub

    Private Sub RegistryB_Click(sender As Object, e As EventArgs) Handles RegistryB.Click
        registry.ChangeState()
    End Sub

    Private Sub TaskSchB_Click(sender As Object, e As EventArgs) Handles TaskSchB.Click

    End Sub

    Private Sub CtrlPalB_Click(sender As Object, e As EventArgs) Handles CtrlPalB.Click

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