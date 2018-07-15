namespace CoderScoreWebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using CoderScoreWebApi.Models;

    [Route("api/fake-scores")]
    public class FakeScoresController : Controller
    {
        private readonly IGithubClient client;
        static int requestCount = 0;

        public FakeScoresController(IGithubClient client)
        {
            this.client = client;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            await Task.Delay(100);
            requestCount++;

            if (requestCount % 4 != 0)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Oops... my bad.");
            }

            var result = await client.GetUser(username);

            return Ok(new FakeScoreResult(result));
        }
    }
}