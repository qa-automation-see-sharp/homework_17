using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.XUnit.Ui.Tests;

public class CheckBoxTests : IAsyncLifetime
{
    private MainPage _mainPage;

    public async Task InitializeAsync()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
        _mainPage.Open();
    }

    [Fact]
    public void GetMainPageTitleTest()
    {
        var title = _mainPage.GetPageTitle();
        Assert.Equal("DEMOQA", title);
    }

    [Fact]
    public void CheckboxPageTests()
    {
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

        Assert.True(checkBoxPageTitle);
        Assert.True(isExpandButtonEnabled);
        Assert.True(isExpandedMenuDisplayed);
        Assert.True(isHomeCheckBoxMarked);
        Assert.True(isDocumentsCheckBoxMarked);
        Assert.True(isTheDescriptionOfSelectedItemsIsPresent);
        Assert.True(isTheTextOfTheDescriptionDisplayed);
        Assert.True(isCollapseButtonEnabled);
        Assert.True(isCollapsedMenuDisplayed);
    }

    public async Task DisposeAsync()
    {
        _mainPage.Close();
    }
}