using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Klimova_EHU.NUnit
{
    [TestFixture]
    public class NunitLanguageTests : BaseTest
    {
        [Test]
        public void Test3_VerifyLanguageChange()
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/");

            var switcher = driver.FindElement(By.CssSelector(".language-switcher"));
            JsClick(switcher);

            Thread.Sleep(5000);
            var ltLink = driver.FindElement(By.XPath("//a[contains(@href, 'lt.ehuniversity.lt')]"));
            JsClick(ltLink);

            Thread.Sleep(5000);
            Assert.That(driver.Url, Does.StartWith("https://lt.ehuniversity.lt/"));
        }
    }
}