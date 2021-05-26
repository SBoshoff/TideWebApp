using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Presentation.Controllers;

namespace TideWebApp.Tests
{
    public class Tests
    {
        string defaultArea = "a";
        int defaultPageSize = 1000;
        int defaultPageNum = 1;
        [SetUp]
        public void Setup()
        {
            Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        [Test]
        public void TestNoArea()
        {

            Assert.Pass();
        }
    }
}