Public Module PInvoke

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
                               ByVal lpType As REG_TYPE,
                               ByRef lpData As UInteger,
                               ByVal lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegSetValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As Integer,
                               ByVal lpType As REG_TYPE,
                               ByVal lpData As String,
                               ByVal lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegQueryValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As IntPtr,
                               ByRef lpType As REG_TYPE,
                               ByVal lpData As String,
                               ByRef lpcbData As Integer) _
                               As ERROR_CODE
        End Function

        <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function RegQueryValueEx(
                               ByVal hKey As IntPtr,
                               ByVal lpValueName As String,
                               ByVal lpReserved As IntPtr,
                               ByRef lpType As REG_TYPE,
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

        <DllImport("advapi32.dll", ExactSpelling:=False, SetLastError:=True, CharSet:=CharSet.Unicode)>
        Friend Shared Function CreateProcessAsUser(
                               ByVal hToken As IntPtr,
                               ByVal lpApplicationName As String,
                               ByVal lpCommandLine As String,
                               ByRef lpProcessAttributes As SECURITY_ATTRIBUTES,
                               ByRef lpThreadAttributes As SECURITY_ATTRIBUTES,
                               ByVal bInheritHandles As Boolean,
                               ByVal dwCreationFlags As Integer,
                               ByVal lpEnvironment As Object,
                               ByVal lpCurrentDirectory As String,
                               ByRef lpStartupInfo As STARTUPINFO,
                               ByRef lpProcessInformation As PROCESS_INFORMATION) _
                               As Boolean
        End Function

        <DllImport("userenv.dll", SetLastError:=True)>
        Friend Shared Function CreateEnvironmentBlock(
                               ByRef lpEnvironment As Object,
                               ByVal hToken As IntPtr,
                               ByVal bInherit As Boolean) _
                               As Boolean
        End Function

        <DllImport("coredll.dll", SetLastError:=True)>
        Friend Shared Function GetLastError() As Integer
        End Function

        <DllImport("userenv.dll", SetLastError:=True)>
        Friend Shared Function DestroyEnvironmentBlock(
                               ByVal lpEnvironment As Object) _
                               As Boolean
        End Function

    End Class
End Module