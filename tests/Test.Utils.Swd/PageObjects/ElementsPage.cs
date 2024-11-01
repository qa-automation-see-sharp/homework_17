using OpenQA.Selenium;
using System.Xml.Linq;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class ElementsPage : BasePage
{
    private WebElement TextBox
        => new(By.XPath("//span[contains(text(),\"Text Box\")]"), Driver!);

    private WebElement Accordion
        => new(By.XPath("//div[@class=\"accordion\"]"), Driver!);

    public TextBoxPage ClickOnTextBox()
    {
        TextBox.Click();
        return new TextBoxPage(Driver!);
    }

    public string GetCurrentUrl()
    {
        return Driver.Url;
    }

    public bool CheckAccordion()
    {
        return Accordion.Displayed && Accordion.Enabled;
    }

    public bool CkeckTextBox()
    {
        return TextBox.Displayed && TextBox.Enabled;
    }

    public ElementsPage(IWebDriver driver)
    {
        Driver = driver;
    }
}