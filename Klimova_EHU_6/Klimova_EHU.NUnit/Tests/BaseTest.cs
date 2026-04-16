using OpenQA.Selenium;

namespace Klimova_EHU.NUnit;

public abstract class BaseTest
{
    protected IWebDriver Driver => Browser.Instance.Driver;

    [TearDown]
    public void TearDown() => Browser.Quit();
}