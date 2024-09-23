using System.Drawing;
using OpenQA.Selenium;
using static Test.Utils.Swd.Helpers.WaitHelper;

namespace Test.Utils.Swd.WebElements;

public class WebElement
{
    private readonly IWebDriver _driver;
    private readonly By _by;
    private IWebElement _element;

    public string TagName => FindElement().TagName;
    public string Text => FindElement().Text;
    public bool Enabled => FindElement().Enabled;
    public bool Selected => FindElement().Selected;
    public bool Displayed => FindElement().Displayed;
    public Point Location => FindElement().Location;
    public Size Size => FindElement().Size;


    public WebElement(By by, IWebDriver driver)
    {
        _driver = driver;
        _by = by;
    }

    private IWebElement FindElement()
    {
        _element = Wait(
            () => _driver.FindElement(_by),
            element => element is null or { Displayed: false } or { Enabled: false });
        return _element;
    }

    public void Clear()
    {
        Wait(() => FindElement().Clear());
    }

    public void SendKeys(string text)
    {
        Wait(() => FindElement().SendKeys(text));
    }

    public void Submit()
    {
        Wait(()=> FindElement().Submit());
    }

    public void Click()
    {
        Wait(() => FindElement().Click());
    }

    public string GetAttribute(string attributeName)
    {
        return Wait(
            () => FindElement().GetAttribute(attributeName),
            attr => attr is not null);
    }

    public string GetDomAttribute(string attributeName)
    {
        return Wait(
            () => FindElement().GetDomAttribute(attributeName), 
            attr => attr is not null);
    }

    public string GetDomProperty(string propertyName)
    {
        return Wait(
            () => FindElement().GetDomProperty(propertyName), 
            prop => prop is not null);
    }

    public string GetCssValue(string propertyName)
    {
        return Wait(
            () => FindElement().GetCssValue(propertyName),
            value => value is not null);
    }

    public ISearchContext GetShadowRoot()
    {
        return Wait(
            () => FindElement().GetShadowRoot(),
            root => root is not null);
    }
}