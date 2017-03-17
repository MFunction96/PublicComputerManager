﻿'**********************************************************
'名称：注册表访问相关API封装
'功能：注册表信息的创建、赋值、读取、删除
'**********************************************************

Imports PublicComputerManager.PInvoke

Namespace RegOpera

    ''' <summary>
    ''' 注册表类型常量枚举
    ''' </summary>
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
    ''' <summary>
    ''' 注册表根键常量枚举
    ''' </summary>
    Public Enum REG_ROOT_KEY
        HKEY_CLASSES_ROOT = &H80000000
        HKEY_CURRENT_USER = &H80000001
        HKEY_LOCAL_MACHINE = &H80000002
        HKEY_USERS = &H80000003
        HKEY_PERFORMANCE_DATA = &H80000004
        HKEY_CURRENT_CONFIG = &H80000005
        HKEY_DYN_DATA = &H80000006
    End Enum
    ''' <summary>
    ''' 注册表路径类
    ''' </summary>
    <Serializable()>
    Public Class RegPath
        Implements ICloneable

        Private _hkey As REG_ROOT_KEY
        Private _lpsubkey As String
        Private _lpvaluename As String
        Private _is64reg As Boolean
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="reg">
        ''' 复制该对象的所有成员
        ''' </param>
        Public Sub New(
                   ByRef reg As RegPath)

            _hkey = reg.hkey()
            _lpsubkey = reg.lpsubkey()
            _lpvaluename = reg.lpvaluename()
            _is64reg = reg.is64reg()

        End Sub

        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="hKey">
        ''' 注册表主键
        ''' </param>
        ''' <param name="lpSubKey">
        ''' 注册表子键
        ''' </param>
        ''' <param name="lpValueName">
        ''' 注册表键名
        ''' </param>
        ''' <param name="is64Reg">
        ''' 注册表操作位宽
        ''' </param>
        Public Sub New(
                   ByRef hKey As REG_ROOT_KEY,
                   ByVal lpSubKey As String,
                   Optional ByVal lpValueName As String = vbNullString,
                   Optional ByRef is64Reg As Boolean = False)

            _hkey = hKey
            _lpsubkey = lpSubKey
            _lpvaluename = lpValueName
            _is64reg = is64Reg

        End Sub
        ''' <summary>
        ''' 深复制操作对象的副本
        ''' </summary>
        ''' <returns>
        ''' 返回一个Object类，包含该对象的全部成员
        ''' </returns>
        Public Function Clone() As Object Implements ICloneable.Clone
            Return MemberwiseClone()
        End Function

        ''' <summary>
        ''' 获取操作对象的主键属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的主键属性
        ''' </returns>
        Public Function hkey() As REG_ROOT_KEY
            Return _hkey
        End Function
        ''' <summary>
        ''' 获取操作对象的子键属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的子键属性
        ''' </returns>
        Public Function lpsubkey() As String
            Return _lpsubkey
        End Function
        ''' <summary>
        ''' 获取操作对象的键名属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的键名属性
        ''' </returns>
        Public Function lpvaluename() As String
            Return _lpvaluename
        End Function
        ''' <summary>
        ''' 获取操作对象的操作注册表位宽属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的操作注册表位宽属性
        ''' </returns>
        Public Function is64reg() As Boolean
            Return _is64reg
        End Function

    End Class
    ''' <summary>
    ''' 注册表键类
    ''' </summary>
    <Serializable()>
    Public Class RegKey
        Inherits RegPath
        Implements ICloneable

        Private _lpvaluetype As REG_TYPE
        Private _regvalue As Object
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="reg">
        ''' 复制该对象的所有成员
        ''' </param>
        Public Sub New(
                   ByRef reg As RegKey)

            MyBase.New(reg.hkey(), reg.lpsubkey(), reg.lpvaluename(), reg.is64reg())
            _lpvaluetype = reg.lpvaluetype()
            _regvalue = reg.regvalue()

        End Sub
        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="reg">
        ''' 构造对象的注册表路径
        ''' </param>
        ''' <param name="lpValueType">
        ''' 构造对象的注册表键值类型
        ''' </param>
        ''' <param name="regValue">
        ''' 构造对象的注册表键值
        ''' </param>
        Public Sub New(
                   ByRef reg As RegPath,
                   Optional ByRef lpValueType As REG_TYPE = REG_TYPE.REG_NONE,
                   Optional ByVal regValue As Object = Nothing)

            MyBase.New(reg)
            _lpvaluetype = lpValueType
            _regvalue = regValue

        End Sub
        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="hKey">
        ''' 构造注册表路径的主键
        ''' </param>
        ''' <param name="lpSubKey">
        ''' 构造注册表路径的子键
        ''' </param>
        ''' <param name="lpValueName">
        ''' 构造注册表路径的键名
        ''' </param>
        ''' <param name="is64Reg">
        ''' 构造注册表路径的操作位宽
        ''' </param>
        ''' <param name="lpValueType">
        ''' 构造注册表的键值类型
        ''' </param>
        ''' <param name="regValue">
        ''' 构造注册表的键值
        ''' </param>
        Public Sub New(
                   ByRef hKey As REG_ROOT_KEY,
                   ByVal lpSubKey As String,
                   Optional ByVal lpValueName As String = vbNullString,
                   Optional ByRef is64Reg As Boolean = False,
                   Optional ByRef lpValueType As REG_TYPE = REG_TYPE.REG_NONE,
                   Optional ByVal regValue As Object = Nothing)

            MyBase.New(hKey, lpSubKey, lpValueName, is64Reg)
            _lpvaluetype = lpValueType
            _regvalue = regValue

        End Sub
        ''' <summary>
        ''' 深复制操作对象的副本
        ''' </summary>
        ''' <returns>
        ''' 返回一个Object类，包含该对象的全部成员
        ''' </returns>
        Public Overloads Function Clone() As Object Implements ICloneable.Clone
            Return MemberwiseClone()
        End Function
        ''' <summary>
        ''' 获取操作对象的键值类型属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的键值类型属性
        ''' </returns>
        Public Function lpvaluetype() As REG_TYPE
            Return _lpvaluetype
        End Function
        ''' <summary>
        ''' 获取操作对象的键值属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的键值属性
        ''' </returns>
        Public Function regvalue() As Object
            Return _regvalue
        End Function

    End Class
    ''' <summary>
    ''' 注册表存储类
    ''' </summary>
    <Serializable()>
    Public Class RegStore
        Inherits RegKey
        Implements ICloneable

        Private _isnull As Boolean
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="store">
        ''' 复制该对象的所有成员
        ''' </param>
        Public Sub New(
                   ByRef store As RegStore)

            MyBase.New(store.hkey(), store.lpsubkey(), store.lpvaluename(), store.is64reg(), store.lpvaluetype(), store.regvalue())
            _isnull = store.isnull()

        End Sub
        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="isNull">
        ''' 表示注册表项是否可以为空
        ''' </param>
        ''' <param name="reg">
        ''' 构造注册表健
        ''' </param>
        Public Sub New(
                   ByRef isNull As Boolean,
                   ByRef reg As RegKey)

            MyBase.New(reg)
            _isnull = isNull

        End Sub
        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="isNull">
        ''' 表示注册表项是否可以为空
        ''' </param>
        ''' <param name="reg">
        ''' 构造注册表路径
        ''' </param>
        ''' <param name="lpValueType">
        ''' 构造注册表键值类型
        ''' </param>
        ''' <param name="regValue">
        ''' 构造注册表键值
        ''' </param>
        Public Sub New(
                   ByRef isNull As Boolean,
                   ByRef reg As RegPath,
                   ByRef lpValueType As REG_TYPE,
                   ByVal regValue As Object)

            MyBase.New(reg, lpValueType, regValue)
            _isnull = isNull

        End Sub
        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="isNull">
        ''' 表示注册表项是否可以为空
        ''' </param>
        ''' <param name="hKey">
        ''' 构造注册表路径主键
        ''' </param>
        ''' <param name="lpSubKey">
        ''' 构造注册表路径子键
        ''' </param>
        ''' <param name="lpValueName">
        ''' 构造注册表路径键名
        ''' </param>
        ''' <param name="is64Reg">
        ''' 构造注册表操作位宽
        ''' </param>
        ''' <param name="lpValueType">
        ''' 构造注册表键值类型
        ''' </param>
        ''' <param name="regValue">
        ''' 构造注册表键值
        ''' </param>
        Public Sub New(
                   ByRef isNull As Boolean,
                   ByRef hKey As REG_ROOT_KEY,
                   ByVal lpSubKey As String,
                   ByVal lpValueName As String,
                   ByRef is64Reg As Boolean,
                   ByRef lpValueType As REG_TYPE,
                   ByVal regValue As Object)

            MyBase.New(hKey, lpSubKey, lpValueName, is64Reg, lpValueType, regValue)
            _isnull = isNull

        End Sub
        ''' <summary>
        ''' 深复制操作对象的副本
        ''' </summary>
        ''' <returns>
        ''' 返回一个Object类，包含该对象的全部成员
        ''' </returns>
        Public Overloads Function Clone() As Object Implements ICloneable.Clone
            Return MemberwiseClone()
        End Function
        ''' <summary>
        ''' 获取操作对象的可以为空属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的可以为空属性
        ''' </returns>
        Public Function isnull() As Boolean
            Return _isnull
        End Function

    End Class
    ''' <summary>
    ''' 注册表操作类
    ''' </summary>
    Public Class RegAPI

        Private Enum OPERATE_OPTION
            REG_OPTION_NON_VOLATILE = &H0
            REG_CREATED_NEW_KEY = &H1
        End Enum

        Private Enum KEY_ACCESS_TYPE
            KEY_ALL_ACCESS = &H3F
            KEY_WOW64_64KEY = &H100
            KEY_WOW64_32KEY = &H200
        End Enum

        Private Const REG_OPENED_EXISTING_KEY As Integer = &H2

        Friend Shared Function RegGetValue(
                               ByRef reg As RegPath) _
                               As RegKey

            Dim reggetvaluetemp As ERROR_CODE
            Dim phkresult As IntPtr
            Dim samdesired As KEY_ACCESS_TYPE
            Dim lptype As REG_TYPE
            Dim lpdatastr As String
            Dim lpdataint As Integer
            Dim lpcbdata As Integer
            Dim regtemp As RegKey

            If Environment.Is64BitOperatingSystem() = True Then
                If reg.is64reg() = True Then
                    samdesired = KEY_ACCESS_TYPE.KEY_WOW64_64KEY
                Else
                    samdesired = KEY_ACCESS_TYPE.KEY_WOW64_32KEY
                End If
                reggetvaluetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey(), 0, samdesired Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
            Else
                samdesired = KEY_ACCESS_TYPE.KEY_ALL_ACCESS
                reggetvaluetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey(), 0, samdesired, phkresult)
            End If

            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                Err.Raise(reggetvaluetemp)
                Return New RegKey(reg)
            End If

            reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, reg.lpvaluename(), IntPtr.op_Explicit(0), lptype, vbNullString, lpcbdata)
            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                NativeMethods.RegCloseKey(phkresult)
                Err.Raise(reggetvaluetemp)
                Return New RegKey(reg)
            End If

            If lptype = REG_TYPE.REG_SZ Or lptype = REG_TYPE.REG_EXPAND_SZ Or lptype = REG_TYPE.REG_MULTI_SZ Then
                lpdatastr = StrDup(lpcbdata, Chr(0))
                reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, reg.lpvaluename(), IntPtr.op_Explicit(0), lptype, lpdatastr, lpcbdata)
                If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    NativeMethods.RegCloseKey(phkresult)
                    Err.Raise(reggetvaluetemp)
                    Return New RegKey(reg)
                End If
                If lptype = REG_TYPE.REG_SZ Then
                    regtemp = New RegKey(reg, lptype, Left(lpdatastr, InStr(lpdatastr, Chr(0)) - 1))
                Else
                    regtemp = New RegKey(reg, lptype, lpdatastr)
                End If
            Else
                reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, reg.lpvaluename(), IntPtr.op_Explicit(0), lptype, lpdataint, lpcbdata)
                If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    Err.Raise(reggetvaluetemp)
                    NativeMethods.RegCloseKey(phkresult)
                    Return New RegKey(reg)
                End If
                regtemp = New RegKey(reg, lptype, lpdataint)
            End If

            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                NativeMethods.RegCloseKey(phkresult)
                Err.Raise(reggetvaluetemp)
                Return New RegKey(reg)
            End If

            NativeMethods.RegCloseKey(phkresult)
            Return regtemp

        End Function

        Friend Shared Sub RegSetValue(
                          ByRef reg As RegKey)

            Dim keyexist As Integer
            Dim samdesired As KEY_ACCESS_TYPE
            Dim phkresult As IntPtr
            Dim strvalue As String = vbNullString
            Dim regsetvaluetemp As ERROR_CODE

            If Environment.Is64BitOperatingSystem = True Then
                If reg.is64reg() = True Then
                    samdesired = KEY_ACCESS_TYPE.KEY_WOW64_64KEY
                Else
                    samdesired = KEY_ACCESS_TYPE.KEY_WOW64_32KEY
                End If
                regsetvaluetemp = NativeMethods.RegCreateKeyEx(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey(), 0, vbNullString, OPERATE_OPTION.REG_OPTION_NON_VOLATILE, samdesired Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, Nothing, phkresult, keyexist)
            Else
                samdesired = KEY_ACCESS_TYPE.KEY_ALL_ACCESS
                regsetvaluetemp = NativeMethods.RegCreateKeyEx(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey(), 0, vbNullString, OPERATE_OPTION.REG_OPTION_NON_VOLATILE, samdesired, Nothing, phkresult, keyexist)
            End If

            If regsetvaluetemp <> ERROR_CODE.ERROR_SUCCESS And keyexist <> REG_OPENED_EXISTING_KEY Then
                Err.Raise(regsetvaluetemp)
                Exit Sub
            End If

            If reg.lpvaluetype() = REG_TYPE.REG_DWORD Then
                regsetvaluetemp = NativeMethods.RegSetValueEx(phkresult, reg.lpvaluename(), 0, REG_TYPE.REG_DWORD, CUInt(reg.regvalue()), 4)
            ElseIf reg.lpvaluetype() = REG_TYPE.REG_SZ Then
                strvalue = CStr(reg.regvalue).Trim()
                regsetvaluetemp = NativeMethods.RegSetValueEx(phkresult, reg.lpvaluename(), 0, REG_TYPE.REG_SZ, strvalue, Len(strvalue))
            End If

            If regsetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                Err.Raise(regsetvaluetemp)
                NativeMethods.RegCloseKey(phkresult)
                Return
            End If

            NativeMethods.RegCloseKey(phkresult)

        End Sub

        Friend Shared Sub RegDel(
                          ByRef reg As RegPath)

            Dim regdeletetemp As ERROR_CODE
            Dim phkresult As IntPtr
            Dim samdesired As Integer

            If reg.lpvaluename() = vbNullString Then
                regdeletetemp = NativeMethods.RegDeleteKey(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey())
                If regdeletetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    Err.Raise(regdeletetemp)
                    Return
                End If
            Else
                If Environment.Is64BitOperatingSystem = True Then
                    If reg.is64reg() = True Then
                        samdesired = KEY_ACCESS_TYPE.KEY_WOW64_64KEY
                    Else
                        samdesired = KEY_ACCESS_TYPE.KEY_WOW64_32KEY
                    End If
                    regdeletetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey(), 0, samdesired Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
                Else
                    samdesired = KEY_ACCESS_TYPE.KEY_ALL_ACCESS
                    regdeletetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.hkey()), reg.lpsubkey(), 0, samdesired, phkresult)
                End If

                If regdeletetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    Err.Raise(regdeletetemp)
                    Return
                End If

                regdeletetemp = NativeMethods.RegDeleteValue(phkresult, reg.lpvaluename())
                If regdeletetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    Err.Raise(regdeletetemp)
                    NativeMethods.RegCloseKey(phkresult)
                    Return
                End If
                regdeletetemp = NativeMethods.RegCloseKey(phkresult)

            End If

        End Sub

    End Class

End Namespace