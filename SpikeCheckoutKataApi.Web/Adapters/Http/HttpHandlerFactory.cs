using System.Text.RegularExpressions;
using System.Web;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public class HttpHandlerFactory:IHttpHandlerFactory
	{
		public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
		{
			if (new Regex("^/baskets/(\\d+)/items/(\\d+)$").IsMatch(url) && requestType == "DELETE")
				return DeleteItemFromBasketHttpHandler.CreateHandler();
			if(new Regex("^/baskets/(\\d+)/items$").IsMatch(url) && requestType == "POST")
				return AddItemToBasketHttpHandler.CreateAddItemToBasketHttpHandler();
			if (new Regex("^/baskets/(\\d+)$").IsMatch(url) && requestType == "GET")
				return RetrieveBasketHttpHandler.CreateRetrieveBasketHttpHandler();
			if (new Regex("^/baskets$").IsMatch(url) && requestType == "POST")
				return CreateBasketHttpHandler.CreateCreateBasketHttpHandler();
			return new NotFoundHttpHandler();
		}

		public void ReleaseHandler(IHttpHandler handler)
		{
		}
	}
}