﻿using System;
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
        string DT = DateTime.Now.ToFileTime().ToString();
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
        public void Add_New_Campaign()
        {
            Campaign camp = new Campaign();
            string DT = DateTime.Now.ToFileTime().ToString();

           

            try
            {

                driver.FindElement(By.XPath("//a[contains(@href, '#/campaign/create')]")).Click();

            // name of campaign 
            driver.FindElement(By.XPath("//input[contains(@class='wizard-input ng-pristine ng-valid ng-touched')][contains(@type='input')]")).SendKeys(camp.Name);




                log.CampSuccedMessage(camp,urlAdrr,DT);



            }
            catch (Exception ex)
            {

                log.ExceptionMessage(ex, "Add Campaign Failure", camp.Name,urlAdrr,DT);
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
