namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public delegate T CreateFromRequest<out T>(string shopper);

	public class Request : ISpecifyBasketToStore
	{
		private readonly string _shopper;

		public Request(string shopper)
		{
			_shopper = shopper;
		}

		public T Create<T>(CreateFromRequest<T> create)
		{
			return create(_shopper);
		}
	}
}