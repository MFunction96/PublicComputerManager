''' <summary>
''' 读取、写入操作XML表单信息
''' </summary>
Public Class XMLControl
    ''' <summary>
    ''' 向XML文件写入序列化对象
    ''' </summary>
    ''' <param name="type">
    ''' 对象的类型
    ''' </param>
    ''' <param name="obj">
    ''' 对象的引用
    ''' </param>
    ''' <param name="xmlFile">
    ''' XML文件位置
    ''' </param>
    Public Shared Sub WriteXML(type As Type, obj As Object, ByVal xmlFile As String)
        Dim writer As New Xml.Serialization.XmlSerializer(type)
        Dim file As New StreamWriter(xmlFile)
        writer.Serialize(file, obj)
        file.Close()
    End Sub
    ''' <summary>
    ''' 从XML文件读取序列化对象
    ''' </summary>
    ''' <param name="type">
    ''' 对象的类型
    ''' </param>
    ''' <param name="xmlFile">
    ''' XML文件位置
    ''' </param>
    ''' <returns>
    ''' 返回逆序列化的对象
    ''' </returns>
    Public Shared Function ReadXML(type As Type, ByVal xmlFile As String) As Object
        Dim reader As New Xml.Serialization.XmlSerializer(type)
        Dim file As New StreamReader(xmlFile)
        Return CType(reader.Deserialize(file), Type)
    End Function

End Class
