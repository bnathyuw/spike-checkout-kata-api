using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketHandler:IHttpHandler, IHandler
	{
		private readonly ItemStore _itemStore;
		private readonly AddItemToBasketRequestReader _readAddItemToBasketRequest;

		public AddItemToBasketHandler()
		{
			_itemStore = new ItemStore();
			_readAddItemToBasketRequest = new AddItemToBasketRequestReader();
		}

		public void ProcessRequest(HttpContext context)
		{
			ProcessRequest(new HttpRequestWrapper(context.Request), new HttpResponseWrapper(context.Response));
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

		public bool IsReusable { get { return false; } }
	}
}