using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace AutomationSWM
{
    [TestClass]
    public class AddUser
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
            //Initializer init = new Initializer();


        }



        [TestMethod]
        public void Add_New_USER()
        {
            for (int i = 0; i < 1; i++)
            {
                USER u = new USER();





                try
                {
                   

                    driver.FindElement(By.XPath("//button[contains(@class,'btn btn-default')][contains(@id,'toggle-sidebar')]")).Click();

                    /// click on user in menue 

                    driver.FindElement(By.XPath("//*[@id='wrapper']/app-sidebar/nav/ul/li[5]/ul/li[2]/a")).Click();

                    /// click on user in menue 

                    driver.FindElement(By.XPath(" //*[@id='toolbar_new']/div[2]/div")).Click();

                    //*[@id="page-wrapper"]/div/app-user-create/div/form/section/div/div[1]/div/input

                    /// complete new user page 
                    driver.FindElement(By.Name("firstName")).SendKeys(u.FirstName);

                    driver.FindElement(By.Name("lastName")).SendKeys(u.LastName);

                    driver.FindElement(By.Name("userName")).SendKeys(u.UserName);

                    driver.FindElement(By.Name("email")).SendKeys(u.Email);

                    driver.FindElement(By.ClassName("selectedLabel")).Click();

                    driver.FindElement(By.XPath(".//label[contains(text(),'0 item(s) selected')]")).Click();
                    driver.FindElement(By.XPath(".//div[contains(text(),'Mq External')]")).Click();

                    driver.FindElement(By.ClassName("selectedLabel")).Click();



                    //Thread.Sleep(2000000);
                    WaitForSaveButtonUntilVisible:
                    if (driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Enabled)
                    {
                        driver.FindElement(By.XPath("//button[contains(@class,'new-form-btn save-btn')]")).Click();
                    }
                    else
                    {
                        goto WaitForSaveButtonUntilVisible;
                    }

                    log.USERSuccedMessage(u,urlAdrr);
                    //rep.Pass("Add New SoftWare Passed", "New SoftWare Creation Passed");

                    Thread.Sleep(2000);

                    driver.FindElement(By.XPath("//i[contains(@class,'icon-harman_logo')]")).Click();

                }
                catch (Exception ex)
                {

                    log.ExceptionMessage(ex, "Add User Failure",u.UserName,urlAdrr);
                    //rep.Fail("Add New SoftWare Failed", "New SoftWare Creation Failed");

                }
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
