using OpenQA.Selenium;
using System.Xml.Linq;
using Test.Utils.PageObjects;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class ElementsPage : BasePage
{
    private WebElement TextBox
        => new(By.XPath("//span[contains(text(),\"Text Box\")]"), Driver!);

    private WebElement CheckBox
        => new(By.XPath("//span[contains(text(),\"Check Box\")]"), Driver!);

    public ElementsPage(IWebDriver driver)
    {
        Driver = driver;
    }
    public CheckBoxPage ClickOnCheckBox()
    {
        CheckBox.Click();
        return new CheckBoxPage(Driver!);
    }
}