using OpenQA.Selenium;

namespace Test.Utils.Swd.WebElements;

public class CheckBox : WebElement
{
    public CheckBox(By by, IWebDriver driver) : base(by, driver) { }

    public bool Checked => FindElement().Selected;

    public void Check()
    {
        if (!Checked)
        {
            Click();
        }
    }

    public void Uncheck()
    {
        if (Checked)
        {
            Click();
        }
    }
}