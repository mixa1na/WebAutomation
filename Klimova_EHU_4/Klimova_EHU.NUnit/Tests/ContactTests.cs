using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Klimova_EHU.NUnit
{
    [TestFixture]
    public class NunitContactTests : BaseTest
    {
        [Test]
        public void Test4_VerifyContactInfo()
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/contact/");
            Thread.Sleep(5000);

            var email = driver.FindElement(By.XPath("//*[contains(text(), 'gmail.com')]"));
            Assert.That(email.Displayed, Is.True);
        }
    }
}