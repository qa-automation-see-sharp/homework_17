using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class CheckBoxPage:BasePage
{
    
    private WebElement CheckBoxPageTitle
        => new(By.XPath("//h1[contains(text(),\"Check Box\")]"), Driver!);
    private WebElement ExpandButton
        => new(By.CssSelector("button[title='Expand all']"), Driver!);
    private WebElement CollapseButton
        => new(By.CssSelector("button[title='Collapse all']"), Driver!);

    public bool CheckCheckBoxPageTitle()
    {
        var element = CheckBoxPageTitle;
        return element.Displayed;
    }
    public CheckBoxPage ExpandMenu()
    {
        ExpandButton.Click();
        return this;
    }
    
    public CheckBoxPage CollapseMenu()
    {
        CollapseButton.Click();
        return this;
    }

    public bool CheckExpandButton()
    {
        var element = ExpandButton;
        return element.Displayed && element.Enabled;
    }
    
    public bool CheckCollapseButton()
    {
        var element = CollapseButton;
        return element.Displayed && element.Enabled;
    }
}