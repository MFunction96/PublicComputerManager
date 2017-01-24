Public Class GenerateGUID

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