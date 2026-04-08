using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Klimova_EHU.xUnit
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver;

        public BaseTest()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
        }

        protected void JsClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}