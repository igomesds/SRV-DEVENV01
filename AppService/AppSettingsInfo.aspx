<%@ Page Language="C#" Debug="true" %>
<%@ Import namespace="AppSettings" %>

<script language="C#" runat="server">

void GetSetting(System.Object sender, System.EventArgs e) {
	AppService ws = new AppService();
	
	lblValue.Text = ws.GetAppSettings(txtSetting.Text);
}

</script>

<html>
	<body>
		<form id="Form1" method="post" runat="server">
			<strong>Enter the Application Setting to retrieve:</strong><br />
			<asp:TextBox id="txtSetting" runat="server"></asp:TextBox><br />
			<asp:Button id="Button1"
									runat="server"
									Text="Submit"
									OnClick="GetSetting"></asp:Button><br />
			<br />
			<% if (IsPostBack) { %>
				<strong>Value retrieve:</strong><br />
				<asp:Label id="lblValue"
									 runat="server"
									 Width="100%"
									 Height="23px"></asp:Label>
			<% } %>
		</form>
	</body>
</html>