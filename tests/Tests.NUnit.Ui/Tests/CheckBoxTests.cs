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
        _mainPage.Open();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }

    private MainPage _mainPage;

    //TODO: divide into several tests
    [Test, Order(1)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void GetMainPageTitleTest()
    {
        var title = _mainPage.GetPageTitle();
        
        Assert.That(title, Is.EqualTo("DEMOQA"));
    }

    [Test, Order(2)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void OpenCheckboxPageTest()
    {
            var elementsPage = _mainPage.OpenElementsPage();
            var checkBoxPage = elementsPage.OpenCheckBoxPage();
            var checkBoxPageTitle = checkBoxPage.CheckCheckBoxPageTitle();
           
            Assert.That(checkBoxPageTitle, Is.True);
    }
    
    
    [Test, Order(3)]
    public void FirstTest()
    {

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