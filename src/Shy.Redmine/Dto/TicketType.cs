using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketType : IdName
	{
		[JsonProperty("default_status")]
		public IdName DefaultStatus { get; set; }
	}
}