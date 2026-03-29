using NUnit.Framework;
using OpenQA.Selenium;

namespace Klimova_EHU
{
    [TestFixture]
    public class SearchTests : BaseTest
    {
        [Test]
        public void Test2_VerifySearchFunctionality()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            var searchInput = driver.FindElement(By.CssSelector("input[type='search'], input[name='s']"));
            searchInput.Clear();
            searchInput.SendKeys("study programs");

            var searchButton = driver.FindElement(By.CssSelector("button[type='submit'], input[type='submit']"));
            searchButton.Click();

            Assert.That(driver.Url, Does.Contain("/?s=study+programs"),
                "Search query not found in URL");

            var searchResults = driver.FindElements(By.CssSelector("article, .search-result, .post"));
            Assert.That(searchResults.Count, Is.GreaterThan(0),
                "No search results found");

            var resultLinks = driver.FindElements(By.CssSelector("a"));
            bool hasStudyProgramsLink = false;
            foreach (var link in resultLinks)
            {
                if (link.Text.Contains("study program", StringComparison.OrdinalIgnoreCase) ||
                    link.GetAttribute("href").Contains("study-program", StringComparison.OrdinalIgnoreCase))
                {
                    hasStudyProgramsLink = true;
                    break;
                }
            }
            Assert.That(hasStudyProgramsLink, Is.True,
                "No study programs related links found in search results");
        }
    }
}