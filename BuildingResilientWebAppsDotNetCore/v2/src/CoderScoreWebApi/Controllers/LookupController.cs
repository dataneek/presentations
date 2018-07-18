namespace CoderScoreWebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using CoderScoreWebApi.Models;
    using System.Net.Http;

    [Route("api/lookup")]
    public class LookupController : Controller
    {
        private readonly IFakeScoreClient client;

        public LookupController(IFakeScoreClient client)
        {
            this.client = client;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var result = await client.GetScore(username);

            return Ok(new LookupResult(result));
        }
    }
}