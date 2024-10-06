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
        
        var isExpandButtonEnabled = checkBoxPage.CheckExpandButton();
        checkBoxPage.ExpandMenu();
        var isExpandedMenuDisplayed = checkBoxPage.CheckExpandedMenuByCommandsCheckBox();
        
        var isCollapseButtonEnabled = checkBoxPage.CheckCollapseButton();
        checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = checkBoxPage.CheckCollapsedMenuByReactCheckBox();
        
        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(checkBoxPageTitle, Is.True);
            Assert.That(isExpandButtonEnabled, Is.True);
            Assert.That(isCollapseButtonEnabled, Is.True);
            Assert.That(isExpandedMenuDisplayed, Is.True);
            Assert.That(isCollapsedMenuDisplayed, Is.False);
        });
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}