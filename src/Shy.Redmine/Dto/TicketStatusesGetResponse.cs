using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketStatusesGetResponse : IRedmineResponse<TicketStatus[]>
	{
		[JsonProperty("issue_statuses")]
		public TicketStatus[] Data { get; set; }
	}
}