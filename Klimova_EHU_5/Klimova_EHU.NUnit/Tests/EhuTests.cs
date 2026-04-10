namespace Klimova_EHU.NUnit;

[TestFixture]
public class EhuTests : BaseTest
{
    [Test]
    public void Test1_VerifyNavigationToAboutPage()
    {
        var homePage = new HomePage();
        homePage.Open();
        homePage.GoToAboutPage();
        Assert.That(Driver.Url, Does.Contain("about"));
    }

    [Test]
    public void Test3_VerifyLanguageChange()
    {
        var homePage = new HomePage();
        homePage.Open();
        homePage.SwitchLanguageToLt();
        Assert.That(Driver.Url, Does.StartWith("https://lt.ehuniversity.lt/"));
    }

    [Test]
    public void Test4_VerifyContactInfo()
    {
        var contactPage = new ContactPage();
        contactPage.Open();
        Assert.That(contactPage.IsEmailDisplayed(), Is.True);
    }
}