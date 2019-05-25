using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketPrioritiesGetResponse
	{
		[JsonProperty("issue_priorities")]
		public TicketPriority[] Data { get; set; }
	}
}