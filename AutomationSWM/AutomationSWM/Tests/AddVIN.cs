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
using System.Security.Policy;
using System.Linq;
using OpenQA.Selenium.PhantomJS;
using AutomationSWM.Classes;

namespace AutomationSWM
{
    [TestClass]
    public class AddVIN
  
    {
        //IWebb.driver driver;
        //string username = "swmuser";
        //string password = "swmPassword1";
        //string urlAdrr = SiteUrl.GetString(SiteUrl.url.d4sprinters5);
        //string b.DT = DateTime.Now.ToFileTime().ToString();

        Base b = new Base();


       

        CreateLogMessage log = new CreateLogMessage();      

        [TestInitialize]
        public void Init()
        {
            //ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
            //b.b.driver = new ChromeDriver(option);
           // driver = new PhantomJSDriver();
            b.driver.Navigate().GoToUrl(b.urlAdrr);
            b.driver.Manage().Window.Maximize();

            Thread.Sleep(1000);
            b.driver.FindElement(By.Name("username")).SendKeys(b.username);
          
            b.driver.FindElement(By.Id("inputPassword")).SendKeys(b.password);
            b.driver.FindElement(By.XPath("/html/body/app-root/app-auth/app-auth-sign-in/div/div/form/div[2]/button")).Click();

            Thread.Sleep(3000);
        


        }

        [TestMethod]
        public void Add_New_Vehicle0()
        {
           
                Thread.Sleep(1000);

                Vehicle v = new Vehicle();


                try
                {


                    b.driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[2]/div/div[2]/div/a")).Click();



                    // choose OS
                    b.driver.FindElement(By.Name("vin")).SendKeys(v.VIN);
                    b.driver.FindElement(By.Name("supplementaryId")).SendKeys(v.SupplementaryID);
                    b.driver.FindElement(By.Name("chassisNumber")).SendKeys(v.ChassisNumber);

                    b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);
                    b.driver.FindElement(By.Name("productionWeek")).SendKeys(v.ProductionWeek);
                    b.driver.FindElement(By.Name("vehicleModelYear")).SendKeys(v.VehicleModelYear);
                    b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);

                    // choose Model Code 
                    b.driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Vehicle Model')]")).Click();

                    // choose ABCD-EFG-P1!
                    //  b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(2)")).Click();

                    // choose ABCD-EFG-P3
                    b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(7) > div > span:nth-child(1)")).Click();


                    //   b.driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ABCD-EFG-P5')]")).Click();
                    Thread.Sleep(2000);




                    WaitForSaveButtonUntilVisible:
                    if (b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                    {
                        b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                    }
                    else
                    {
                        goto WaitForSaveButtonUntilVisible;
                    }

                    log.VINSuccedMessage(v, b.urlAdrr,b.DT );


                b.driver.FindElement(By.XPath("//*[@id='wrapper']/app-topbar/nav/a/div")).Click();


            }

                catch (Exception ex)
                {



                    b.driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + b.DT + ".png", ImageFormat.Png);
                
                    log.ExceptionMessage(ex, "Add Vehicle Failure", v.VIN, b.urlAdrr, b.DT);
                    //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

                }

            
        }

        [TestMethod]
        public void Add_New_Vehicle1()
        {

            Thread.Sleep(1000);

            Vehicle v = new Vehicle();


            try
            {


                b.driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[2]/div/div[2]/div/a")).Click();



                // choose OS
                b.driver.FindElement(By.Name("vin")).SendKeys(v.VIN);
                b.driver.FindElement(By.Name("supplementaryId")).SendKeys(v.SupplementaryID);
                b.driver.FindElement(By.Name("chassisNumber")).SendKeys(v.ChassisNumber);

                b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);
                b.driver.FindElement(By.Name("productionWeek")).SendKeys(v.ProductionWeek);
                b.driver.FindElement(By.Name("vehicleModelYear")).SendKeys(v.VehicleModelYear);
                b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);

                // choose Model Code 
                b.driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Vehicle Model')]")).Click();

                // choose ABCD-EFG-P1!
                //  b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(2)")).Click();

                // choose ABCD-EFG-P3
                b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(5) > div > span:nth-child(1)")).Click();


                //   b.driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ABCD-EFG-P5')]")).Click();
                Thread.Sleep(2000);




                WaitForSaveButtonUntilVisible:
                if (b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                {
                    b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                }
                else
                {
                    goto WaitForSaveButtonUntilVisible;
                }

                log.VINSuccedMessage(v, b.urlAdrr, b.DT);


                b.driver.FindElement(By.XPath("//*[@id='wrapper']/app-topbar/nav/a/div")).Click();


            }

            catch (Exception ex )
            {


               

                b.driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + b.DT + ".png", ImageFormat.Png);

                log.ExceptionMessage(ex, "Add Vehicle Failure", v.VIN, b.urlAdrr, b.DT);
                //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

            }


        }

        [TestMethod]
        public void Add_New_Vehicle2()
        {

            Thread.Sleep(1000);

            Vehicle v = new Vehicle();


            try
            {


                b.driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[2]/div/div[2]/div/a")).Click();



                // choose OS
                b.driver.FindElement(By.Name("vin")).SendKeys(v.VIN);
                b.driver.FindElement(By.Name("supplementaryId")).SendKeys(v.SupplementaryID);
                b.driver.FindElement(By.Name("chassisNumber")).SendKeys(v.ChassisNumber);

                b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);
                b.driver.FindElement(By.Name("productionWeek")).SendKeys(v.ProductionWeek);
                b.driver.FindElement(By.Name("vehicleModelYear")).SendKeys(v.VehicleModelYear);
                b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);

                // choose Model Code 
                b.driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Vehicle Model')]")).Click();

                // choose ABCD-EFG-P1!
                //  b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(2)")).Click();

                // choose ABCD-EFG-P3
                b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(2) > div > span:nth-child(1)")).Click();


                //   b.driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ABCD-EFG-P5')]")).Click();
                Thread.Sleep(2000);




                WaitForSaveButtonUntilVisible:
                if (b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                {
                    b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                }
                else
                {
                    goto WaitForSaveButtonUntilVisible;
                }

                log.VINSuccedMessage(v, b.urlAdrr, b.DT);


                b.driver.FindElement(By.XPath("//*[@id='wrapper']/app-topbar/nav/a/div")).Click();


            }

            catch (Exception ex)
            {



                b.driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + b.DT + ".png", ImageFormat.Png);

                log.ExceptionMessage(ex, "Add Vehicle Failure", v.VIN, b.urlAdrr, b.DT);
                //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

            }


        }

        [TestMethod]
        public void Add_New_Vehicle3()
        {

            Thread.Sleep(1000);

            Vehicle v = new Vehicle();


            try
            {


                b.driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[2]/div/div[2]/div/a")).Click();



                // choose OS
                b.driver.FindElement(By.Name("vin")).SendKeys(v.VIN);
                b.driver.FindElement(By.Name("supplementaryId")).SendKeys(v.SupplementaryID);
                b.driver.FindElement(By.Name("chassisNumber")).SendKeys(v.ChassisNumber);

                b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);
                b.driver.FindElement(By.Name("productionWeek")).SendKeys(v.ProductionWeek);
                b.driver.FindElement(By.Name("vehicleModelYear")).SendKeys(v.VehicleModelYear);
                b.driver.FindElement(By.Name("plant")).SendKeys(v.Plant);

                // choose Model Code 
                b.driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Vehicle Model')]")).Click();

                // choose ABCD-EFG-P1!
                //  b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(2)")).Click();

                // choose ABCD-EFG-P3
                b.driver.FindElement(By.CssSelector("#filter-modelCode > app-input-select > div > div > ul > li:nth-child(6) > div > span:nth-child(1)")).Click();


                //   b.driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ABCD-EFG-P5')]")).Click();
                Thread.Sleep(2000);




                WaitForSaveButtonUntilVisible:
                if (b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                {
                    b.driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                }
                else
                {
                    goto WaitForSaveButtonUntilVisible;
                }

                log.VINSuccedMessage(v, b.urlAdrr, b.DT);


                b.driver.FindElement(By.XPath("//*[@id='wrapper']/app-topbar/nav/a/div")).Click();


            }

            catch (Exception ex)
            {



                b.driver.TakeScreenshot().SaveAsFile(@"C:\Users\ravdaian\Documents\GitHub\Automation\AutomationSWM\AutomationSWM\Images\" + b.DT + ".png", ImageFormat.Png);

                log.ExceptionMessage(ex, "Add Vehicle Failure", v.VIN, b.urlAdrr, b.DT);
                //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

            }


        }

        [TestCleanup]
        public void CloseBrowser()
        {
            //rep.EndReport();
            b.driver.Close();
        }
    }
}
