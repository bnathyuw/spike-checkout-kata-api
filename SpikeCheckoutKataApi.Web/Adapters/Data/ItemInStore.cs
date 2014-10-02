namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public delegate T CreateFromItemInStore<out T>(int id, int basketId, char code);

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

		public bool Matches(Behaviour.DeleteItemFromBasket.Request request)
		{
			return request.Matches(_basketId, _id);
		}

		public T Create<T>(CreateFromItemInStore<T> create)
		{
			return create(_id, _basketId, _code);
		}


		public bool Matches(BasketInStore basketInStore)
		{
			return basketInStore.Matching(_basketId);
		}
	}
}