using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketGetResponse
	{
		[JsonProperty("issue")]
		public Ticket Ticket { get; set; }
	}
}