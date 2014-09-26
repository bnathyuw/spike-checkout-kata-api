﻿using SpikeCheckoutKataApi.Web.Data;

namespace SpikeCheckoutKataApi.Web.AddItemToBasket
{
	public struct ItemRequest
	{
		private readonly char _code;
		private readonly int _basketId;

		public ItemRequest(char code, int basketId)
		{
			_code = code;
			_basketId = basketId;
		}

		public ItemInStore ToItemInStore()
		{
			return new ItemInStore(_code, _basketId);
		}
	}
}