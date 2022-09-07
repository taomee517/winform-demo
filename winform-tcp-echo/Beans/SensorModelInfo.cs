using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beans
{
    public class SensorModelInfo
    {
        // 传感器型号名称
        public string ModelName { get; set; }

        // 传感器参数个数
        public int ParamSize { get; set; }

        // 参数名称
        public List<String> ParamNames { get; set; }

        // 参数单位
        public List<String> ParamUnits { get; set; }

    }
}
