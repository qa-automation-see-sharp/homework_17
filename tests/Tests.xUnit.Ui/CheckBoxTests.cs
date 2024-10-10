using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.xUnit.Ui;

public class CheckBoxTests : IAsyncLifetime
{
    private MainPage _mainPage;

    public async Task DisposeAsync()
    {
        _mainPage.Close();
    }

    public async Task InitializeAsync()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Firefox, "--start-maximized");
    }

    [Fact]
    public void CheckedAFewItems()
    {
        _mainPage.Open();
        var elementsPage = _mainPage.ClickOnElements();
        var checkBoxPage = elementsPage.ClickOnCheckBox();
        checkBoxPage.CheckItemByName("Notes");
        checkBoxPage.CheckItemByName("Angular");
        checkBoxPage.CheckItemByName("Veu");
        checkBoxPage.CheckItemByName("General");
        var text = checkBoxPage.GetResultText();
        var homeHalfCheck = checkBoxPage.IsNodeHalfCheck("Home");
        var desktopHalfCheck = checkBoxPage.IsNodeHalfCheck("Desktop");
        var workSpaceHalfCheck = checkBoxPage.IsNodeHalfCheck("WorkSpace");
        var documentsHalfCheck = checkBoxPage.IsNodeHalfCheck("Documents");
        var generalChecked = checkBoxPage.IsNodeChecked("General");


        Assert.Multiple(() =>
        {
            Assert.Contains("\nnotes\nangular\nveu\ngeneral", text);
            Assert.True(homeHalfCheck);
            Assert.True(desktopHalfCheck);
            Assert.True(workSpaceHalfCheck);
            Assert.True(documentsHalfCheck);
            Assert.True(generalChecked);
        });
    }

    [Fact]
    public void CheckedHome()
    {
        _mainPage.Open();
        var elementsPage = _mainPage.ClickOnElements();
        var checkBoxPage = elementsPage.ClickOnCheckBox();
        checkBoxPage.CheckHomeClick();
        var result = checkBoxPage.IsDisplayResult();
        var text = checkBoxPage.GetResultText();

        Assert.True(result);
        Assert.Contains(
            "\nhome\ndesktop\nnotes\ncommands\ndocuments\nworkspace\nreact\nangular\nveu\noffice\npublic\nprivate\nclassified\ngeneral\ndownloads\nwordFile\nexcelFile",
            text);
    }

    [Fact]
    public void CheckUrlTitleCheckBoxPage()
    {
        _mainPage.Open();
        var elementsPage = _mainPage.ClickOnElements();
        var checkBoxPage = elementsPage.ClickOnCheckBox();
        var url = checkBoxPage.GetPageUrl();
        var title = checkBoxPage.GetTitleCheckBox();

        Assert.Multiple(() =>
        {
            Assert.Equal(url, "https://demoqa.com/checkbox");
            Assert.Equal(title, "Check Box");
        });
    }
}