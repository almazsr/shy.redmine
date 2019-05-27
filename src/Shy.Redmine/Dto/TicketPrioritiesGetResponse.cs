using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketPrioritiesGetResponse : IRedmineResponse<TicketPriority[]>
	{
		[JsonProperty("issue_priorities")]
		public TicketPriority[] Data { get; set; }
	}
}