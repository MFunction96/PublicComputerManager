'Public Class CrtProc
'    Public Function CrtProcAsAdmin(
'                    ByVal strExePath As String) _
'                    As Integer

'        Dim hUserToken As IntPtr
'        Dim lpEnvBlock As Object
'        If (NativeMethods.CreateEnvironmentBlock(lpEnvBlock, hUserToken, False) = False) Then
'            Return NativeMethods.GetLastError()
'        End If
'        If (NativeMethods.CreateProcessAsUser(hUserToken, strExePath, vbNull, vbNull, vbNull, False, CREATE_UNICODE_ENVIRONMENT, lpEnvBlock, strDirectory, & si, & pi)) = False Then
'            Return NativeMethods.GetLastError()
'        End If
'        If (NativeMethods.DestroyEnvironmentBlock(lpEnvBlock) = False) Then
'            Return NativeMethods.GetLastError()
'        End If
'        Return ERROR_CODE.ERROR_SUCCESS
'    End Function
'End Class