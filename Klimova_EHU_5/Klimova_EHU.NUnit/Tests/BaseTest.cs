using OpenQA.Selenium;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(1)]

namespace Klimova_EHU.NUnit;

public class BaseTest
{
    protected IWebDriver Driver => Browser.Instance.Driver;

    [TearDown]
    public void TearDown() => Browser.Quit();
}