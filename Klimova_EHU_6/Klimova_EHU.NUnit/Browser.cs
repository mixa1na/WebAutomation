using OpenQA.Selenium;

namespace Klimova_EHU.NUnit;

public sealed class Browser
{
    private static Browser? _instance;
    private static readonly object _lock = new();
    private readonly IWebDriver _driver;

    private Browser()
    {
        _driver = WebDriverFactory.CreateDriver();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public static Browser Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance ??= new Browser();
            }
        }
    }

    public IWebDriver Driver => _driver;

    public static void Quit()
    {
        if (_instance == null) return;

        try
        {
            _instance._driver.Quit();
            _instance._driver.Dispose();
        }
        catch
        {

        }
        finally
        {
            _instance = null;
        }
    }
}