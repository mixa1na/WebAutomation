using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Klimova_EHU.NUnit
{
    [TestFixture]
    public class NunitSearchTests : BaseTest
    {
        [TestCase("erasmus")]
        public void Test2_VerifySearch(string query)
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/");

            Thread.Sleep(8000);

            var searchInput = driver.FindElement(By.Name("s"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].click();", searchInput);
            Thread.Sleep(1000);

            js.ExecuteScript("arguments[0].value = '';", searchInput);
            js.ExecuteScript("arguments[0].value = arguments[1];", searchInput, query);

            Thread.Sleep(1000);

            js.ExecuteScript("arguments[0].form.submit();", searchInput);

            Thread.Sleep(8000);

            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Does.Contain(query), "URL не содержит поисковый запрос");

                var results = driver.FindElements(By.CssSelector("article, .post, .search-result"));
                Assert.That(results.Count, Is.GreaterThan(0), "Результаты поиска не найдены на странице");
            });
        }
    }
}