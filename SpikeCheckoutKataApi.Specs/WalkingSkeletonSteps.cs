using System.Net;
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
		public void WhenIHitTheApi()
		{
			_browser.GetRoot().Wait();
		}

		[Then(@"I get an OK response")]
		public void ThenIGetAnOkResponse()
		{
			Assert.That(_browser.StatusCode, Is.EqualTo(HttpStatusCode.OK));
		}
	}
}
