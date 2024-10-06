using System;
using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;

namespace Test.Utils.Swd.PageObjects.ElementGroup;

public class CheckBoxPage : BasePage
{
    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }

    private By CheckBoxTitle => By.CssSelector("h1.text-center");
    private By ExpandAllButton => By.CssSelector("button.rct-option.rct-option-expand-all");
    private By CollapseAllButton => By.CssSelector("button.rct-option.rct-option-collapse-all");
    private By RctTitle = By.ClassName(".rct-title");
    private By RctCollapseButton = By.ClassName(".rct-collapse.rct-collapse-btn");
    private By RctCheckBox = By.XPath("//*[@class='rct-icon rct-icon-uncheck' or @class='rct-icon rct-icon-check' or @class='rct-icon rct-icon-half-check']");
    private By Result = By.Id("result");
   // private By UnCheck = By.ClassName(".rct-icon.rct-icon-uncheck");
    //private By CheckBox= By.ClassName(".rct-icon.rct-icon-check");
    //private By HalfCheckBox = By.ClassName(".rct-icon.rct-icon-half-check");

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

    public string GetTitleCheckBox(){
        return Driver.FindElement(CheckBoxTitle).Text;
    }

    public bool IsExpandAll (){
        return Driver.FindElements(RctCheckBox).Count == 17;
    }

    public void CheckHomeClick(){
        Driver.FindElements(RctCheckBox).FirstOrDefault().Click();
    }

    public string GetResultText(){
        return Driver.FindElement(Result).Text;
    }

    public bool IsDisplayResult(){
        return Driver.FindElement(Result).Displayed;
    }

}
