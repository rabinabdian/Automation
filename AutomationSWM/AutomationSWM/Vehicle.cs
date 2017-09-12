using System;

namespace AutomationSWM
{
    public class Vehicle
    {

        public Vehicle()
        {
            DateTime DT = DateTime.Now;
            VIN = "VIN-" + DT.ToFileTime().ToString();
            SupplementaryID = DT.ToFileTime().ToString();
            ChassisNumber = DT.ToFileTime().ToString();
            Plant = DT.ToFileTime().ToString();
            ProductionWeek =DT.Day.ToString().PadLeft(2, '0')+ DT.Year.ToString();
            VehicleModelYear = DT.Year.ToString();
        }

        public string VIN { get; internal set; }
        public string SupplementaryID { get; internal set; }
        public string ChassisNumber { get; internal set; }
        public string Plant { get; internal set; }
        public string ProductionWeek { get; internal set; }
        public string VehicleModelYear { get; internal set; }
    }
}