using OpenQA.Selenium;

namespace Test.Utils.Swd.WebElements;

public class Buttons : WebElement
{
    public new string Text => FindElement().Text;
    
    public Buttons(By by, IWebDriver driver) : base(by, driver) { }

    public new void Click()
    {
        FindElement().Click();
    }
}