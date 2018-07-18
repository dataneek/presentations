namespace CoderScoreWebApi.Models 
{
    using System;
    using Newtonsoft.Json;

    public class FakeScoreResult
    {
        public FakeScoreResult() { }
        public FakeScoreResult(GithubUser t)
        {
            Username = t.Username;
            DisplayName = t.DisplayName;
            ProprietaryScore = (t.PublicGistCount * 50) + (t.PublicRepoCount * 100) + (t.FollowerCount * 1000) + (t.FollowingCount * 25);
        }

        public string Username { get; set; }
        public string DisplayName { get; set; }
        public long ProprietaryScore { get; set; }
    }
}