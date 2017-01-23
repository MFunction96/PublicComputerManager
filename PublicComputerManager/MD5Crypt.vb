Public Class MD5Crypt
    Public Sub DESEncrypt()
    End Sub

    Public Function Encrypt(ByVal Text As String) As String
        Return Encrypt(Text, "MFunction")
    End Function

    Public Function Encrypt(ByVal Text As String, ByVal sKey As String) As String
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

    Public Function Decrypt(ByVal Text As String) As String
        Return Decrypt(Text, "MFunction")
    End Function

    Public Function Decrypt(ByVal Text As String, ByVal sKey As String) As String
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
