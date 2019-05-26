using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AsyncEnumerable;
using Shy.Redmine.Dto;
using Xunit;

namespace Shy.Redmine.Tests
{
	using static RedmineClientSettings;

	public class RedmineClientTests
	{
		private HttpClientHandler _httpClientHandler;

		public RedmineClientTests()
		{
			_httpClientHandler = new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
			};
		}

		[Theory]
		[InlineData(0), InlineData(25), InlineData(100), InlineData(200)]
		public async Task GetAllTickets_CallWithCountIsN_ReturnsNTickets(int count)
		{
			var redmineClient = new RedmineClient(BaseUri, ApiKey, _httpClientHandler);
			var tickets = await redmineClient.GetAllTicketsAsync(count: count);
			Assert.Equal(count, tickets.Count);
		}

		[Fact]
		public async Task GetAllTickets_CallWithSomeParameters_ReturnsSomeTickets()
		{
			var redmineClient = new RedmineClient(BaseUri, ApiKey, _httpClientHandler);
			var tickets = await redmineClient.GetAllTicketsAsync(new IdsFilter(9), new IdsFilter(5));
			Assert.True(tickets.Count > 0);
		}


		[Theory]
		[InlineData(10000), InlineData(1000), InlineData(20000)]
		public async Task GetTicket_CallWithN_ReturnsTicketWithIdN(int id)
		{
			var redmineClient = new RedmineClient(BaseUri, ApiKey, _httpClientHandler);
			var ticket = await redmineClient.GetTicketAsync(id);
			Assert.Equal(id, ticket.Id);
		}

		[Fact]
		public async Task GetProjects_Call_ReturnsSomeProjects()
		{
			var redmineClient = new RedmineClient(BaseUri, ApiKey, _httpClientHandler);
			var projects = await redmineClient.GetProjectsAsync();
			Assert.True(projects.Length > 0);
		}
	}
}
