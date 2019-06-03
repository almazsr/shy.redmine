using System;

namespace Shy.Redmine
{
    public class RedmineConfiguration
    {
        public RedmineConfiguration()
        {
            LastRefreshedAt = new DateTime(2000, 1, 1);
        }

        public Uri BaseUri { get; set; }
        public string ApiKey { get; set; }
        public int ProjectId { get; set; }
        public DateTime LastRefreshedAt { get; set; }
    }
}