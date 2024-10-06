
using static Test.Utils.Swd.WebDriver.BrowserNames;
using Test.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui
{
    public class TextBoxTests : IAsyncLifetime
    {
        private MainPage _mainPage;

        public async Task InitializeAsync()
        {
            _mainPage = new MainPage();
            _mainPage.OpenWith(Firefox, "--start-maximized");
        }

        [Fact]
        public void TextBoxFieldsEntered()
        {
            var name = "Andre Pinch";
            var email = "andre.pich@google.com";
            var current = "Current adderess";
            var permanentAddress = "Address";

            _mainPage.Open();
            var title = _mainPage.GetPageTitle();
            var elementsPage = _mainPage.ClickOnElements();
            var isAccordionElementPresent = elementsPage.CheckAccordion();

            var textBoxPage = elementsPage.ClickOnTextBox();
            var textBoxForIsPresent = textBoxPage.CheckTextBoxForm();
            var textBoxTitle = textBoxPage.CheckTextBoxTitle();
            var textBoxLabelName = textBoxPage.GetFullNameLabelText();
            var textBoxLabelEmail = textBoxPage.GetEmailLabelText();
            var textBoxLableCurrentAddress = textBoxPage.GetCurrentAddressLabelText();
            var textBoxLablePermanentAddress = textBoxPage.GetPermanentAddressLabelText();

            textBoxPage.EnterFullName(name);
            textBoxPage.EnterEmail(email);
            textBoxPage.EnterCurrentAddress(current);
            textBoxPage.EnterPermanentAddress(permanentAddress);
            textBoxPage.SubmitClick();
            var outEmail = textBoxPage.GetOutPutEmail();
            var outFullName = textBoxPage.GetOutPutName();
            var outCurrentAddress = textBoxPage.GetOutPutCurrentAddress();
            var outPermanentAddress = textBoxPage.GetOutPutPermanentAddress();

            Assert.Multiple(() =>
                    {
                        Assert.Equal("DEMOQA", title);
                        Assert.True(isAccordionElementPresent);
                        Assert.True(textBoxForIsPresent);
                        Assert.True(textBoxTitle);
                        Assert.Equal("Full Name", textBoxLabelName);
                        Assert.Equal("Email", textBoxLabelEmail);
                        Assert.Equal("Current Address", textBoxLableCurrentAddress);
                        Assert.Equal("Permanent Address", textBoxLablePermanentAddress);
                        Assert.Contains(email, outEmail);
                        Assert.Contains(name, outFullName);
                        Assert.Contains(current, outCurrentAddress);
                        Assert.Contains(permanentAddress, outPermanentAddress);
                    });
        }

        public async Task DisposeAsync()
        {
            _mainPage.Close();
        }
    }
}