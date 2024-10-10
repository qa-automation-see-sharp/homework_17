using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxTests
{
    [OneTimeSetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }

    private MainPage _mainPage;

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

        checkBoxPage.MarkHomeCheckbox();
        var isHomeCheckBoxMarked = checkBoxPage.VerifyTheHomeCheckBoxIsMarked();
        var isDocumentsCheckBoxMarked = checkBoxPage.VerifyTheDocumentsCheckBoxIsMarked();
        var isTheDescriptionOfSelectedItemsIsPresent = checkBoxPage.CheckTheDescriptionOfSelectedItems();
        var isTheTextOfTheDescriptionDisplayed = checkBoxPage.CheckTheTextOfTheDescription();
        checkBoxPage.UnMarkHomeCheckbox();


        var isCollapseButtonEnabled = checkBoxPage.CheckCollapseButton();
        checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = checkBoxPage.CheckCollapsedMenuByTheHomeFolderIcon();


        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("DEMOQA"));
            Assert.That(checkBoxPageTitle, Is.True);
            Assert.That(isExpandButtonEnabled, Is.True);
            Assert.That(isCollapseButtonEnabled, Is.True);
            Assert.That(isExpandedMenuDisplayed, Is.True);
            Assert.That(isHomeCheckBoxMarked, Is.True);
            Assert.That(isDocumentsCheckBoxMarked, Is.True);
            Assert.That(isTheDescriptionOfSelectedItemsIsPresent, Is.True);
            Assert.That(isTheTextOfTheDescriptionDisplayed, Is.True);
            Assert.That(isCollapsedMenuDisplayed, Is.True);
        });
    }
}