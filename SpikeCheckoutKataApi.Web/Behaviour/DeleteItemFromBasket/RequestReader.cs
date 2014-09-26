using System.Web;

namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public class RequestReader:IReadRequests{
		public Request From(HttpRequestBase request)
		{
			var basketId = request.GetBasketId();
			var itemId = request.GetItemId();
			return new Request(basketId, itemId);
		}
	}
}