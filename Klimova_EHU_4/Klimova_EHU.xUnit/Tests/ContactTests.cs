using Xunit;
using OpenQA.Selenium;

namespace Klimova_EHU.xUnit
{
    public class ContactTests : BaseTest
    {
        [Fact]
        [Trait("Category", "UI")]
        public void Test4_VerifyContactInfo()
        {
            driver.Navigate().GoToUrl("https://en.ehuniversity.lt/contact/");
            System.Threading.Thread.Sleep(3000);

            var email = driver.FindElement(By.XPath("//*[contains(text(), 'franciskscarynacr@gmail.com')]"));
            Assert.True(email.Displayed);
        }
    }
}