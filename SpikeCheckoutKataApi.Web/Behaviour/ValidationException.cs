using System;

namespace SpikeCheckoutKataApi.Web.Behaviour
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