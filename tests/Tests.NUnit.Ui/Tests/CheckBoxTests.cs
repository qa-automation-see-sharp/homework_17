using OpenQA.Selenium;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;


namespace Tests.NUnit.Ui.Tests
{
    public class CheckBoxTests
    {
        private MainPage _mainPage;
        private ElementsPage _elementsPage;
        private CheckBoxPage _checkBoxPage;
        private TextBoxPage _textBoxPage;
        private string _expectedPage = "https://demoqa.com/checkbox";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _mainPage = new MainPage();
            _mainPage.OpenWith(Chrome, "--start-maximized", "--headless");
        }

        [SetUp]
        public void SetUp()
        {
            _mainPage.Open();
            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _mainPage.Close();
        }

        [Test]
        public void CheckIfCheckBoxPageOpened()
        {
            string currentPageIs = _checkBoxPage.GetCurrentUrl();

            //Assert multiple is not needed whe you have only one assert
            Assert.True(string.Equals(currentPageIs, _expectedPage, StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void CheckIfAllStructureExpandWhenPressExpandAllBtn()
        {
            _checkBoxPage.ClickOnExpandeAll();

            var ifAllExpended = _checkBoxPage.CheckIfAllElementsExpanded();
            bool isAllStructureExpande = _checkBoxPage.CheckIfAllStructureExpande();

            Assert.Multiple(() =>
            {
                Assert.True(ifAllExpended);
                Assert.True(isAllStructureExpande);
            });
        }

        [Test]
        public void CheckIfAllStructureCollapseWhenPressCollapseAllBtn()
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnCollapseAll();

            bool isAllStructureCollapse = _checkBoxPage.CheckIfAllStructureCollapse();

            //Assert multiple is not needed whe you have only one assert
            Assert.True(isAllStructureCollapse);
        }

        [Test]
        public void CheckIfAllCheckboxesAreChecked()
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnHomeCheckBox();

            bool isAllChecked = _checkBoxPage.CheckIfAllChecked();

            //Assert multiple is not needed whe you have only one assert
            Assert.True(isAllChecked);
        }

        [Test]
        public void CheckIfAllResultDisplayedWhenAllCheckboxesAreChecked()
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnHomeCheckBox();

            bool isAllChecked = _checkBoxPage.CheckIfAllChecked();
            bool isAllResultDisplayed = _checkBoxPage.CheckIfResultIsDisplayed();

            Assert.Multiple(() =>
            {
                Assert.True(isAllChecked);
                Assert.True(isAllResultDisplayed);
            });
        }

        [Test]
        public void CheckIfAllCheckboxesAreUnchecked()
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnHomeCheckBox();
            _checkBoxPage.ClickOnHomeCheckBox();

            bool isAllUnChecked = _checkBoxPage.CheckIfAllUnchecked();

            //Assert multiple is not needed whe you have only one assert
            Assert.True(isAllUnChecked);
        }

        [Test]
        public void CheckIsResultNotDisplayedWhenAllCheckboxesAreUnchecked()
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnHomeCheckBox();
            _checkBoxPage.ClickOnHomeCheckBox();

            bool isAllUnChecked = _checkBoxPage.CheckIfAllUnchecked();
            bool isResultNotDisplayed = _checkBoxPage.CheckIfResultIsDisplayed();

            Assert.Multiple(() =>
            {
                Assert.True(isAllUnChecked);
                Assert.False(isResultNotDisplayed);
            });
        }

        [Test]
        [TestCase("//span[@class='rct-title' and text() ='Desktop']", "desktop")]
        [TestCase("//span[@class='rct-title' and text() ='Notes']", "notes")]
        [TestCase("//span[@class='rct-title' and text() ='Commands']", "commands")]
        [TestCase("//span[@class='rct-title' and text() ='Documents']", "documents")]
        [TestCase("//span[@class='rct-title' and text() ='WorkSpace']", "workspace")]
        [TestCase("//span[@class='rct-title' and text() ='React']", "react")]
        [TestCase("//span[@class='rct-title' and text() ='Angular']", "angular")]
        [TestCase("//span[@class='rct-title' and text() ='Veu']", "veu")]
        [TestCase("//span[@class='rct-title' and text() ='Office']", "office")]
        [TestCase("//span[@class='rct-title' and text() ='Public']", "public")]
        [TestCase("//span[@class='rct-title' and text() ='Private']", "private")]
        [TestCase("//span[@class='rct-title' and text() ='Classified']", "classified")]
        [TestCase("//span[@class='rct-title' and text() ='General']", "general")]
        [TestCase("//span[@class='rct-title' and text() ='Downloads']", "downloads")]
        [TestCase("//span[@class='rct-title' and text() ='Word File.doc']", "wordFile")]
        [TestCase("//span[@class='rct-title' and text() ='Excel File.doc']", "excelFile")]
        public void CheckIfElementCheckedWhenClickOnIt(string elementPath, string elementName)
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnElement(By.XPath(elementPath));

            bool isElementChecked = _checkBoxPage.CheckIfElementChecked(elementName);

            //Assert multiple is not needed whe you have only one assert
            Assert.True(isElementChecked);
        }

        [Test]
        [TestCase("//span[@class='rct-title' and text() ='Desktop']", "desktop", "Desktop")]
        [TestCase("//span[@class='rct-title' and text() ='Notes']", "notes", "Notes")]
        [TestCase("//span[@class='rct-title' and text() ='Commands']", "commands", "Commands")]
        [TestCase("//span[@class='rct-title' and text() ='Documents']", "documents", "Documents")]
        [TestCase("//span[@class='rct-title' and text() ='WorkSpace']", "workspace", "WorkSpace")]
        [TestCase("//span[@class='rct-title' and text() ='React']", "react", "React")]
        [TestCase("//span[@class='rct-title' and text() ='Angular']", "angular", "Angular")]
        [TestCase("//span[@class='rct-title' and text() ='Veu']", "veu", "Veu")]
        [TestCase("//span[@class='rct-title' and text() ='Office']", "office", "Office")]
        [TestCase("//span[@class='rct-title' and text() ='Public']", "public", "Public")]
        [TestCase("//span[@class='rct-title' and text() ='Private']", "private", "Private")]
        [TestCase("//span[@class='rct-title' and text() ='Classified']", "classified", "Classified")]
        [TestCase("//span[@class='rct-title' and text() ='General']", "general", "General")]
        [TestCase("//span[@class='rct-title' and text() ='Downloads']", "downloads", "Downloads")]
        [TestCase("//span[@class='rct-title' and text() ='Word File.doc']", "wordFile", "Word File.doc")]
        [TestCase("//span[@class='rct-title' and text() ='Excel File.doc']", "excelFile", "Excel File.doc")]
        public void CheckIfResultPresentWhenElementChecked(string elementPath, string elementName, string elementTitle)
        {
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnElement(By.XPath(elementPath));

            bool isElementChecked = _checkBoxPage.CheckIfElementChecked(elementName);
            bool isResultDisplayed = _checkBoxPage.CheckIfResultIsDisplayed(elementName);
            bool isAncestors = _checkBoxPage.CheckIfAncestorsAreHalfChecked(elementTitle);

            Assert.Multiple(() =>
            {
                Assert.True(isElementChecked);
                Assert.True(isResultDisplayed);
                Assert.True(isAncestors);
            });
        }
    }
}