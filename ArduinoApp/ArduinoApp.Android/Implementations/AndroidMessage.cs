
using Android.App;
using Android.Widget;
using ArduinoApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ArduinoApp.Droid.Implementations.AndroidMessage))]
namespace ArduinoApp.Droid.Implementations
{
    public class AndroidMessage : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}