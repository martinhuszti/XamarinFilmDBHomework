using FilmDB.Models;
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
	public partial class SeriesDetailPage : ContentPage
	{
        private int seriesId;

        public SeriesDetailPage (int id)
		{
			InitializeComponent ();
            Title = "Series Detail Page";
            seriesId = id;

            ToolbarItems.Add(new ToolbarItem("Search", "home.png", () =>
            {
                Navigation.PopToRootAsync();
            }));

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var series = await App.MovieManager.GetSeriesDetails(seriesId);
            if (series != null)
            {
                mainlayout.BindingContext = series;
                seasonpicker.ItemsSource = series.seasons;
                seasonpicker.ItemDisplayBinding = new Binding("name");
                view.Opacity = 100;
            }
            else {
                { await DisplayAlert("No Internet Connection or Series Not Found", "Please check your internet connection", "OK"); }
                title.Text = "Ismeretlen Sorozat";
            }

            
            loading.IsRunning = false;
            

        }

        async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            episodelist.ItemsSource = null;
            episodeload.IsRunning = true;
            var picker = (Picker)sender;
            var selectedSeason = (Season) picker.SelectedItem;

            episodelist.ItemsSource = await App.MovieManager.GetEpisodeList(seriesId, selectedSeason.season_number);

            episodeload.IsRunning = false;




        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;

            await Navigation.PushAsync(new ActorPage(id));
        }
    }
}