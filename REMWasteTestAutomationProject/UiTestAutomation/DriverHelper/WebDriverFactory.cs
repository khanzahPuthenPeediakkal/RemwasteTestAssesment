using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UiTestAutomation.DriverHelper
{
    public class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var options = new ChromeOptions();
            var tempUserDataDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            options.AddArgument($"--user-data-dir={tempUserDataDir}");
           
            if (Environment.GetEnvironmentVariable("CI") == "true")
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--window-size=1920,1080");
            }
            return new ChromeDriver(options);
        }

    }
}
