//using OtpNet;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace DemoQATests
{
    public class UtilityMethods : BaseClass
    {
        public TimeSpan timeSpan = TimeSpan.FromSeconds(3);

        #region Find By

        public IWebElement FindById(string id)
        {
            WaitForElementDisplayedById(id);
            return driver.FindElement(By.Id(id));
        }

        public IWebElement FindByClassName(string className)
        {
            WaitForElementDisplayedByClassName(className);
            return driver.FindElement(By.ClassName(className));
        }

        public IWebElement FindByLinkText(string linkText)
        {
            WaitForElementDisplayedByLinkText(linkText);
            return driver.FindElement(By.LinkText(linkText));
        }

        public IWebElement FindByPartialLinkText(string partialLinkText)
        {
            WaitForElementDisplayedByPartialLinkText(partialLinkText);
            return driver.FindElement(By.PartialLinkText(partialLinkText));
        }

        public IWebElement FindByXPath(string xpath)
        {
            WaitForElementDisplayedByXpath(xpath);
            return driver.FindElement(By.XPath(xpath));
        }

        public IWebElement FindByName(string name)
        {
            WaitForElementDisplayedByName(name);
            return driver.FindElement(By.Name(name));
        }

        public IWebElement FindByCssSelector(string cssSelector)
        {
            WaitForElementDisplayedByCssSelector(cssSelector);
            return driver.FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement FindByTagName(string tagName)
        {
            //WaitForElementDisplayedByTagName(tagName);
            return driver.FindElement(By.TagName(tagName));
        }

        #endregion Find By

        #region Javascript Methods

        public void jsHoverByClassName(string className)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";

            IWebElement element = FindByClassName(className);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(javaScript, element);
        }

        public void jsClickById(string id)
        {
            IWebElement element = driver.FindElement(By.Id(id));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }

        public void jsClickByPartiaLinkText(string partialLinkText)
        {
            IWebElement element = driver.FindElement(By.PartialLinkText(partialLinkText));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }

        public void jsClickByXPath(string xpath)
        {
            IWebElement element = driver.FindElement(By.PartialLinkText(xpath));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", element);
        }

        #endregion Javascript Methods

        #region Waits

        public void WaitForElementDisplayedById(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.Id(id));
                    return elementToBeDisplayed.Displayed;
                }
                catch (ElementClickInterceptedException)
                {
                    var elementToBeDisplayed = driver.FindElement(By.Id(id));
                    return elementToBeDisplayed.Displayed;
                }
                catch (ElementNotInteractableException)
                {
                    var elementToBeDisplayed = driver.FindElement(By.Id(id));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByPartialLinkText(string partialLinkText)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.PartialLinkText(partialLinkText));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByCssSelector(string cssSelector)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.CssSelector(cssSelector));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByLinkText(string linkText)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.LinkText(linkText));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.ClassName(className));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByXpath(string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.XPath(xpath));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByName(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.Name(name));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForElementDisplayedByTagName(string tagName)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.TagName(tagName));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void WaitForLoadingBar()
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);

            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = FindByClassName("pace-progress");
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        private bool IsAlertShown()
        {
            try
            {
                driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            return true;
        }

        public void WaitForAlert()
        {
            var wait = new WebDriverWait(driver, timeSpan);
            wait.Until(driver => IsAlertShown());
        }

        #endregion Waits

        public void SwitchToNewTab() => driver.SwitchTo().Window(driver.WindowHandles[1]);

        public void SwitchToNewWindow() => driver.SwitchTo().Window(driver.WindowHandles[0]);

        public void CloseTab()
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Alt).SendKeys(Keys.F4).Build().Perform();
        }

        public static string workingDirectory = Directory.GetCurrentDirectory();
        public string imagePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"/Resources/Toolsqa.jpg";
    }
}