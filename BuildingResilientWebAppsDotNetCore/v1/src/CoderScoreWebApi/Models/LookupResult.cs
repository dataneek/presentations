namespace CoderScoreWebApi.Models 
{
    using System;
    using Models;

    public class LookupResult
    {
        public LookupResult() { }

        public LookupResult(FakeScoreResult t)
        {
            DisplayName = t.DisplayName;
            Username = t.Username;
            EngagementIndex = t.ProprietaryScore * 100;
        }

        public string DisplayName { get; set; }
        public string Username { get; set; }
        public long EngagementIndex { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}