using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class ProjectUpdateRequest
	{
		[JsonProperty("project")]
		public ProjectUpdate Data { get; set; }
	}
}