﻿using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class BasketInStore
	{
		private readonly int _id;
		private string _shopper;

		public BasketInStore(int id, string shopper)
		{
			_id = id;
			_shopper = shopper;
		}

		public BasketResponse ToResponseWithContents(IEnumerable<char> contents)
		{
			return new BasketResponse(contents.ToArray(), _shopper);
		}

		public bool Matching(Request request)
		{
			return request.Matches(_id);
		}
	}
}