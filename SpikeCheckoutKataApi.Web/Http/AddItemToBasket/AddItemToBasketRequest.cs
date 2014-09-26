using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using SpikeCheckoutKataApi.Web.Data;

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

		public static ItemRequest From(HttpRequest httpRequest)
		{
			var basketId = httpRequest.GetBasketId();
			using(var stream = httpRequest.GetBufferlessInputStream())
			using (var reader = new StreamReader(stream))
			{
				var body = reader.ReadToEnd();
				var item = Serializer.Deserialize<ItemRequest>(body);
				item.BasketId = basketId;
				return item;
			}
		}
	}

	public class ItemRequest
	{
		public char Code { private get; set; }
		public int BasketId { get; set; }

		public ItemInStore ToItemInStore()
		{
			return new ItemInStore(Code, BasketId);
		}
	}
}