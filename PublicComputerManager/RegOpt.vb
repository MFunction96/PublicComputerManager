'**********************************************************
'名称：注册表访问相关API封装
'功能：注册表信息的创建、赋值、读取、删除
'**********************************************************
Imports PublicComputerManager.PInvoke

Namespace RegOpt
    ''' <summary>
    ''' 注册表主键常量枚举
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
    ''' 注册表路径类
    ''' </summary>
    <Serializable()>
    Public Class RegPath
        Implements ICloneable, ISerializable

        Private _hKey As Integer
        Private _lpsubkey As String
        Private _lpvaluename As String
        ''' <summary>
        ''' 无参数构造函数支持序列化
        ''' </summary>
        Public Sub New()

        End Sub
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="reg">
        ''' 复制该对象的所有成员
        ''' </param>
        Public Sub New(
                   ByRef reg As RegPath)

            _hKey = reg.Hkey
            _lpsubkey = reg.Lpsubkey
            _lpvaluename = reg.Lpvaluename

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
        Public Sub New(
                   ByRef hKey As Integer,
                   ByVal lpSubKey As String,
                   Optional ByVal lpValueName As String = vbNullString)

            _hKey = hKey
            _lpsubkey = lpSubKey
            _lpvaluename = lpValueName

        End Sub
        ''' <summary>
        ''' 逆序列化构造函数
        ''' </summary>
        ''' <param name="info">
        ''' 要填充数据的序列化信息
        ''' </param>
        ''' <param name="context">
        ''' 此序列化的目标
        ''' </param>
        Protected Sub New(info As SerializationInfo, context As StreamingContext)
            _hKey = info.GetInt32("hkey")
            _lpsubkey = info.GetString("lpsubkey")
            _lpvaluename = info.GetString("lpvaluename")
        End Sub
        ''' <summary>
        ''' 序列化接口实现方法
        ''' </summary>
        ''' <param name="info">
        ''' 要填充数据的序列化信息
        ''' </param>
        ''' <param name="context">
        ''' 此序列化的目标
        ''' </param>
        Protected Overridable Overloads Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
            info.AddValue("hkey", _hKey)
            info.AddValue("lpsubkey", _lpsubkey)
            info.AddValue("lpvaluename", _lpvaluename)
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
        ''' 获取注册表路径的主键属性
        ''' </summary>
        ''' <returns>
        ''' 注册表路径的主键属性值
        ''' </returns>
        Public ReadOnly Property Hkey As Integer
            Get
                Return _hKey
            End Get
        End Property
        ''' <summary>
        ''' 获取注册表路径的子键属性
        ''' </summary>
        ''' <returns>
        ''' 注册表路径的子键属性值
        ''' </returns>
        Public ReadOnly Property Lpsubkey As String
            Get
                Return _lpsubkey
            End Get
        End Property
        ''' <summary>
        ''' 获取注册表路径的键名属性
        ''' </summary>
        ''' <returns>
        ''' 注册表路径的键名属性值
        ''' </returns>
        Public ReadOnly Property Lpvaluename As String
            Get
                Return _lpvaluename
            End Get
        End Property
    End Class
    ''' <summary>
    ''' 注册表键类
    ''' </summary>
    <Serializable()>
    Public Class RegKey
        Inherits RegPath
        Implements ICloneable, ISerializable

        Private _lpvaluetype As Integer
        Private _regvalue As Object
        ''' <summary>
        ''' 无参数构造函数支持序列化
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="reg">
        ''' 复制该对象的所有成员
        ''' </param>
        Public Sub New(
                   ByRef reg As RegKey)

            MyBase.New(reg.Hkey, reg.Lpsubkey, reg.Lpvaluename)
            _lpvaluetype = reg.Lpvaluetype()
            _regvalue = reg.Regvalue()

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
                   Optional ByRef lpValueType As Integer = REG_TYPE.REG_NONE,
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
        ''' <param name="lpValueType">
        ''' 构造注册表的键值类型
        ''' </param>
        ''' <param name="regValue">
        ''' 构造注册表的键值
        ''' </param>
        Public Sub New(
                   ByRef hKey As Integer,
                   ByVal lpSubKey As String,
                   Optional ByVal lpValueName As String = vbNullString,
                   Optional ByRef lpValueType As Integer = REG_TYPE.REG_NONE,
                   Optional ByVal regValue As Object = Nothing)

            MyBase.New(hKey, lpSubKey, lpValueName)
            _lpvaluetype = lpValueType
            _regvalue = regValue

        End Sub
        ''' <summary>
        ''' 逆序列化构造函数
        ''' </summary>
        ''' <param name="info">
        ''' 要填充数据的序列化信息
        ''' </param>
        ''' <param name="context">
        ''' 此序列化的目标
        ''' </param>
        Protected Sub New(info As SerializationInfo, context As StreamingContext)
            MyBase.New(info, context)
            _lpvaluetype = info.GetInt32("lpvaluetype")
            _regvalue = info.GetValue("regvalue", info.ObjectType)
        End Sub
        ''' <summary>
        ''' 序列化接口实现方法
        ''' </summary>
        ''' <param name="info">
        ''' 要填充数据的序列化信息
        ''' </param>
        ''' <param name="context">
        ''' 此序列化的目标
        ''' </param>
        Protected Overridable Overloads Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
            MyBase.GetObjectData(info, context)
            info.AddValue("lpvaluetype", _lpvaluetype)
            info.AddValue("regvalue", _regvalue)
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
        Public ReadOnly Property Lpvaluetype As Integer
            Get
                Return _lpvaluetype
            End Get
        End Property
        ''' <summary>
        ''' 获取操作对象的键值属性
        ''' </summary>
        ''' <returns>
        ''' 返回操作对象的键值属性
        ''' </returns>
        Public ReadOnly Property Regvalue As Object
            Get
                Return _regvalue
            End Get
        End Property

    End Class
    ''' <summary>
    ''' 注册表存储类
    ''' </summary>
    <Serializable()>
    Public Class RegStore
        Inherits RegKey
        Implements ICloneable, ISerializable

        Private _isnull As Boolean

        ''' <summary>
        ''' 无参数构造函数支持序列化
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="store">
        ''' 复制该对象的所有成员
        ''' </param>
        Public Sub New(
                   ByRef store As RegStore)

            MyBase.New(store.Hkey, store.Lpsubkey, store.Lpvaluename, store.Lpvaluetype, store.Regvalue)
            _isnull = store.Isnull

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
                   ByRef lpValueType As Integer,
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
        ''' <param name="lpValueType">
        ''' 构造注册表键值类型
        ''' </param>
        ''' <param name="regValue">
        ''' 构造注册表键值
        ''' </param>
        Public Sub New(
                   ByRef isNull As Boolean,
                   ByRef hKey As Integer,
                   ByVal lpSubKey As String,
                   ByVal lpValueName As String,
                   ByRef lpValueType As Integer,
                   ByVal regValue As Object)

            MyBase.New(hKey, lpSubKey, lpValueName, lpValueType, regValue)
            _isnull = isNull

        End Sub
        ''' <summary>
        ''' 逆序列化构造函数
        ''' </summary>
        ''' <param name="info">
        ''' 要填充数据的序列化信息
        ''' </param>
        ''' <param name="context">
        ''' 此序列化的目标
        ''' </param>
        Protected Sub New(info As SerializationInfo, context As StreamingContext)
            MyBase.New(info, context)
            _isnull = info.GetBoolean("isnull")
        End Sub
        ''' <summary>
        ''' 序列化接口实现方法
        ''' </summary>
        ''' <param name="info">
        ''' 要填充数据的序列化信息
        ''' </param>
        ''' <param name="context">
        ''' 此序列化的目标
        ''' </param>
        Protected Overridable Overloads Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
            MyBase.GetObjectData(info, context)
            info.AddValue("isnull", _isnull)
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
        Public ReadOnly Property Isnull As Boolean
            Get
                Return _isnull
            End Get
        End Property

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

            Dim reggetvaluetemp As Integer
            Dim phkresult As IntPtr
            Dim lptype As Integer
            Dim lpdatastr As String
            Dim lpdataint As Integer
            Dim lpcbdata As Integer
            Dim regtemp As RegKey

            If Environment.Is64BitOperatingSystem() = True Then
                reggetvaluetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey, 0, KEY_ACCESS_TYPE.KEY_WOW64_64KEY Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
            Else
                reggetvaluetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey, 0, KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
            End If

            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                Err.Raise(reggetvaluetemp)
                Return New RegKey(reg)
            End If

            reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, reg.Lpvaluename, IntPtr.op_Explicit(0), lptype, vbNullString, lpcbdata)
            If reggetvaluetemp <> ERROR_CODE.ERROR_SUCCESS Then
                NativeMethods.RegCloseKey(phkresult)
                Err.Raise(reggetvaluetemp)
                Return New RegKey(reg)
            End If

            If lptype = REG_TYPE.REG_SZ Or lptype = REG_TYPE.REG_EXPAND_SZ Or lptype = REG_TYPE.REG_MULTI_SZ Then
                lpdatastr = StrDup(lpcbdata, Chr(0))
                reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, reg.Lpvaluename, IntPtr.op_Explicit(0), lptype, lpdatastr, lpcbdata)
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
                reggetvaluetemp = NativeMethods.RegQueryValueEx(phkresult, reg.Lpvaluename, IntPtr.op_Explicit(0), lptype, lpdataint, lpcbdata)
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
            Dim phkresult As IntPtr
            Dim strvalue As String = vbNullString
            Dim regsetvaluetemp As Integer

            If Environment.Is64BitOperatingSystem = True Then
                regsetvaluetemp = NativeMethods.RegCreateKeyEx(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey, 0, vbNullString, OPERATE_OPTION.REG_OPTION_NON_VOLATILE, KEY_ACCESS_TYPE.KEY_WOW64_64KEY Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, Nothing, phkresult, keyexist)
            Else
                regsetvaluetemp = NativeMethods.RegCreateKeyEx(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey, 0, vbNullString, OPERATE_OPTION.REG_OPTION_NON_VOLATILE, KEY_ACCESS_TYPE.KEY_ALL_ACCESS, Nothing, phkresult, keyexist)
            End If

            If regsetvaluetemp <> ERROR_CODE.ERROR_SUCCESS And keyexist <> REG_OPENED_EXISTING_KEY Then
                Err.Raise(regsetvaluetemp)
                Exit Sub
            End If

            If reg.Lpvaluetype() = REG_TYPE.REG_DWORD Then
                regsetvaluetemp = NativeMethods.RegSetValueEx(phkresult, reg.Lpvaluename, 0, REG_TYPE.REG_DWORD, CUInt(reg.Regvalue()), 4)
            ElseIf reg.Lpvaluetype() = REG_TYPE.REG_SZ Then
                strvalue = CStr(reg.Regvalue).Trim()
                regsetvaluetemp = NativeMethods.RegSetValueEx(phkresult, reg.Lpvaluename, 0, REG_TYPE.REG_SZ, strvalue, Len(strvalue) * 2)
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

            Dim regdeletetemp As Integer
            Dim phkresult As IntPtr

            If reg.Lpvaluename = vbNullString Then
                regdeletetemp = NativeMethods.RegDeleteKey(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey)
                If regdeletetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    Err.Raise(regdeletetemp)
                    Return
                End If
            Else
                If Environment.Is64BitOperatingSystem = True Then
                    regdeletetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey, 0, KEY_ACCESS_TYPE.KEY_WOW64_64KEY Or KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
                Else
                    regdeletetemp = NativeMethods.RegOpenKeyEx(IntPtr.op_Explicit(reg.Hkey), reg.Lpsubkey, 0, KEY_ACCESS_TYPE.KEY_ALL_ACCESS, phkresult)
                End If

                If regdeletetemp <> ERROR_CODE.ERROR_SUCCESS Then
                    Err.Raise(regdeletetemp)
                    Return
                End If

                regdeletetemp = NativeMethods.RegDeleteValue(phkresult, reg.Lpvaluename)
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