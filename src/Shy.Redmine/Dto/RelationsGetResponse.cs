using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationsGetResponse : IRedmineResponse<Relation[]>
	{
		[JsonProperty("relations")]
		public Relation[] Data { get; set; }
	}
}