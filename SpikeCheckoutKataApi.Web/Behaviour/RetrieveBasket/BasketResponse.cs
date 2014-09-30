namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public class BasketResponse
	{
		private readonly string _shopper;

		public BasketResponse(char[] contents, string shopper)
		{
			_shopper = shopper;
			Contents = contents;
		}

		public char[] Contents { get; private set; }

		public string Shopper
		{
			get { return _shopper; }
		}
	}
}