using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public static class RedmineApiClientExtensions
	{
		public static Task<IList<Project>> GetAllProjectsAsync(this IRedmineClient apiClient, int offset = 0, int count = int.MaxValue)
		{
			return RedminePaginationHelper.GetAllAsync<Project>(async (o, l) => await apiClient.GetProjectsAsync(o, l), offset,
				count);
		}

		public static Task<IList<Ticket>> GetAllTicketsAsync(this IRedmineClient apiClient, long[] ids = null, long[] statusIds = null, long[] trackerIds = null, long[] assignedToIds = null,
			string subject = null, DateTime? updatedOnFrom = null, DateTime? updatedOnTo = null, string[] include = null, int offset = 0, int count = int.MaxValue)
		{
            return RedminePaginationHelper.GetAllAsync<Ticket>(
				async (o, l) => await apiClient.GetTicketsAsync(ids, statusIds,
					trackerIds, assignedToIds, subject, updatedOnFrom, updatedOnTo, include, o, l), offset,
				count);
		}

		public static Task<IList<Membership>> GetAllMembershipsAsync(this IRedmineClient apiClient, long projectId, int offset = 0,
			int count = int.MaxValue)
		{
			return RedminePaginationHelper.GetAllAsync<Membership>(
				async (o, l) => await apiClient.GetProjectMembershipsAsync(projectId, o, l), offset,
				count);
		}
	}
}