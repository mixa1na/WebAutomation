using OpenQA.Selenium;

namespace Klimova_EHU.NUnit;

public class HomePage : BasePage
{
    private readonly string _url = "https://en.ehuniversity.lt/";

    private IWebElement AboutLink => Wait.Until(d => d.FindElement(By.CssSelector("a[href*='about']")));
    private IWebElement LanguageSwitcher => Wait.Until(d => d.FindElement(By.CssSelector(".language-switcher")));
    private IWebElement SearchInput => Wait.Until(d => d.FindElement(By.Name("s")));

    public void Open() => Driver.Navigate().GoToUrl(_url);

    public void GoToAboutPage() => JsClick(AboutLink);

    public void SwitchLanguageToLt()
    {
        JsClick(LanguageSwitcher);

        System.Threading.Thread.Sleep(1000);

        var ltLink = Wait.Until(d => d.FindElement(By.XPath("//a[contains(@href, 'lt.ehuniversity.lt')]")));
        JsClick(ltLink);
    }

    public void Search(string query)
    {
        var js = (IJavaScriptExecutor)Driver;
        js.ExecuteScript("arguments[0].value = arguments[1];", SearchInput, query);
        js.ExecuteScript("arguments[0].form.submit();", SearchInput);
    }
}