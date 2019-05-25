using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketPriority : IdName
	{
		[JsonProperty("is_default", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsDefault { get; set; }
	}
}