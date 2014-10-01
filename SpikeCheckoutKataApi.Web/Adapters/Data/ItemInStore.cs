using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class ItemInStore
	{
		private readonly char _code;
		private readonly int _basketId;
		private readonly int _id;

		public ItemInStore(char code, int basketId, int id)
		{
			_code = code;
			_basketId = basketId;
			_id = id;
		}

		public bool Matches(Request request)
		{
			return request.Matches(_basketId);
		}

		public char ToItem()
		{
			return _code;
		}

		public bool Matches(Behaviour.DeleteItemFromBasket.Request request)
		{
			return request.Matches(_basketId, _id);
		}

		public CreatedItem ToCreatedItem()
		{
			return new CreatedItem(_id, _basketId);
		}
	}
}