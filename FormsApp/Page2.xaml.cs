using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;
using Plugin.Geolocator;

namespace FormsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Page2 : ContentPage
    {
        SensorSpeed speed = SensorSpeed.UI;
        String gyroScope;
        String Location;
        public Page2()
        {
            InitializeComponent();

            Button flashlightOnButton = new Button
            {
                Text = "Flashlight On",
                Command = new Command(() =>
                {
                    Xamarin.Essentials.Flashlight.TurnOnAsync();
                })
            };
            Button flashlightOffButton = new Button
            {
                Text = "Flashlight Off",
                Command = new Command(() =>
                {
                    Xamarin.Essentials.Flashlight.TurnOffAsync();
                })
            };
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Button
                    {
                        Text = "Go Back",
                        Command = new Command(() =>
                        {
                            App.Current.MainPage = new FirstPage();
                        })
                    },
                    
                    new Label
                    {
                        Text = "Location: " + getLocation()
                    },
                    new Label
                    {
                        Text = "GyroScope: " + gyroScope
                    },
                    new Button
                    {
                        Text = "Vibrate",
                        Command = new Command(() =>
                        {
                            Vibration.Vibrate();
                        })
                    },
                    flashlightOnButton,
                    flashlightOffButton
                }
            };
        }

        //explore shiny, connect and list characteristics
        //light blue explorer
        //macincloud

        public async void findLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            System.TimeSpan timeS = new System.TimeSpan(0,0,5);
            var position = await locator.GetPositionAsync(timeout: timeS);
            decimal latitude = Convert.ToDecimal(position.Latitude);
            decimal longitude = Convert.ToDecimal(position.Longitude);
            Location =  "Latitude: " + latitude + ", Longitude: " + longitude;
        }
        public String getLocation ()
        {
            findLocation();
            return Location;
        }

        

   
    }
}