namespace SpikeCheckoutKataApi.Web.Http.RetrieveBasket
{
	public class Basket
	{
		public Basket(char[] contents)
		{
			Contents = contents;
		}

		public char[] Contents { get; private set; }
	}
}