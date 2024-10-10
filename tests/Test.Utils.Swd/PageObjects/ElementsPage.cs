using OpenQA.Selenium;
using Test.Utils.Swd.PageObjects.ElementGroup;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class ElementsPage : BasePage
{
    public ElementsPage(IWebDriver driver)
    {
        Driver = driver;
    }

    private WebElement TextBox
        => new(By.XPath("//span[contains(text(),\"Text Box\")]"), Driver!);

    private WebElement CheckBox
        => new(By.XPath("//span[contains(text(),\"Check Box\")]"), Driver!);

    private By Accordion => By.XPath("//div[@class=\"accordion\"]");

    public bool CheckAccordion()
    {
        return Driver.FindElement(Accordion).Displayed;
    }

    public TextBoxPage ClickOnTextBox()
    {
        TextBox.Click();
        return new TextBoxPage(Driver!);
    }

    public CheckBoxPage ClickOnCheckBox()
    {
        CheckBox.Click();
        return new CheckBoxPage(Driver!);
    }
}