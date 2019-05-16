using ArduinoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArduinoApp.Abstractions
{
    public abstract class BaseBluetoothClient : IBluetoothClient
    {

        public event EventHandler<byte> ByteReceived; 

        public abstract bool Connect(string deviceId);

        public abstract void Disconnect();

        public abstract string GetDeviceName(string deviceId);

        public abstract List<string> GetPairedDeviceIds();

        public abstract void SendMessage(byte data, string deviceId);

        protected abstract Task Listen();

        //This is the method that raises the event
        protected void OnByteReceived(byte receivedByte)
        {
            ByteReceived?.Invoke(null, receivedByte);
        }

    }
}
