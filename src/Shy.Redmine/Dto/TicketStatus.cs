using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketStatus
	{
	    [JsonProperty("id")]
	    public long Id { get; set; }

	    [JsonProperty("name")]
	    public string Name { get; set; }

        [JsonProperty("is_closed", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsClosed { get; set; }
	}
}