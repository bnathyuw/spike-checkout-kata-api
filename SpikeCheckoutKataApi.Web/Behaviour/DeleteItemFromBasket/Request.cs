namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public class Request
	{
		private readonly int _basketId;
		private readonly int _itemId;

		public Request(int basketId, int itemId)
		{
			_basketId = basketId;
			_itemId = itemId;
		}

		public bool Matches(int basketId, int itemId)
		{
			return _itemId == itemId && _basketId == basketId;
		}
	}
}