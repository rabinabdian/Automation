using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationSWM
{
   
    struct Address
    {
        public enum url {star12, star34R }
        static List<string> strings =
            new List<string>()
            { "http://star12.redbend.com:8080/sma2/#/auth/sign-in",

                "http://d2-star34.redbend.com:8080/sma2/#/auth/sign-in" };


        public string GetString(Address.url value)
        {
            return strings[(int)value];
        }
    }

    public class Initializer
    {
        IWebDriver driver;
        Address add;
        public string username { get; set; }
        public string password { get; set; }
        public string urlAdrr { get; set; }
       

           

        public Initializer()
        {
            username = "swmuser";
            password = "swmPassword1";
            urlAdrr = add.GetString(Address.url.star12);
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(urlAdrr);
            driver.Manage().Window.Maximize();

            Thread.Sleep(5000);
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("/html/body/app-root/app-auth/app-auth-sign-in/div/div/form/div[2]/button")).Click();

            Thread.Sleep(5000);
           // driver.FindElement(By.XPath("//i[contains(@class,'icon-harman_logo')]")).Click();




        }










    }
}
