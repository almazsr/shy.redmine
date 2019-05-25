using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketTypesGetResponse
	{
		[JsonProperty("trackers")]
		public TicketType[] Data { get; set; }
	}
}