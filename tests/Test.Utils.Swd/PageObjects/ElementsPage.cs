using OpenQA.Selenium;

namespace Test.Utils.Swd.PageObjects;

public class ElementsPage
{
    private readonly IWebDriver _driver;

    public ElementsPage(IWebDriver driver)
    {
        _driver = driver;
    }
}