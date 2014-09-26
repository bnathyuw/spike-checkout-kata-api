using System.Net;
using System.Web;
using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketHandler:IHttpHandler
	{
		private readonly ItemStore _itemStore;
		private readonly ItemRequestReader _readItemRequest;

		public AddItemToBasketHandler()
		{
			_itemStore = new ItemStore();
			_readItemRequest = new ItemRequestReader();
		}

		public void ProcessRequest(HttpContext context)
		{
			var request = _readItemRequest.From(context.Request);

			_itemStore.StoreItem(request);
			
			context.Response.StatusCode = (int) HttpStatusCode.Created;
		}

		public bool IsReusable { get { return false; } }
	}
}