using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.XUnit.Ui.Tests;

public class CheckBoxTests : IDisposable
{
    private MainPage _mainPage;
    private CheckBoxPage _checkBoxPage;

    
    public CheckBoxTests()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
        _mainPage.Open();
    }

    public void Dispose()
    {
        _mainPage.Close();
    }

    [Fact]
    public void GetMainPageTitleTest()
    {
        var title = _mainPage.GetPageTitle();
        Assert.Equal("DEMOQA", title);
    }

    [Fact]
    public void OpenCheckboxPageTest()
    {
        var elementsPage = _mainPage.OpenElementsPage();
        _checkBoxPage = elementsPage.OpenCheckBoxPage();
        var checkBoxPageTitle = _checkBoxPage.CheckCheckBoxPageTitle();
        Assert.True(checkBoxPageTitle);
    }

    [Fact]
    public void ExpandMenuTest()
    {
        var isExpandButtonEnabled = _checkBoxPage.CheckExpandButton();
        _checkBoxPage.ExpandMenu();
        var isExpandedMenuDisplayed = _checkBoxPage.CheckExpandedMenuByCommandsCheckBox();
        
        Assert.True(isExpandButtonEnabled);
        Assert.True(isExpandedMenuDisplayed);
    }

    [Fact]
    public void MarkHomeCheckBoxTest()
    {
        _checkBoxPage.MarkHomeCheckbox();
        var isHomeCheckBoxMarked = _checkBoxPage.VerifyTheHomeCheckBoxIsMarked();
        
        Assert.True(isHomeCheckBoxMarked);
    }

    [Fact]
    public void CheckMarkedElementsAndDescriptionTest()
    {
        var isDocumentsCheckBoxMarked = _checkBoxPage.VerifyTheDocumentsCheckBoxIsMarked();
        var isTheDescriptionOfSelectedItemsIsPresent = _checkBoxPage.CheckTheDescriptionOfSelectedItems();
        var isTheTextOfTheDescriptionDisplayed = _checkBoxPage.CheckTheTextOfTheDescription();
        
        Assert.True(isDocumentsCheckBoxMarked);
        Assert.True(isTheDescriptionOfSelectedItemsIsPresent);
        Assert.True(isTheTextOfTheDescriptionDisplayed);
    }

    [Fact]
    public void UnmarkCheckboxAndCloseTheMenuTest()
    {
        _checkBoxPage.UnMarkHomeCheckbox();

        var isCollapseButtonEnabled = _checkBoxPage.CheckCollapseButton();
        _checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = _checkBoxPage.CheckCollapsedMenuByTheHomeFolderIcon();

        Assert.True(isCollapseButtonEnabled);
        Assert.True(isCollapsedMenuDisplayed);
    }
}
