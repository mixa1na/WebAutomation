using Xunit;
using OpenQA.Selenium;

namespace Klimova_EHU.xUnit
{
    public class LanguageTests : BaseTest
    {
        [Fact]
        [Trait("Category", "Localization")]
        public void Test3_VerifyLanguageChange()
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/");

            var switcher = driver.FindElement(By.CssSelector(".language-switcher"));
            JsClick(switcher);

            System.Threading.Thread.Sleep(4000);

            var ltLink = driver.FindElement(By.XPath("//a[contains(@href, 'lt.ehuniversity.lt')]"));
            JsClick(ltLink);

            System.Threading.Thread.Sleep(4000);
            Assert.StartsWith("https://lt.ehuniversity.lt/", driver.Url);
        }
    }
}