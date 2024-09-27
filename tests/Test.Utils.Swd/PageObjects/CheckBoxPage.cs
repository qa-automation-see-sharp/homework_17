using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class CheckBoxPage:BasePage
{
    
    private WebElement ExpandButton
        => new(By.CssSelector("button[title='Expand all']"), Driver!);

    public CheckBoxPage ExpandMenu()
    {
        ExpandButton.Click();
        return this;
    }

    public bool CheckExpandButton()
    {
        var element = ExpandButton;
        return element.Displayed && element.Enabled;
    }
}