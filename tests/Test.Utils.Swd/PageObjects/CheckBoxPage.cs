using Test.Utils.Swd.WebElements;
using OpenQA.Selenium;

namespace Test.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage
{
    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }
    private By toggleHome => By.XPath("//button[contains(@class, 'rct-collapse-btn')]");
    private By folderDesktop => By.XPath("//span[contains(text(), 'Desktop')]");
    private By folderDocuments => By.XPath("//span[contains(text(), 'Documents')]");
    private By folderDownloads => By.XPath("//span[contains(text(), 'Downloads')]");
    private By uncheckedHome => By.CssSelector("label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-uncheck");
    private By uncheckedDesktop => By.CssSelector("label[for='tree-node-desktop'] .rct-checkbox svg.rct-icon.rct-icon-uncheck");
    private By uncheckedDocuments => By.CssSelector("label[for='tree-node-documents'] .rct-checkbox svg.rct-icon.rct-icon-uncheck");
    private By uncheckedDownloads => By.CssSelector("label[for='tree-node-downloads'] .rct-checkbox svg.rct-icon.rct-icon-uncheck");
    private By checkedHome => By.CssSelector("label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-check");
    private By checkedDesktop => By.CssSelector("label[for='tree-node-desktop'] .rct-checkbox svg.rct-icon.rct-icon-check");
    private By checkedDocuments => By.CssSelector("label[for='tree-node-documents'] .rct-checkbox svg.rct-icon.rct-icon-check");
    private By checkedDownloads => By.CssSelector("label[for='tree-node-downloads'] .rct-checkbox svg.rct-icon.rct-icon-check");
    private By output => By.XPath("//*[@id='result']");

    public void ToggleHome()
    {
        Driver.FindElement(toggleHome).Click();
    }

    public bool IsDisplayedFolderList()
    {
        bool IsElementDisplayed(By by)
        {
            var elements = Driver.FindElements(by);
            return elements.Count > 0 && elements[0].Displayed;
        }

        var folders = new List<bool>()
        {
            IsElementDisplayed(folderDesktop),
            IsElementDisplayed(folderDocuments),
            IsElementDisplayed(folderDownloads)
        };

        return folders.All(x => x);
    }

    public void CheckHome()
    {
        Driver.FindElement(uncheckedHome).Click();
    }

    public bool IsHomeChecked()
    {
        return Driver.FindElement(checkedHome).Displayed;
    }

    public bool IsDesktopChecked()
    {
        return Driver.FindElement(checkedDesktop).Displayed;
    }

    public bool IsDocumentsChecked()
    {
        return Driver.FindElement(checkedDocuments).Displayed;
    }

    public bool IsDownloadsChecked()
    {
        return Driver.FindElement(checkedDownloads).Displayed;
    }

    public bool OutputContainsCheckedElements()
    {
        var outputHome = "home";
        var outputDesktop = Driver.FindElement(folderDesktop).Text.ToLower();
        var outputDocuments = Driver.FindElement(folderDocuments).Text.ToLower();
        var outputDownloads = Driver.FindElement(folderDownloads).Text.ToLower(); 
        var outputText = "You have selected";
        var element = Driver.FindElement(output);
        return  element.Text.Contains(outputText) && 
                element.Text.Contains(outputDesktop) &&
                element.Text.Contains(outputDocuments) &&
                element.Text.Contains(outputDownloads) &&
                element.Text.Contains(outputHome);
    }
}