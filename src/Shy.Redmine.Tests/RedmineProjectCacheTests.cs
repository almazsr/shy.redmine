using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using Shy.Redmine.Dto;
using Xunit;

namespace Shy.Redmine.Tests
{
	using static RedmineClientSettings;

	public class RedmineProjectCacheTests
	{
		private readonly IRedmineApiClient _apiClient;

		public RedmineProjectCacheTests()
		{
			var httpClientHandler = new RedmineHttpClientHandler(ApiKey)
			{
				ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
			};
			var httpClient = new HttpClient(httpClientHandler)
			{
				BaseAddress = BaseUri
			};
			_apiClient = RestService.For<IRedmineApiClient>(httpClient);
		}

		[Fact]
		public async Task InitializeAsync_Call_FillsProjectCacheWithData()
		{
			var projectCache = new RedmineProjectCache(_apiClient, 1);
			await projectCache.InitializeAsync();
			Assert.NotNull(projectCache.Categories);
			Assert.NotNull(projectCache.Versions);
			Assert.NotNull(projectCache.Priorities);
			Assert.NotNull(projectCache.Statuses);
			Assert.NotNull(projectCache.Types);
			Assert.NotNull(projectCache.Memberships);
		}
	}
}
