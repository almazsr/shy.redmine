using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class TicketCategory
	{
	    [JsonProperty("id")]
	    public long Id { get; set; }

	    [JsonProperty("name")]
	    public string Name { get; set; }
    }
}