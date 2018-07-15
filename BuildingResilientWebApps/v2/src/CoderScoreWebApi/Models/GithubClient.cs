namespace CoderScoreWebApi.Models 
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GithubClient : IGithubClient
    {
        private readonly HttpClient httpClient;

        public GithubClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        async Task<GithubUser> IGithubClient.GetUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException(nameof(username));
            }

            var request = $"users/{username}";
            var response = await httpClient.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<GithubUser>();
        }
    }
}