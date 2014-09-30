namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class Response
	{
		private readonly int _basketId;

		public Response(int basketId)
		{
			_basketId = basketId;
		}

		public string GetLocation()
		{
			return "/baskets/" + _basketId;
		}
	}
}