namespace CoderScoreWebApi.Models 
{
    using System.Threading.Tasks;

    public interface IFakeScoreClient
    {
        Task<FakeScoreResult> GetScore(string username);
    }
}