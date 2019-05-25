using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketStatus : IdName
	{
		[JsonProperty("is_closed", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsClosed { get; set; }
	}
}