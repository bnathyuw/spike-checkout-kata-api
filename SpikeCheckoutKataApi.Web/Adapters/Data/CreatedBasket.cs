namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public interface IBasketTemplate
	{
		string CompleteWith(int basketId);
	}

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