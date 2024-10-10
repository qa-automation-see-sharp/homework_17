using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Test.Utils.Swd.WebElements;

namespace Test.Utils.Swd.PageObjects.ElementGroup;

public class TextBoxPage : BasePage
{
    public TextBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }

    private By TextBoxTitle => By.XPath("//h1[contains(text(),\"Text Box\")]");
    private By TextBoxForm => By.Id("userForm");
    private By FullNameLable => By.Id("userName-label");
    private By FullNameInput => By.Id("userName");
    private By EmailLable => By.Id("userEmail-label");
    private By EmailInput => By.Id("userEmail");
    private By CurrentAddressLable => By.Id("currentAddress-label");
    private By CurrentAddressInput => By.Id("currentAddress");
    private By PermanentAddressLable => By.Id("permanentAddress-label");
    private By PermanentAddressInput => By.Id("permanentAddress");
    private By SubmitButton => By.Id("submit");
    private By OutPutName => By.Id("name");
    private By OutPutEmail => By.Id("email");
    private By OutPutCurrentAddress => By.CssSelector("p#currentAddress");
    private By OutPutPrermanentAddress => By.CssSelector("p#permanentAddress");

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

    public TextBoxPage SubmitClick()
    {
        var submit = Driver.FindElement(SubmitButton);
        var deltaY = submit.Location.Y;
        new Actions(Driver)
            .ScrollByAmount(0, deltaY)
            .Perform();
        submit.Click();
        return this;
    }

    public void BrowserQuit()
    {
        Driver.Close();
        Driver.Quit();
    }

    #region Enter text to fields

    public TextBoxPage EnterCurrentAddress(string currentAddress)
    {
        Driver.FindElement(CurrentAddressInput).SendKeys(currentAddress);

        return this;
    }

    public TextBoxPage EnterEmail(string email)
    {
        Driver.FindElement(EmailInput).SendKeys(email);

        return this;
    }

    public TextBoxPage EnterFullName(string fullName)
    {
        Driver.FindElement(FullNameInput).SendKeys(fullName);

        return this;
    }

    public TextBoxPage EnterPermanentAddress(string permanentAddress)
    {
        Driver.FindElement(PermanentAddressInput).SendKeys(permanentAddress);

        return this;
    }

    #endregion

    #region Get Lables and OutPut

    public string GetFullNameLabelText()
    {
        return Driver.FindElement(FullNameLable).Text;
    }

    public string GetEmailLabelText()
    {
        return Driver.FindElement(EmailLable).Text;
    }

    public string GetCurrentAddressLabelText()
    {
        return Driver.FindElement(CurrentAddressLable).Text;
    }

    public string GetPermanentAddressLabelText()
    {
        return Driver.FindElement(PermanentAddressLable).Text;
    }

    public string GetOutPutName()
    {
        return Driver.FindElement(OutPutName).Text;
    }

    public string GetOutPutEmail()
    {
        return Driver.FindElement(OutPutEmail).Text;
    }

    public string GetOutPutCurrentAddress()
    {
        return Driver.FindElement(OutPutCurrentAddress).Text;
    }

    public string GetOutPutPermanentAddress()
    {
        return Driver.FindElement(OutPutPrermanentAddress).Text;
    }

    #endregion
}