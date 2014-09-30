using System;
using System.Globalization;
using System.Threading.Tasks;

namespace SpikeCheckoutKataApi.Specs.Support
{
	public static class UseBrowserTo
	{
		private const string ApiBaseUriString = "http://spike-checkout-kata-api.local/";

		public static async Task CreateBasket(this Browser browser, string shopperName)
		{
			var uri = new Uri(ApiBaseUriString + "baskets");
			var entity = new {Shopper = shopperName};
			await browser.Post(uri, entity);
		}

		public static async Task RetrieveBasket(this Browser browser, Uri basketUri)
		{
			await browser.Get(basketUri);
		}

		public static async Task AddToBasket(this Browser browser, Uri basketUri, char item)
		{
			await browser.AddToBasket(basketUri, item.ToString(CultureInfo.InvariantCulture));
		}

		public static async Task AddToBasket(this Browser browser, Uri basketUri, string item)
		{
			var entity = new { Code = item };
			var itemsUri = new Uri(basketUri.OriginalString + "/items");
			await browser.Post(itemsUri, entity);
		}

		public static async Task RemoveFromBasket(this Browser browser, Uri itemUri)
		{
			await browser.Delete(itemUri);
		}
	}
}