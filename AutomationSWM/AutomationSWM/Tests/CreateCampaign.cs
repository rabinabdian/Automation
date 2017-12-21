using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing.Imaging;
using OpenQA.Selenium.PhantomJS;

namespace AutomationSWM.Tests
{
    [TestClass]
    public class CreateCampaign
    {

        IWebDriver driver;
        string username = "swmuser";
        string password = "swmPassword1";
        string urlAdrr = SiteUrl.GetString(SiteUrl.url.d4sprinters5);
        string DT = DateTime.Now.ToFileTime().ToString();
        CreateLogMessage log = new CreateLogMessage();

        [TestInitialize]
        public void Init()
        {
           
            driver = new ChromeDriver();
            //driver = new PhantomJSDriver();
            driver.Navigate().GoToUrl(urlAdrr);
            driver.Manage().Window.Maximize();

            Thread.Sleep(1000);
            driver.FindElement(By.Name("username")).SendKeys(username);
            //Thread.Sleep(5000);
            driver.FindElement(By.Id("inputPassword")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/app-root/app-auth/app-auth-sign-in/div/div/form/div[2]/button")).Click();

            Thread.Sleep(3000);
           


        }



        [TestMethod]
        public void NewCampaign()
        {

            Thread.Sleep(1000);

            Campaign c = new Campaign();


            try
            {


                driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[3]/div/div[2]/div/a")).Click();


                Thread.Sleep(3000);
                // choose OS
                driver.FindElement(By.CssSelector("#inputName")).SendKeys(c.Name);

                driver.FindElement(By.XPath("//*[@id='campaignCreate']/div/div/app-campaign-create-basics-step/div/button")).Click();

                driver.FindElement(By.CssSelector("#campaignCreate > div > div > app-campaign-create-basics-step > div > div.advanced-settings-wrapper > div:nth-child(4) > div > div.col-8.col-sm-8 > app-input > div > textarea")).SendKeys(c.UpdateFailureMessage);

                driver.FindElement(By.CssSelector("#campaignCreate > div > div > app-campaign-create-basics-step > div > div.advanced-settings-wrapper > div:nth-child(5) > div > div.col-8.col-sm-8 > app-input > div > textarea")).SendKeys(c.UpdateSuccessMessage);

                driver.FindElement(By.CssSelector("#campaignCreate > div > div > app-campaign-create-basics-step > div > div.advanced-settings-wrapper > div:nth-child(6) > div > div.col-8.col-sm-8 > app-input > div > textarea")).SendKeys(c.Description);
                // choose Model Code 
                // driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Vehicle Model')]")).Click();

                driver.FindElement(By.XPath("//*[@id='campaignCreate']/div/app-campaign-create-header/nav/div/div[1]/div[4]/div")).Click();

               

                //   driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ABCD-EFG-P5')]")).Click();
                Thread.Sleep(2000);




                WaitForExecuteButtonUntilVisible:
                if (driver.FindElement(By.XPath("//*[@id='wizard_toolbar_execute']")).Enabled)
                {
                    driver.FindElement(By.XPath("//*[@id='wizard_toolbar_execute']")).Click();
                }
                else
                {
                    goto WaitForExecuteButtonUntilVisible;
                }

                log.CampSuccedMessage(c, urlAdrr, DT);


              //  driver.FindElement(By.XPath("//*[@id='wrapper']/app-topbar/nav/a/div")).Click();


            }

            catch (Exception ex)
            {



                driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + DT + ".png", ImageFormat.Png);

                log.ExceptionMessage(ex, "Add Campaign Failure", c.Name, urlAdrr, DT);
                //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

            }



        }


        [TestCleanup]
        public void CloseBrowser()
        {
            //rep.EndReport();
            driver.Close();
        }
    }
}
