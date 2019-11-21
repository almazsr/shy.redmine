using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class ChildTicket
    {
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("tracker")]
		public IdName Tracker { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

        [JsonProperty("children")]
        public ChildTicket[] Children { get; set; }
    }
}