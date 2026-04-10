using OpenQA.Selenium;

namespace Klimova_EHU.NUnit;

public class ContactPage : BasePage
{
    private readonly string _url = "https://en.ehuniversity.lt/contact/";

    private IWebElement Email => Wait.Until(d => d.FindElement(By.XPath("//*[contains(text(), 'gmail.com')]")));

    public void Open() => Driver.Navigate().GoToUrl(_url);
    public bool IsEmailDisplayed() => Email.Displayed;
}