<SCRIPT LANGUAGE="VBScript" runat="server">
Option Explicit

Sub Application_OnStart()
	Application("ConnectionString") = GetAppSettings("ConnectionString")
	
	Response.Write(Application("ConnectionString"))
End Sub

Function GetAppSettings(key)

	Dim url, xmlhttp, dom, node
	
	'Call Web Service using HTTP-GET
	url = "http://localhost/ProWebServices/AppService.asmx/"
	url = url & "GetAppSettings?key=" & key
	
	Set xmlhttp = Server.CreateObject("Microsoft.XMLHTTP")
	Call xmlhttp.Open("GET", url, False)
	Call xmlhttp.send()
	
	'Parse result
	Set dom = Server.CreateObject("Microsoft.XMLDOM")
	dom.Load(xmlhttp.responseBody)
	Set node = dom.SelectSingleNode("//string")
	
	If Not node Is Nothinng Then
		GetAppSettings = node.Text
	End If

End Function

</SCRIPT>


