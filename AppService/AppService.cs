using System.Configuration;
using System.Web;
using System.Web.Services;

[WebService(Namespace="http://www.wrox.com.br/services")]
public class AppService 
{
	[WebMethod]
	public void SetAppState(string key, string value)
	{
		HttpApplicationState Application;
		Application = HttpContext.Current.Application;

		Application.Lock();
		Application[key] = value;
		Application.UnLock();
	}

	[WebMethod]
	public string GetAppState(string key)
	{
		HttpApplicationState Application;
		Application = HttpContext.Current.Application;

		if (Application[key] == null)
			return null;
		else if (Application[key] is System.String)
			return Application[key].ToString();
		else
			return null;
	}

	[WebMethod]
	public string GetAppSettings(string key, int delay)
	{
		return ConfigurationSettings.AppSettings[key];
	}
}