using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace AutomationSWM.Classes
{
    public class Base
    {

        //public  IWebDriver driver;
        //  public string username = "swmuser";
        //  public string password = "swmPassword1";
        //  public string urlAdrr = SiteUrl.GetString(SiteUrl.url.d4sprinters5);
        //  public string DT = DateTime.Now.ToFileTime().ToString();
        public string username { get; internal set; }
        public string password { get; internal set; }
        public string urlAdrr { get; internal set; }
        public string DT { get; internal set; }
        public IWebDriver driver { get; internal set; }

        public Base()
        {
            username = "swmuser";
            password = "swmPassword1";
            urlAdrr = SiteUrl.GetString(SiteUrl.url.d4sprinters5);
            DT = DateTime.Now.ToFileTime().ToString();
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            driver = new ChromeDriver(option);

        }


    }
}
