namespace SpikeCheckoutKataApi.Web.Http.AddItemToBasket
{
	public class Error
	{
		public string Message { get; set; }

		public Error(string message)
		{
			Message = message;
		}
	}
}