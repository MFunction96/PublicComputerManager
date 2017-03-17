'**********************************************************
'名称：状态类
'功能：用于查询当前计算机的功能相关状态
'**********************************************************

Imports PublicComputerManager.RegOpera
Imports PublicComputerManager.PInvoke

Namespace StatusOpera

    ''' <summary>
    ''' 存储及描述注册表当前状态
    ''' </summary>
    <Serializable()>
    Public Class RegStatus
        Implements ICloneable

        Private Const ON_STATE As Integer = -1
        Private Const OFF_STATE As Integer = 0

        Protected _state As Boolean
        Protected _regnum As Integer
        Protected _onreg() As RegStore
        Protected _offreg() As RegStore
        ''' <summary>
        ''' 复制构造函数
        ''' </summary>
        ''' <param name="reg">
        ''' 复制该类所有成员构造操作对象
        ''' </param>
        Public Sub New(
                   ByRef reg As RegStatus)

            Dim i As Integer

            _state = reg._state
            _regnum = reg._regnum
            ReDim _onreg(reg._regnum), _offreg(reg._regnum)
            For i = 0 To reg._regnum - 1 Step 1
                _onreg(i) = CType(reg._onreg(i).Clone(), RegStore)
                _offreg(i) = CType(reg._offreg(i).Clone(), RegStore)
            Next

        End Sub

        ''' <summary>
        ''' 构造函数
        ''' </summary>
        ''' <param name="regNum">
        ''' 表示注册表状态的注册表项数
        ''' </param>
        ''' <param name="onReg">
        ''' 状态为启用时的注册表项
        ''' </param>
        ''' <param name="offReg">
        ''' 状态为关闭时的注册表项
        ''' </param>
        Public Sub New(
                   ByVal regNum As Integer,
                   ByRef onReg() As RegStore,
                   ByRef offReg() As RegStore)

            Dim i As Integer

            _state = False
            _regnum = regNum
            ReDim _onreg(regNum), _offreg(regNum)
            For i = 0 To regNum - 1 Step 1
                _onreg(i) = CType(onReg(i).Clone(), RegStore)
                _offreg(i) = CType(offReg(i).Clone(), RegStore)
            Next

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
        ''' 检查并获取注册表值满足该类处于何种状态
        ''' </summary>
        ''' <returns>
        ''' 若返回负数则表示状态开启；若返回0表示状态关闭；若返回正数则表示处理异常，该数对应Windows异常代码。
        ''' </returns>
        Public Function CheckState() As Integer

            Dim flag As Boolean = True
            Dim i As Integer
            Dim regtemp As RegKey
            Dim intresult As Integer
            Dim strresult As String

            For i = 0 To _regnum - 1 Step 1
                Try
                    regtemp = RegAPI.RegGetValue(New RegPath(_onreg(i).hkey, _onreg(i).lpsubkey, _onreg(i).lpvaluename, _onreg(i).is64reg))
                Catch ex As Exception When Not (Err.Number() = ERROR_CODE.ERROR_FILE_NOT_FOUND Or Err.Number() = ERROR_CODE.ERROR_PATH_NOT_FOUND And _onreg(i).isnull())
                    MsgBox("错误代码：" & Err.Number() & Chr(10) + "错误信息：" + ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
                    Return Err.Number()
                Catch ex As Exception
                    regtemp = New RegKey(New RegPath(_onreg(i).hkey, _onreg(i).lpsubkey, _onreg(i).lpvaluename, _onreg(i).is64reg))
                End Try

                If regtemp.lpvaluetype = REG_TYPE.REG_SZ Then
                    strresult = CStr(regtemp.regvalue)
                    If strresult <> CStr(_onreg(i).regvalue) Then
                        _state = False
                        Return OFF_STATE
                    End If
                ElseIf regtemp.lpvaluetype = REG_TYPE.REG_DWORD Then
                    intresult = CInt(regtemp.regvalue)
                    If intresult <> CInt(_onreg(i).regvalue) Then
                        _state = False
                        Return OFF_STATE
                    End If
                Else
                    If regtemp.lpvaluetype <> REG_TYPE.REG_NONE Or _onreg(i).isnull <> True Then
                        _state = False
                        Return OFF_STATE
                    End If
                End If
            Next

            Return ON_STATE

        End Function

        ''' <summary>
        ''' 更换操作对象状态并修改相应注册表值
        ''' </summary>
        ''' <returns>
        ''' 若返回负数则表示状态开启；若返回0表示状态关闭；若返回正数则表示处理异常，该数对应Windows异常代码。
        ''' </returns>
        Public Function ChangeState() As Integer

            Dim i As Integer
            Dim r As RegStore
            Dim e As ERROR_CODE

            For i = 0 To _regnum - 1 Step 1
                If _state Then
                    r = _offreg(i)
                Else
                    r = _onreg(i)
                End If
                If r.isnull() Then
                    Try
                        RegAPI.RegDel(New RegPath(r.hkey, r.lpsubkey, r.lpvaluename, r.is64reg))
                    Catch ex As Exception When Err.Number() <> ERROR_CODE.ERROR_FILE_NOT_FOUND Or Err.Number() <> ERROR_CODE.ERROR_PATH_NOT_FOUND
                        MsgBox("错误代码：" & Err.Number() & Chr(10) + "错误信息：" + ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
                        Return Err.Number()
                    Catch ex As Exception
                        e = ERROR_CODE.ERROR_SUCCESS
                    End Try
                Else
                    Try
                        RegAPI.RegSetValue(New RegKey(r.hkey, r.lpsubkey, r.lpvaluename, r.is64reg, r.lpvaluetype, r.regvalue))
                    Catch ex As Exception
                        MsgBox("错误代码：" & Err.Number() & Chr(10) + "错误信息：" + ex.Message, CType(vbOKOnly + vbCritical, MsgBoxStyle), "错误")
                        Return Err.Number()
                    End Try
                End If
            Next

            _state = Not _state
            e = ERROR_CODE.ERROR_SUCCESS
            Return e

        End Function

    End Class

    ''' <summary>
    ''' 
    ''' </summary>
    <Serializable()>
    Public Class Status
        Inherits RegStatus
        Implements ICloneable

        Private _tip As Label
        Private _ctrl As Button

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="state">
        ''' 
        ''' </param>
        Public Sub New(
                   ByRef state As Status)

            MyBase.New(state._regnum, state._onreg, state._offreg)
            _tip = state._tip
            _ctrl = state._ctrl

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="tip">
        ''' 
        ''' </param>
        ''' <param name="ctrl">
        ''' 
        ''' </param>
        ''' <param name="reg">
        ''' 
        ''' </param>
        Public Sub New(
                   ByRef tip As Label,
                   ByRef ctrl As Button,
                   ByRef reg As RegStatus)

            MyBase.New(reg)
            _tip = tip
            _ctrl = ctrl

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        Public Overloads Sub ChangeState()

            MyBase.ChangeState()


        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        Public Overloads Sub CheckState()

            MyBase.CheckState()

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns>
        ''' 
        ''' </returns>
        Public Overloads Function Clone() As Object Implements ICloneable.Clone
            Return MemberwiseClone()
        End Function

    End Class

End Namespace