using SpikeCheckoutKataApi.Web.Behaviour.CreateBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class CreatedBasket
	{
		private readonly int _basketId;

		public CreatedBasket(int basketId)
		{
			_basketId = basketId;
		}

		public string CompleteTemplate(IBasketTemplate basketTemplate)
		{
			return basketTemplate.CompleteWith(_basketId);
		}
	}
}