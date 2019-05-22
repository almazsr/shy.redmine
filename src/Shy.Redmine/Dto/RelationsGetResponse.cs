using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationsGetResponse
	{
		[JsonProperty("relations")]
		public Relation[] Relations { get; set; }
	}
}