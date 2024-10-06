
using Test.Utils.Swd.PageObjects;
using Test.Utils.Swd.PageObjects.ElementGroup;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests
{
    [TestFixture]
    public class CheckBoxTests
    {
        private MainPage _mainPage;

        [SetUp]
        public void Setup()
        {
            _mainPage = new MainPage();
            _mainPage.OpenWith(Firefox, "--start-maximized");
        }

        [Test]
        public void ExpandAndCollapsAll()
        {
             _mainPage.Open();
            var title = _mainPage.GetPageTitle();
            var elementsPage = _mainPage.ClickOnElements();
            var isAccordionElementPresent = elementsPage.CheckAccordion();

            var checkBoxPage = elementsPage.ClickOnCheckBox();
            checkBoxPage.ExpandAllClick();
            var isExpandAll = checkBoxPage.IsExpandAll();
            checkBoxPage.CollapseAllClick();
            var isCollapsAll = checkBoxPage.IsExpandAll();

            Assert.Multiple(() =>
                {
                    Assert.True(isExpandAll);
                    Assert.False(isCollapsAll);
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
        public void CheckedHome(){
            _mainPage.Open();
            var elementsPage = _mainPage.ClickOnElements();
            var checkBoxPage = elementsPage.ClickOnCheckBox();
            checkBoxPage.CheckHomeClick();
            var result = checkBoxPage.IsDisplayResult();
            var text = checkBoxPage.GetResultText();

            Assert.True(result);
            Assert.That(text, Does.Contain("\nhome\ndesktop\nnotes\ncommands\ndocuments\nworkspace\nreact\nangular\nveu\noffice\npublic\nprivate\nclassified\ngeneral\ndownloads\nwordFile\nexcelFile"));
        }

        public void CheckedOffice(){
            _mainPage.Open();
            var elementsPage = _mainPage.ClickOnElements();
            var checkBoxPage = elementsPage.ClickOnCheckBox();
            //checkBoxPage.
        }

        public void test2(){

        }

        [TearDown]
        public void TearDown(){
            _mainPage.Close();
        }
    }
}