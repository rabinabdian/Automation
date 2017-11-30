using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSWM
{
   public abstract class SiteUrl
    {


        public enum url { d4sprinters1, d4sprinters3, d4sprinters5 , d4sprinters6 }
        static List<string> strings =
            new List<string>()
            { "http://d4-sprinters1.redbend.com:8080/sma2/#/auth/sign-in",

                "http://d4-sprinters3.redbend.com:8080/sma2/#/auth/sign-in",

                "http://d4-sprinters5.redbend.com:8080/sma2/#/auth/sign-in",
                 "http://d4-sprinters6.redbend.com:8080/sma2/#/auth/sign-in"
            };



        public static string GetString(SiteUrl.url value)
        {
            return strings[(int)value];
        }





    }
}
