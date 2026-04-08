using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Klimova_EHU.NUnit
{
    [TestFixture]
    public class NunitNavigationTests : BaseTest
    {
        [Test]
        public void Test1_VerifyNavigationToAboutPage()
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/");
            Thread.Sleep(5000);

            var aboutLink = driver.FindElement(By.CssSelector("a[href*='about']"));
            JsClick(aboutLink);

            Thread.Sleep(5000);
            Assert.That(driver.Url, Does.Contain("about"));
        }
    }
}