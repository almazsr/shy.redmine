using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationCreateRequest
	{
		[JsonProperty("relation")]
		public RelationCreate Data { get; set; }
	}
}