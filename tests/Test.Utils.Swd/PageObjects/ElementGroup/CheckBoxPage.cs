using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Test.Utils.Swd.WebElements;

namespace Test.Utils.Swd.PageObjects.ElementGroup;

public class CheckBoxPage : BasePage
{
    private readonly By CheckBox = By.XPath("//*[contains(@class,'icon-check')]");
    private readonly By HalfCheckBox = By.XPath("//*[contains(@class,'half-check')]");

    private readonly By RctCheckBox =
        By.XPath(
            "//*[@class='rct-icon rct-icon-uncheck' or @class='rct-icon rct-icon-check' or @class='rct-icon rct-icon-half-check']");

    private readonly By Result = By.Id("result");
    private readonly By UnCheck = By.XPath("//*[contains(@class,'-uncheck')]");

    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }

    private By CheckBoxTitle => By.CssSelector("h1.text-center");
    private By ExpandAllButton => By.CssSelector("button.rct-option.rct-option-expand-all");
    private By CollapseAllButton => By.CssSelector("button.rct-option.rct-option-collapse-all");

    private By NodeName(string name)
    {
        return By.XPath($"//label[starts-with(@for, 'tree-node-{name}')]");
    }

    public string ResultText()
    {
        return Driver.FindElement(Result).Text;
    }

    public CheckBoxPage CollapseAllClick()
    {
        Driver.FindElement(CollapseAllButton).Click();
        return this;
    }

    public CheckBoxPage ExpandAllClick()
    {
        Driver.FindElement(ExpandAllButton).Click();
        return this;
    }

    public string GetTitleCheckBox()
    {
        return Driver.FindElement(CheckBoxTitle).Text;
    }

    public bool IsExpandAll()
    {
        return Driver.FindElements(RctCheckBox).Count == 17;
    }

    public void CheckHomeClick()
    {
        Driver.FindElements(RctCheckBox).FirstOrDefault().Click();
    }

    public string GetResultText()
    {
        return Driver.FindElement(Result).Text;
    }

    public void CheckItemByName(string name)
    {
        var count = Driver.FindElements(RctCheckBox).Count;
        if (count == 1) ExpandAllClick();
        var ele = Driver.FindElement(NodeName(name.ToLower()));
        new Actions(Driver)
            .ScrollByAmount(0, ele.Location.Y / 5)
            .Perform();
        ele.Click();
    }

    public bool IsDisplayResult()
    {
        return Driver.FindElement(Result).Displayed;
    }

    public bool IsNodeHalfCheck(string nameNode)
    {
        return Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(HalfCheckBox).Displayed
               && Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(HalfCheckBox).Enabled;
    }

    public bool IsNodeChecked(string nameNode)
    {
        return Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(CheckBox).Displayed
               && Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(CheckBox).Enabled;
    }

    public bool IsNodeUncheck(string nameNode)
    {
        return Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(UnCheck).Displayed
               && Driver.FindElement(NodeName(nameNode.ToLower())).FindElement(UnCheck).Enabled;
    }
}