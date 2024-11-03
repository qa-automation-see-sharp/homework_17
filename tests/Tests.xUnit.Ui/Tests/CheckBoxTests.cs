using Test.Utils.Swd.PageObjects;
using OpenQA.Selenium;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.xUnit.Ui.Tests
{
    public class CheckBoxTests : IAsyncLifetime
    {
        private MainPage _mainPage;
        private ElementsPage _elementsPage;
        private CheckBoxPage _checkBoxPage;
        private TextBoxPage _textBoxPage;
        private string _expectedPage = "https://demoqa.com/checkbox";
        public async Task InitializeAsync()
        {
            _mainPage = new MainPage();
            _mainPage.OpenWith(Chrome, "--start-maximized");
        }

        public async Task DisposeAsync()
        {
            _mainPage.Close();
        }

        [Fact]
        public void CheckIfCheckBoxPageOpened()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
            string currentPageIs = _checkBoxPage.GetCurrentUrl();

            Assert.Multiple(() =>
            {
                Assert.True(string.Equals(currentPageIs, _expectedPage, StringComparison.OrdinalIgnoreCase));
            });
        }

        [Fact]
        public void CheckIfAllStructureExpandeWhenPressExpandeAllBtn()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
            _checkBoxPage.ClickOnExpandeAll();

            var ifAllExpended = _checkBoxPage.CheckIfAllElementsExpanded();
            bool isAllStructureExpande = _checkBoxPage.CheckIfAllStructureExpande();

            Assert.Multiple(() =>
            {
                Assert.True(ifAllExpended);
                Assert.True(isAllStructureExpande);
            });
        }

        [Fact]
        public void CheckIfAllStructureCollapseWhenPressCollapswAllBtn()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnCollapseAll();
            
            bool isAllStructureCollapse = _checkBoxPage.CheckIfAllStructureCollapse();

            Assert.Multiple(() =>
            {
                Assert.True(isAllStructureCollapse);
            });
        }

        [Fact]
        public void CheckIfAllCheckboxesAreChecked()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnHomeCheckBox();

            bool isAllChecked = _checkBoxPage.CheckIfAllChecked();

            Assert.Multiple(() =>
            {
                Assert.True(isAllChecked);
            });
        }

        [Fact]
        public void CheckIfAllResultDisplayedWhenAllCheckboxesAreChecked()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
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

        [Fact]
        public void CheckIfAllCheckboxesAreUnchecked()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnHomeCheckBox();
            _checkBoxPage.ClickOnHomeCheckBox();

            bool isAllUnChecked = _checkBoxPage.CheckIfAllUnchecked();

            Assert.Multiple(() =>
            {
                Assert.True(isAllUnChecked);
            });
        }

        [Fact]
        public void CheckIsResultNotDisplayedWhenAllCheckboxesAreUnchecked()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
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

        [Theory]
        [InlineData("//span[@class='rct-title' and text() ='React']", "react")]
        public void CheckIfElementCheckedWhenClickOnIt(string elementPath, string elementName)
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
            _checkBoxPage.ClickOnExpandeAll();
            _checkBoxPage.ClickOnElement(By.XPath(elementPath));

            bool isElementChecked = _checkBoxPage.CheckIfElementChecked(elementName);

            Assert.Multiple(() =>
            {
                Assert.True(isElementChecked);
            });
        }

        [Theory]
        [InlineData("//span[@class='rct-title' and text() ='Desktop']", "desktop", "Desktop")]
        [InlineData("//span[@class='rct-title' and text() ='Notes']", "notes", "Notes")]
        [InlineData("//span[@class='rct-title' and text() ='Commands']", "commands", "Commands")]
        [InlineData("//span[@class='rct-title' and text() ='Documents']", "documents", "Documents")]
        [InlineData("//span[@class='rct-title' and text() ='WorkSpace']", "workspace", "WorkSpace")]
        [InlineData("//span[@class='rct-title' and text() ='React']", "react", "React")]
        [InlineData("//span[@class='rct-title' and text() ='Angular']", "angular", "Angular")]
        [InlineData("//span[@class='rct-title' and text() ='Veu']", "veu", "Veu")]
        [InlineData("//span[@class='rct-title' and text() ='Office']", "office", "Office")]
        [InlineData("//span[@class='rct-title' and text() ='Public']", "public", "Public")]
        [InlineData("//span[@class='rct-title' and text() ='Private']", "private", "Private")]
        [InlineData("//span[@class='rct-title' and text() ='Classified']", "classified", "Classified")]
        [InlineData("//span[@class='rct-title' and text() ='General']", "general", "General")]
        [InlineData("//span[@class='rct-title' and text() ='Downloads']", "downloads", "Downloads")]
        [InlineData("//span[@class='rct-title' and text() ='Word File.doc']", "wordFile", "Word File.doc")]
        [InlineData("//span[@class='rct-title' and text() ='Excel File.doc']", "excelFile", "Excel File.doc")]

        public void CheckIfResultPresentWhenElementChecked(string elementPath, string elementName, string elementTitle)
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
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
