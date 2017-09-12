using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSWM
{
   public abstract class SiteUrl
    {


        public enum url { star12, star34R ,dmz11 }
        static List<string> strings =
            new List<string>()
            { "http://star12.redbend.com:8080/sma2/#/auth/sign-in",

                "http://d2-star34.redbend.com:8080/sma2/#/auth/sign-in",

                "http://dmz11.redbend.com:8080/sma2/#/auth/sign-in"
            };



        public static string GetString(SiteUrl.url value)
        {
            return strings[(int)value];
        }





    }
}
