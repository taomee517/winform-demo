using SDK.MEASURE.Device;
using SDK.STD.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows;
using winform_demo.Device;

namespace Device
{
    public class MockDeviceFactory
    {
        public static AbstractMockDevice BuildMockDevice(
                int sensorType, 
                string mac,
                Gateway.ShowMsgLog showMsgLog,
                Gateway.StatusChange statusChange,
                Gateway.PwdGetter pwdGetter)
        {
            if (sensorType == 27000 )
            {
                return new AeroVMMockDevice(mac, showMsgLog, statusChange, pwdGetter);
            }
            else if(sensorType == 7000)
            {
                return new MeasureMockDevice(mac,showMsgLog, statusChange);
            }

            return null;
        }
    }
}
