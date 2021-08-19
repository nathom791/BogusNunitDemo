using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQATests
{
    public class BaseClass
    {
        public IWebDriver driver;

        public BaseClass()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("no-sandbox");
            options.AddArgument("incognito");
            options.AddArgument("disable-dev-shm-usage");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("start-maximized");
            options.PageLoadStrategy = PageLoadStrategy.Default;

            driver = new ChromeDriver(options);
        }
    }
}