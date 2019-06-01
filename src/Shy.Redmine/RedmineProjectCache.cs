using System.Linq;
using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public class RedmineProjectCache : IRedmineProjectCache
	{
		public int ProjectId { get; }
		private readonly IRedmineApiClient _apiClient;

		public RedmineProjectCache(IRedmineApiClient apiClient, int projectId)
		{
			ProjectId = projectId;
			_apiClient = apiClient;
		}

		public async Task InitializeAsync()
		{
			Categories = (await _apiClient.GetTicketCategoriesAsync(ProjectId)).Data;
			Types = (await _apiClient.GetTicketTypesAsync()).Data;
			Priorities = (await _apiClient.GetTicketPrioritiesAsync(ProjectId)).Data;
			Statuses = (await _apiClient.GetTicketStatusesAsync()).Data;
			Versions = (await _apiClient.GetProjectVersionsAsync(ProjectId)).Data;
			Memberships = (await _apiClient.GetAllMembershipsAsync(ProjectId)).ToArray();
		}

		public TicketCategory[] Categories { get; private set; }
		public TicketType[] Types { get; private set; }
		public TicketPriority[] Priorities { get; private set; }
		public TicketStatus[] Statuses { get; private set; }
		public Version[] Versions { get; private set; }
		public Membership[] Memberships { get; private set; }
	}
}