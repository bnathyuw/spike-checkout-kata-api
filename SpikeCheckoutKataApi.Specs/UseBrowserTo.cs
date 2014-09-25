using System;
using System.Threading.Tasks;

namespace SpikeCheckoutKataApi.Specs
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
	}
}