using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class DataEventArgs : EventArgs
    {
        public List<SensorDataInfo> SensorDatas { get; set; }

        public DataEventArgs(List<SensorDataInfo> sensorDatas)
        {
            this.SensorDatas = sensorDatas;
        }
    }
}
