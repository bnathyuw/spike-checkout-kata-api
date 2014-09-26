using System;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public class ValidationException : Exception
	{
		public ValidationException(string message)
			: base(message)
		{

		}

		public Error ToError()
		{
			return new Error(Message);
		}
	}
}