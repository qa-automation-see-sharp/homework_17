using OpenQA.Selenium;
using Test.Utils.Swd.WebDriver;
using Test.Utils.Swd.WebElements;
using WebElement = Test.Utils.Swd.WebElements.WebElement;

namespace Test.Utils.Swd.PageObjects;

public class MainPage : BasePage
{
    private string Url => "https://demoqa.com/";

    private WebElement Elements
        => new(By.XPath("//div[@class=\"card mt-4 top-card\"]/div/div/h5[contains(text(),\"Elements\")]"), Driver!);


    public ElementsPage ClickOnElements()
    {
        Elements.Click();
        return new ElementsPage(Driver!);
    }


    public void Close()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }

    public void Open()
    {
        NavigateTo(Url);
    }
}