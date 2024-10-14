using Test.Utils.Swd.WebElements;
using OpenQA.Selenium;
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
    private WebElement CollapseButton
        => new(By.CssSelector("button[title='Collapse all']"), Driver!);
    private WebElement CheckBoxIcon =>
       new(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/label/span[1]"), Driver!);

    private WebElement CheckBoxToggle =>
      new(By.XPath("//*[@id=\"tree-node\"]/ol/li/span/button"), Driver!);
    private WebElement HomeCheckBox
        => new (By.XPath("//div[@id='tree-node']/ol/li/span/label/span[@class='rct-checkbox']"), Driver!);
    private WebElement HomeCheckBoxMarked
        => new(By.CssSelector("[for='tree-node-home'] .rct-icon-check"), Driver!);
    private WebElement HomeCheckBoxUnarked
        => new(By.CssSelector("label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-uncheck"), Driver!);
    private WebElement folderDesktop
    => new(By.XPath("//span[contains(text(), 'Desktop')]"), Driver!);
    private WebElement folderDocuments
    => new(By.XPath("//span[contains(text(), 'Documents')]"), Driver!);
    private WebElement folderDownloads
        => new(By.XPath("//span[contains(text(), 'Downloads')]"), Driver!);


    public void CheckHome()
    {
        HomeCheckBox.Click();
    }
    public bool IsHomeChecked()
    {
        return HomeCheckBoxMarked.Displayed;
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
        IsElementDisplayed(By.XPath("//span[contains(text(), 'Desktop')]")),
        IsElementDisplayed(By.XPath("//span[contains(text(), 'Documents')]")),
        IsElementDisplayed(By.XPath("//span[contains(text(), 'Downloads')]"))
    };

        return folders.All(x => x);
    }


}