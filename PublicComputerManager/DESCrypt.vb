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
    ''' 自定义密码加密，默认密码为MFunction
    ''' </summary>
    ''' <param name="Text">
    ''' 需要加密的文本
    ''' </param>
    ''' <param name="sKey">
    ''' 自定义加密密码
    ''' </param>
    ''' <returns>
    ''' 加密后文本
    ''' </returns>
    Public Shared Function Encrypt(ByVal Text As String, Optional ByVal sKey As String = "MFunction") As String
        If sKey = vbNullString Then
            sKey = "MFunction"
        End If
        Dim des As New DESCryptoServiceProvider()
        Dim inputByteArray As Byte()
        inputByteArray = Encoding.Default.GetBytes(Text)
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
    ''' 自定义密码解密，默认密码为MFunction
    ''' </summary>
    ''' <param name="Text">
    ''' 需要解密的文本
    ''' </param>
    ''' <param name="sKey">
    ''' 自定义密码
    ''' </param>
    ''' <returns>
    ''' 解密后的文本
    ''' </returns>
    Public Shared Function Decrypt(ByVal Text As String, Optional ByVal sKey As String = "MFunction") As String
        If sKey = vbNullString Then
            sKey = "MFunction"
        End If
        Dim des As New DESCryptoServiceProvider()
        Dim len As Integer
        len = CInt(Text.Length / 2)
        Dim inputByteArray(len - 1) As Byte
        Dim x, i As Integer
        For x = 0 To len - 1
            i = Convert.ToInt32(Text.Substring(x * 2, 2), 16)
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
