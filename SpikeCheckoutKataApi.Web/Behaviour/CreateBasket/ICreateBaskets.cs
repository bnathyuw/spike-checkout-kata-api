using SpikeCheckoutKataApi.Web.Adapters.Data;

namespace SpikeCheckoutKataApi.Web.Behaviour.CreateBasket
{
	public interface ICreateBaskets
	{
		CreatedBasket CreateBasket(Request request);
	}
}