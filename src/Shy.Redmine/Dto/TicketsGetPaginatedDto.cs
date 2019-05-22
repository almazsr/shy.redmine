namespace Shy.Redmine.Dto
{
	public interface IPaginated<T> : IPaginated
	{
		T[] Data { get; set; }
	}
}