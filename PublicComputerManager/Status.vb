﻿Public Structure REGVALUESET
    Dim isNull As Boolean
    Dim lpType As REG_TYPE
    Dim lpvalue As Object
    Dim is64Reg As Boolean

    Sub New(
        ByVal isNullP As Boolean,
        ByVal lpTypeP As REG_TYPE,
        ByVal lpvalueP As Object,
        ByVal is64RegP As Boolean)

        isNull = isNullP
        lpType = lpTypeP
        lpvalue = lpvalueP
        is64Reg = is64RegP

    End Sub
End Structure

Public Class Status

    Private state As Boolean
    Private regnum As Integer
    Private hKey As REG_ROOT_KEY
    Private lpSubKey As String
    Private lpValueName As String

    Private label As Label
    Private button As Button

    Private onreg() As REGVALUESET
    Private offreg() As REGVALUESET

    Public Sub New(
               ByVal lableP As Label,
               ByVal buttonP As Button,
               ByVal regNumP As Integer,
               ByVal hKeyP As REG_ROOT_KEY,
               ByVal lpSubkeyP As String,
               ByVal lpValueNameP As String,
               ByVal onRegP() As REGVALUESET,
               ByVal offRegP() As REGVALUESET)

        Dim i As Integer

        state = False
        label = lableP
        button = buttonP
        regnum = regNumP
        hKey = hKeyP
        lpSubKey = lpSubkeyP
        lpValueName = lpValueNameP
        ReDim onreg(regnum), offreg(regnum)
        For i = 0 To regnum - 1 Step 1
            onreg(i) = onRegP(i)
            offreg(i) = offRegP(i)
        Next

    End Sub

    Public Function CheckState() As Integer

        Dim flag As Boolean = True
        Dim i As Integer
        Dim reg As New RegAPI
        Dim regvalue As RegAPI.VALUE
        Dim intresult As Integer
        Dim strresult As String

        For i = 0 To regnum - 1 Step 1
            reg.RegGetValue(hKey, lpSubKey, lpValueName, onreg(i).is64Reg)
            regvalue = reg.GetValue()
            If reg.GetError() <> ERROR_CODE.ERROR_SUCCESS And Not (reg.GetError() = ERROR_CODE.ERROR_FILE_NOT_FOUND And onreg(i).isNull) Then
                Return reg.GetError()
            End If

            If regvalue.valuetype = vbString Then
                strresult = CStr(regvalue.value)
                If strresult <> CStr(onreg(i).lpvalue) Then
                    state = False
                    Return 0
                End If
            ElseIf regvalue.valuetype = vbInteger Then
                intresult = CInt(regvalue.value)
                If intresult <> CInt(onreg(i).lpvalue) Then
                    state = False
                    Return 0
                End If
            Else
                If regvalue.valuetype <> vbNull Or onreg(i).isNull <> True Then
                    state = False
                    Return 0
                End If
            End If
        Next

        Return -1

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