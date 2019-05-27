using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketTypesGetResponse : IRedmineResponse<TicketType[]>
	{
		[JsonProperty("trackers")]
		public TicketType[] Data { get; set; }
	}
}