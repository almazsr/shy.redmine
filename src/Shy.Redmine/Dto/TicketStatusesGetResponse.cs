using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketStatusesGetResponse
	{
		[JsonProperty("issue_statuses")]
		public TicketStatus[] Data { get; set; }
	}
}