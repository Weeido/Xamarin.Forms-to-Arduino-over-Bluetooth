using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArduinoApp.Services
{
    public static class PageHelper
    {
        public static void CreateButton(string name, Action action, StackLayout container)
        {
            var button = new Button
            {
                Text = name
            };

            button.Clicked += (object sender, EventArgs e) => action.Invoke();
            container.Children.Add(button);
        }

        
        public static void CreatePressReleaseButton(string name, Action pressAction, Action releaseAction , StackLayout container)
        {
            var button = new Button
            {
                Text = name
            };

            button.Pressed += (object sender, EventArgs e) => pressAction.Invoke();
            button.Released += (object sender, EventArgs e) => releaseAction.Invoke();
            container.Children.Add(button);
        }

    }
}
