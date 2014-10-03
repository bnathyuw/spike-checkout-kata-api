namespace SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket
{
	public class Request : ISpecifyItemToDelete
	{
		private readonly int _basketId;
		private readonly int _itemId;

		public Request(int basketId, int itemId)
		{
			_basketId = basketId;
			_itemId = itemId;
		}

		public bool Matches(int itemId, int basketId)
		{
			return _itemId == itemId && _basketId == basketId;
		}
	}
}