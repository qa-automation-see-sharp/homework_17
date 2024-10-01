using Test.Utils.PageObjects;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxTests
{
    private MainPage _mainPage;
    protected ElementsPage _elementsPage;
    protected CheckBoxPage _checkBoxPage;

    [OneTimeSetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
        _mainPage.Open();
        _elementsPage = _mainPage.ClickOnElements();
        _checkBoxPage = _elementsPage.ClickOnCheckBox();
    }

    [Test]
    public void NavigateToCheckBox_CheckThePageIsCorrect()
    {
        var pageTitle = _checkBoxPage.VerifyCheckBoxTitle();
        var homeBox = _checkBoxPage.CheckHomeBoxTitle();

        Assert.Multiple(() =>
        {
            Assert.That(pageTitle, Is.True);
            Assert.That(homeBox, Is.True);
        });
    }

    [Test]
    public void NavigateToCheckBox_WhenIUnrollHome_ElementShouldBeDisplayed()
    {
        _checkBoxPage.ExpandAll();
        var unrolledFolders = _checkBoxPage.CheckUnrolledFolders();

        _checkBoxPage.CollapseAll();
        var foldersCollapsed = !_checkBoxPage.CheckUnrolledFolders();

        Assert.Multiple(() =>
        {
            Assert.That(unrolledFolders, Is.True);
            Assert.That(foldersCollapsed, Is.True);
        });
    }

    [Test]
    public void CheckBox_WhenChecked_ShouldDisplayCheckedIcon()
    {
        _checkBoxPage.ExpandAll();
        _checkBoxPage.CheckHomeBox();

        var resultText = _checkBoxPage.ResultText();
        bool areAllChecked = _checkBoxPage.CheckAllBoxesAreChecked();

        var expectedSelections = new[]
        {
            "home", "desktop", "notes", "commands", "documents", "workspace",
            "react", "angular", "veu", "office", "public", "private",
            "classified", "general", "downloads", "wordFile", "excelFile"
        };

        var normalizedResultText = resultText.Replace("\n", " ").Trim();

        Assert.Multiple(() =>
        {
            Assert.That(areAllChecked, Is.True);
            Assert.That(resultText, Does.Contain("You have selected :"), "The result text does not start with the expected prefix.");

            foreach (var selection in expectedSelections)
            {
                Assert.That(resultText, Does.Contain(selection), $"The result text does not contain '{selection}'.");
            }
        });
    }

    [Test]
    public void CheckBox_WhenChecked_ShowsSelectedObjectLabel()
    {
        _checkBoxPage.ReloadPage();

        _checkBoxPage.ExpandAll();
        _checkBoxPage.CheckNotesBox();

        var resultText = _checkBoxPage.ResultText();

        Assert.That(resultText, Does.Contain("notes"));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}