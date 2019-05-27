namespace Shy.Redmine.Dto
{
	public interface IRedmineResponse<T>
	{
		T Data { get; set; }
	}
}