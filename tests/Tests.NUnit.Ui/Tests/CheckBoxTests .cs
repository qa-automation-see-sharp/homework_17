using OpenQA.Selenium;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxTests
{
    private MainPage _mainPage;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--start-maximized");
    }

    [Test]
    public void CheckCheckBoxUrl()
    {
        //Arrange
        _mainPage.Open();
        var elementsPage = _mainPage.ClickOnElements();
        elementsPage.ClickOnCheckBox();
       
        //Act
        var url = elementsPage.GetPageUrl();

        //Assert
        Assert.That(url, Is.EqualTo("https://demoqa.com/checkbox"));
    }
    [Test]
    public void ExpandCheckBoxList_ShouldDisplayFolders()
    {
        //Arrange
        _mainPage.Open();
        // Scroll the page to bring "Elements" into view
        //IJavaScriptExecutor js = (IJavaScriptExecutor)_mainPage.Driver;
        //js.ExecuteScript("window.scrollBy(0,350)", "");

        var elementsPage = _mainPage.ClickOnElements();
        var checkBoxPage = elementsPage.ClickOnCheckBox();

        //Act
        checkBoxPage.CheckHome();
        var foldersExpanded = checkBoxPage.IsDisplayedFolderList();
        checkBoxPage.CheckHome();
        var foldersCollapsed = checkBoxPage.IsDisplayedFolderList();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(foldersExpanded, Is.True);
            Assert.That(foldersCollapsed, Is.False);
        });
    }





    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}