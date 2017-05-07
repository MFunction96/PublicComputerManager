''' <summary>
''' 
''' </summary>
Public Class Process
    
    ''' <summary>
    ''' 
    ''' </summary>
    Public Enum ProcFlag
        CREATE_BREAKAWAY_FROM_JOB = &H1000000
        CREATE_DEFAULT_ERROR_MODE = &H4000000
        CREATE_NEW_CONSOLE = &H10
        CREATE_NEW_PROCESS_GROUP = &H200
        CREATE_NO_WINDOW = &H8000000
    End Enum
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="app"></param>
    ''' <param name="args"></param>
    Public Shared Sub Createproc(app As String, args As String)
        Dim si As PInvoke.NativeMethods.STARTUPINFO
        si.cb = 0
        si.lpReserved = vbNullString
        si.lpDesktop = vbNullString
        si.lpTitle = vbNullString
        si.dwX = 0
        si.dwY = 0
        si.dwXSize = 0
        si.dwYSize = 0
        si.dwXCountChars = 0
        si.dwYCountChars = 0
        si.dwFillAttribute = 0
        si.dwFlags = 0
        si.wShowWindow = 0
        si.cbReserved2 = 0
        si.lpReserved2 = 0
        si.hStdInput = New IntPtr(0)
        si.hStdOutput = New IntPtr(0)
        si.hStdError = New IntPtr(0)

    End Sub
End Class