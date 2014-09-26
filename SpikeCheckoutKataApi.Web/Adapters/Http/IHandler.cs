using System.Web;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public interface IHandler
	{
		void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse);
	}
}