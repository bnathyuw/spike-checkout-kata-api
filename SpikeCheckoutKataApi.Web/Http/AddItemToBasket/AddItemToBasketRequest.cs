using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class AddItemToBasketRequest
	{
		private readonly int _basketId;
		private readonly ItemRequest _itemRequest;
		private static readonly JavaScriptSerializer Serializer;

		public AddItemToBasketRequest(int basketId, ItemRequest itemRequest)
		{
			_basketId = basketId;
			_itemRequest = itemRequest;
		}

		static AddItemToBasketRequest()
		{
			Serializer = new JavaScriptSerializer();
		}

		public int BasketId
		{
			get { return _basketId; }
		}

		public ItemRequest ItemRequest
		{
			get { return _itemRequest; }
		}

		public static AddItemToBasketRequest From(HttpRequest httpRequest)
		{
			var id = httpRequest.GetBasketId();
			using(var stream = httpRequest.GetBufferlessInputStream())
			using (var reader = new StreamReader(stream))
			{
				var body = reader.ReadToEnd();
				var item = Serializer.Deserialize<ItemRequest>(body);
				return new AddItemToBasketRequest(id, item);
			}
		}
	}

	public class ItemRequest
	{
		public char Code { get; set; }

		public char ToItemInStore()
		{
			return Code;
		}
	}
}