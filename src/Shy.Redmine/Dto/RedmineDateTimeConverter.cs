using Newtonsoft.Json.Converters;

namespace Shy.Redmine.Dto
{
	internal class RedmineDateTimeConverter : IsoDateTimeConverter
	{
		public RedmineDateTimeConverter()
		{
			DateTimeFormat = "yyyy-MM-dd";
		}
	}
}