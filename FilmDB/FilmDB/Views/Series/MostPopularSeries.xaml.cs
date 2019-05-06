using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilmDB.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MostPopularSeries : ContentPage
	{
		public MostPopularSeries ()
		{
			InitializeComponent ();
            Title = "Most Popular Series";
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var MostPopularSeries = await App.MovieManager.GetPopularSeriesAsync();
            if (MostPopularSeries != null) {
                listView.ItemsSource = MostPopularSeries;
            }
            else
            { await DisplayAlert("No Internet Connection", "Please check your internet connection", "OK"); }
            loading.IsRunning = false;

        }

        public async void ItemTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;
            await Navigation.PushAsync(new SeriesDetailPage(id));

        }

    }
}