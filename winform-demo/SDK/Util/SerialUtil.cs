using System.Collections.Concurrent;
using System.Threading;

namespace winform_demo.SDK.Util
{
    public class SearialUtil
    {
        private static ConcurrentDictionary<string, int> SerialMap = new ConcurrentDictionary<string, int>();

        public static int GetSerial(string key)
        {
            var serial = 0;
            if (!SerialMap.ContainsKey(key))
            {
                SerialMap[key] = serial;
                return serial;
            }
            var temp = SerialMap[key];
            serial = Interlocked.Increment(ref temp) % 0x100;
            SerialMap[key] = serial;
            return serial;
        }
    }
}
