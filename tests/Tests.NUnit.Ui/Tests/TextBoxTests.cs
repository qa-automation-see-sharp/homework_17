using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TextBoxTests
{
    private MainPage _mainPage;

    [SetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
    }

    [Test]
    public void FirstTest()
    {
        _mainPage.Open();
        var title = _mainPage.GetPageTitle();
        
        _mainPage.ClickOnElements();
        
        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}