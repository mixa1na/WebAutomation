using NUnit.Framework;
using OpenQA.Selenium;

namespace Klimova_EHU
{
    [TestFixture]
    public class NavigationTests : BaseTest
    {
        [Test]
        public void Test1_VerifyNavigationToAboutPage()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            var aboutLink = driver.FindElement(By.CssSelector("a[href*='about']"));
            aboutLink.Click();

            Assert.That(driver.Url, Is.EqualTo("https://en.ehu.lt/about/"),
                "URL does not match expected About page URL");

            Assert.That(driver.Title, Is.EqualTo("About EHU"),
                "Page title does not match expected title");

            var headerElement = driver.FindElement(By.TagName("h1"));
            Assert.That(headerElement.Text, Does.Contain("About"),
                "Header does not contain 'About'");
        }
    }
}