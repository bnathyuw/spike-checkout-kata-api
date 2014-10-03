namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public delegate T CreateFromItemInStore<out T>(int itemId, int basketId, char code);
	public delegate bool MatchesItemInStore(int itemId, int basketId);

	public class ItemInStore
	{
		private readonly char _code;
		private readonly int _basketId;
		private readonly int _itemId;

		public ItemInStore(char code, int basketId, int itemId)
		{
			_code = code;
			_basketId = basketId;
			_itemId = itemId;
		}

		public T Create<T>(CreateFromItemInStore<T> create)
		{
			return create(_itemId, _basketId, _code);
		}

		public bool Matches(MatchesItemInStore matches)
		{
			return matches(_itemId, _basketId);
		}
	}
}