using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace Automation_Test_Engineer
{
    public class Tests : BasePage
    {
        private By WomenButton =
        By.XPath("//div[@id='block_top_menu']/ul/li/a[@title='Women']");
        private By DressesButton =
      By.XPath("//div[@id='block_top_menu']/ul/li/a[@title='Dresses']");
        private By ProductList =
        By.XPath("//ul[starts-with(@class,'product_list')]/li");
        private By AddtoCart =
        By.LinkText("Add to cart");
        private By Continue_Shopping =
        By.XPath("//span[@title='Continue shopping']");
        private By cartQuantity =
        By.XPath("//div[@class='shopping_cart']/a/span[starts-with(@class,'ajax_cart_quantity')]");
        private By Cart =
        By.XPath("//div[@class='shopping_cart']/a");
        private By SummaryCart =
        By.XPath("//table[@id='cart_summary']/tbody/tr");
        private By DeleteButton =
        By.XPath("//a[@title='Delete']");


        int amountOfProducts = 10;

        private List<IWebElement> list;

        [Test]
        public void MainTest()
        {
            //3. Browser Website, add 10 Unique items to the shopping cart.
            //AUTOR'S NOTE: THERE IS ONLY 7 UNIQUE ITEMS.
            //4. Navigate to shopping cart, verify total number of items = 10 -> amountOfProducts
            ClickBy(WomenButton);
            list = returnList(ProductList);
            foreach (var product in list)
            {
                Dev("Selected Item: "+ product.Text);
                MouseOverElementToElement(product, AddtoCart);
                ClickBy(Continue_Shopping);
                if (CheckProductQuantity(cartQuantity) == amountOfProducts)
                {
                    break;
                }

            }

            ClickBy(DressesButton);
            list = returnList(ProductList);
            foreach (var product in list)
            {
                if (CheckProductQuantity(cartQuantity) == amountOfProducts)
                {
                    break;
                }
                MouseOverElementToElement(product, AddtoCart);
                ClickBy(Continue_Shopping);
            }

            //5. Remove all items from shopping cart 1 by 1, verify cart is empty 
            
            ClickBy(Cart);
            do
            {
                //THIS PAUSE IS FOR THE FADE WHEN THE PRODUCT IS DELETED --> COMPLETELY SITUATIONAL
                Pause(1000);
                //***********************************************************
                if (returnList(SummaryCart).Count !=0)
                {
                    returnList(SummaryCart).First().FindElement(DeleteButton).Click();

                }
                else
                {
                    break;
                }
            } while (returnList(SummaryCart).Count != 0);

            //VERIFY CART IS EMPTY
            Assert.IsTrue(returnList(SummaryCart).Count==0);





        }

    }
}