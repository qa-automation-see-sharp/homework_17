using System;
using OpenQA.Selenium;
using Test.Utils.Swd.WebElements;

namespace Test.Utils.Swd.PageObjects.ElementGroup;

public class CheckBoxPage : BasePage
{
    public CheckBoxPage(IWebDriver driver)
    {
        Driver = driver;
    }
}
