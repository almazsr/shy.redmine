using System.Threading.Tasks;
using Shy.Redmine.Dto;

namespace Shy.Redmine
{
	public interface IRedmineProjectCache
	{
		Task InitializeAsync();
		TicketCategory[] Categories { get; }
		TicketType[] Types { get; }
		TicketPriority[] Priorities { get; }
		TicketStatus[] Statuses { get; }
		Version[] Versions { get; }
		Membership[] Memberships { get; }
	}
}