using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace AutomationSWM
{
    [TestClass]
    public class AddSW
    {

        IWebDriver driver;
        string username = "swmuser";
        string password = "swmPassword1";
       
        string urlAdrr = SiteUrl.GetString(SiteUrl.url.d4sprinters1);
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
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/app-root/app-auth/app-auth-sign-in/div/div/form/div[2]/button")).Click();

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//i[contains(@class,'icon-harman_logo')]")).Click();


        }

        [TestMethod]
        public void Add_New_Software()
        {

            for (int i = 0; i < 1; i++)
            {



                Software sw = new Software();

                try
                {

                    driver.FindElement(By.XPath("//*[@id='dashboardItems']/div[1]/div/div[2]/div/a")).Click();



                    // choose OS
                    driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select OS')]")).Click();

                    Thread.Sleep(1000);

                    driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'AUTOSAR [AUTOSAR]')]")).Click();

                    Thread.Sleep(1000);

                    // choose sw type

                    driver.FindElement(By.XPath("//div[contains(@class,'select-button-item placeHolderStyling truncated')][contains(text(),'Select Software Type')]")).Click();

                    Thread.Sleep(1000);

                    driver.FindElement(By.XPath("//span[contains(@class,'list-option-item-value truncated')][contains(text(),'ECU full image without delta (103), Native')]")).Click();

                    Thread.Sleep(1000);

                    driver.FindElement(By.Name("softwareName")).SendKeys(sw.softwareName);

                    driver.FindElement(By.Name("softwareId")).SendKeys(sw.softwareId);

                    driver.FindElement(By.Name("softwareVendor")).SendKeys(sw.softwareVendor);

                    driver.FindElement(By.XPath("//span[contains(text(),'Select ECU Models')]")).Click();

                    Thread.Sleep(2000);

                    // switch to popup window select ecu models 


                    driver.FindElement(By.XPath("//div[contains(@class,'modal-content')]")).Click();

                    driver.FindElement(By.XPath("//input[contains(@class,'form-check-input noclick')]")).Click();

                    driver.FindElement(By.XPath("//*[@id='popupSelectECUModels']/div/div/div/div[3]/button[2]")).Click();

                    driver.FindElement(By.Name("softwareVersionName")).SendKeys(sw.softwareVersionName);

                    driver.FindElement(By.Name("softwareVersionNumber")).SendKeys(sw.softwareVersionNumber);

                    driver.FindElement(By.Name("shortDescription")).SendKeys(sw.shortDescription);

                    // driver.FindElement(By.XPath("//textarea[contains(@class,'ng-pristine ng-valid ng-touched)][contains(@maxlength,'4000')]")).SendKeys(LongDescription); #page-wrapper > div > app-software-create > div > form > section:nth-child(2) > div > div.new-form-line.double-input > div > app-input > div > textarea#page-wrapper > div > app-software-create > div > form > section:nth-child(2) > div > div.new-form-line.double-input > div > app-input > div > textarea

                    /* IList<IWebElement> divIncludeLongDesc= */
                    //driver.FindElement(By.XPath("//textarea[contains(@class,'ng-pristine ng-valid ng-touched')]/*[contains(@maxlength,'4000')]*/[contains(@type,'text')]")).SendKeys(LongDescription);


                    //driver.FindElement(By.CssSelector("#page-wrapper > div > app-software-create > div > form > section:nth-child(2) > div > div.new-form-line.double-input > div > app-input > div > textarea#page-wrapper > div > app-software-create > div > form > section:nth-child(2) > div > div.new-form-line.double-input > div > app-input > div > textarea")).SendKeys(LongDescription);

                    // driver.FindElement(By.XPath("//*[@id='page - wrapper']/div/app-software-create/div/form/section[2]/div/div[7]/div/app-input/div/textarea")).SendKeys(WhatsNew);


                    driver.FindElement(By.Name("estimatedInstallationTime")).SendKeys(sw.estimatedInstallationTime);


                    WaitForSaveButtonUntilVisible:
                    if (driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                    {
                        driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                    }
                    else
                    {
                        goto WaitForSaveButtonUntilVisible;
                    }

                    log.SoftwareSuccedMessage(sw, urlAdrr);
                    //  rep.Pass("Add New SoftWare Passed", "New SoftWare Creation Passed");

                    Thread.Sleep(2000);

                    driver.FindElement(By.XPath("//i[contains(@class,'icon-harman_logo')]")).Click();

                }
                catch (Exception ex)
                {
                    log.ExceptionMessage(ex, "Add_Software_Failure",sw.softwareName, urlAdrr);
                    //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

                }
            }




        }

        //*[@id="wrapper"]/app-sidebar/nav/ul/li[5]/ul/li[2]/a/text()

        [TestCleanup]
        public void CloseBrowser()
        {
            //rep.EndReport();
            driver.Close();
        }
    }
}
