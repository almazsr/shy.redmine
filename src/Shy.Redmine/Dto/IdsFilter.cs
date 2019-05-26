using System.Linq;

namespace Shy.Redmine.Dto
{
	public class MultipleValueFilter
	{
		public string Delimiter { get; }
		public object[] Values { get; }

		public MultipleValueFilter(string delimiter, params object[] values)
		{
			Delimiter = delimiter;
			Values = values;
		}

		public override string ToString()
		{
			if(Values?.Length == 0)
			{
				return string.Empty;
			}
			return string.Join(Delimiter, Values);
		}
	}

	public class IdsFilter : MultipleValueFilter
	{
		public IdsFilter(params object[] values) : base("|", values)
		{
		}
	}
	public class IncludeFilter : MultipleValueFilter
	{
		public IncludeFilter(params object[] values) : base(",", values)
		{
		}
	}
}