using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class WatcherAddRequest
	{
		[JsonProperty("user_id")]
		public string UserId { get; set; }
	}
}