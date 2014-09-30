namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class Response
	{
		private readonly int _basketId;

		public Response(int basketId)
		{
			_basketId = basketId;
		}

		public int BasketId
		{
			get { return _basketId; }
		}

		public string GetBasketLocation()
		{
			return "/baskets/" + _basketId;
		}
	}
}