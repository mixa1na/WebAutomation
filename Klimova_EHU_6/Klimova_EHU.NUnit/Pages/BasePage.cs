using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Klimova_EHU.NUnit.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver => Browser.Instance.Driver;
    protected WebDriverWait Wait => new(Driver, TimeSpan.FromSeconds(10));

    protected void JsClick(IWebElement element)
    {
        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
    }
}