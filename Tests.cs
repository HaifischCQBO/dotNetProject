using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation_Test_Engineer
{
    public class Tests : BasePage
    {
        private readonly By firstName =
        By.Id("firstName");
        private readonly By lastName =
        By.Name("lastName");
        private readonly By cellPhone =
        By.CssSelector("[type='tel']");
        private readonly By userName =
        By.Id("username");
        private readonly By age =
        By.Name("age");
        private readonly By email =
        By.Id("email");
        private readonly By address =
        By.Id("address");
        private readonly By address2 =
        By.Id("address2");
        private readonly By country =
        By.Id("country");
        private readonly By state =
        By.Id("state");
        private readonly By city =
        By.Id("city");
        private readonly By agreeCheckBox =
        By.XPath("//label[@for='agree-terms-conditions']");
        private readonly By sendButton =
        By.XPath("//button[@type='submit' and text()='Send']");
        private readonly By privacyPolicy =
        By.LinkText("Privacy");
        private readonly By firstParagraph =
       By.CssSelector("[class='col-lg-12']>p");


        //validation messages
        private readonly By firstNameVal =
       By.CssSelector("[id='firstName'] + div");
        private readonly By lastNameVal =
        By.CssSelector("[name='lastName'] + div");
        private readonly By cellPhoneVal =
        By.CssSelector("[type='tel'] + div");
        private readonly By userNameVal =
        By.CssSelector("[id='username'] + div");
        private readonly By ageVal =
        By.CssSelector("[name='age'] + div");
        private readonly By emailVal =
        By.CssSelector("[id='email'] + div");
        private readonly By addressVal =
        By.CssSelector("[id='address'] + div");
        private readonly By stateVal =
        By.CssSelector("[id='state'] + div");
        private readonly By cityVal =
        By.CssSelector("[id='city'] + div");


        private string expectedTitleFormPage = "Test for Automation Test Engineer - form";
        private string expectedTitleResultPage = "Test for Automation Test Engineer - result";

        [Test]
        public void checkTitleFormPage()
        {
            Assert.AreEqual(getWindowTitle(), expectedTitleFormPage);
            FillForm();
            ClickBy(agreeCheckBox);
            ClickBy(sendButton);



        }

        [Test]
        public void checkValidationMessages()
        {
            ClickBy(sendButton);
            isDisplayed(firstNameVal);
            isDisplayed(lastNameVal);
            isDisplayed(cellPhoneVal);
            isDisplayed(userNameVal);
            isDisplayed(ageVal);
            isDisplayed(emailVal);
            isDisplayed(addressVal);
            isDisplayed(stateVal);
            isDisplayed(cityVal);
            FillForm();
            ClickBy(agreeCheckBox);
            ClickBy(sendButton);



        }
        [Test]
        public void checkTitleResultPage()
        {
            Assert.AreEqual(getWindowTitle(), expectedTitleFormPage);
            FillForm();
            ClickBy(agreeCheckBox);
            ClickBy(sendButton);
            Assert.AreEqual(getWindowTitle(), expectedTitleResultPage);



        }
        [Test]
        public void checkSuccessMessage()
        {
        /*  THERE IS NO ELEMENT FOR CHECKING*/


        }
        [Test]
        public void checkPrivacyPolicy()
        {
            ClickBy(privacyPolicy);
            changeToLastWindow();
            string text = getText(firstParagraph);
            string expectedText = @"TEAM International Services Inc. further referred to as “we,” “us” or “our”, is a custom software development consultancy headquartered at 1145 TownPark Avenue, Suite 2201, Lake Mary, FL 32746, USA. We operate through our subsidiaries located in Ukraine, Poland, and Colombia.";
            Assert.AreEqual(expectedText, text);


        }




        public void FillForm()
        {

            SendKeys(firstName, "User FirstName");
            SendKeys(lastName, "User LastName");
            SendKeys(cellPhone, "123456");
            SendKeys(userName, "userName");
            SendKeys(age, "25");
            SendKeys(email, "user@teamEmail.net");
            SendKeys(address, "User Main Address");
            SendKeys(address2, "User Aditional Address");
            SelectElement(country, "United States");
            SelectElement(state, "Florida");
            SelectElement(city, "Lake Mary");
            Pause(1000);
        }
    }
}