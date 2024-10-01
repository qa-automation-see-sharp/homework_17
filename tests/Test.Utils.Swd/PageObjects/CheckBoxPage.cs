using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;
using static System.Net.WebRequestMethods;

namespace Test.Utils.PageObjects;

public class CheckBoxPage : BasePage
{
    private readonly string Url = "https://demoqa.com/checkbox";
    private By CheckBoxTitle => By.XPath("//h1[contains(text(),\"Check Box\")]");
    private By HomeBoxTitle => By.XPath("//span[@class='rct-title' and text()='Home']");
    private By ExpandAllButton => (By.XPath("//button[@aria-label='Expand all' and @title='Expand all']"));
    private By CollapseAllButton => (By.XPath("//button[@aria-label='Collapse all' and @title='Collapse all']"));
    private By DesktopFolder => By.XPath("//span[contains(text(), 'Desktop')]");
    private By DocumentsFolder => By.XPath("//span[contains(text(), 'Documents')]");
    private By DownloadsFolder => By.XPath("//span[contains(text(), 'Downloads')]");
    private By HomeCheckBox => By.XPath("//label[@for='tree-node-home']");
    private By NotesCheckBox => By.XPath("//label[@for='tree-node-notes']"); 
    private By DesktopCheckBox => By.XPath("//label[@for='tree-node-desktop']");
    private By DocumentsCheckBox => By.XPath("//label[@for='tree-node-documents']");
    private By DownloadsCheckBox => By.XPath("//label[@for='tree-node-downloads']");
    private By Result => By.XPath("//*[@id='result']");

    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }

    public bool VerifyCheckBoxTitle()
    {
        var element = Driver.FindElement(CheckBoxTitle);
        return element.Displayed && element.Enabled;
    }

    public bool CheckHomeBoxTitle()
    {
        var element = Driver.FindElement(HomeBoxTitle);
        return element.Displayed && element.Enabled;
    }

    public string ResultText()
    {
        return Driver.FindElement(Result).Text;
    }

    public CheckBoxPage ExpandAll()
    {
        var toggle = Driver.FindElement(ExpandAllButton);
        toggle.Click();

        return this;
    }

    public CheckBoxPage CollapseAll()
    {
        var toggle = Driver.FindElement(CollapseAllButton);
        toggle.Click();

        return this;
    }

    public bool CheckUnrolledFolders()
    {
        var elements = new List<IWebElement>
    {
        Driver.FindElements(DesktopFolder).FirstOrDefault(),
        Driver.FindElements(DocumentsFolder).FirstOrDefault(),
        Driver.FindElements(DownloadsFolder).FirstOrDefault()
    }.Where(e => e != null).ToList();

        return elements.Any() && elements.All(IsElementVisible);
    }

    private bool IsElementVisible(IWebElement element)
    {
        return element.Displayed && element.Enabled;
    }

    public CheckBoxPage CheckHomeBox()
    {
        var homeBox = Driver.FindElement(HomeCheckBox);
        homeBox.Click();

        return this;
    }

    public CheckBoxPage CheckNotesBox()
    {
        var notesBox = Driver.FindElement(NotesCheckBox);
        notesBox.Click();

        return this;
    }

    public bool CheckAllBoxesAreChecked()
    {
        var checkBoxes = new List<By>
        {
            HomeCheckBox,
            DesktopCheckBox,
            DocumentsCheckBox,
            DownloadsCheckBox
        };

        return checkBoxes.All(IsCheckboxChecked);
    }

    private bool IsCheckboxChecked(By checkbox)
    {
        var element = Driver.FindElements(checkbox).FirstOrDefault();
        return element != null && element.Displayed && element.Enabled;
    }

    public void ReloadPage()
    {
        Driver.Navigate().GoToUrl(Url);
    }
}