using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AsyncEnumerable;
using Xunit;

namespace Shy.Redmine.Tests
{
	public class RedmineClientTests
	{
		public const string ApiKey = "edc3b9a9ff66020c941c990a8c06965f175f6b15";
		public const string RootPath = "https://133.162.101.18:4433/redmine";

		[Fact]
		public async Task EnumerateTickets_CallWithoutParameters_DoesWork()
		{
			using(var httpClientHandler = new HttpClientHandler())
			{
				httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

				var redmineClient = new RedmineClient(RootPath, ApiKey, httpClientHandler);
				var ticketsEnumerable = redmineClient.EnumerateTicketsAsync();
				var tickets = await ticketsEnumerable.Take(1000).ToList();
			}
		}
	}
}
