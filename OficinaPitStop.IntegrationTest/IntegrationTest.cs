using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using OficinaPitStop.Api;
using Microsoft.Extensions.Configuration;

namespace OficinaPitStop.IntegrationTest

{
    public class IntegrationTest
    {
        protected readonly HttpClient Client;

        protected IntegrationTest()
        {
            string curDir = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(curDir)
                .AddJsonFile("appsettings.json");
            
            var webBuilder = new WebHostBuilder()
                .UseContentRoot(curDir).UseConfiguration(builder.Build())
                .UseStartup<Startup>();

            var server = new TestServer(webBuilder);
            Client = server.CreateClient();
            Client.BaseAddress = new System.Uri("https://localhost:5001");
        }
    }
}