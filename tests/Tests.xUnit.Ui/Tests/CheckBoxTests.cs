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
        
        var isExpandButtonEnabled = checkBoxPage.CheckExpandButton();
        checkBoxPage.ExpandMenu();
        var isExpandedMenuDisplayed = checkBoxPage.CheckExpandedMenuByCommandsCheckBox();

        checkBoxPage.MarkHomeCheckbox();
        var isHomeCheckBoxMarked = checkBoxPage.VerifyTheHomeCheckBoxIsMarked();
        var isDocumentsCheckBoxMarked = checkBoxPage.VerifyTheDocumentsCheckBoxIsMarked();
        var isTheDescriptionOfSelectedItemsIsPresent = checkBoxPage.CheckTheDescriptionOfSelectedItems();
        var isTheTextOfTheDescriptionDisplayed = checkBoxPage.CheckTheTextOfTheDescription();
        checkBoxPage.UnMarkHomeCheckbox();

        
        var isCollapseButtonEnabled = checkBoxPage.CheckCollapseButton();
        checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = checkBoxPage.CheckCollapsedMenuByTheHomeFolderIcon();
        
        Assert.Equal("DEMOQA", title);
        Assert.True(checkBoxPageTitle);
        Assert.True(isExpandButtonEnabled);
        Assert.True(isCollapseButtonEnabled);
        Assert.True(isExpandedMenuDisplayed);
        Assert.True(isHomeCheckBoxMarked);
        Assert.True(isDocumentsCheckBoxMarked);
        Assert.True(isTheDescriptionOfSelectedItemsIsPresent);
        Assert.True(isTheTextOfTheDescriptionDisplayed);
        Assert.True(isCollapsedMenuDisplayed);
        
    }
    public void Dispose()
    {
        _mainPage.Close();
    }
}