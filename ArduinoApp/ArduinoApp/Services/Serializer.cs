using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoApp.Services
{
    public static class Serializer
    {
        public static byte Serialize(int data)
        {
            return Convert.ToByte(data);
        }
    }
}
