using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Swd.PageObjects;
using Test.Utils.Swd.WebDriver;

namespace Tests.NUnit.Ui.Tests
{
    public class CheckBoxTests
    {
        private MainPage _mainPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mainPage = new MainPage();
            BrowserNames Chrome = BrowserNames.Chrome;
            _mainPage.OpenWith(Chrome, "--start-maximized");
        }

        [Test]
        public void TestPageOpen()
        {
            //Arrange
            _mainPage.Open();
            var elementsPage = _mainPage.ClickOnElements();
            elementsPage.ClickOnCheckBox();
            var expectedUrl = "https://demoqa.com/checkbox";

            //Act
            var url = elementsPage.GetPageUrl();

            //Assert
            Assert.That(url, Is.EqualTo(expectedUrl));
        }

        [Test]
        public void TestExpandCheckBoxList()
        {
            //Arrange
            _mainPage.Open();
            var elementsPage = _mainPage.ClickOnElements();
            var checkBoxPage = elementsPage.ClickOnCheckBox();

            //Act
            checkBoxPage.ToggleHome();
            var foldersExpanded = checkBoxPage.IsDisplayedFolderList();
            checkBoxPage.ToggleHome();
            var foldersCollapsed = checkBoxPage.IsDisplayedFolderList();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(foldersExpanded, Is.True);
                Assert.That(foldersCollapsed, Is.False);
            });
        }

        [Test]
        public void TestCheckBoxesAndOutputText()
        {
            _mainPage.Open();
            var elementsPage = _mainPage.ClickOnElements();
            var checkBoxPage = elementsPage.ClickOnCheckBox();

            checkBoxPage.ToggleHome();
            checkBoxPage.CheckHome();
            var isCheckedHome = checkBoxPage.IsHomeChecked();
            var isCheckedDesktop = checkBoxPage.IsDesktopChecked();
            var isCheckedDocuments = checkBoxPage.IsDocumentsChecked();
            var isCheckedDownloads = checkBoxPage.IsDownloadsChecked();
            var outputContainsText = checkBoxPage.OutputContainsCheckedElements();

            Assert.Multiple(() =>
            {
                Assert.That(isCheckedHome, Is.True);
                Assert.That(isCheckedDesktop, Is.True);
                Assert.That(isCheckedDocuments, Is.True);
                Assert.That(isCheckedDownloads, Is.True);
                Assert.That(outputContainsText, Is.True);
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _mainPage.Close();
        }
    }
}
