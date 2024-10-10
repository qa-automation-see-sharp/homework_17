using OpenQA.Selenium;
using Test.Utils.Swd.WebDriver;
using static Test.Utils.Swd.Helpers.WaitHelper;
using static Test.Utils.Swd.WebDriver.WebDriverFactory;

namespace Test.Utils.Swd.WebElements;

public abstract class BasePage
{
    protected IWebDriver? Driver;

    public void OpenWith(BrowserNames name, params string[] args)
    {
        Driver = CreateWebDriver(name, args);
    }

    public string GetPageTitle()
    {
        return Wait(() => Driver!.Title, title => title is null);
    }

    public string GetPageUrl()
    {
        return Wait(() => Driver!.Url, url => url is null);
    }

    public void NavigateTo(string url)
    {
        Wait(() => Driver?.Navigate().GoToUrl(url));
    }

    public void RefreshPage()
    {
        Wait(() => Driver?.Navigate().Refresh());
    }

    public void GoBack()
    {
        Wait(() => Driver?.Navigate().Back());
    }

    public void GoForward()
    {
        Wait(() => Driver?.Navigate().Forward());
    }
}