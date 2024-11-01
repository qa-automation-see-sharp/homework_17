using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Utils.Swd.PageObjects;
using static Test.Utils.Swd.WebDriver.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TextBoxTests
{
    private MainPage _mainPage;
    private ElementsPage _elementsPage;
    private TextBoxPage _textBoxPage;
    private string _expectedPage = "https://demoqa.com/elements";

    [OneTimeSetUp]
    public void OnetimeSetUp()
    {
        _mainPage = new MainPage();
        _mainPage.OpenWith(Chrome, "--headless=new, --start-maximized");
    }

    [SetUp]
    public void SetUp()
    {
        _mainPage.Open();
    }

    [Test]
    public void CheckIfUserCanGetToMainPage()
    {
        var mainPageTitle = _mainPage.GetPageTitle();
        var isElementsCardPresent = _mainPage.CheckElements();

        Assert.Multiple(() =>
        {
            Assert.That(mainPageTitle, Is.EqualTo("DEMOQA"));
        });
    }

    [Test]
    public void CheckIfUserCanGetToElementsPage()
    {
        _elementsPage = _mainPage.ClickOnElements();

        string currentPageIs = _elementsPage.GetCurrentUrl();
        var isAccordionElementPresent = _elementsPage.CheckAccordion();
        var isTextBoxPresent = _elementsPage.CkeckTextBox();

        Assert.Multiple(() =>
        {
            Assert.That(currentPageIs, Is.EqualTo(_expectedPage).Using<string>((x, y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase)));
            Assert.That(isAccordionElementPresent, Is.True);
            Assert.That(isTextBoxPresent, Is.True);
        });
    }

    [Test]
    public void CheckIfUserCanGetToTextBoxPage()
    {
        _elementsPage = _mainPage.ClickOnElements();
        _textBoxPage = _elementsPage.ClickOnTextBox();

        var isTextBoxTitlePresent = _textBoxPage.CheckTextBoxTitle();
        var textBoxTitle = _textBoxPage.GetTextBoxTitle();

        Assert.Multiple(() =>
        {
            Assert.That(isTextBoxTitlePresent, Is.True);
            Assert.AreEqual("Text Box", textBoxTitle);
        });
    }

    [Test]
    public void CheckIfAllElementsPresentOnTheTextBoxPage()
    {
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
            Assert.That(isTextBoxFormPresent, Is.True);
            Assert.That(isFullNamePresent, Is.True);
            Assert.That(isEmailPresent, Is.True);
            Assert.True(isCurrentAddressPresent);
            Assert.That(isPermanentAddressPresent, Is.True);
            Assert.That(isSubmitButtonPresent, Is.True);
        });
    }
    [Test]
    public void CheckIfAllElementsGetRightNames()
    {
        _elementsPage = _mainPage.ClickOnElements();
        _textBoxPage = _elementsPage.ClickOnTextBox();

        var fullNameLabel = _textBoxPage.GetFullNameLabelText();
        var emailLabel = _textBoxPage.GetEmailLabelText();
        var currentAddressLabel = _textBoxPage.GetCurrentAddressLabelText();
        var permanentAddressLabel = _textBoxPage.GetPermanentAddressLabelText();
        var submitButtonName = _textBoxPage.GetSubmitButtonText();

        Assert.Multiple(() =>
        {
            Assert.That(fullNameLabel, Is.EqualTo("Full Name"));
            Assert.That(emailLabel, Is.EqualTo("Email"));
            Assert.That(currentAddressLabel, Is.EqualTo("Current Address"));
            Assert.That(permanentAddressLabel, Is.EqualTo("Permanent Address"));
            Assert.That(submitButtonName, Is.EqualTo("Submit"));
        });
    }

    [Test]
    public void CheckIfAllInputsPresented()
    {
        _elementsPage = _mainPage.ClickOnElements();
        _textBoxPage = _elementsPage.ClickOnTextBox();

        var isFullNameInputPresent = _textBoxPage.CheckFullNameInput();
        var isEmailInputPresent = _textBoxPage.CheckEmailInput();
        var isCurrentAddressInputPresent = _textBoxPage.CheckCurrentAddressInput();
        var isPermanentAddressInputPresent = _textBoxPage.CheckPermanentAddressInput();

        Assert.Multiple(() =>
        {
            Assert.That(isFullNameInputPresent, Is.True);
            Assert.That(isEmailInputPresent, Is.True);
            Assert.That(isCurrentAddressInputPresent, Is.True);
            Assert.That(isPermanentAddressInputPresent, Is.True);
        });
    }

    [Test]
    public void CheckIfAllPlaseholdersArePresented()
    {
        _elementsPage = _mainPage.ClickOnElements();
        _textBoxPage = _elementsPage.ClickOnTextBox();

        var fullNamePlaceholder = _textBoxPage.CheckIfFullNamePlaceholderIsPresent();
        var emailPlaceholder = _textBoxPage.CheckIfEmailPlaceholderIsPresent();
        var currentAddressPlaceholder = _textBoxPage.CheckIfCurrentAddressPlaceholderIsPresent();
        var permanentAddressPlaceholder = _textBoxPage.CheckIfPermanentAddressPlaceholderIsPresent();

        Assert.Multiple(() =>
        {
            Assert.That(fullNamePlaceholder, Is.True);
            Assert.That(emailPlaceholder, Is.True);
            Assert.That(currentAddressPlaceholder, Is.True);
            Assert.That(permanentAddressPlaceholder, Is.False);
        });
    }

    [Test]
    public void CheckIfAllPlaceholderNamesHaveRightName()
    {
        _elementsPage = _mainPage.ClickOnElements();
        _textBoxPage = _elementsPage.ClickOnTextBox();

        var fullNamePlaceholder = _textBoxPage.GetFullNamePlaceholderText();
        var emailPlaceholder = _textBoxPage.GetEmailPlaceholderText();
        var currentAddressPlaceholder = _textBoxPage.GetCurrentAddressPlaceholderText();
        var permanentAddressPlaceholder = _textBoxPage.GetPermanentAddressPlaceholderText();

        Assert.Multiple(() =>
        {
            Assert.That(fullNamePlaceholder, Is.EqualTo("Full Name"));
            Assert.That(emailPlaceholder, Is.EqualTo("name@example.com"));
            Assert.That(currentAddressPlaceholder, Is.EqualTo("Current Address"));
            //There is some case in DOM: placeholder is present, but its value is empty and you need to find it some deep in the attributes in comand line. $x("//*[@id='permanentAddress']") => 0: textarea#permanentAddress.form-control => placeholder: "" => value: ""
            Assert.That(permanentAddressPlaceholder, Is.EqualTo(""));
        });
    }

    [Test]
    public void FillAllFieldsAndSubmit()
    {
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
            Assert.That(expectedFullName, Is.EqualTo(enterFullName));
            Assert.That(expectedEmail, Is.EqualTo(enterEmail));
            Assert.That(expectedCurrentAddress, Is.EqualTo(enterCurrentAddress));
            Assert.That(expectedPermanentAddress, Is.EqualTo(enterPermanentAddress));
        });

    }
    [OneTimeTearDown]
    public void TearDown()
    {
        _mainPage.Close();
    }
}