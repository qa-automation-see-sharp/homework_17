using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxTests
{
    [SetUp]
    public void Setup()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Firefox, "--start-maximized");
    }

    [TearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }

    private MainPage _mainPage;

    [Test]
    public void ExpandAndCollapseAll()
    {
        _mainPage.Open();
        var title = _mainPage.GetPageTitle(); //TODO Do you need this?? 
        var elementsPage = _mainPage.ClickOnElements();
        var isAccordionElementPresent = elementsPage.CheckAccordion(); //TODO Do you need this??

        var checkBoxPage = elementsPage.ClickOnCheckBox();
        checkBoxPage.ExpandAllClick();
        var isExpandAll = checkBoxPage.IsExpandAll();
        checkBoxPage.CollapseAllClick();
        var isCollapseAll = checkBoxPage.IsExpandAll(); 

        Assert.Multiple(() =>
        {
            Assert.That(isExpandAll, Is.True);
            Assert.That(isCollapseAll, Is.False);
        });
    }

    [Test]
    public void CheckUrlTitleCheckBoxPage()
    {
        _mainPage.Open();
        var elementsPage = _mainPage.ClickOnElements();
        var checkBoxPage = elementsPage.ClickOnCheckBox();
        var url = checkBoxPage.GetPageUrl();
        var title = checkBoxPage.GetTitleCheckBox();

        Assert.Multiple(() =>
        {
            Assert.That(url, Is.EqualTo("https://demoqa.com/checkbox"));
            Assert.That(title, Is.EqualTo("Check Box"));
        });
    }

    [Test]
    public void CheckedHome()
    {
        _mainPage.Open();
        var elementsPage = _mainPage.ClickOnElements();
        var checkBoxPage = elementsPage.ClickOnCheckBox();
        checkBoxPage.CheckHomeClick();
        var result = checkBoxPage.IsDisplayResult();
        var text = checkBoxPage.GetResultText();
        
        //TODO Pay attention to not miss Assert.Multiple 
        Assert.Multiple(() =>
        {
            Assert.True(result);
            Assert.That(text, Does.Contain(
                "\nhome\ndesktop\nnotes\ncommands\ndocuments\nworkspace\nreact\nangular\nveu\noffice\npublic\nprivate\nclassified\ngeneral\ndownloads\nwordFile\nexcelFile"));
        });
    }

    [Test]
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
            Assert.That(text, Does.Contain("\nnotes\nangular\nveu\ngeneral"));
            Assert.True(homeHalfCheck);
            Assert.True(desktopHalfCheck);
            Assert.True(workSpaceHalfCheck);
            Assert.True(documentsHalfCheck);
            Assert.True(generalChecked);
        });
    }
}