using System.Collections.Specialized;

namespace Shy.Redmine
{
    public static class NameValueCollectionExtensions
    {
        public static NameValueCollection WithParam<T>(this NameValueCollection query, string name, T value)
        {
            if (value != null)
            {
                query[name] = value.ToString();
            }

            return query;
        }

        public static NameValueCollection WithParamArray<T>(this NameValueCollection query, string name, T[] value, string separator)
        {
            if (value != null)
            {
                query[name] = string.Join(separator, value);
            }

            return query;
        }
    }
}
