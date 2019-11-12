using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceControllor
{
    public class DeviceMessage
    {
        public DeviceMessage(uint devId, uint command, string msg)
        {
            m_content = msg;
            m_command = command;
            m_deviceId = devId;
        }

        public string m_content;
        public uint m_command;
        public uint m_deviceId;
    };
}
