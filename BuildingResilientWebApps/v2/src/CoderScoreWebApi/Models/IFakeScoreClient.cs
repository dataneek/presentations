namespace CoderScoreWebApi.Models 
{
    using System.Threading.Tasks;
    using Refit;

    public interface IFakeScoreClient
    {
        [Get("/api/fake-scores/{username}")]
        Task<FakeScoreResult> GetScore(string username);
    }
}