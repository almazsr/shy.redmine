using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class GetRolesResponse : IRedmineResponse<Role[]>
	{
		[JsonProperty("roles")]
		public Role[] Data { get; set; }
	}
}