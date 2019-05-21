using System.Linq;

namespace Shy.Redmine.Dto
{
    public class IdsFilter
    {
        public long[] Ids { get; }

        public IdsFilter(params long[] ids)
        {
            Ids = ids;
        }

        public bool Contains(long id) => Ids.Contains(id);
        public bool Contains(string id) => Ids.Select(i=>i.ToString()).Contains(id);

        public override string ToString()
        {
            if (Ids?.Length == 0)
            {
                return string.Empty;
            }
            return string.Join("|", Ids);
        }
    }
}