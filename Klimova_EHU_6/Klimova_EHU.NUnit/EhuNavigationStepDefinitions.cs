using Reqnroll;
using Klimova_EHU.NUnit.Pages;

namespace Klimova_EHU.NUnit;

[Binding]
public class EhuNavigationStepDefinitions
{
    private HomePage _homePage = null!;
    private SearchResultsPage _searchResultsPage = null!;
    private ContactPage _contactPage = null!;

    [Given(@"I am on the EHU homepage")]
    public void GivenIAmOnTheEHUHomepage()
    {
        _homePage = new HomePage();
        _homePage.Open();
        TestContext.Progress.WriteLine("Открыта главная страница EHU");
    }

    [When(@"I switch language to Lithuanian")]
    public void WhenISwitchLanguageToLithuanian()
    {
        _homePage.SwitchLanguageToLt();
        TestContext.Progress.WriteLine("Язык переключен на Литовский");
    }

    [Then(@"I should be redirected to Lithuanian version")]
    public void ThenIShouldBeRedirectedToLithuanianVersion()
    {
        var currentUrl = Browser.Instance.Driver.Url;
        Assert.That(currentUrl, Does.StartWith("https://lt.ehuniversity.lt/"),
            $"URL должен начинаться с lt.ehuniversity.lt, но был {currentUrl}");
        TestContext.Progress.WriteLine("Успешно перенаправлены на литовскую версию");
    }

    [When(@"I navigate to About page")]
    public void WhenINavigateToAboutPage()
    {
        _homePage = new HomePage();
        _homePage.GoToAboutPage();
        TestContext.Progress.WriteLine("Переход на страницу About");
    }

    [Then(@"I should see About page content")]
    public void ThenIShouldSeeAboutPageContent()
    {
        var currentUrl = Browser.Instance.Driver.Url;
        Assert.That(currentUrl, Does.Contain("about"),
            $"URL должен содержать 'about', но был {currentUrl}");
        TestContext.Progress.WriteLine("Страница About успешно загружена");
    }

    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string query)
    {
        _homePage = new HomePage();
        _homePage.Open();
        _homePage.Search(query);
        TestContext.Progress.WriteLine($"Выполнен поиск по запросу: {query}");
    }

    [Then(@"I should see search results")]
    public void ThenIShouldSeeSearchResults()
    {
        _searchResultsPage = new SearchResultsPage();
        var hasResults = _searchResultsPage.AreResultsDisplayed();
        Assert.That(hasResults, Is.True, "Результаты поиска не отображаются");
        TestContext.Progress.WriteLine("Результаты поиска успешно отображены");
    }

    [When(@"I navigate to Contact page")]
    public void WhenINavigateToContactPage()
    {
        _contactPage = new ContactPage();
        _contactPage.Open();
        TestContext.Progress.WriteLine("Переход на страницу Contact");
    }

    [Then(@"I should see contact email address")]
    public void ThenIShouldSeeContactEmailAddress()
    {
        var isDisplayed = _contactPage.IsEmailDisplayed();
        Assert.That(isDisplayed, Is.True, "Email адрес не отображается на странице контактов");
        TestContext.Progress.WriteLine("Email адрес успешно отображен");
    }
}