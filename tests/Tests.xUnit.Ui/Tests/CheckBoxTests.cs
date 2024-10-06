using OpenQA.Selenium;
using Test.Utils.Swd.PageObjects;
using Xunit;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.XUnit.Ui.Tests;

public class TextBoxTests : IDisposable
{
    private MainPage _mainPage;
    public TextBoxTests()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
    }

    [Fact]
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
        
        Assert.Equal("DEMOQA", title);
        Assert.True(checkBoxPageTitle);
        Assert.True(IsExpandButtonEnabled);
        Assert.True(IsCollapseButtonEnabled);
    }
    public void Dispose()
    {
        _mainPage.Close();
    }
}