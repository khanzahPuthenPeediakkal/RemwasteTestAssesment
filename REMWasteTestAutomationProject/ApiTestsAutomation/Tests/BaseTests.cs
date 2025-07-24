using ApiTestsAutomation.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Configuration;

namespace ApiTestsAutomation.Tests
{
    public abstract class BaseTests
    {
        protected string BaseUrl;
        protected RestClientHelper clientHelper;

        [SetUp]
        public void Setup()
        {
            var configuration = LoadConfiguration();

            BaseUrl = configuration["BaseUrl"];
            if (string.IsNullOrEmpty(BaseUrl))
            {
                throw new ConfigurationErrorsException("BaseUrl is not configured in appsettings.json");
            }

            clientHelper = new RestClientHelper(BaseUrl);
        }

        private IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        [TearDown]
        public void TearDown()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var status = TestContext.CurrentContext.Result.Outcome.Status.ToString();
        }
    }
}
