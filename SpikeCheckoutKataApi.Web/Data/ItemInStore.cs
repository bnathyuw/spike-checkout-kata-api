namespace SpikeCheckoutKataApi.Web.Data
{
	public class ItemInStore
	{
		private readonly char _code;
		private readonly int _basketId;

		public ItemInStore(char code, int basketId)
		{
			_code = code;
			_basketId = basketId;
		}

		public bool IsInBasket(int basketId)
		{
			return _basketId == basketId;
		}

		public char ToItem()
		{
			return _code;
		}
	}
}