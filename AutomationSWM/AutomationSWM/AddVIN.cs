using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using OpenQA.Selenium.Support.Extensions;
using System.Xml.Linq;

namespace AutomationSWM
{
    [TestClass]
    public class AddVIN
  
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
            //rep.StartReport();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(urlAdrr);
            driver.Manage().Window.Maximize();

            Thread.Sleep(5000);
            driver.FindElement(By.Name("username")).SendKeys(username);
            //Thread.Sleep(5000);
            driver.FindElement(By.Id("inputPassword")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/app-root/app-auth/app-auth-sign-in/div/div/form/div[2]/button")).Click();

            Thread.Sleep(5000);
           // driver.FindElement(By.XPath("//i[contains(@class,'logo')]")).Click();


        }

        [TestMethod]
        public void Add_New_Vehicle()
        {
           
                Vehicle v = new Vehicle();


                

                try
                {

                    driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[2]/div/div[2]/div/a")).Click();



                    // choose OS
                    driver.FindElement(By.Name("vin")).SendKeys(v.VIN);
                    driver.FindElement(By.Name("supplementaryId")).SendKeys(v.SupplementaryID);
                    driver.FindElement(By.Name("chassisNumber")).SendKeys(v.ChassisNumber);

                    driver.FindElement(By.Name("plant")).SendKeys(v.Plant);
                    driver.FindElement(By.Name("productionWeek")).SendKeys(v.ProductionWeek);
                    driver.FindElement(By.Name("vehicleModelYear")).SendKeys(v.VehicleModelYear);
                    driver.FindElement(By.Name("plant")).SendKeys(v.Plant);

                    // choose Model Code 
                    driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Vehicle Model')]")).Click();


                driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(2)")).Click();

                //   driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ABCD-EFG-P5')]")).Click();
                Thread.Sleep(5000);




                    WaitForSaveButtonUntilVisible:
                    if (driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                    {
                        driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                    }
                    else
                    {
                        goto WaitForSaveButtonUntilVisible;
                    }

                    log.VINSuccedMessage(v,urlAdrr,DT);
                    //rep.Pass("Add New SoftWare Passed", "New SoftWare Creation Passed");

                    Thread.Sleep(1000);

                   // driver.FindElement(By.XPath("//i[contains(@class,'icon-harman_logo')]")).Click();

                }
                catch (Exception ex)
                {



               driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + DT + ".png", ImageFormat.Png);

                log.ExceptionMessage(ex, "Add Vehicle Failure",v.VIN,urlAdrr,DT);
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
