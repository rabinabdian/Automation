using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSWM
{
    public class USER
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string UserName { get; internal set; }
        public string Email { get; internal set; }


        public USER()
        {
            string DT = DateTime.Now.ToFileTime().ToString();
            FirstName = "FN-" + DT;
            LastName = "LN-" + DT;
            UserName = "UN-" + DT;
            Email = "ruben.avdaian@redbend.com";
        }




    }
}
