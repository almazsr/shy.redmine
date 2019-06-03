using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Refit;
using Shy.Redmine.Dto;
using Version = Shy.Redmine.Dto.Version;

namespace Shy.Redmine
{
    public class RedmineProjectCache : IRedmineProjectCache
    {
        public static readonly TimeSpan DefaultRefreshInterval = TimeSpan.FromDays(3);

        public bool ShouldIgnoreServerSslCertificate { get; set; } = false;
        public TimeSpan RefreshInterval { get; set; } = DefaultRefreshInterval;

        private IRedmineApiClient _apiClient;

        public async Task ApplyConfigurationAsync(RedmineConfiguration configuration)
        {
            using (var db = new RedmineProjectDbContext())
            {
                var configurations = await db.Configurations.ToArrayAsync();
                if (configurations.Any())
                {
                    db.Configurations.RemoveRange(configurations);
                }
                await db.Configurations.AddRangeAsync(configuration);
                await db.SaveChangesAsync();
            }

            Configuration = configuration;

            var redmineHttpClientHandler = new RedmineHttpClientHandler(Configuration.ApiKey);
            if (ShouldIgnoreServerSslCertificate)
            {
                redmineHttpClientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
            }
            var httpClient = new HttpClient(redmineHttpClientHandler) { BaseAddress = Configuration.BaseUri };
            _apiClient = RestService.For<IRedmineApiClient>(httpClient);
        }

        public async Task RefreshAsync()
        {
            var projectId = Configuration.ProjectId;

            var categories = (await _apiClient.GetTicketCategoriesAsync(projectId)).Data;
	        var types = (await _apiClient.GetTicketTypesAsync()).Data;
	        var priorities = (await _apiClient.GetTicketPrioritiesAsync(projectId)).Data;
	        var statuses = (await _apiClient.GetTicketStatusesAsync()).Data;
	        var versions = (await _apiClient.GetProjectVersionsAsync(projectId)).Data;
	        var memberships = (await _apiClient.GetAllMembershipsAsync(projectId)).ToArray();

	        using (var db = new RedmineProjectDbContext())
	        {
	            await db.Database.EnsureDeletedAsync();
	            await db.Database.EnsureCreatedAsync();
	        }

            using (var db = new RedmineProjectDbContext())
            {
                await db.Categories.AddRangeAsync(categories);
                await db.Types.AddRangeAsync(types);
                await db.Priorities.AddRangeAsync(priorities);
                await db.Statuses.AddRangeAsync(statuses);
                await db.Versions.AddRangeAsync(versions);
                await db.Memberships.AddRangeAsync(memberships);
                await db.SaveChangesAsync();
            }
	    }

        public RedmineConfiguration Configuration { get; private set; }

        public async Task LoadAsync()
	    {
	        using (var db = new RedmineProjectDbContext())
	        {
	            Configuration = await db.Configurations.FirstOrDefaultAsync();
	        }

	        if (DateTime.Now - Configuration.LastRefreshedAt > RefreshInterval)
	        {
	            await RefreshAsync();
	        }

	        using (var db = new RedmineProjectDbContext())
	        {
	            Categories = await db.Categories.ToArrayAsync();
	            Types = await db.Types.ToArrayAsync();
                Priorities = await db.Priorities.ToArrayAsync();
                Statuses = await db.Statuses.ToArrayAsync();
                Versions = await db.Versions.ToArrayAsync();
                Memberships = await db.Memberships.ToArrayAsync();
            }
        }

	    public TicketCategory[] Categories { get; private set; }
		public TicketType[] Types { get; private set; }
		public TicketPriority[] Priorities { get; private set; }
		public TicketStatus[] Statuses { get; private set; }
		public Version[] Versions { get; private set; }
		public Membership[] Memberships { get; private set; }
	}
}