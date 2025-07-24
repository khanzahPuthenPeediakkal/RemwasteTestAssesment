using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using UiTestAutomation.DriverHelper;
using UiTestAutomation.Pages;

namespace UiTestAutomation.Utils
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        protected TodoPage TodoPage { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        protected string AppUrl => Configuration["Url"];

        [SetUp]
        public void SetUp()
        {
            Configuration = LoadConfiguration();
            Driver = WebDriverFactory.Create();

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(AppUrl);

            TodoPage = new TodoPage(Driver);
            TodoPage.WaitForPageToLoad();
        }

        [TearDown]
        public void TearDown()
        {
            Driver?.Quit();
        }

        private IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
