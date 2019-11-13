using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
    public class RedmineClient : IRedmineClient
    {
        protected Uri BaseUri { get; }
        protected string ApiKey { get; }

        private const string Pipe = "|";
        private const string Comma = ",";
        private const string DateFormat = "yyyy-MM-dd";

        private readonly HttpClient _httpClient;

        public RedmineClient(HttpClient httpClient, Uri baseUri, string apiKey)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
            _httpClient = httpClient;
        }

        internal class Nothing
        {

        }

        private NameValueCollection CreateQuery()
        {
            return HttpUtility.ParseQueryString(string.Empty);
        }

        public virtual async Task<TResponse> SendAsync<TResponse>(HttpMethod httpMethod, string path, NameValueCollection query = null, object request = null)
        {
            var uri = new Uri(BaseUri, path);
            var uriBuilder = new UriBuilder(uri);
            query = query ?? CreateQuery();
            query["key"] = ApiKey;
            uriBuilder.Query = query.ToString();
            uri = uriBuilder.Uri;
            var requestMessage = new HttpRequestMessage(httpMethod, uri);
            if (request != null)
            {
                var requestJson = JsonConvert.SerializeObject(request);
                requestMessage.Content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            }

            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            Trace.TraceInformation($"Response {responseMessage.StatusCode} received for {uri}");

            var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(responseJson);
            }

            if (typeof(TResponse) == typeof(Nothing))
            {
                return default(TResponse);
            }
            
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

        public Task<TicketsGetPaginatedResponse> GetTicketsAsync(long[] ids = null, long[] statusIds = null, long[] trackerIds = null,
            long[] assignedToIds = null, string subject = null, DateTime? updatedOnFrom = null,
            DateTime? updatedOnTo = null, string[] include = null, int? offset = null, int? limit = null)
        {
            string updatedOn = null;

            if (updatedOnFrom != null && updatedOnTo != null)
            {
                updatedOn = $"><{updatedOnFrom:yyyy-MM-dd}|{updatedOnTo:yyyy-MM-dd}";
            }
            else if (updatedOnFrom != null)
            {
                updatedOn = $">={updatedOnFrom:yyyy-MM-dd}";
            }
            else if (updatedOnTo != null)
            {
                updatedOn = $"<={updatedOnTo:yyyy-MM-dd}";
            }
            var query = CreateQuery()
                .WithParamArray("issue_id", ids, Comma)
                .WithParamArray("status_id", statusIds, Pipe)
                .WithParamArray("tracker_id", trackerIds, Pipe)
                .WithParamArray("assigned_to_id", assignedToIds, Pipe)
                .WithParam("subject", subject != null ? $"~{subject}" : null)
                .WithParam("updated_on", updatedOn)
                .WithParamArray("include", include, Comma)
                .WithParam("offset", offset)
                .WithParam("limit", limit);
            
            return SendAsync<TicketsGetPaginatedResponse>(HttpMethod.Get, "issues.json", query);
        }

        public Task<TicketGetResponse> GetTicketAsync(long id, string[] include = null)
        {
            var query = CreateQuery()
                .WithParamArray("include", include, Comma);

            return SendAsync<TicketGetResponse>(HttpMethod.Get, $"issues/{id}.json", query);
        }

        public Task CreateTicketAsync(TicketUpdateRequest request)
        {
            return SendAsync<TicketGetResponse>(HttpMethod.Post, "issues.json", request: request);
        }

        public Task UpdateTicketAsync(long id, TicketUpdateRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Put, $"issues/{id}.json", request: request);
        }

        public Task DeleteTicketAsync(long id)
        {
            return SendAsync<Nothing>(HttpMethod.Delete, $"issues/{id}.json");
        }

        public Task<UserGetResponse> GetUserAsync(long id)
        {
            return SendAsync<UserGetResponse>(HttpMethod.Get, $"users/{id}.json");
        }

        public Task<TicketStatusesGetResponse> GetTicketStatusesAsync()
        {
            return SendAsync<TicketStatusesGetResponse>(HttpMethod.Get, "issue_statuses.json");
        }

        public Task<TicketTypesGetResponse> GetTicketTypesAsync()
        {
            return SendAsync<TicketTypesGetResponse>(HttpMethod.Get, "trackers.json");
        }

        public Task<TicketCategoriesGetResponse> GetTicketCategoriesAsync(long projectId)
        {
            return SendAsync<TicketCategoriesGetResponse>(HttpMethod.Get, $"projects/{projectId}/issue_categories.json");
        }

        public Task<TicketPrioritiesGetResponse> GetTicketPrioritiesAsync()
        {
            return SendAsync<TicketPrioritiesGetResponse>(HttpMethod.Get, "enumerations/issue_priorities.json");
        }

        public Task<VersionsGetResponse> GetProjectVersionsAsync(long projectId)
        {
            return SendAsync<VersionsGetResponse>(HttpMethod.Get, $"projects/{projectId}/versions.json");
        }

        public Task AddTicketWatcherAsync(long ticketId, WatcherAddRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Post, $"issues/{ticketId}/watchers.json", request: request);
        }

        public Task RemoveTicketWatcherAsync(long ticketId, long watcherId)
        {
            return SendAsync<Nothing>(HttpMethod.Delete, $"issues/{ticketId}/watchers/{watcherId}.json");
        }
        
        public Task<RelationsGetResponse> GetTicketRelationsAsync(long ticketId)
        {
            return SendAsync<RelationsGetResponse>(HttpMethod.Get, $"issues/{ticketId}/relations.json");
        }

        public Task<RelationGetResponse> GetRelationAsync(long id)
        {
            return SendAsync<RelationGetResponse>(HttpMethod.Get, $"relations/{id}.json");
        }

        public Task AddTicketRelationAsync(long ticketId, RelationCreateRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Post, $"issues/{ticketId}/relations.json", request: request);
        }

        public Task DeleteRelationAsync(long id)
        {
            return SendAsync<Nothing>(HttpMethod.Delete, $"relations/{id}.json");
        }
        
        public Task<ProjectsGetPaginatedResponse> GetProjectsAsync(int? offset = null, int? limit = null)
        {
            var query = CreateQuery()
                .WithParam("offset", offset)
                .WithParam("limit", limit);

            return SendAsync<ProjectsGetPaginatedResponse>(HttpMethod.Get, "projects.json", query);
        }
        
        public Task<ProjectGetResponse> GetProjectAsync(long id)
        {
            return SendAsync<ProjectGetResponse>(HttpMethod.Get, $"projects/{id}.json");
        }

        public Task CreateProjectAsync(ProjectUpdateRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Post, "projects.json", request: request);
        }

        public Task UpdateProjectAsync(long id, ProjectUpdateRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Put, $"projects/{id}.json", request: request);
        }
        
        public Task DeleteProjectAsync(long id)
        {
            return SendAsync<Nothing>(HttpMethod.Delete, $"projects/{id}.json");
        }

        public Task<MembershipsGetPaginatedResponse> GetProjectMembershipsAsync(long projectId, int? offset = null, int? limit = null)
        {
            var query = CreateQuery()
                .WithParam("offset", offset)
                .WithParam("limit", limit);

            return SendAsync<MembershipsGetPaginatedResponse>(HttpMethod.Get, $"projects/{projectId}/memberships.json", query);
        }

        public Task<MembershipGetResponse> GetMembershipAsync(long id)
        {
            return SendAsync<MembershipGetResponse>(HttpMethod.Get, $"memberships/{id}.json");
        }

        public Task CreateProjectMembershipAsync(long projectId, MembershipCreateRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Post, $"projects/{projectId}/memberships.json", request: request);
        }

        public Task UpdateMembershipAsync(long id, MembershipUpdateRequest request)
        {
            return SendAsync<Nothing>(HttpMethod.Put, $"memberships/{id}.json", request: request);
        }

        public Task DeleteMembershipAsync(long id)
        {
            return SendAsync<Nothing>(HttpMethod.Delete, $"memberships/{id}.json");
        }
    }
}