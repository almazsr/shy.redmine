using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class RelationsGetDto
	{
		[JsonProperty("relations")]
		public Relation[] Relations { get; set; }
	}
}