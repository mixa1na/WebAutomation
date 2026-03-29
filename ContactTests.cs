using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Klimova_EHU
{
    [TestFixture]
    public class ContactTests : BaseTest
    {
        [Test]
        public void Test4_VerifyContactFormSubmission()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");

            var emailElement = driver.FindElement(By.XPath("//*[contains(text(), 'franciskscarynacr@gmail.com')]"));
            Assert.That(emailElement.Displayed, Is.True, "Email not displayed");
            Assert.That(emailElement.Text, Contains.Substring("franciskscarynacr@gmail.com"),
                "Email address is incorrect or not visible");

            var phoneLTElement = driver.FindElement(By.XPath("//*[contains(text(), '+370 68 771365')]"));
            Assert.That(phoneLTElement.Displayed, Is.True, "Lithuanian phone number not displayed");
            Assert.That(phoneLTElement.Text, Contains.Substring("+370 68 771365"),
                "Lithuanian phone number is incorrect or not visible");

            var phoneBYElement = driver.FindElement(By.XPath("//*[contains(text(), '+375 29 5781488')]"));
            Assert.That(phoneBYElement.Displayed, Is.True, "Belarusian phone number not displayed");
            Assert.That(phoneBYElement.Text, Contains.Substring("+375 29 5781488"),
                "Belarusian phone number is incorrect or not visible");

            var socialLinks = new Dictionary<string, string>
            {
                { "Facebook", "https://www.facebook.com/groups/434978221124539/" },
                { "Telegram", "https://t.me/skaryna_cultural_route" },
                { "VK", "https://vk.com/public203605228" }
            };

            foreach (var social in socialLinks)
            {
                var linkElement = driver.FindElement(By.XPath($"//a[contains(@href, '{social.Value}')]"));
                Assert.That(linkElement.Displayed, Is.True, $"{social.Key} link not displayed");
                Assert.That(linkElement.GetAttribute("href"), Is.EqualTo(social.Value),
                    $"{social.Key} link URL is incorrect");
            }

            var contactSections = driver.FindElements(By.CssSelector(".contact-info, .contacts, .address"));
            Assert.That(contactSections.Count, Is.GreaterThan(0),
                "Contact information sections not found on the page");
        }
    }
}