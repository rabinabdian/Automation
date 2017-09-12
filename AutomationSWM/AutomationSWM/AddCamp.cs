using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationSWM
{
    [TestClass]
    public class AddCamp
    {

        IWebDriver driver;
        string username = "swmuser";
        string password = "swmPassword1";
        string urlAdrr = SiteUrl.GetString(SiteUrl.url.star34R);
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
        public void Add_New_Campaign()
        {
            Campaign camp = new Campaign();
            string DT = DateTime.Now.ToFileTime().ToString();

            camp.Name="CAMP"+ DT;
            camp.UpdateFailureMessage = camp.Name + " Update Failure Message";
            camp.UpdateSuccessMessage = camp.Name+" Update Success Message";
            camp.Description = camp.Name +" Description";

            try
            {

                driver.FindElement(By.XPath("//a[contains(@href, '#/campaign/create')]")).Click();

            // name of campaign 
            driver.FindElement(By.XPath("//input[contains(@class='wizard-input ng-pristine ng-valid ng-touched')][contains(@type='input')]")).SendKeys(camp.Name);




                log.AddCampSucceed(camp,urlAdrr);



            }
            catch (Exception ex)
            {

                log.ExceptionMessage(ex, "Add Campaign Failure", camp.Name,urlAdrr);
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
