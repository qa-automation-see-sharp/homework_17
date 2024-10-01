using Test.Utils.PageObjects;
using Test.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.Tests
{
    public class CheckBoxTests : IAsyncLifetime
    {
        private MainPage _mainPage;
        protected ElementsPage _elementsPage;
        protected CheckBoxPage _checkBoxPage;

        public async Task InitializeAsync()
        {
            _mainPage = new MainPage();
            _mainPage.OpenWith(Test.Utils.Swd.WebDriver.BrowserNames.Chrome, "--start-maximized");
            _mainPage.Open();
            _elementsPage = _mainPage.ClickOnElements();
            _checkBoxPage = _elementsPage.ClickOnCheckBox();
        }

        [Fact]
        public void NavigateToCheckBox_CheckThePageIsCorrect()
        {
            var pageTitle = _checkBoxPage.VerifyCheckBoxTitle();
            var homeBox = _checkBoxPage.CheckHomeBoxTitle();

            Assert.True(pageTitle);
            Assert.True(homeBox);
        }

        [Fact]
        public void NavigateToCheckBox_WhenIUnrollHome_ElementShouldBeDisplayed()
        {
            _checkBoxPage.ExpandAll();
            var unrolledFolders = _checkBoxPage.CheckUnrolledFolders();

            _checkBoxPage.CollapseAll();
            var foldersCollapsed = !_checkBoxPage.CheckUnrolledFolders();

            Assert.True(unrolledFolders);
            Assert.True(foldersCollapsed);
        }

        [Fact]
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
                Assert.Equal(true, areAllChecked);
                Assert.Contains("You have selected :", resultText);

                foreach (var selection in expectedSelections)
                {
                    Assert.Contains(selection, resultText);
                }
            });
        }

        [Fact]
        public void CheckBox_WhenChecked_ShowsSelectedObjectLabel()
        {
            _checkBoxPage.ReloadPage();

            _checkBoxPage.ExpandAll();
            _checkBoxPage.CheckNotesBox();

            var resultText = _checkBoxPage.ResultText();

            Assert.Contains("notes", resultText);
        }

        public async Task DisposeAsync()
        {
            _mainPage.Close();
        }
    }
}
