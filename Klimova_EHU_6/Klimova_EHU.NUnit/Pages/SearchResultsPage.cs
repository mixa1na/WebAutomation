using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Klimova_EHU.NUnit.Pages;

public class SearchResultsPage : BasePage
{
    public bool AreResultsDisplayed()
    {
        try
        {
            Wait.Until(d =>
                d.FindElements(By.CssSelector("article, .post, .search-result, .no-results")).Count > 0);

            var noResults = Driver.FindElements(By.CssSelector(".no-results, .not-found"));
            if (noResults.Count > 0) return false;

            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}