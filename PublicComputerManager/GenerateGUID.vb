Public Class GenerateGUID

    Private sguid As String

    Public Function Generate(
                    ByVal isReg As Boolean) _
                    As String

        sguid = Guid.NewGuid.ToString()
        If isReg Then
            sguid = "{" + sguid + "}"
        End If
        Return sguid
    End Function
End Class