using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketUpdateRequest
	{
		[JsonProperty("issue")]
		public TicketUpdate Data { get; set; }
	}
}