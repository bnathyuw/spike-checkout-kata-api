using SpikeCheckoutKataApi.Web.Adapters.Http;

namespace SpikeCheckoutKataApi.Web.Behaviour.NotFound
{
	internal class HandlerFactory:IHandlerFactory
	{
		public IHandler CreateHandler()
		{
			return new Handler();
		}

		public bool Matches(string requestType, string url)
		{
			return true;
		}
	}
}