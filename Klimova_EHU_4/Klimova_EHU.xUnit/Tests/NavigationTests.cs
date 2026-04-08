using Xunit;
using OpenQA.Selenium;

namespace Klimova_EHU.xUnit
{
    public class NavigationTests : BaseTest
    {
        [Fact]
        [Trait("Category", "UI")]
        public void Test1_VerifyNavigationToAboutPage()
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/");
            System.Threading.Thread.Sleep(3000);

            var link = driver.FindElement(By.CssSelector("a[href*='about']"));
            JsClick(link);

            System.Threading.Thread.Sleep(3000);
            Assert.Contains("about", driver.Url);
            Assert.Contains("About", driver.Title);
        }
    }
}