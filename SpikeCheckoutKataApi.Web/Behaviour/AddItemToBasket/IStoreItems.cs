using SpikeCheckoutKataApi.Web.Adapters.Data;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public interface IStoreItems
	{
		CreatedItem StoreItem(Request request);
	}
}