'**********************************************************
'名称：MD5加密类
'功能：用于数据加密
'**********************************************************
Imports System.Web
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
''' <summary>
''' MD5加密类
''' </summary>
Public Class DESCrypt
    ''' <summary>
    ''' 自定义密码加密，默认密码为12345678
    ''' </summary>
    ''' <param name="str">
    ''' 需要加密的文本
    ''' </param>
    ''' <param name="sKey">
    ''' 自定义加密密码
    ''' </param>
    ''' <returns>
    ''' 加密后文本
    ''' </returns>
    Public Shared Function Encrypt(str As String, Optional sKey As String = "12345678") As String
        If str = vbNullString Then
            Throw New Exception("不能加密空字符串")
        ElseIf sKey.Length <> 8 Then
            Throw New Exception("密码长度必须等于8个字符")
        End If
        Dim des As New DESCryptoServiceProvider()
        Dim inputByteArray As Byte()
        inputByteArray = Encoding.Default.GetBytes(str)
        des.Key = Encoding.ASCII.GetBytes(Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
        des.IV = Encoding.ASCII.GetBytes(Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
        Dim ms As New MemoryStream()
        Dim cs As New CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write)
        cs.Write(inputByteArray, 0, inputByteArray.Length)
        cs.FlushFinalBlock()
        Dim ret As New StringBuilder()
        Dim b As Byte
        For Each b In ms.ToArray()
            ret.AppendFormat("{0:X2}", b)
        Next
        Return ret.ToString()
    End Function
    ''' <summary>
    ''' 自定义密码解密，默认密码为12345678
    ''' </summary>
    ''' <param name="str">
    ''' 需要解密的文本
    ''' </param>
    ''' <param name="sKey">
    ''' 自定义密码
    ''' </param>
    ''' <returns>
    ''' 解密后的文本
    ''' </returns>
    Public Shared Function Decrypt(str As String, Optional sKey As String = "12345678") As String
        If str = vbNullString Then
            Throw New Exception("不能加密空字符串")
        ElseIf sKey.Length <> 8 Then
            Throw New Exception("密码长度必须等于8个字符")
        End If
        Dim des As New DESCryptoServiceProvider()
        Dim len As Integer
        len = CInt(str.Length / 2)
        Dim inputByteArray(len - 1) As Byte
        Dim x, i As Integer
        For x = 0 To len - 1
            i = Convert.ToInt32(str.Substring(x * 2, 2), 16)
            inputByteArray(x) = CType(i, Byte)
        Next
        des.Key = Encoding.ASCII.GetBytes(Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
        des.IV = Encoding.ASCII.GetBytes(Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8))
        Dim ms As New MemoryStream()
        Dim cs As New CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write)
        cs.Write(inputByteArray, 0, inputByteArray.Length)
        cs.FlushFinalBlock()
        Return Encoding.Default.GetString(ms.ToArray())
    End Function

End Class
