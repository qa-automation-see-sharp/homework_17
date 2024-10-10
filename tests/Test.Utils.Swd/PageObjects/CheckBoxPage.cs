using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage
{
    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }

    private WebElement CheckBoxPageTitle
        => new(By.XPath("//h1[contains(text(),\"Check Box\")]"), Driver!);

    private WebElement ExpandButton
        => new(By.CssSelector("button[title='Expand all']"), Driver!);

    private WebElement CollapseButton
        => new(By.CssSelector("button[title='Collapse all']"), Driver!);

    private CheckBox HomeCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/span/label/span[@class='rct-checkbox']"), Driver!);

    private CheckBox HomeCheckBoxMarked
        => new(By.CssSelector("[for='tree-node-home'] .rct-icon-check"), Driver!);

    private WebElement HomeFolderIconInACollapsedMenu
        => new(By.CssSelector(".rct-icon.rct-icon-parent-close > path"), Driver!);

    private CheckBox DesktopCheckBox
        => new(
            By.XPath("//div[@id='tree-node']/ol/li/ol/li[1]/span[@class='rct-text']/label/span[@class='rct-checkbox']"),
            Driver!);

    private CheckBox CommandsCheckBox
        => new(
            By.XPath(
                "//div[@id='tree-node']/ol/li/ol/li[1]/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']"),
            Driver!);

    private CheckBox ReactCheckBox
        => new(By.XPath("//div[@id='tree-node']/ol/li/ol/li[2]/ol/li[1]/ol/li[1]/span[@class='rct-text']"), Driver!);

    private CheckBox DocumentsCheckBox
        => new(
            By.XPath("//div[@id='tree-node']/ol/li/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']"),
            Driver!);

    private CheckBox DocumentsCheckBoxMarked
        => new(
            By.CssSelector(
                "[for='tree-node-documents'] [d='M19 3H5c-1\\.11 0-2 \\.9-2 2v14c0 1\\.1\\.89 2 2 2h14c1\\.11 0 2-\\.9 2-2V5c0-1\\.1-\\.89-2-2-2zm-9 14l-5-5 1\\.41-1\\.41L10 14\\.17l7\\.59-7\\.59L19 8l-9 9z']"),
            Driver!);

    private CheckBox DownloadsCheckBox
        => new(
            By.XPath("//div[@id='tree-node']/ol/li/ol/li[3]/span[@class='rct-text']/label/span[@class='rct-checkbox']"),
            Driver!);

    private WebElement DescriptionOfSelectedItems
        => new(By.XPath("//div[@id='result']/span[.='You have selected :']"), Driver!);

    public bool CheckCheckBoxPageTitle()
    {
        var element = CheckBoxPageTitle;
        return element.Displayed;
    }

    public void ExpandMenu()
    {
        ExpandButton.Click();
        Thread.Sleep(2000);
    }

    public void CollapseMenu()
    {
        CollapseButton.Click();
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

    public bool CheckCollapsedMenuByTheHomeFolderIcon()
    {
        var element = HomeFolderIconInACollapsedMenu;
        return element.Displayed;
    }

    public void MarkHomeCheckbox()
    {
        HomeCheckBox.Mark();
        Thread.Sleep(3000); //TODO: remove this sleep %)
    }

    public bool CheckTheDescriptionOfSelectedItems()
    {
        var element = DescriptionOfSelectedItems;
        return element.Displayed;
    }

    public bool CheckTheTextOfTheDescription()
    {
        var element = DescriptionOfSelectedItems;
        return element.Text.Equals("You have selected :");
    }

    public bool VerifyTheHomeCheckBoxIsMarked()
    {
        var element = HomeCheckBoxMarked;
        return element.Displayed;
    }

    public bool VerifyTheDocumentsCheckBoxIsMarked()
    {
        var element = DocumentsCheckBoxMarked;
        return element.Displayed;
    }

    public void UnMarkHomeCheckbox()
    {
        HomeCheckBox.UnMark();
        Thread.Sleep(5000); //TODO: remove this sleep %)
    }
}