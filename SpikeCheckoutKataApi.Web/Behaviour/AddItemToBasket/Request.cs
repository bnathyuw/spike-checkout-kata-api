using SpikeCheckoutKataApi.Web.Adapters.Data;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class Request
	{
		private readonly char _code;
		private readonly int _basketId;

		public Request(char code, int basketId)
		{
			_code = code;
			_basketId = basketId;
		}

		public ItemInStore ToItemInStore()
		{
			return new ItemInStore(_code, _basketId);
		}
	}
}