using Newtonsoft.Json;

namespace Shy.Redmine.Dto
{
	public class MembershipUpdate
	{
		[JsonProperty("role_ids")]
		public long[] RoleIds { get; set; }
	}
}