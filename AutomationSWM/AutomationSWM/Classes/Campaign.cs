using System;

namespace AutomationSWM
{
    public class Campaign
    {
        public string Name { get; internal set; }
        public string UpdateFailureMessage { get; internal set; }
        public string UpdateSuccessMessage { get; internal set; }
        public string Description { get; internal set; }


 public Campaign()
    {

            string DT = DateTime.Now.ToFileTime().ToString();
            Name = "Camp-" + DT;
            UpdateFailureMessage = "UpdateFailureMessage- " + DT;
            UpdateSuccessMessage = "UpdateSuccessMessage- " + DT;
            Description = "Description ruben.avdaian@redbend.com";

        }







    }


   
}