using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.NotFound
{
	public class Handler : IHandler
	{
		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			httpResponse.StatusCode = (int) HttpStatusCode.NotFound;
		}
	}
}