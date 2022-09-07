using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class SensorDataInfo
    {
        // 是否选中
        public bool CheckeState { get; set; }

        // 传感器型号
        public SensorModelInfo ModelInfo { get; set; }

        // 参数值
        public List<Object> Params { get; set; }

    }
}
