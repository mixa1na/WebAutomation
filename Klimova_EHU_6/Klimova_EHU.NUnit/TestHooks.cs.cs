using Reqnroll;
using OpenQA.Selenium;

namespace Klimova_EHU.NUnit;

[Binding]
public class TestHooks
{
    private readonly ScenarioContext _scenarioContext;

    public TestHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        TestContext.Progress.WriteLine($"Запуск сценария: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Browser.Quit();
        TestContext.Progress.WriteLine($"Сценарий завершен: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterStep]
    public void AfterStep()
    {
        if (_scenarioContext.TestError != null)
        {
            var error = _scenarioContext.TestError;
            TestContext.Progress.WriteLine($"Ошибка на шаге '{_scenarioContext.StepContext.StepInfo.Text}': {error.Message}");

            try
            {
                TakeScreenshot(_scenarioContext.StepContext.StepInfo.Text);
            }
            catch { }
        }
    }

    private void TakeScreenshot(string stepName)
    {
        if (Browser.Instance.Driver is ITakesScreenshot takesScreenshot)
        {
            var screenshot = takesScreenshot.GetScreenshot();
            var fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{stepName.Replace(" ", "_")}.png";
            var dir = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots");
            Directory.CreateDirectory(dir);
            var path = Path.Combine(dir, fileName);
            screenshot.SaveAsFile(path);
            TestContext.Progress.WriteLine($"Скриншот сохранен: {path}");
        }
    }
}