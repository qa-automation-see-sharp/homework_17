using OpenQA.Selenium;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TextBoxTests
{
    private MainPage _mainPage;

    [OneTimeSetUp]
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
        
        var elementsPage = _mainPage.OpenElementsPage();
        var checkBoxPage = elementsPage.OpenCheckBoxPage();
        var checkBoxPageTitle = checkBoxPage.CheckCheckBoxPageTitle();
        
        var IsExpandButtonEnabled = checkBoxPage.CheckExpandButton();
        checkBoxPage.ExpandMenu();
        
        var IsCollapseButtonEnabled = checkBoxPage.CheckCollapseButton();
        checkBoxPage.CollapseMenu();
        
        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(checkBoxPageTitle, Is.True);
            Assert.That(IsExpandButtonEnabled, Is.True);
            Assert.That(IsCollapseButtonEnabled, Is.True);
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}