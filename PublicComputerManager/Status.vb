'**********************************************************
'名称：状态类
'功能：用于查询当前计算机的功能相关状态
'**********************************************************
<Serializable()> Public Class RegStatus
    Inherits RegKey : Implements ICloneable

    Private _isnull As Boolean

    Public Sub New(
               ByRef state As RegStatus)

        MyBase.New(state.hkey(), state.lpsubkey(), state.lpvaluename(), state.is64reg(), state.lpvaluetype(), state.regvalue())
        _isnull = state.isnull()

    End Sub

    Public Sub New(
               ByRef isNull As Boolean,
               ByRef reg As RegKey)

        MyBase.New(reg)
        _isnull = isNull

    End Sub

    Public Sub New(
               ByRef isNull As Boolean,
               ByRef reg As RegPath,
               ByRef lpValueType As RegAPI.REG_TYPE,
               ByVal regValue As Object)

        MyBase.New(reg, lpValueType, regValue)
        _isnull = isNull

    End Sub

    Public Sub New(
               ByRef isNull As Boolean,
               ByRef hKey As RegAPI.REG_ROOT_KEY,
               ByVal lpSubKey As String,
               ByVal lpValueName As String,
               ByRef is64Reg As Boolean,
               ByRef lpValueType As RegAPI.REG_TYPE,
               ByVal regValue As Object)

        MyBase.New(hKey, lpSubKey, lpValueName, is64Reg, lpValueType, regValue)
        _isnull = isNull

    End Sub

    Public Overloads Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function

    Public Function isnull() As Boolean
        Return _isnull
    End Function

End Class

<Serializable()> Public Class Status : Implements ICloneable

    Private Const ON_STATE As Integer = -1
    Private Const OFF_STATE As Integer = 0

    Private _state As Boolean
    Private _regnum As Integer

    Private _label As Label
    Private _button As Button

    Private _onreg() As RegStatus
    Private _offreg() As RegStatus

    Public Sub New(
               ByVal label As Label,
               ByVal button As Button,
               ByVal regNum As Integer,
               ByRef onReg() As RegStatus,
               ByRef offReg() As RegStatus)

        Dim i As Integer

        _state = False
        _label = label
        _button = button
        _regnum = regNum
        ReDim _onreg(regNum), _offreg(regNum)
        For i = 0 To regNum - 1 Step 1
            _onreg(i) = CType(onReg(i).Clone(), RegStatus)
            _offreg(i) = CType(offReg(i).Clone(), RegStatus)
        Next

    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Return MemberwiseClone()
    End Function

    Public Function CheckState() As Integer

        Dim flag As Boolean = True
        Dim i As Integer
        Dim regtemp As RegKey
        Dim intresult As Integer
        Dim strresult As String

        For i = 0 To _regnum - 1 Step 1
            Try
                regtemp = RegAPI.RegGetValue(New RegPath(_onreg(i).hkey, _onreg(i).lpsubkey, _onreg(i).lpvaluename, _onreg(i).is64reg))
            Catch ex As Exception When Not (Err.Number <> ERROR_CODE.ERROR_FILE_NOT_FOUND And _onreg(i).isnull())
                MsgBox("错误信息" + Chr(10) + ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
                Return Err.Number
            End Try

            If regtemp.lpvaluetype = RegAPI.REG_TYPE.REG_SZ Then
                strresult = CStr(regtemp.regvalue)
                If strresult <> CStr(_onreg(i).regvalue) Then
                    _state = False
                    Return OFF_STATE
                End If
            ElseIf regtemp.lpvaluetype = RegAPI.REG_TYPE.REG_DWORD Then
                intresult = CInt(regtemp.regvalue)
                If intresult <> CInt(_onreg(i).regvalue) Then
                    _state = False
                    Return OFF_STATE
                End If
            Else
                If regtemp.lpvaluetype <> RegAPI.REG_TYPE.REG_NONE Or _onreg(i).IsNull <> True Then
                    _state = False
                    Return OFF_STATE
                End If
            End If
        Next

        Return ON_STATE

    End Function

    Public Function ChangeState() As Integer

        Dim i As Integer
        Dim r As RegStatus
        Dim e As ERROR_CODE

        For i = 0 To _regnum - 1 Step 1
            If _state Then
                r = _offreg(i)
            Else
                r = _onreg(i)
            End If
            If r.IsNull() Then
                Try
                    RegAPI.RegDel(New RegPath(r.hkey, r.lpsubkey, r.lpvaluename, r.is64reg))
                Catch ex As Exception When Err.Number <> ERROR_CODE.ERROR_FILE_NOT_FOUND Or Err.Number <> ERROR_CODE.ERROR_PATH_NOT_FOUND
                    MsgBox("错误信息" + Chr(10) + ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
                    Return Err.Number
                End Try
            Else
                Try
                    RegAPI.RegSetValue(New RegKey(r.hkey, r.lpsubkey, r.lpvaluename, r.is64reg, r.lpvaluetype, r.regvalue))
                Catch ex As Exception
                    MsgBox("错误信息" + Chr(10) + ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
                    Return Err.Number
                End Try
            End If
        Next

        _state = Not _state
        e = ERROR_CODE.ERROR_SUCCESS
        Return e

    End Function

End Class