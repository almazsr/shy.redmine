namespace Shy.Redmine.Dto
{
	public interface IRedminePaginatedResponse<T> : IRedminePaginated, IRedmineResponse<T[]>
	{

	}
}