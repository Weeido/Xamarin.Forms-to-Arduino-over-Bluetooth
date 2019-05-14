using ArduinoApp.Interfaces;
using ArduinoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArduinoApp
{
    public partial class App : Application
    {
        public static IBluetoothClient BluetoothClient { get; set; }

        public App(IBluetoothClient bluetoothClient)
        {
            InitializeComponent();

            BluetoothClient = bluetoothClient;

            MainPage = new NavigationPage(new ConnectionPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
