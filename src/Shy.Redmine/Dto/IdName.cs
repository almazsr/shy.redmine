using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class IdName
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}