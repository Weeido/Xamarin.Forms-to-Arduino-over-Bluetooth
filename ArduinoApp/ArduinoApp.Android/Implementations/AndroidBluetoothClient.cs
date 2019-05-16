using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.Bluetooth;
using ArduinoApp.Abstractions;

namespace ArduinoApp.Droid.Implementations
{
    public class AndroidBluetoothClient : BaseBluetoothClient
    {
        private Dictionary<string, BluetoothDevice> deviceIdToBluetoothDevice = new Dictionary<string, BluetoothDevice>();

        private BluetoothAdapter myBluetoothAdapter;

        private Stream outStream;

        private Stream inputStream;

        private bool isConnected;

        /*
         * Since data can be received at any point of time, running a thread to listen for data would be best. 
         * First, the input stream is queried for available data. Then, the bytes are converted to human readable UTF-8 
         * format and the text is send to a handler to post onto the UI. 
         * This is done because the UI can't be updated from background threads.
         */

        private BluetoothSocket btSocket = null;

        private Java.Util.UUID myUUID = Java.Util.UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");


        class AndroidBTClientExeception : Exception { }
        class CantOpenStream : AndroidBTClientExeception { }
        class CantWriteData : AndroidBTClientExeception { }

        class GoodException : AndroidBTClientExeception{ }
        
        public override bool Connect(string deviceId)
        {
            BluetoothDevice bTDevice = deviceIdToBluetoothDevice[deviceId];     

            myBluetoothAdapter.CancelDiscovery();                               

            try
            {
                btSocket = bTDevice.CreateRfcommSocketToServiceRecord(myUUID);
                btSocket.Connect();
                isConnected = true;
                Task.Run(async () => await Listen());
            }
            catch
            {
                btSocket.Close();
                isConnected = false;
                return false;
            }

            return true;
        }

        public override void Disconnect()
        {
            isConnected = false;
            btSocket.Close();
            outStream = null;
            inputStream = null;
            btSocket = null;

        }

        public override List<string> GetPairedDeviceIds()
        {
            myBluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            deviceIdToBluetoothDevice.Clear();

            var devices = myBluetoothAdapter.BondedDevices;

            foreach (var currentDevice in devices)
            {
                var currentDeviceAddress = currentDevice.Address;

                deviceIdToBluetoothDevice[currentDeviceAddress] = currentDevice;
            }

            return deviceIdToBluetoothDevice.Keys.ToList(); 
        }

        public override string GetDeviceName(string deviceId)
        {
            var Device = deviceIdToBluetoothDevice[deviceId];

            return Device.Name;
        }

        public override void SendMessage(byte data, string deviceId)
        {

            if (outStream == null)
            {
                try
                {
                    outStream = btSocket.OutputStream;
                }
                catch
                {
                    throw new CantOpenStream();
                }
            }

            try
            {
                outStream?.WriteByte(data);

            }
            catch
            {
                throw new CantWriteData();

            }


        }

        protected override async Task Listen()
        {
            while (isConnected)
            {
                if (inputStream == null)
                {
                    try
                    {
                        inputStream = btSocket.InputStream;
                    }
                    catch
                    {
                        throw new CantOpenStream();
                    }
                }

                var inputByte = inputStream.ReadByte();// maybe optimize later
                
                OnByteReceived((byte)inputByte); 
                
            }

            inputStream = null;
        }
    }
}

