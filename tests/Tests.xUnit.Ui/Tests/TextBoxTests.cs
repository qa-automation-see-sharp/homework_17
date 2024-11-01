using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.xUnit.Ui.Tests
{
    public class TextBoxTests : IAsyncLifetime
    {
        private MainPage _mainPage;
        private ElementsPage _elementsPage;
        private TextBoxPage _textBoxPage;
        private string _expectedPage = "https://demoqa.com/elements";

        public async Task InitializeAsync()
        {
            _mainPage = new MainPage();
            _mainPage.OpenWith(Chrome, "--headless=new, --start-maximized");
        }

        
        public async Task DisposeAsync()
        {
            _mainPage.Close();
        }

        [Fact]
        public void CheckIfUserCanGetToMainPage()
        {
            _mainPage.Open();

            var mainPageTitle = _mainPage.GetPageTitle();
            var isElementsCardPresent = _mainPage.CheckElements();

            Assert.Multiple(() =>
            {
                Assert.Equal("DEMOQA", mainPageTitle);
                Assert.True(isElementsCardPresent);
            });
        }

        [Fact]
        public void CheckIfUserCanGetToElementsPage()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();

            var currentPageIs = _elementsPage.GetCurrentUrl();
            var isAccordionElementPresent = _elementsPage.CheckAccordion();
            var isTextBoxPresent = _elementsPage.CkeckTextBox();

            Assert.Multiple(() =>
            {
                Assert.True(string.Equals(currentPageIs, _expectedPage, StringComparison.OrdinalIgnoreCase));
                Assert.True(isAccordionElementPresent);
                Assert.True(isTextBoxPresent);
            });
        }

        [Fact]
        public void CheckIfUserCanGetToTextBoxPage()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var isTextBoxTitlePresent = _textBoxPage.CheckTextBoxTitle();
            var textBoxTitle = _textBoxPage.GetTextBoxTitle();

            Assert.Multiple(() =>
            {
                Assert.True(isTextBoxTitlePresent);
                Assert.Equal("Text Box", textBoxTitle);
            });
        }

        [Fact]
        public void CheckIfAllElementsPresentOnTheTextBoxPage()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var isTextBoxFormPresent = _textBoxPage.CheckTextBoxForm();
            var isFullNamePresent = _textBoxPage.CheckFullName();
            var isEmailPresent = _textBoxPage.CheckEmail();
            var isCurrentAddressPresent = _textBoxPage.CheckCurrentAddress();
            var isPermanentAddressPresent = _textBoxPage.CheckPermanentAddress();
            var isSubmitButtonPresent = _textBoxPage.CheckSubmitButton();

            Assert.Multiple(() =>
            {
                Assert.True(isTextBoxFormPresent);
                Assert.True(isFullNamePresent);
                Assert.True(isEmailPresent);
                Assert.True(isCurrentAddressPresent);
                Assert.True(isPermanentAddressPresent);
                Assert.True(isSubmitButtonPresent);
            });
        }

        [Fact]
        public void CheckIfAllElementsGetRightNames()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var fullNameLabel = _textBoxPage.GetFullNameLabelText();
            var emailLabel = _textBoxPage.GetEmailLabelText();
            var currentAddressLabel = _textBoxPage.GetCurrentAddressLabelText();
            var permanentAddressLabel = _textBoxPage.GetPermanentAddressLabelText();
            var submitButtonName = _textBoxPage.GetSubmitButtonText();

            Assert.Multiple(() =>
            {
                Assert.Equal("Full Name", fullNameLabel);
                Assert.Equal("Email", emailLabel);
                Assert.Equal("Current Address", currentAddressLabel);
                Assert.Equal("Permanent Address", permanentAddressLabel);
                Assert.Equal("Submit", submitButtonName);
            });
        }

        [Fact]
        public void CheckIfAllInputsPresented()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var isFullNameInputPresent = _textBoxPage.CheckFullNameInput();
            var isEmailInputPresent = _textBoxPage.CheckEmailInput();
            var isCurrentAddressInputPresent = _textBoxPage.CheckCurrentAddressInput();
            var isPermanentAddressInputPresent = _textBoxPage.CheckPermanentAddressInput();

            Assert.Multiple(() =>
            {
                Assert.True(isFullNameInputPresent);
                Assert.True(isEmailInputPresent);
                Assert.True(isCurrentAddressInputPresent);
                Assert.True(isPermanentAddressInputPresent);
            });
        }

        [Fact]
        public void CheckIfAllPlaseholdersArePresented()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var fullNamePlaceholder = _textBoxPage.CheckIfFullNamePlaceholderIsPresent();
            var emailPlaceholder = _textBoxPage.CheckIfEmailPlaceholderIsPresent();
            var currentAddressPlaceholder = _textBoxPage.CheckIfCurrentAddressPlaceholderIsPresent();
            var permanentAddressPlaceholder = _textBoxPage.CheckIfPermanentAddressPlaceholderIsPresent();

            Assert.Multiple(() =>
            {
                Assert.True(fullNamePlaceholder);
                Assert.True(emailPlaceholder);
                Assert.True(currentAddressPlaceholder);
                Assert.False(permanentAddressPlaceholder);
            });
        }

        [Fact]
        public void CheckIfAllPlaceholderNamesHaveRightName()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var fullNamePlaceholder = _textBoxPage.GetFullNamePlaceholderText();
            var emailPlaceholder = _textBoxPage.GetEmailPlaceholderText();
            var currentAddressPlaceholder = _textBoxPage.GetCurrentAddressPlaceholderText();
            var permanentAddressPlaceholder = _textBoxPage.GetPermanentAddressPlaceholderText();

            Assert.Multiple(() =>
            {
                Assert.Equal("Full Name", fullNamePlaceholder);
                Assert.Equal("name@example.com", emailPlaceholder);
                Assert.Equal("Current Address", currentAddressPlaceholder);
                Assert.Equal("", permanentAddressPlaceholder);
                //There is some case in DOM: placeholder is present, but its value is empty and you need to find it some deep in the attributes in comand line. $x("//*[@id='permanentAddress']") => 0: textarea#permanentAddress.form-control => placeholder: "" => value: ""
            });
        }

        [Fact]
        public void FillAllFieldsAndSubmit()
        {
            _mainPage.Open();

            _elementsPage = _mainPage.ClickOnElements();
            _textBoxPage = _elementsPage.ClickOnTextBox();

            var enterFullName = _textBoxPage.EnterFullName("John Doe");
            var enterEmail = _textBoxPage.EnterEmail("some.one@universe.com");
            var enterCurrentAddress = _textBoxPage.EnterCurrentAddress("Some address");
            var enterPermanentAddress = _textBoxPage.EnterPermanentAddress("Another address");

            var submit = _textBoxPage.SubmitForm();

            var expectedFullName = _textBoxPage.GetFullNameOutput();
            var expectedEmail = _textBoxPage.GetEmailOutput();
            var expectedCurrentAddress = _textBoxPage.GetCurrentAddressOutput();
            var expectedPermanentAddress = _textBoxPage.GetPermanentAddressOutput();

            Assert.Multiple(() =>
            {
                Assert.Equal(enterFullName, expectedFullName);
                Assert.Equal(enterEmail, expectedEmail);
                Assert.Equal(enterCurrentAddress, expectedCurrentAddress);
                Assert.Equal(enterPermanentAddress, expectedPermanentAddress);
            });
        }
    }
}
