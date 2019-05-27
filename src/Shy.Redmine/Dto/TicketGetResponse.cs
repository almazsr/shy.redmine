using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketGetResponse : IRedmineResponse<Ticket>
	{
		[JsonProperty("issue")]
		public Ticket Data { get; set; }
	}
}