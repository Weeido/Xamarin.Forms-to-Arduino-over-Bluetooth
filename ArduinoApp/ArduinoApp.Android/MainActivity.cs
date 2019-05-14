using Android.App;
using Android.OS;
using ArduinoApp.Droid.Implementations;
using ArduinoApp.Interfaces;

namespace ArduinoApp.Droid
{

    [Activity(Label = "ArduinoApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            IBluetoothClient androidBluetoothClient = new AndroidBluetoothClient();

            LoadApplication(new App(androidBluetoothClient));


        }

    }
}
