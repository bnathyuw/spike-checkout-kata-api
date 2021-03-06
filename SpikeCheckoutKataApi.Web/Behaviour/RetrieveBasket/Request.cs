﻿namespace SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket
{
	public class Request : ISpecifyBasketToRetrieve
	{
		private readonly int _basketId;

		public Request(int basketId)
		{
			_basketId = basketId;
		}

		public bool Matches(int basketId)
		{
			return basketId == _basketId;
		}
	}
}