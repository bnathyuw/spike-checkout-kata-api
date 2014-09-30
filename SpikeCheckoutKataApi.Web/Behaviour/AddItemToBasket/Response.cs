namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class Response
	{
		private readonly int _itemId;
		private readonly int _basketId;

		public Response(int itemId, int basketId)
		{
			_itemId = itemId;
			_basketId = basketId;
		}

		public string GetLocation()
		{
			return string.Format("/baskets/{0}/items/{1}", _basketId, _itemId);
		}
	}
}