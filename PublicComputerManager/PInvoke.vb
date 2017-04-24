'**********************************************************
'名称：P/Invoke模块
'功能：实现非托管代码的P/Invoke方法
'**********************************************************

Imports PublicComputerManager.RegOpt

Namespace PInvoke
    ''' <summary>
    ''' Windows错误代码常量枚举
    ''' </summary>
    Public Enum ERROR_CODE
        ERROR_SUCCESS = &H0
        ERROR_FILE_NOT_FOUND = &H2
        ERROR_PATH_NOT_FOUND = &H3
        ERROR_ACCESS_DENIED = &H5
        ERROR_INVALID_HANDLE = &H6
        ERROR_INVALID_PARAMETER = &H57
        ERROR_NOACCESS = &H3E6
    End Enum

    Friend NotInheritable Class NativeMethods

        Private Sub New()
        End Sub

        <StructLayout(LayoutKind.Sequential)>
        Structure SECURITY_ATTRIBUTES
            Dim nLength As Integer
            Dim lpSecurityDescriptor As Object
            Dim bInheritHandle As Boolean
        End Structure

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
        Structure STARTUPINFO
            Dim cb As Integer
            Dim lpReserved As String
            Dim lpDesktop As String
            Dim lpTitle As String
            Dim dwX As Integer
            Dim dwY As Integer
            Dim dwXSize As Integer
            Dim dwYSize As Integer
            Dim dwXCountChars As Integer
            Dim dwYCountChars As Integer
            Dim dwFillAttribute As Integer
            Dim dwFlags As Integer
            Dim wShowWindow As Short
            Dim cbReserved2 As Short
            Dim lpReserved2 As Integer
            Dim hStdInput As IntPtr
            Dim hStdOutput As IntPtr
            Dim hStdError As IntPtr
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Structure PROCESS_INFORMATION
            Dim hProcess As IntPtr
            Dim hThread As IntPtr
            Dim dwProcessId As Integer
            Dim dwThreadId As Integer
        End Structure

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegSetValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As Integer,
                               ByVal lpType As Integer,
                               ByRef lpData As UInteger,
                               ByVal lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegSetValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As Integer,
                               ByVal lpType As Integer,
                               ByVal lpData As String,
                               ByVal lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegQueryValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As IntPtr,
                               ByRef lpType As Integer,
                               ByVal lpData As String,
                               ByRef lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegQueryValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As IntPtr,
                               ByRef lpType As Integer,
                               ByRef lpData As Integer,
                               ByRef lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegQueryValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As IntPtr,
                               ByRef lpType As Integer,
                               ByVal lpData As Byte(),
                               ByRef lpcbData As Integer) _
                               As Integer
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegCreateKeyEx(
                               ByVal hKey As IntPtr,
                               ByVal lpSubKey As String,
                               ByVal Reserved As Integer,
                               ByVal lpClass As String,
                               ByVal dwOptions As Integer,
                               ByVal samDesired As Integer,
                               ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES,
                               ByRef phkResult As IntPtr,
                               ByRef lpdwDisposition As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegOpenKeyEx(
                               ByVal hKey As IntPtr,
                               ByVal lpSubKey As String,
                               ByVal ulOptions As Integer,
                               ByVal samDesired As Integer,
                               ByRef phkResult As IntPtr) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegCloseKey(
                               ByVal hKey As IntPtr) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegDeleteKey(
                               ByVal hKey As IntPtr,
                               ByVal lpSubKey As String) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegDeleteValue(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String) _
                               As ERROR_CODE
        End Function

        <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function CreateProcess(
                               lpApplicationName As String,
                               lpCommandLine As String,
                               ByRef lpProcessAttributes As SECURITY_ATTRIBUTES,
                               ByRef lpThreadAttributes As SECURITY_ATTRIBUTES,
                               bInheritHandles As Boolean,
                               dwCreationFlags As UInteger,
                               lpEnvironment As IntPtr,
                               lpCurrentDirectory As String,
                               ByRef lpStartupInfo As STARTUPINFO,
                               ByRef lpProcessInformation As PROCESS_INFORMATION) _
                               As Boolean
        End Function

        <DllImport("coredll.dll", SetLastError:=True)>
        Friend Shared Function GetLastError() As Integer
        End Function

    End Class

End Namespace