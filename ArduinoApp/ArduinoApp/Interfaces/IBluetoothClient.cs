using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoApp.Interfaces
{
    public interface IBluetoothClient
    {

        // EventHandler is a type of delegate(or specific delegate) that returns nuthing(void)
        // the EventHandler epresent the method that will handle an event when the event provides data.
        // unlike action(which is also a delegate), the EventHandler takes 2 arguments

        event EventHandler<byte> ByteReceived;  // this is the event

        void SendMessage(byte data , string deviceId);

        List<string> GetPairedDeviceIds();

        string GetDeviceName(string deviceId);

        bool Connect(string deviceId);
        
        //     Task<bool> ConnectAsync(string deviceId);

        void Disconnect();


    }
}
