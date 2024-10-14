using OpenQA.Selenium;

namespace Test.Utils.Swd.WebElements;

public class CheckBox(By by, IWebDriver driver) : WebElement(by, driver)
{
    public bool Marked => Selected;

    public void Mark()
    {
        if (!Marked)
        {
            Click();
        }
    }

    public void UnMark()
    {
        //TODO Marked return false
        if (Marked)
        {
            Click();
        }
    }
}