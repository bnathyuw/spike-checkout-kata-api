using System.Web;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class HttpHandler:IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
		}

		public bool IsReusable { get { return false; } }
	}
}