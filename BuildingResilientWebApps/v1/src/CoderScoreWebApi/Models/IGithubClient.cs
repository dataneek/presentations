namespace CoderScoreWebApi.Models 
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IGithubClient
    {
        Task<GithubUser> GetUser(string username);
    }
}