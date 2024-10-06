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
        var isExpandedMenuDisplayed = checkBoxPage.CheckExpandedMenuByCommandsCheckBox();

        checkBoxPage.MarkHomeCheckbox();
        var isTheDescriptionOfSelectedItemsIsPresent = checkBoxPage.CheckTheDescriptionOfSelectedItems();

        
        var IsCollapseButtonEnabled = checkBoxPage.CheckCollapseButton();
        checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = checkBoxPage.CheckCollapsedMenuByTheHomeFolderIcon();
        
        Assert.Equal("DEMOQA", title);
        Assert.True(checkBoxPageTitle);
        Assert.True(IsExpandButtonEnabled);
        Assert.True(IsCollapseButtonEnabled);
        Assert.True(isExpandedMenuDisplayed);
        Assert.False(isCollapsedMenuDisplayed);
        Assert.True(isTheDescriptionOfSelectedItemsIsPresent);
    }
    public void Dispose()
    {
        _mainPage.Close();
    }
}