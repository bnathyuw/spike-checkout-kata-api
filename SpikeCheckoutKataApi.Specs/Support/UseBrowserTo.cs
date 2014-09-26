using System;
using System.Threading.Tasks;

namespace SpikeCheckoutKataApi.Specs.Support
{
	public static class UseBrowserTo
	{
		private const string ApiBaseUriString = "http://spike-checkout-kata-api.local/";

		public static async Task CreateBasket(this Browser browser)
		{
			var uri = new Uri(ApiBaseUriString + "baskets");
			var entity = new {Shopper = "Bloggs"};
			await browser.Post(uri, entity);
		}

		public static async Task RetrieveBasket(this Browser browser, Uri basketUri)
		{
			await browser.Get(basketUri);
		}

		public static async Task GetRoot(this Browser browser)
		{
			await browser.Get(new Uri(ApiBaseUriString));
		}

		public static async Task AddToBasket(this Browser browser, Uri basketUri, char item)
		{
			var entity = new {Code = item};
			await browser.Post(basketUri, entity);
		}

		public static async Task AddToBasket(this Browser browser, Uri basketUri, string item)
		{
			var entity = new { Code = item };
			await browser.Post(basketUri, entity);
		}
	}
}