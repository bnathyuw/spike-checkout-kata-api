using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddItemToBasketHandlerFactory = SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket.HandlerFactory;
using DeleteItemFromBasketHandlerFactory = SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket.HandlerFactory;
using RetrieveBasketHandlerFactory = SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket.HandlerFactory;
using CreateBasketHandlerFactory = SpikeCheckoutKataApi.Web.Behaviour.CreateBasket.HandlerFactory;
using NotFoundHandlerFactory = SpikeCheckoutKataApi.Web.Behaviour.NotFound.HandlerFactory;

namespace SpikeCheckoutKataApi.Web.Adapters.Http
{
	public interface IHandlerFactory
	{
		IHandler CreateHandler();
		bool Matches(string requestType, string url);
	}
	
	public class HttpHandlerFactory : IHttpHandlerFactory
	{
		private readonly List<IHandlerFactory> _factories;

		public HttpHandlerFactory()
		{
			_factories = new List<IHandlerFactory>
				{
					new DeleteItemFromBasketHandlerFactory(),
					new AddItemToBasketHandlerFactory(),
					new RetrieveBasketHandlerFactory(),
					new CreateBasketHandlerFactory(),
					new NotFoundHandlerFactory()
				};
		}

		public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
		{
			return new HttpHandlerWrapper(_factories.First(f => f.Matches(requestType, url)).CreateHandler());
		}

		public void ReleaseHandler(IHttpHandler handler)
		{
		}
	}
}