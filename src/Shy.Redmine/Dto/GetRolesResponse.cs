using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class GetRolesResponse
	{
		[JsonProperty("roles")]
		public Role[] Data { get; set; }
	}
}