using System.Net;
using System.Web;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class NotFoundHttpHandler:IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.StatusCode = (int) HttpStatusCode.NotFound;
		}

		public bool IsReusable { get { return false; } }
	}

}