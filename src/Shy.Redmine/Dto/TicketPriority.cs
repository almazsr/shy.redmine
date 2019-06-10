using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketPriority
	{
	    [JsonProperty("id")]
	    public long Id { get; set; }

	    [JsonProperty("name")]
	    public string Name { get; set; }

        [JsonProperty("is_default", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IsDefault { get; set; }
	}
}