using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Data;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public interface ICreateBaskets
	{
		CreatedBasket CreateBasket(Request request);
	}

	public interface IReadRequests
	{
		Request From(HttpRequestBase httpRequest);
	}

	public class Handler : IHandler
	{
		private readonly ICreateBaskets _basketStore;
		private readonly IReadRequests _readRequest;
		private readonly IBasketTemplate _basketTemplate;

		public Handler(ICreateBaskets basketStore, IReadRequests readRequest, IBasketTemplate basketTemplate)
		{
			_basketStore = basketStore;
			_readRequest = readRequest;
			_basketTemplate = basketTemplate;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			var request = _readRequest.From(httpRequest);
			var createBasketResponse = _basketStore.CreateBasket(request);
			httpResponse.StatusCode = (int)HttpStatusCode.Created;
			httpResponse.RedirectLocation = createBasketResponse.CompleteTemplate(_basketTemplate);
		}
	}
}