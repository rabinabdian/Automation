using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuriyGuts.RegexBuilder;

namespace AutomationSWM
{
    public class Software
    {
        internal string LongDescription;
        internal string WhatsNew;

        public Software()
        {
            string DT = DateTime.Now.ToFileTime().ToString();
            softwareName = "SW-" + DT;
            softwareId = DT;
            softwareVendor = "RUBISOFT";
            softwareVersionName = "softwareVersionName";
            softwareVersionNumber = "1";
            shortDescription = "short Description";
            LongDescription = "Long Description";
            WhatsNew = "What's New (Release Notes)";
            estimatedInstallationTime = "1000";




        }

        public string softwareName { get; set; }
        public object sw { get; internal set; }
        public string softwareVendor { get; internal set; }
        public string softwareVersionName { get; internal set; }
        public string softwareVersionNumber { get; internal set; }
        public string shortDescription { get; internal set; }
        public string estimatedInstallationTime { get; internal set; }
        public string softwareId { get; private set; }
    }



    

}
