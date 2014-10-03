using System;

namespace SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket
{
	public class Request : ISpecifyItemToStore
	{
		private readonly char _code;
		private readonly int _basketId;

		public Request(char code, int basketId)
		{
			_code = code;
			_basketId = basketId;
		}

		public T Create<T>(Func<char, int, T> create)
		{
			return create(_code, _basketId);
		}
	}
}