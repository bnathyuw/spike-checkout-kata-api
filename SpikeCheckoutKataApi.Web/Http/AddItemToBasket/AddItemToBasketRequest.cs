using System.Web;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketRequest
	{
		private readonly int _id;
		private readonly char _item;

		public AddItemToBasketRequest(int id, char item)
		{
			_id = id;
			_item = item;
		}

		public int Id
		{
			get { return _id; }
		}

		public char Item
		{
			get { return _item; }
		}

		public static AddItemToBasketRequest From(HttpRequest httpRequest)
		{
			var id = httpRequest.GetBasketId();
			return new AddItemToBasketRequest(id, 'A');
		}
	}
}