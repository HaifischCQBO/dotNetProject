using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation_Test_Engineer
{
    public class BasePage
    {
        static IWebDriver _driver;
        private string root = Environment.CurrentDirectory;
        private int waitingTimeInSeconds = 20;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(@"..\..\..\driver\");
            _driver.Navigate().GoToUrl("https://sdetteamintl.z22.web.core.windows.net/");
        }
        [TearDown]
        public void Terminate()
        {
            _driver.Quit();

        }

        public void WaitUntilElementBeClickeable(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTimeInSeconds));

            try
            {
                IWebElement Element = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Wait: element located by {by.ToString()} not visible and enabled within {waitingTimeInSeconds.ToString()} waitingTimeInSecondsonds.");
            }
        }


        public bool WaitUntilPageTitle(string pageTitle)
        {

           return  new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTimeInSeconds)).Until(ExpectedConditions.TitleContains(pageTitle));

        }

        public void ClickBy(By by)
        {
            WaitUntilElementBeClickeable(by);
            _driver.FindElement(by).Click();

        }

        public void SendKeys(By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTimeInSeconds));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(valueToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by.ToString()} not visible and enabled within {waitingTimeInSeconds} waitingTimeInSecondsonds.");
            }
        }

        public string getText(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTimeInSeconds));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                return myElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by.ToString()} not visible and enabled within {waitingTimeInSeconds} waitingTimeInSecondsonds.");
                return null;
            }
        }

        public void SelectElement(By by, string valueToType )
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTimeInSeconds));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.SendKeys(valueToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by.ToString()} not visible and enabled within {waitingTimeInSeconds} waitingTimeInSecondsonds.");
            }
        }

        public void isDisplayed(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitingTimeInSeconds));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
              
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in isDisplayued(): element located by {by.ToString()} not visible and enabled within {waitingTimeInSeconds} sec.");
            }
        }

        //THIS METHOD IS JUST FOR DEBUGGING *****NOT FOR USE******
        public void Pause(int miliwaitingTimeInSeconds)
        {

            Thread.Sleep(miliwaitingTimeInSeconds);
        }

        public void changeToLastWindow()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }
        public string getWindowTitle()
        {
            return _driver.Title;
        }
    }
}
