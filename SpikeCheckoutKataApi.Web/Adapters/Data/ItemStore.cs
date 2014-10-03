using System.Collections.Generic;
using System.Linq;
using SpikeCheckoutKataApi.Web.Behaviour.AddItemToBasket;
using SpikeCheckoutKataApi.Web.Behaviour.DeleteItemFromBasket;
using SpikeCheckoutKataApi.Web.Behaviour.RetrieveBasket;

namespace SpikeCheckoutKataApi.Web.Adapters.Data
{
	public class ItemStore : IStoreItems, IDeleteItemsFromBaskets, IFindItemsByBasket
	{
		private static readonly List<ItemInStore> Items = new List<ItemInStore>();
		private static int _currentId;

		public IEnumerable<char> GetMatching(ISpecifyBasketToRetrieve basket)
		{
			return Items.Where(item => item.Matches((itemId, basketId) => basket.Matches(basketId)))
			            .Select(CreateItemInBasket);
		}

		public ICompleteItemTemplates StoreItem(ISpecifyItemToStore request)
		{
			var itemInStore = request.Create(CreateItemInStore);
			Items.Add(itemInStore);
			return itemInStore.Create(CreateStoredItem);
		}

		private static int GetNextId()
		{
			return ++_currentId;
		}

		private static char CreateItemInBasket(ItemInStore item)
		{
			return item.Create((id, basketId, code) => code);
		}

		private static ItemInStore CreateItemInStore(char code, int basketId)
		{
			return new ItemInStore(code, basketId, GetNextId());
		}

		private static CreatedItem CreateStoredItem(int id, int basket, char code)
		{
			return new CreatedItem(id, basket);
		}

		public void DeleteItem(ISpecifyItemToDelete request)
		{
			var item = Items.Single(i => i.Matches(request.Matches));
			Items.Remove(item);
		}
	}
}