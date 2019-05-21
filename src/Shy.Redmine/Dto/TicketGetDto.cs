using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketGetDto
	{
		[JsonProperty("issue")]
		public TicketGet Ticket { get; set; }
	}
}