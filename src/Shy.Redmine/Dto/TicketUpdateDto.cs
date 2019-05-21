using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketUpdateDto
	{
		[JsonProperty("issue")]
		public TicketUpdate Ticket { get; set; }
	}
}