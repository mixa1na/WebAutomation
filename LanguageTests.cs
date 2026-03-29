using NUnit.Framework;
using OpenQA.Selenium;

namespace Klimova_EHU
{
    [TestFixture]
    public class LanguageTests : BaseTest
    {
        [Test]
        public void Test3_VerifyLanguageChangeFunctionality()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            var languageSwitcher = driver.FindElement(By.CssSelector(".language-switcher, .lang-switch, [aria-label*='language']"));
            languageSwitcher.Click();

            var lithuanianOption = driver.FindElement(By.XPath("//a[contains(text(), 'Lietuvių')]"));
            lithuanianOption.Click();

            Assert.That(driver.Url, Does.StartWith("https://lt.ehu.lt/"),
                "Not redirected to Lithuanian version of the site");

            var bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.That(bodyText, Does.Contain("Lietuvių").Or.Contains("LT").Or.Contains("lt"),
                "Page content does not appear to be in Lithuanian");

            var menuElements = driver.FindElements(By.CssSelector("nav a"));
            bool hasLithuanianText = false;
            foreach (var element in menuElements)
            {
                if (element.Text.Contains("Apie") || element.Text.Contains("Studijos"))
                {
                    hasLithuanianText = true;
                    break;
                }
            }
            Assert.That(hasLithuanianText, Is.True,
                "Menu items not displayed in Lithuanian");
        }
    }
}