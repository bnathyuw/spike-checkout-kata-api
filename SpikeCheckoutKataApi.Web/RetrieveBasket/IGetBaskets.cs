namespace SpikeCheckoutKataApi.Web.RetrieveBasket
{
	public interface IGetBaskets
	{
		Basket GetBasket(RetrieveBasketRequest request);
	}
}