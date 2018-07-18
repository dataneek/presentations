namespace CoderScoreWebApi.Models 
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class FakeScoreClient : IFakeScoreClient
    {
        private readonly HttpClient httpClient;

        public FakeScoreClient()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "ScoreClient");
            httpClient.BaseAddress = new Uri("http://localhost:5000");
        }

        async Task<FakeScoreResult> IFakeScoreClient.GetScore(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException(nameof(username));
            }

            var request = $"api/fake-scores/{username}";
            var response = await httpClient.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<FakeScoreResult>();
        }
    }
}