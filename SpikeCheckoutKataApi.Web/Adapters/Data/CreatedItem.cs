﻿using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class CreatedItem : ICompleteItemTemplates
	{
		private readonly int _itemId;
		private readonly int _basketId;

		public CreatedItem(int itemId, int basketId)
		{
			_itemId = itemId;
			_basketId = basketId;
		}

		public string CompleteTemplate(IItemTemplate itemTemplate)
		{
			return itemTemplate.CompleteWith(_basketId, _itemId);
		}
	}
}