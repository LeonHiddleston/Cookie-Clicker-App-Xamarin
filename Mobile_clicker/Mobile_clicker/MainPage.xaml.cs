using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_clicker
{
    public partial class MainPage : ContentPage
    {
        public static ulong cookie = 0;
        public MainPage()
        {
            InitializeComponent();
            CookieCounter.Text = cookie.ToString();

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                cookie = cookie + (ulong) Shop.Ovens;
                if( Shop.Factories > 0)
                {
                    cookie = cookie * (ulong) Shop.Factories;
                }

                CookieCounter.Text = cookie.ToString();
                return true;
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            cookie += (ulong)( Shop.Grandmas + 1 );
            CookieCounter.Text = cookie.ToString();
        }

        private async void Shop_Open(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Shop());
        }
    }
}
