'**********************************************************
'名称：注册表访问相关API封装
'功能：注册表信息的创建、赋值、读取、删除
'修改时间：2017-01-26
'**********************************************************
Public Enum REG_TYPE
    REG_NONE = 0
    REG_SZ = 1
    REG_EXPAND_SZ = 2
    REG_BINARY = 3
    REG_DWORD = 4
    REG_DWORD_LITTLE_ENDIAN = 4
    REG_DWORD_BIG_ENDIAN = 5
    REG_MULTI_SZ = 7
End Enum

Public Enum REG_ROOT_KEY
    HKEY_CLASSES_ROOT = &H80000000
    HKEY_CURRENT_USER = &H80000001
    HKEY_LOCAL_MACHINE = &H80000002
    HKEY_USERS = &H80000003
    HKEY_PERFORMANCE_DATA = &H80000004
    HKEY_CURRENT_CONFIG = &H80000005
    HKEY_DYN_DATA = &H80000006
End Enum

Public Enum KEY_ACCESS_TYPE
    KEY_ALL_ACCESS = &H3F
    KEY_WOW64_64KEY = &H100
    KEY_WOW64_32KEY = &H200
End Enum

Public Class RegAPI

    Private Enum OPERATE_OPTION
        REG_OPTION_NON_VOLATILE = &H0
        REG_CREATED_NEW_KEY = &H1
    End Enum

    Public Structure VALUE
        Dim value As Object
        Dim valuetype As VariantType
        Sub New(
            ByVal value As Object,
            ByVal valuetype As VariantType)

            Me.value = value
            Me.valuetype = valuetype

        End Sub
    End Structure

    Private Const REG_OPENED_EXISTING_KEY As Integer = &H2
    Private regvalue As VALUE
    Private returnvalue As ERROR_CODE

    Public Function GetValue() As VALUE
        Return regvalue
    End Function

    Public Function GetError() As ERROR_CODE
        Return returnvalue
    End Function

    Public Sub RegGetValue _
               (ByVal hKey As REG_ROOT_KEY,
               ByVal lpSubKey As String,
               ByVal lpValueName As String,
               ByVal is64Reg As Boolean)

        Dim reggetvaluetemp As ERROR_CODE
        Dim phkresult As IntPtr
        Dim samdesired As KEY_ACCESS_TYPE
        Dim lptype As REG_TYPE
        Dim lpdatastr As String
        Dim lpdataint As Integer
        Dim lpcbdata As Integer

        If Environment.Is64BitOperatingSystem() = True Then
            If is64Reg = True Then
                samdesired = KEY_ACCESS_TYPE.KEY_WOW64_64KEY
            Else
                samdesired = KEY_ACCESS_TYPE.KEY_WOW64_32KEY
            End If
            reggetvaluetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(hKey), lpSubKey, 0, samdesired Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
        Else
            samdesired = KEY_ACCESS_TYPE.KEY_ALL_ACCESS
            reggetvaluetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(hKey), lpSubKey, 0, samdesired, phkresult)
        End If

        If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
            returnvalue = reggetvaluetemp
            regvalue = New VALUE(vbNull, vbNull)
            Return
        End If

        reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, lpValueName, IntPtr.op_Explicit(0), lptype, vbNullString, lpcbdata)
        If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
            returnvalue = reggetvaluetemp
            reggetvaluetemp = NativeMethods.RegCloseKey(phkresult)
            regvalue = New VALUE(vbNull, vbNull)
            Return
        End If

        If lptype = REG_TYPE.REG_SZ Or lptype = REG_TYPE.REG_EXPAND_SZ Or lptype = REG_TYPE.REG_MULTI_SZ Then
            lpdatastr = StrDup(lpcbdata, Chr(0))
            reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, lpValueName, IntPtr.op_Explicit(0), lptype, lpdatastr, lpcbdata)
            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                returnvalue = reggetvaluetemp
                reggetvaluetemp = NativeMethods.RegCloseKey(phkresult)
                regvalue = New VALUE(vbNull, vbNull)
                Return
            End If
            If lptype = REG_TYPE.REG_SZ Then
                regvalue = New VALUE(Left(lpdatastr, InStr(lpdatastr, Chr(0)) - 1), vbString)
            Else
                regvalue = New VALUE(lpdatastr, vbString)
            End If
        Else
            reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, lpValueName, IntPtr.op_Explicit(0), lptype, lpdataint, lpcbdata)
            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                returnvalue = reggetvaluetemp
                reggetvaluetemp = NativeMethods.RegCloseKey(phkresult)
                regvalue = New VALUE(vbNull, vbNull)
                Return
            End If
            regvalue = New VALUE(lpdataint, vbInteger)
        End If

        returnvalue = reggetvaluetemp

        If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
            reggetvaluetemp = NativeMethods.RegCloseKey(phkresult)
            regvalue = New VALUE(vbNull, vbNull)
            Return
        End If

        reggetvaluetemp = NativeMethods.RegCloseKey(phkresult)
        Return

    End Sub

    Public Sub RegSetValue _
               (ByVal hKey As REG_ROOT_KEY,
               ByVal lpSubKey As String,
               ByVal lpValueName As String,
               ByVal setValue As Object,
               ByVal valueType As REG_TYPE,
               ByVal is64Reg As Boolean)

        Dim keyexist As Integer
        Dim samdesired As KEY_ACCESS_TYPE
        Dim phkresult As IntPtr
        Dim strvalue As String = vbNullString
        Dim regsetvaluetemp As ERROR_CODE

        If Environment.Is64BitOperatingSystem = True Then
            If is64Reg = True Then
                samdesired = KEY_ACCESS_TYPE.KEY_WOW64_64KEY
            Else
                samdesired = KEY_ACCESS_TYPE.KEY_WOW64_32KEY
            End If
            regsetvaluetemp = NativeMethods.RegCreateKeyEx(IntPtr.op_Explicit(hKey), lpSubKey, 0, vbNullString, OPERATE_OPTION.REG_OPTION_NON_VOLATILE, samdesired Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, Nothing, phkresult, keyexist)
        Else
            samdesired = KEY_ACCESS_TYPE.KEY_ALL_ACCESS
            regsetvaluetemp = NativeMethods.RegCreateKeyEx(IntPtr.op_Explicit(hKey), lpSubKey, 0, vbNullString, OPERATE_OPTION.REG_OPTION_NON_VOLATILE, samdesired, Nothing, phkresult, keyexist)
        End If

        If regsetvaluetemp <> ERROR_CODE.ERROR_SUCCESS And keyexist <> REG_OPENED_EXISTING_KEY Then
            returnvalue = regsetvaluetemp
            Exit Sub
        End If

        If valueType = REG_TYPE.REG_DWORD Then
            regsetvaluetemp = NativeMethods.RegSetValueEx(phkresult, lpValueName, 0, REG_TYPE.REG_DWORD, CUInt(setValue), 4)
        Else
            strvalue = CStr(setValue).Trim
            regsetvaluetemp = NativeMethods.RegSetValueEx(phkresult, lpValueName, 0, REG_TYPE.REG_SZ, strvalue, Len(strvalue))
        End If

        returnvalue = regsetvaluetemp
        regsetvaluetemp = NativeMethods.RegCloseKey(phkresult)

    End Sub

    Public Sub RegDelete _
               (ByVal hKey As REG_ROOT_KEY,
               ByVal lpSubKey As String,
               ByVal is64Reg As Boolean,
               Optional ByVal lpValueName As String = vbNullString)

        Dim regdeletetemp As ERROR_CODE
        Dim phkresult As IntPtr
        Dim samdesired As Integer

        If lpValueName = vbNullString Then
            regdeletetemp = NativeMethods.RegDeleteKey(IntPtr.op_Explicit(hKey), lpSubKey)
            returnvalue = regdeletetemp
        Else
            If Environment.Is64BitOperatingSystem = True Then
                If is64Reg = True Then
                    samdesired = KEY_ACCESS_TYPE.KEY_WOW64_64KEY
                Else
                    samdesired = KEY_ACCESS_TYPE.KEY_WOW64_32KEY
                End If
                regdeletetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(hKey), lpSubKey, 0, samdesired Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
            Else
                samdesired = KEY_ACCESS_TYPE.KEY_ALL_ACCESS
                regdeletetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(hKey), lpSubKey, 0, samdesired, phkresult)
            End If

            If regdeletetemp <> ERROR_CODE.ERROR_SUCCESS Then
                returnvalue = regdeletetemp
                Exit Sub
            End If

            regdeletetemp = NativeMethods.RegDeleteValue(phkresult, lpValueName)
            returnvalue = regdeletetemp
            regdeletetemp = NativeMethods.RegCloseKey(phkresult)

        End If

    End Sub

End Class