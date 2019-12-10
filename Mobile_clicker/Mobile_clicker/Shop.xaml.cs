using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile_clicker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Shop : ContentPage
	{
        public static int Grandmas;
        public static int Ovens;
        public static int Factories;


        static int GrandmaPrice = 15;
        static int OvenPrice = 10;
        static ulong FactoryPrice = 50;



        public Shop ()
		{
			InitializeComponent ();

            GrandmaCounter.Text = Grandmas.ToString();
            OvenCounter.Text = Ovens.ToString();

            OPriceLbl.Text = OvenPrice.ToString();
            GPriceLbl.Text = GrandmaPrice.ToString();
            FPriceLbl.Text = FactoryPrice.ToString();
        }

        private async void BuyGrandma(object sender, EventArgs e)
        {
            if(MainPage.cookie < (ulong)GrandmaPrice)
            {
                await DisplayAlert("Alert", "You can't afford this", "Okay");
                return;
            }

            MainPage.cookie -= (ulong)GrandmaPrice;
            Grandmas++;
            GrandmaPrice = Grandmas * 15;
            GPriceLbl.Text = GrandmaPrice.ToString();

            GrandmaCounter.Text = Grandmas.ToString();
        }

        private async void BuyOven(object sender, EventArgs e)
        {
            if (MainPage.cookie < (ulong)OvenPrice)
            {
                await DisplayAlert("Alert", "You can't afford this", "Okay");
                return;
            }

            MainPage.cookie -= (ulong)OvenPrice;
            Ovens++;
            OvenPrice = 10 * Ovens;
            OPriceLbl.Text = OvenPrice.ToString();

            OvenCounter.Text = Ovens.ToString();
        }

        private async void BuyFactory(object sender, EventArgs e)
        {

            if( Factories >= 3)
            {
                await DisplayAlert("Alert", "Can't buy any more factories.", "Okay");
                ((Button)sender).IsEnabled = false;
                return;
            }

            if (MainPage.cookie < (ulong)FactoryPrice)
            {
                await DisplayAlert("Alert", "You can't afford this", "Okay");
                return;
            }

            MainPage.cookie -= (ulong)FactoryPrice;
            Factories++;
            FactoryPrice = FactoryPrice * 650;
            FPriceLbl.Text = FactoryPrice.ToString();

            FactoryCounter.Text = Factories.ToString();
        }
    }
}