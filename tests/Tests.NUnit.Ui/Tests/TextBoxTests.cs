using OpenQA.Selenium;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TextBoxTests
{
    private MainPage _mainPage;
    private CheckBoxPage _checkBoxPage;

    [OneTimeSetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
        _checkBoxPage = new CheckBoxPage();
    }

    [Test]
    public void FirstTest()
    {
        _mainPage.Open();
        var title = _mainPage.GetPageTitle();
        
        var elementsPage = _mainPage.OpenElementsPage();
        elementsPage.OpenCheckBoxPage();
        _checkBoxPage.ExpandMenu();
        var IsExpandButtonEnabled = _checkBoxPage.CheckExpandButton();
        
        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(IsExpandButtonEnabled, Is.True);
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}