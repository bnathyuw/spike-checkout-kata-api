using SpikeCheckoutKataApi.Web.Adapters.Data;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public class BasketTemplate : IBasketTemplate
	{
		private const string Template = "http://spike-checkout-kata-api.local/baskets/{0}";

		public string CompleteWith(int basketId)
		{
			return string.Format(Template, basketId);
		}
	}
}