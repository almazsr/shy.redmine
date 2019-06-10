using System;
using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
    public interface IRedmineClient
    {
        Task AddTicketWatcherAsync(int ticketId, WatcherAddRequest request);
        Task CreateProjectAsync(ProjectUpdateRequest request);
        Task CreateProjectMembershipAsync(int projectId, MembershipCreateRequest request);
        Task CreateRelationAsync(RelationCreateRequest request);
        Task CreateTicketAsync(TicketUpdateRequest request);
        Task DeleteMembershipAsync(int id);
        Task DeleteProjectAsync(int id);
        Task DeleteRelationAsync(int id);
        Task DeleteTicketAsync(int id);
        Task<MembershipGetResponse> GetMembershipAsync(int id);
        Task<ProjectGetResponse> GetProjectAsync(long id);
        Task<MembershipsGetPaginatedResponse> GetProjectMembershipsAsync(long projectId, int? offset = null, int? limit = null);
        Task<ProjectsGetPaginatedResponse> GetProjectsAsync(int? offset = null, int? limit = null);
        Task<VersionsGetResponse> GetProjectVersionsAsync(long projectId);
        Task<RelationGetResponse> GetRelationAsync(int id);
        Task<TicketGetResponse> GetTicketAsync(long id, string[] include = null);
        Task<TicketCategoriesGetResponse> GetTicketCategoriesAsync(long projectId);
        Task<TicketPrioritiesGetResponse> GetTicketPrioritiesAsync();
        Task<RelationsGetResponse> GetTicketRelationsAsync(int ticketId);
        Task<TicketsGetPaginatedResponse> GetTicketsAsync(long[] ids = null, long[] statusIds = null, long[] trackerIds = null, long[] assignedToIds = null, string subject = null, DateTime? updatedOnFrom = null, DateTime? updatedOnTo = null, string[] include = null, int? offset = null, int? limit = null);
        Task<TicketStatusesGetResponse> GetTicketStatusesAsync();
        Task<TicketTypesGetResponse> GetTicketTypesAsync();
        Task<UserGetResponse> GetUserAsync(long id);
        Task RemoveTicketWatcherAsync(int ticketId, int watcherId);
        Task UpdateMembershipAsync(int id, MembershipUpdateRequest request);
        Task UpdateProjectAsync(ProjectUpdateRequest request);
        Task UpdateTicketAsync(TicketUpdateRequest request);
    }
}