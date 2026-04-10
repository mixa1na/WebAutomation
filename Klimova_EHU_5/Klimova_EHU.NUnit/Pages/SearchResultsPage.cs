using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Klimova_EHU.NUnit.Pages;

public class SearchResultsPage : BasePage
{
    public bool AreResultsDisplayed()
    {
        try
        {
            Wait.Until(d => d.FindElements(By.CssSelector("article, .post, .search-result")).Count > 0);
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}