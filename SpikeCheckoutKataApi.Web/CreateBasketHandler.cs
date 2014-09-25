using System.Web;

namespace SpikeCheckoutKataApi.Web
{
	public class CreateBasketHandler:IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.RedirectLocation = "http://spike-checkout-kata-api.local/baskets/1";
		}

		public bool IsReusable { get { return false; } }
	}
}