using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class Handler : IHandler
	{
		private readonly ICreateBaskets _basketStore;
		private readonly IReadRequests _readRequest;

		public Handler(ICreateBaskets basketStore, IReadRequests readRequest)
		{
			_basketStore = basketStore;
			_readRequest = readRequest;
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			var request = _readRequest.From(httpRequest);
			var basketId = _basketStore.CreateBasket(request);
			httpResponse.StatusCode = (int)HttpStatusCode.Created;
			httpResponse.RedirectLocation = "http://spike-checkout-kata-api.local/baskets/" + basketId;
		}
	}
}