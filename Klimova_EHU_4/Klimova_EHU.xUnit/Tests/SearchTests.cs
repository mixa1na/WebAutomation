using Xunit;
using OpenQA.Selenium;
using System.Threading;

namespace Klimova_EHU.xUnit
{
    public class XunitSearchTests : BaseTest
    {
        [Theory]
        [InlineData("erasmus")]
        public void Test2_VerifySearch(string query)
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/");
            Thread.Sleep(8000);

            var searchInput = driver.FindElement(By.Name("s"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].value = arguments[1];", searchInput, query);
            Thread.Sleep(1000);

            js.ExecuteScript("arguments[0].form.submit();", searchInput);

            Thread.Sleep(8000);
            Assert.Contains(query, driver.Url);
            Assert.NotEmpty(driver.FindElements(By.CssSelector("article, .post")));
        }
    }
}