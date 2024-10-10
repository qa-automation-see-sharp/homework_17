using OpenQA.Selenium;
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
        => new(
            By.XPath(
                "//div[@id='app']/div[@class='body-height']/div[@class='container playgound-body']/div[@class='row']//div[@class='accordion']/div[1]/div/ul[@class='menu-list']/li[2]/span[@class='text']"),
            Driver!);

    public CheckBoxPage OpenCheckBoxPage()
    {
        CheckBox.Click();
        return new CheckBoxPage(Driver!);
    }
}