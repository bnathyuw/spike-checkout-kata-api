namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public class BasketResponse
	{
		public BasketResponse(char[] contents)
		{
			Contents = contents;
		}

		public char[] Contents { get; private set; }
	}
}