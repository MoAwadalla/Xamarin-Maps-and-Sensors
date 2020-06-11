using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FormsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        
        public FirstPage()
        {
            InitializeComponent();
            
            
            
        }

        private void Random_Button_Clicked(object sender, EventArgs e)
        {
            Random rand = new Random();
            double a = rand.NextDouble() * 100;
            double b = rand.NextDouble() * 100 * -1;
            Position position = new Position(a, b);
            MapSpan mapSpan = new MapSpan(position,0.01, 0.01);
            Xamarin.Forms.View OldContent = Content;
            DisplayAlert("Travelling", "Arrived at: " + a + ", " + b, "Ok");
            Button home = new Button
            {
                Text = "Go Home",
                Command = new Command(() =>
                {
                    Content = OldContent;
                })
            };
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    new Map(mapSpan),
                    home
                    
                }
            };
            
            
        }

        private void Next_Page_Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage( new Page2());
        }
    }
}