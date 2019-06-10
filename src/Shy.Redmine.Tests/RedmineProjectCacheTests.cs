using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shy.Redmine.Tests
{
	using static RedmineClientSettings;

	public class RedmineProjectCacheTests
	{
		private readonly IRedmineClient _client;

		public RedmineProjectCacheTests()
		{
			var httpClientHandler = new HttpClientHandler()
			{
				ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
			};
		    var httpClient = new HttpClient(httpClientHandler);
		    _client = new RedmineClient(httpClient, BaseUri, ApiKey);
		}
	}
}
