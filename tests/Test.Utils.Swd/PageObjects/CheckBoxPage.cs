using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Test.Utils.Swd.WebElements;

namespace Test.Utils.Swd.PageObjects
{
    public class CheckBoxPage : BasePage
    {
        private readonly string Url = "https://demoqa.com/checkbox";
        private By ToggleHome => By.XPath("//button[@class='rct-collapse rct-collapse-btn']");
        public By Home => By.XPath("//span[@class='rct-title' and text() ='Home']");
        public By ExpandeAll => By.XPath("//button[@title = 'Expand all']");
        private By CollapseAll => By.XPath("//button[@title = 'Collapse all']");
        private By ExpandeAllList => By.XPath("//li[@class='rct-node rct-node-parent rct-node-expanded']");
        private By CollapseAllList => By.XPath("//li[@class='rct-node rct-node-parent rct-node-collapsed']");
        private By HomeCheckBox => By.XPath("//label[@for='tree-node-home']");
        private By Result => By.XPath("//div[@id='result']");

        protected List<string> AllElementsTitle = new List<string>
        {
            "Desktop",
            "Notes",
            "Commands",
            "Documents",
            "WorkSpace",
            "React",
            "Angular",
            "Veu",
            "Office",
            "Public",
            "Private",
            "Classified",
            "General",
            "Downloads",
            "Word File.doc",
            "Excel File.doc"
        };

        public List<string> PresentElements = new List<string>();

        protected List<string> NodeTreeElements = new List<string>
         {
             "desktop",
             "notes",
             "commands",
             "documents",
             "workspace",
             "react",
             "angular",
             "veu",
             "office",
             "public",
             "private",
             "classified",
             "general",
             "downloads",
             "wordFile",
             "excelFile"
         };

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public void ClickOnHome()
        {
            Driver.FindElement(Home).Click();
        }

        public void ClickOnExpandeAll()
        {
            Driver.FindElement(ExpandeAll).Click();
        }

        public bool CheckIfElementPresent(string elementName)
        {
            var element = Driver.FindElement(By.XPath($"//span[@class='rct-title' and text() ='{elementName}']"));
            return element.Displayed && element.Enabled;
        }

        public bool CheckIfAllElementsExpanded()
        {
            foreach (var element in AllElementsTitle)
            {
                if (CheckIfElementPresent(element))
                {
                    PresentElements.Add(element);
                }
            }

            bool result = PresentElements.Count == AllElementsTitle.Count;
            return result;
        }

        public bool CheckIfAllStructureExpande()
        {
            var elements = Driver.FindElement(ExpandeAllList);
            return elements.Displayed && elements.Enabled;
        }

        public bool CheckIfAllStructureCollapse()
        {
            var elements = Driver.FindElement(CollapseAllList);
            return elements.Displayed && elements.Enabled;
        }

        public void ClickOnCollapseAll()
        {
            Driver.FindElement(CollapseAll).Click();
        }
        public void ClickOnToggleHome()
        {
            Driver.FindElement(ToggleHome).Click();
        }

        public void ClickOnHomeCheckBox()
        {
            Driver.FindElement(HomeCheckBox).Click();
        }

        public bool CheckIfAllChecked()
        {
            foreach (var element in NodeTreeElements)
            {
                var elementPath = Driver.FindElement(By.XPath($"//label[@for='tree-node-{element}']/span[@class='rct-checkbox']/*[contains(@class, 'rct-icon-check')]"));
                if (elementPath.Displayed && elementPath.Enabled)
                {
                    PresentElements.Add(element);
                }
            }
            bool result = PresentElements.Count == AllElementsTitle.Count;
            return result;
        }

        public bool CheckIfResultIsDisplayed()
        {
            try
            {
                var result = Driver.FindElement(By.XPath("//div[@id='result']"));
                if (result == null || !result.Displayed || !result.Enabled)
                {
                    return false;
                }

                var spanText = result.FindElement(By.XPath(".//span[text()='You have selected :']"));
                if (spanText == null || !spanText.Displayed || !spanText.Enabled)
                {
                    return false;
                }

                foreach (var element in NodeTreeElements)
                {
                    var elementPath = result.FindElement(By.XPath($".//span[text()='{element}']"));
                    if (elementPath == null || !elementPath.Displayed) 
                    {
                        return false; 
                    }
                }
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckIfAllUnchecked()
        {
            foreach (var element in NodeTreeElements)
            {
                var elementPath = Driver.FindElement(By.XPath($"//label[@for='tree-node-{element}']/span[@class='rct-checkbox']/*[contains(@class, 'rct-icon-uncheck')]"));
                if (elementPath.Displayed && elementPath.Enabled)
                {
                    PresentElements.Add(element);
                }
            }
            bool result = PresentElements.Count == AllElementsTitle.Count;
            return result;
        }

        public void ClickOnElement(By elementName)
        {
            //doesnt work for some elements
            //Driver.FindElement(elementName).Click();

            var element = Driver.FindElement(elementName); 
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            //time 2.5sec
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

            //time 52.7sec
            //WaitHelper.Wait(() => element, e => e.Displayed && e.Enabled);
            element.Click();
        }

        public bool CheckIfElementChecked(string element)
        {
            var elementPath = Driver.FindElement(By.XPath($"//label[@for='tree-node-{element}']/span[@class='rct-checkbox']/*[contains(@class, 'rct-icon-check')]"));
            return elementPath.Displayed && elementPath.Enabled;
        }

        public bool CheckIfResultIsDisplayed(string elementName)
        {
            try
            {
                var result = Driver.FindElement(Result);
                if (result == null || !result.Displayed || !result.Enabled)
                {
                    return false;
                }

                var spanText = result.FindElement(By.XPath(".//span[text()='You have selected :']"));
                if (spanText == null || !spanText.Displayed || !spanText.Enabled)
                {
                    return false;
                }

                var elementPath = result.FindElement(By.XPath($".//span[text()='{elementName}']"));
                if (elementPath == null || !elementPath.Displayed)
                { 
                    return false; 
                }
                return true;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckIfAncestorsAreHalfChecked(string elementChecked)
        {
            var element = Driver.FindElement(By.XPath($"//span[text()='{elementChecked}']"));
            var ancestors = element.FindElements(By.XPath($"//ancestor::li[contains(@class, 'rct-node-parent')]//*[contains(@class, 'rct-icon-half-check')]"));
            int ancestorsCount = ancestors.Count;
            if (ancestors.Count == 0)
            {
                return false;
            }
            return true;
        }

        public CheckBoxPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
