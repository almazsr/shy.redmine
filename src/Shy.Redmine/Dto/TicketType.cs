using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketType
	{
	    [JsonProperty("id")]
	    public long Id { get; set; }

	    [JsonProperty("name")]
	    public string Name { get; set; }

        [JsonProperty("default_status")]
		public IdName DefaultStatus { get; set; }
	}
}