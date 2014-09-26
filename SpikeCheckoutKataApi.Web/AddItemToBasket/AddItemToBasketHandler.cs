using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;
using SpikeCheckoutKataApi.Web.Http;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public class AddItemToBasketHandler : IHandler
	{
		private readonly ItemStore _itemStore;
		private readonly AddItemToBasketRequestReader _readAddItemToBasketRequest;

		public AddItemToBasketHandler()
		{
			_itemStore = new ItemStore();
			_readAddItemToBasketRequest = new AddItemToBasketRequestReader();
		}

		public void ProcessRequest(HttpRequestBase httpRequest, HttpResponseBase httpResponse)
		{
			try
			{
				var request = _readAddItemToBasketRequest.From(httpRequest);

				_itemStore.StoreItem(request);

				httpResponse.StatusCode = (int) HttpStatusCode.Created;
			}
			catch (ValidationException badRequestException)
			{
				httpResponse.StatusCode = (int) HttpStatusCode.BadRequest;
				httpResponse.WriteBody(badRequestException.ToError());
			}
		}
	}
}