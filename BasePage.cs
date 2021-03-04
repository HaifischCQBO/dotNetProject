using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation_Test_Engineer
{
    public class BasePage
    {
        static IWebDriver _driver;
        static IWebElement _element;
        private TimeSpan waitingTimeInSeconds = TimeSpan.FromSeconds(20);
        string webAppUrl = TestContext.Parameters["webAppUrl"];
        private List<IWebElement> list;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            //1. Open Chrome
            _driver = new ChromeDriver(@"..\..\..\driver\");
            //2. Navigate to http://automationpractice.com/
            _driver.Navigate().GoToUrl(webAppUrl);
            _driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void Terminate()
        {
            //CLose browser, exit rutine
            _driver.Quit();

        }

        public void WaitUntilElementBeClickeable(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, waitingTimeInSeconds);

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

            return new WebDriverWait(_driver, waitingTimeInSeconds).Until(ExpectedConditions.TitleContains(pageTitle));

        }

        public void ClickBy(By by)
        {
            WaitUntilElementBeClickeable(by);
            _driver.FindElement(by).Click();

        }

        public void ClickBy(IWebElement element)
        {

            element.Click();

        }

        public void SendKeys(By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(_driver, waitingTimeInSeconds);

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
            WebDriverWait wait = new WebDriverWait(_driver, waitingTimeInSeconds);

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

        public void SelectElement(By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(_driver, waitingTimeInSeconds);

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
            WebDriverWait wait = new WebDriverWait(_driver, waitingTimeInSeconds);

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

        public void Dev(string text)
        {
            Debug.Write("\r\n DEV: " + text);
        }

        public ReadOnlyCollection<IWebElement> waitUntilPresenceofAllElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, waitingTimeInSeconds);
            ReadOnlyCollection<IWebElement> _list;

            _list = wait.Until(e => e.FindElements(by));

            return _list;

        }
        public List<IWebElement> returnList(By by)
        {
            waitUntilPresenceofAllElements(by);
            list = new List<IWebElement>(_driver.FindElements(by));
            Dev("Number of Element on the list: " + list.Count);
            return list;


        }

        public void MouseOverElementToElement(IWebElement element1, IWebElement element2)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element1).MoveToElement(element2).Click().Build().Perform();

        }
        public void MouseOverElementToElement(IWebElement element, By by)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Build().Perform();
            WaitUntilElementBeClickeable(by);
            IWebElement element2 = _driver.FindElement(by);
            action.MoveToElement(element2).Click().Build().Perform();

        }

        public int CheckProductQuantity(By by)
        {
            Pause(1000);
            _element = _driver.FindElement(by);
            string n_products = _element.Text;
            if (n_products.Contains("empty"))
            {

                return 0;
            }
            else
            {
                Dev("Number of Elements in the Cart: " + n_products);
                return int.Parse(n_products);

            }


        }
    }
}
