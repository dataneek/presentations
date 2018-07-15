namespace CoderScoreWebApi.Models 
{
    using Newtonsoft.Json;
    
    public class GithubUser
    {
        [JsonProperty(PropertyName="id")]
        public long InternalId { get; set; }

        [JsonProperty(PropertyName="login")]
        public string Username { get; set; }

        [JsonProperty(PropertyName="name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName="company")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName="bio")]
        public string Bio { get; set; }

        [JsonProperty(PropertyName="email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName="public_repos")]
        public int PublicRepoCount { get; set; } 

        [JsonProperty(PropertyName="public_gists")]
        public int PublicGistCount { get; set; }

        [JsonProperty(PropertyName="following")]
        public int FollowingCount { get; set; }

        [JsonProperty(PropertyName="followers")]
        public int FollowerCount { get; set; }
    }
}