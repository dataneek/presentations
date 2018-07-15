namespace CoderScoreWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Polly;
    using Refit;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpClient<IGithubClient, GithubClient>(t =>
            {
                t.BaseAddress = new Uri("https://api.github.com/");
                t.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                t.DefaultRequestHeaders.Add("User-Agent", "GithubClient");
            });
                
            services.AddHttpClient("FakeScoreClient", t =>
            {
                t.DefaultRequestHeaders.Add("User-Agent", "FakeScoreClient");
                t.BaseAddress = new Uri("http://localhost:5000");
            })
            .AddTypedClient<IFakeScoreClient>(e=> RestService.For<IFakeScoreClient>(e))
            .AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
            //    app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}