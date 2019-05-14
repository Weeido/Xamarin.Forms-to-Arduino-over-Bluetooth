using ArduinoApp.Enums;
using ArduinoApp.Interfaces;
using ArduinoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArduinoApp.Views
{
  //  [XamlCompilation(XamlCompilationOptions.Compile)] //TODO:
    public partial class ControlerPage : ContentPage
    {
        private string deviceId;

        public ControlerPage(string deviceId)
        {
            //        InitializeComponent(); //TODO:

            var stackLayout = new StackLayout();

            this.deviceId = deviceId;
            this.Content = stackLayout;

            PageHelper.CreatePressReleaseButton("leftButton", LeftButtonPressed, ReleaseButton, stackLayout);
            PageHelper.CreatePressReleaseButton("rightButton", RightButtonPressed, ReleaseButton, stackLayout);
            PageHelper.CreatePressReleaseButton("upButton", UpButtonPressed, ReleaseButton, stackLayout);
            PageHelper.CreatePressReleaseButton("downButton", DownButtonPressed, ReleaseButton, stackLayout);
            PageHelper.CreateButton("Stop Connection", StopConnectionButtonClicked, stackLayout);

            App.BluetoothClient.ByteReceived += BluetoothClient_ByteReceived; // setting a subscriber to the event
        }

        private void BluetoothClient_ByteReceived(object sender, byte e)
        {
            Device.BeginInvokeOnMainThread(() => DependencyService.Get<IMessage>().ShortAlert("Byte recived" + e));
        }

        private void StopConnectionButtonClicked()
        {
            App.BluetoothClient.Disconnect();

            DependencyService.Get<IMessage>().ShortAlert("Disconnected");

            Navigation.PopAsync();
        }

        private void SendBluetoothMessage(Direction data)
        {
            try
            {
                App.BluetoothClient.SendMessage(Serializer.Serialize((int)data), deviceId);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Concat("The Exception:", ex.GetType().Name, " has occured");
                DependencyService.Get<IMessage>().LongAlert(errorMessage);
            }
        }

        private void DownButtonPressed()
        {
            SendBluetoothMessage(Direction.BACKWARD);
        }

        private void UpButtonPressed()
        {
            SendBluetoothMessage(Direction.FORWARD);
        }

        private void RightButtonPressed()
        {
            SendBluetoothMessage(Direction.RIGHT);
        }

        private void LeftButtonPressed()
        {
            SendBluetoothMessage(Direction.LEFT);
        }

        private void ReleaseButton()
        {
            SendBluetoothMessage(Direction.RELEASE);
        }
    }
}