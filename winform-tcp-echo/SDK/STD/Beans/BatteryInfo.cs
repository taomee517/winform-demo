using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.STD.Beans
{
    public class BatteryInfo
    {
        public bool BatteryEnable { get; set; }

        public double Battery { get; set; }


        public bool VoltageEnable { get; set; }

        public double Voltage { get; set; }


        public bool TempEnable { get; set; }

        public double Temp { get; set; }
    }
}
