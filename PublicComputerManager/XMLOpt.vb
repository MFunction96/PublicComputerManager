''' <summary>
''' XML操作类，可以读取写入XML文件元素
''' </summary>
Public Class XMLOpt
    Private _mxmldoc As New Xml.XmlDocument
    Private _xmlfile As String
    ''' <summary>
    ''' 声明xml文件名只读属性
    ''' </summary>
    ''' <returns>
    ''' xml文件名
    ''' </returns>
    Public ReadOnly Property XmlFile As String
        Get
            Return _xmlfile
        End Get
    End Property
    ''' <summary>
    ''' xml读写构造函数
    ''' </summary>
    ''' <param name="filename">
    ''' xml文件名
    ''' </param>
    Public Sub New(ByVal filename As String)
        _xmlfile = filename
        _mxmldoc.Load(_xmlfile)
    End Sub
    ''' <summary>
    ''' 获取xml元素值
    ''' </summary>
    ''' <param name="node">
    ''' xml节点名称
    ''' </param>
    ''' <param name="element">
    ''' xml元素名称
    ''' </param>
    ''' <returns>
    ''' xml元素值
    ''' </returns>
    Public Function GetElement(ByVal node As String, ByVal element As String) As String
        Dim mXmlNode As Xml.XmlNode = _mxmldoc.SelectSingleNode("//" + node)
        Dim xmlNode As Xml.XmlNode = mXmlNode.SelectSingleNode(element)
        Return xmlNode.InnerText
    End Function
    ''' <summary>
    ''' 存储xml值
    ''' </summary>
    ''' <param name="node">
    ''' xml节点名称
    ''' </param>
    ''' <param name="element">
    ''' xml元素名称
    ''' </param>
    ''' <param name="val">
    ''' xml元素值
    ''' </param>
    Public Sub SaveElement(ByVal node As String, ByVal element As String, ByVal val As String)
        Dim mxmlnode As Xml.XmlNode = _mxmldoc.SelectSingleNode("//" + node)
        Dim xmlnodenew As Xml.XmlNode
        xmlnodenew = mXmlNode.SelectSingleNode(element)
        xmlnodenew.InnerText = val
        _mxmldoc.Save(_xmlfile)
    End Sub
End Class
