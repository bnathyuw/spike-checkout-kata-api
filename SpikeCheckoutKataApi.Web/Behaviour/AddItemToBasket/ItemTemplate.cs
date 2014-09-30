using SpikeCheckoutKataApi.Web.Adapters.Data;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class ItemTemplate : IItemTemplate
	{
		private const string Template = "http://spike-checkout-kata-api.local/baskets/{0}/items/{1}";

		public string CompleteWith(int basketId, int itemId)
		{
			return string.Format(Template, basketId, itemId);
		}
	}
}