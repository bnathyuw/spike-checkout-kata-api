using System.Web;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class HttpHandlerWrapper : IHttpHandler
	{
		private readonly IHandler _handler;

		public HttpHandlerWrapper(IHandler handler)
		{
			_handler = handler;
		}

		public bool IsReusable { get { return false; } }

		public void ProcessRequest(HttpContext context)
		{
			_handler.ProcessRequest(new HttpRequestWrapper(context.Request), new HttpResponseWrapper(context.Response));
		}
	}
}