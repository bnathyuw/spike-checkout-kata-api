using SpikeCheckoutKataApi.Web.RetrieveBasket;

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

		public bool Matches(RetrieveBasketRequest request)
		{
			return request.Matches(_basketId);
		}

		public char ToItem()
		{
			return _code;
		}
	}
}