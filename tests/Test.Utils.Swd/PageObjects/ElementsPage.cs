using OpenQA.Selenium;
using System.Xml.Linq;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class ElementsPage : BasePage
{
    private WebElement TextBox
        => new(By.XPath("//span[contains(text(),\"Text Box\")]"), Driver!);

    private WebElement CheckBox
        => new(By.XPath("//span[contains(text(),\"Check Box\")]"), Driver!);

    private WebElement Element =>
        new(By.XPath("//div[@class='card mt-4 top-card']//div[@class='card-body']/h5[text()='Elements']"), Driver!);


    public CheckBoxPage ClickOnCheckBox()
    {
        CheckBox.Click();
        return new CheckBoxPage(Driver!);
    }



    public ElementsPage(IWebDriver driver)
    {
        Driver = driver;
    }
    
}