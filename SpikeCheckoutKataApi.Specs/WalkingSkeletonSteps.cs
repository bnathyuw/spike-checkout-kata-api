using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpikeCheckoutKataApi.Specs
{
	[Binding]
	public class WalkingSkeletonSteps
	{
		private readonly Browser _browser;

		public WalkingSkeletonSteps(Browser browser)
		{
			_browser = browser;
		}

		[When(@"I hit the API")]
		public async Task WhenIHitTheApi()
		{
			await _browser.GetRoot();
		}

		[Then(@"I get an OK response")]
		public async Task ThenIGetAnOkResponse()
		{
			Assert.That(_browser.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}
