using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;
using static Test.Utils.Swd.Helpers.WaitHelper;


namespace Test.Utils.Swd.PageObjects
{
    public class TextBoxPage : BasePage
    {
        private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
        private By TextBoxForm => By.Id("userForm");
        private By FullNameLable => By.Id("userName-label");
        private By FullNameInput => By.Id("userName");
        private By EmailLabel => By.Id("userEmail-label");
        private By EmailInput => By.Id("userEmail");
        private By CurrentAddressLabel => By.Id("currentAddress-label");
        private By CurrentAddressInput => By.Id("currentAddress");
        private By PermanentAddressLabel => By.Id("permanentAddress-label");
        private By PermanentAddressInput => By.Id("permanentAddress");
        private By SubmitButton => By.Id("submit");
        private By Output => By.Id("output");

        public bool CheckTextBoxTitle()
        {
            var element = Driver.FindElement(TextBoxTitle);
            return element.Displayed && element.Enabled;
        }

        public bool CheckTextBoxForm()
        {
            var element = Driver.FindElement(TextBoxForm);
            return element.Displayed && element.Enabled;
        }

        public bool CheckFullName()
        {
            var inputElement = Driver.FindElement(FullNameInput);
            var labelElement = Driver.FindElement(FullNameLable);

            bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                    labelElement.Displayed && labelElement.Enabled;

            return areBothDisplayed;
        }
        public bool CheckEmail()
        {
            var inputElement = Driver.FindElement(EmailInput);
            var labelElement = Driver.FindElement(EmailLabel);

            bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                    labelElement.Displayed && labelElement.Enabled;

            return areBothDisplayed;
        }
        public bool CheckCurrentAddress()
        {
            var inputElement = Driver.FindElement(CurrentAddressInput);
            var labelElement = Driver.FindElement(CurrentAddressLabel);

            bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                    labelElement.Displayed && labelElement.Enabled;

            return areBothDisplayed;
        }
        public bool CheckPermanentAddress()
        {
            var inputElement = Driver.FindElement(PermanentAddressInput);
            var labelElement = Driver.FindElement(PermanentAddressLabel);

            bool areBothDisplayed = inputElement.Displayed && inputElement.Enabled &&
                                    labelElement.Displayed && labelElement.Enabled;

            return areBothDisplayed;
        }
        public bool CheckSubmitButton()
        {
            var element = Driver.FindElement(SubmitButton);
            return element.Displayed && element.Enabled;
        }

        public string GetTextBoxTitle()
        {
            return Driver.FindElement(TextBoxTitle).Text;
        }

        public string GetFullNameLabelText()
        {
            return Driver.FindElement(FullNameLable).Text;
        }

        public string GetEmailLabelText()
        {
            return Driver.FindElement(EmailLabel).Text;
        }

        public string GetCurrentAddressLabelText()
        {
            return Driver.FindElement(CurrentAddressLabel).Text;
        }
        public string GetPermanentAddressLabelText()
        {
            return Driver.FindElement(PermanentAddressLabel).Text;
        }
        public string GetSubmitButtonText()
        {
            return Driver.FindElement(SubmitButton).Text;
        }

        public bool CheckFullNameInput()
        {
            var element = Driver.FindElement(FullNameInput);
            return element.Displayed && element.Enabled;
        }
        public bool CheckEmailInput()
        {
            var element = Driver.FindElement(EmailInput);
            return element.Displayed && element.Enabled;
        }
        public bool CheckCurrentAddressInput()
        {
            var element = Driver.FindElement(CurrentAddressInput);
            return element.Displayed && element.Enabled;
        }
        public bool CheckPermanentAddressInput()
        {
            var element = Driver.FindElement(PermanentAddressInput);
            return element.Displayed && element.Enabled;
        }

        public bool CheckIfFullNamePlaceholderIsPresent()
        {
            var element = Driver.FindElement(FullNameInput);
            return element.GetAttribute("placeholder") != null;
        }
        public bool CheckIfEmailPlaceholderIsPresent()
        {
            var element = Driver.FindElement(EmailInput);
            return element.GetAttribute("placeholder") != null;
        }
        public bool CheckIfCurrentAddressPlaceholderIsPresent()
        {
            var element = Driver.FindElement(CurrentAddressInput);
            return element.GetAttribute("placeholder") != null;
        }
        public bool CheckIfPermanentAddressPlaceholderIsPresent()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("permanentAddress")));
            var placeholder = element.GetAttribute("placeholder");
            return !string.IsNullOrEmpty(placeholder);
        }

        public string GetFullNamePlaceholderText()
        {
            return Driver.FindElement(FullNameInput).GetAttribute("placeholder");
        }
        public string GetEmailPlaceholderText()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("userEmail")));
            return Driver.FindElement(EmailInput).GetAttribute("placeholder");
        }
        public string GetCurrentAddressPlaceholderText()
        {
            return Driver.FindElement(CurrentAddressInput).GetAttribute("placeholder");
        }
        public string GetPermanentAddressPlaceholderText()
        {
            return Driver.FindElement(PermanentAddressInput).GetAttribute("placeholder");
        }

        public string EnterFullName(string fullName)
        {
            var element = Driver.FindElement(By.Id("userName"));
            element.Clear();
            element.SendKeys(fullName);
            return $"Name:{fullName}";
        }
        public string EnterEmail(string email)
        {
            var element = Driver.FindElement(EmailInput);
            element.Clear();
            element.SendKeys(email);
            return $"Email:{email}";
        }

        public string EnterCurrentAddress(string currentAddress)
        {
            var element = Driver.FindElement(CurrentAddressInput);
            element.Clear();
            element.SendKeys(currentAddress);
            return $"Current Address :{currentAddress}";
        }

        public string EnterPermanentAddress(string permanentAddress)
        {
            var element = Driver.FindElement(PermanentAddressInput);
            element.Clear();
            element.SendKeys(permanentAddress);
            return $"Permananet Address :{permanentAddress}";
            //The return shhould be "Permanent Address :{permanentAddress}" but there is a typo in the DOM. Just for good picture I will leave it as it is.
        }

        public TextBoxPage SubmitForm()
        {
            IWebElement element = Driver.FindElement(SubmitButton);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
            return this;
        }

        //Get outputs
        public string GetFullNameOutput()
        {
            var element = Driver.FindElement(Output);
            var fullNameOutput = element.FindElement(By.Id("name")).Text;
            return fullNameOutput;
        }

        public string GetEmailOutput()
        {
            var element = Driver.FindElement(Output);
            var emailOutput = element.FindElement(By.Id("email")).Text;
            return emailOutput;
        }

        public string GetCurrentAddressOutput()
        {
            var element = Driver.FindElement(Output);
            var currentAddressOutput = element.FindElement(By.Id("currentAddress")).Text;
            return currentAddressOutput;
        }

        public string GetPermanentAddressOutput()
        {
            var element = Driver.FindElement(Output);
            var permanentAddressOutput = element.FindElement(By.Id("permanentAddress")).Text;
            return permanentAddressOutput;
        }

        public TextBoxPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
