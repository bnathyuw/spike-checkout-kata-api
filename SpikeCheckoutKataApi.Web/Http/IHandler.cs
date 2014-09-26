using System.Web;

namespace SpikeCheckoutKataApi.Web.Http
{
	public interface IHandler
	{
		void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse);
	}
}