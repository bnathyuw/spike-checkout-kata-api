namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public class RetrieveBasketRequest
	{
		private readonly int _basketId;

		public RetrieveBasketRequest(int basketId)
		{
			_basketId = basketId;
		}

		public bool Matches(int basketId)
		{
			return basketId == _basketId;
		}
	}
}