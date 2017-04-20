'**********************************************************
'名称：GUID生成类
'功能：用于生成各类程序中使用的GUID
'**********************************************************
''' <summary>
''' GUID生成类
''' </summary>
Public Class GenerateGUID
    ''' <summary>
    ''' 生成GUID
    ''' </summary>
    ''' <param name="isReg">
    ''' 是否用于注册表
    ''' </param>
    ''' <returns>
    ''' 返回GUID字符串
    ''' </returns>
    Public Shared Function Generate(
                           ByVal isReg As Boolean) _
                           As String

        Dim sguid As String

        sguid = Guid.NewGuid.ToString()
        If isReg Then
            sguid = "{" + sguid + "}"
        End If
        Return sguid

    End Function

End Class