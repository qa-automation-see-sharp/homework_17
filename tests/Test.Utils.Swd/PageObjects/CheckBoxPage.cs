using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage
{
    
    private WebElement CheckBoxPageTitle
        => new(By.XPath("//h1[contains(text(),\"Check Box\")]"), Driver!);
    private WebElement ExpandButton
        => new(By.CssSelector("button[title='Expand all']"), Driver!);
    private WebElement CollapseButton
        => new(By.CssSelector("button[title='Collapse all']"), Driver!);
    private WebElement HomeCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/span/label/span[@class='rct-checkbox']"), Driver!);
    private WebElement DesktopCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/ol/li[1]/span[@class='rct-text']/label/span[@class='rct-checkbox']"), Driver!);
    private WebElement CommandsCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/ol/li[1]/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']"), Driver!);
    private WebElement ReactCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/ol/li[2]/ol/li[1]/ol/li[1]/span[@class='rct-text']/label/span[@class='rct-checkbox']"), Driver!);
    private WebElement DocumentsCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']"), Driver!);
    private WebElement DownloadsCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/ol/li[3]/span[@class='rct-text']/label/span[@class='rct-checkbox']"), Driver!);

    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }
    public bool CheckCheckBoxPageTitle()
    {
        var element = CheckBoxPageTitle;
        return element.Displayed;
    }
    public CheckBoxPage ExpandMenu()
    {
        ExpandButton.Click();
        Thread.Sleep(5000);
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

    public bool CheckExpandedMenuByCommandsCheckBox()
    {
        var element = CommandsCheckBox;
        return element.Displayed;
    }
    
    public bool CheckCollapseButton()
    {
        var element = CollapseButton;
        return element.Displayed && element.Enabled;
    }
    
    public bool CheckCollapsedMenuByReactCheckBox()
    {
        var element = ReactCheckBox;
        return element.Displayed;
    }
}