'**********************************************************
'名称：状态类
'功能：用于查询当前计算机的功能相关状态
'修改时间：2017-01-26
'**********************************************************
Public Structure REGVALUESET
    Dim isnull As Boolean
    Dim lptype As RegAPI.REG_TYPE
    Dim lpvalue As Object
    Dim is64reg As Boolean

    Sub New(
        ByVal isnull As Boolean,
        ByVal lptype As RegAPI.REG_TYPE,
        ByVal lpvalue As Object,
        ByVal is64reg As Boolean)

        Me.isnull = isnull
        Me.lptype = lptype
        Me.lpvalue = lpvalue
        Me.is64reg = is64reg

    End Sub

    Sub New(
        ByRef regvalueset As REGVALUESET)

        isnull = regvalueset.isnull
        lptype = regvalueset.lptype
        lpvalue = regvalueset.lpvalue
        is64reg = regvalueset.is64reg

    End Sub

End Structure

Public Class Status

    Private Const ON_STATE As Integer = -1
    Private Const OFF_STATE As Integer = 0

    Private state As Boolean
    Private regnum As Integer
    Private hkey As RegAPI.REG_ROOT_KEY
    Private lpsubkey As String
    Private lpvaluename As String

    Private label As Label
    Private button As Button

    Private onreg() As REGVALUESET
    Private offreg() As REGVALUESET

    Public Sub New(
               ByVal label As Label,
               ByVal button As Button,
               ByVal regNum As Integer,
               ByVal hKey As RegAPI.REG_ROOT_KEY,
               ByVal lpSubkey As String,
               ByVal lpValueName As String,
               ByRef onReg() As REGVALUESET,
               ByRef offReg() As REGVALUESET)

        Dim i As Integer

        state = False
        Me.label = label
        Me.button = button
        Me.regnum = regNum
        Me.hkey = hKey
        Me.lpsubkey = lpSubkey
        Me.lpvaluename = lpValueName
        ReDim Me.onreg(regNum), Me.offreg(regNum)
        For i = 0 To regNum - 1 Step 1
            Me.onreg(i) = onReg(i)
            Me.offreg(i) = offReg(i)
        Next

    End Sub

    Public Function CheckState() As Integer

        Dim flag As Boolean = True
        Dim i As Integer
        Dim reg As New RegAPI
        Dim regvalue As RegAPI.REG_VALUE
        Dim intresult As Integer
        Dim strresult As String

        For i = 0 To regnum - 1 Step 1
            reg.RegGetValue(hkey, lpsubkey, lpvaluename, onreg(i).is64reg)
            If reg.GetError() <> ERROR_CODE.ERROR_SUCCESS And Not (reg.GetError() = ERROR_CODE.ERROR_FILE_NOT_FOUND And onreg(i).isnull) Then
                Return reg.GetError()
            End If
            regvalue = reg.GetValue()
            If regvalue.valuetype = vbString Then
                strresult = CStr(regvalue.value)
                If strresult <> CStr(onreg(i).lpvalue) Then
                    state = False
                    Return OFF_STATE
                End If
            ElseIf regvalue.valuetype = vbInteger Then
                intresult = CInt(regvalue.value)
                If intresult <> CInt(onreg(i).lpvalue) Then
                    state = False
                    Return OFF_STATE
                End If
            Else
                If regvalue.valuetype <> vbNull Or onreg(i).isnull <> True Then
                    state = False
                    Return OFF_STATE
                End If
            End If
        Next

        Return ON_STATE

    End Function

    Public Function ChangeState() As ERROR_CODE

        Dim i As Integer
        Dim r As REGVALUESET
        Dim e As ERROR_CODE
        Dim reg As New RegAPI

        For i = 0 To regnum - 1 Step 1
            If state Then
                r = offreg(i)
            Else
                r = onreg(i)
            End If
            If r.isNull Then
                reg.RegDelete(hKey, lpSubKey, r.is64Reg, lpValueName)
                e = reg.GetError()
                If reg.GetError() = ERROR_CODE.ERROR_FILE_NOT_FOUND Then e = ERROR_CODE.ERROR_SUCCESS
            Else
                reg.RegSetValue(hKey, lpSubKey, lpValueName, r.lpvalue, r.lpType, r.is64Reg)
                e = reg.GetError()
            End If
            If e <> ERROR_CODE.ERROR_SUCCESS Then Return e
        Next

        e = ERROR_CODE.ERROR_SUCCESS
        Return e

    End Function

End Class