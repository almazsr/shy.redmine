using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class VersionsGetResponse
	{
		[JsonProperty("versions")]
		public Version[] Data { get; set; }

		[JsonProperty("total_count")]
		public long TotalCount { get; set; }
	}
}